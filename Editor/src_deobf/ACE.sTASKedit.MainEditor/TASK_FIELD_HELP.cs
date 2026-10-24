using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ACE.sTASKedit.MainEditor;

/// <summary>
/// Adds concise, gameplay-oriented help to task editor controls while preserving
/// any existing tooltip text and the task data/editing behavior.
/// </summary>
internal static class TASK_FIELD_HELP
{
	private sealed class TooltipBinding
	{
		public ToolTip ToolTip;
		public ToolStripStatusLabel StatusLabel;
	}

	private static readonly ConditionalWeakTable<Control, TooltipBinding> tooltipBindings = new ConditionalWeakTable<Control, TooltipBinding>();
	internal static void Apply(Control root, ToolTip toolTip, bool portuguese)
	{
		if (root == null)
		{
			return;
		}

		// A Tasks fica sem popups de descrição; isso também preserva o conteúdo
		// original da barra de status (mensagens, progresso, versão e contagem).
		if (toolTip != null)
		{
			toolTip.Active = false;
		}
		DisableGridTooltips(root);
	}

	private static void DisableGridTooltips(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is DataGridView grid)
			{
				grid.ShowCellToolTips = false;
			}
			if (control.HasChildren)
			{
				DisableGridTooltips(control);
			}
		}
	}

	private static ToolStripStatusLabel EnsureContextHelpLabel(Control root, bool portuguese)
	{
		StatusStrip statusStrip = FindStatusStrip(root);
		if (statusStrip == null)
		{
			return null;
		}

		foreach (ToolStripItem item in statusStrip.Items)
		{
			if (item.Name == "taskFieldContextHelp")
			{
				return (ToolStripStatusLabel)item;
			}
		}

		ToolStripStatusLabel helpLabel = new ToolStripStatusLabel
		{
			Name = "taskFieldContextHelp",
			Text = portuguese
				? "Passe o mouse sobre um campo para ver sua função no jogo."
				: "Hover over a field to see what it does in game.",
			AutoSize = true,
			AutoToolTip = true,
			Spring = true,
			Overflow = ToolStripItemOverflow.Never,
			BorderSides = ToolStripStatusLabelBorderSides.All,
			TextAlign = ContentAlignment.MiddleLeft,
			Margin = new Padding(0, 3, 2, 6)
		};
		statusStrip.Items.Insert(Math.Min(2, statusStrip.Items.Count), helpLabel);
		return helpLabel;
	}

	private static StatusStrip FindStatusStrip(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is StatusStrip statusStrip)
			{
				return statusStrip;
			}
			if (control.HasChildren)
			{
				StatusStrip nested = FindStatusStrip(control);
				if (nested != null)
				{
					return nested;
				}
			}
		}
		return null;
	}

	private static void ApplyRecursive(Control parent, ToolTip toolTip, bool portuguese, ToolStripStatusLabel statusLabel)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is DataGridView grid)
			{
				ApplyGrid(grid, portuguese);
			}
			else if (IsUserEditable(control))
			{
				string field = GetControlCaption(control) ?? FindFieldLabel(control) ?? control.Name;
				AddHelp(control, field, toolTip, portuguese, statusLabel);
			}
			else if (control is Label label && !string.IsNullOrWhiteSpace(label.Text))
			{
				AddHelp(label, label.Text, toolTip, portuguese, statusLabel);
			}
			else if (control is GroupBox group && !string.IsNullOrWhiteSpace(group.Text))
			{
				AddHelp(group, group.Text, toolTip, portuguese, statusLabel);
			}

			if (control.HasChildren)
			{
				ApplyRecursive(control, toolTip, portuguese, statusLabel);
			}
		}
	}

	private static bool IsUserEditable(Control control)
	{
		return control is TextBoxBase || control is CheckBox || control is RadioButton ||
			control is ComboBox || control is NumericUpDown || control is DateTimePicker ||
			control is CheckedListBox || control is ListBox || control is TrackBar;
	}

	private static string GetControlCaption(Control control)
	{
		if (control is CheckBox checkBox && !string.IsNullOrWhiteSpace(checkBox.Text))
		{
			return checkBox.Text;
		}
		if (control is RadioButton radioButton && !string.IsNullOrWhiteSpace(radioButton.Text))
		{
			return radioButton.Text;
		}
		return null;
	}

	private static string FindFieldLabel(Control control)
	{
		Control parent = control.Parent;
		if (parent == null)
		{
			return null;
		}

		Label nearest = null;
		int nearestDistance = int.MaxValue;
		foreach (Control sibling in parent.Controls)
		{
			if (!(sibling is Label label) || string.IsNullOrWhiteSpace(label.Text))
			{
				continue;
			}
			int verticalDistance = Math.Abs(label.Top - control.Top);
			int horizontalGap = control.Left - label.Right;
			if (horizontalGap < -10 || horizontalGap > 180 || verticalDistance > Math.Max(12, control.Height))
			{
				continue;
			}
			int distance = verticalDistance * 4 + Math.Max(0, horizontalGap);
			if (distance < nearestDistance)
			{
				nearest = label;
				nearestDistance = distance;
			}
		}
		return nearest?.Text;
	}

	private static void ApplyGrid(DataGridView grid, bool portuguese)
	{
		// Evita que dicas de células abram popups por cima dos controles da Tasks.
		grid.ShowCellToolTips = false;
	}

	private static void AddHelp(Control control, string field, ToolTip toolTip, bool portuguese, ToolStripStatusLabel statusLabel)
	{
		string oldText = toolTip.GetToolTip(control);
		toolTip.SetToolTip(control, BuildTooltip(oldText, BuildHelp(field, control.Name, portuguese)));
		if (tooltipBindings.TryGetValue(control, out TooltipBinding binding))
		{
			binding.ToolTip = toolTip;
			binding.StatusLabel = statusLabel;
			return;
		}

		tooltipBindings.Add(control, new TooltipBinding { ToolTip = toolTip, StatusLabel = statusLabel });
		// Keep the native WinForms tooltip as the only floating popup. A second,
		// manually positioned popup competed with it and could make both vanish.
		control.MouseEnter += UpdateContextHelp;
		control.MouseMove += UpdateContextHelp;
	}

	private static void UpdateContextHelp(object sender, EventArgs e)
	{
		if (!(sender is Control control) || !tooltipBindings.TryGetValue(control, out TooltipBinding binding))
		{
			return;
		}

		ToolTip toolTip = binding.ToolTip;
		string text = toolTip?.GetToolTip(control);
		string statusText = string.IsNullOrWhiteSpace(text) ? string.Empty : text.Replace(Environment.NewLine, "  |  ");
		if (binding.StatusLabel != null && statusText.Length > 0 && binding.StatusLabel.Text != statusText)
		{
			binding.StatusLabel.Text = statusText;
		}
	}

	private static string BuildTooltip(string existingText, string help)
	{
		string originalText = GetOriginalTooltipText(existingText);
		string combined = string.IsNullOrWhiteSpace(originalText)
			? help
			: originalText.Trim() + Environment.NewLine + Environment.NewLine + help;
		return WrapText(combined);
	}

	private static string GetOriginalTooltipText(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}

		int portugueseMarker = text.LastIndexOf("No jogo:", StringComparison.OrdinalIgnoreCase);
		int englishMarker = text.LastIndexOf("In game:", StringComparison.OrdinalIgnoreCase);
		int generatedHelpStart = Math.Max(portugueseMarker, englishMarker);
		if (generatedHelpStart < 0)
		{
			return text.Trim();
		}

		string separator = Environment.NewLine + Environment.NewLine;
		int separatorStart = text.LastIndexOf(separator, generatedHelpStart, StringComparison.Ordinal);
		return separatorStart < 0 ? string.Empty : text.Substring(0, separatorStart).TrimEnd();
	}

	private static string WrapText(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}

		const int maxLineLength = 76;
		StringBuilder result = new StringBuilder(text.Length + 32);
		string[] paragraphs = text.Replace("\r", string.Empty).Split('\n');
		for (int paragraphIndex = 0; paragraphIndex < paragraphs.Length; paragraphIndex++)
		{
			if (paragraphIndex > 0)
			{
				result.AppendLine();
			}
			string paragraph = paragraphs[paragraphIndex].Trim();
			if (paragraph.Length == 0)
			{
				continue;
			}

			string[] words = paragraph.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			int lineLength = 0;
			foreach (string word in words)
			{
				if (lineLength > 0 && lineLength + word.Length + 1 > maxLineLength)
				{
					result.AppendLine();
					lineLength = 0;
				}
				else if (lineLength > 0)
				{
					result.Append(' ');
					lineLength++;
				}
				result.Append(word);
				lineLength += word.Length;
			}
		}
		return result.ToString().TrimEnd();
	}

	private static string BuildHelp(string label, string technicalName, bool portuguese)
	{
		string source = NormalizeWords((label ?? string.Empty) + " " + (technicalName ?? string.Empty));
		string gameEffect;
		if (Contains(source, "exibir conforme exp", "show by exp", "check exp", "verificar exp"))
			gameEffect = portuguese ? "No jogo: usa a EXP do personagem para verificar ou exibir esta missão." : "In game: uses the character's EXP to check or show this quest.";
		else if (Contains(source, "experience", "experiencia", "experiência", "spirit", "exp") && Contains(source, "award", "reward", "recompensa", "recompens", "prêmio", "premio", "quantidade", "amount"))
			gameEffect = portuguese ? "No jogo: define a EXP ou os pontos concedidos como recompensa da missão." : "In game: sets the EXP or points granted as the quest reward.";
		else if (Contains(source, "experience", "experiencia", "experiência", "spirit", "exp") && Contains(source, "premise", "requirement", "requisito", "exigida", "exigido", "mínima", "minima", "minimum", "min"))
			gameEffect = portuguese ? "No jogo: usa a EXP do personagem como requisito desta missão." : "In game: uses the character's EXP as a requirement for this quest.";
		else if (Contains(source, "experience", "experiencia", "experiência", "spirit", "exp"))
			gameEffect = portuguese ? "No jogo: usa este valor em uma regra de EXP da missão." : "In game: uses this value in a quest EXP rule.";
		else if (Contains(source, "gold", "money", "dinheiro", "moeda", "silver", "coin", "ouro"))
			gameEffect = portuguese ? "No jogo: define a quantia de moeda entregue ou usada pela missão. O valor exato segue as regras e a unidade desta versão." : "In game: sets the currency amount granted or used by the quest. The exact value follows this version's rules and unit.";
		else if (Contains(source, "reputation", "reputacao", "reputação", "renown"))
			gameEffect = portuguese ? "No jogo: ajusta a reputação do personagem ao receber esta recompensa." : "In game: adjusts the character's reputation when this reward is granted.";
		else if (Contains(source, "diálogo com vários npcs", "dialogo com varios npcs", "multi npc talk", "multinpctalk"))
			gameEffect = portuguese ? "No jogo: permite falar com vários NPCs nesta missão." : "In game: allows dialogue with multiple NPCs in this quest.";
		else if (Contains(source, "subordinadas em ordem", "subtasks in order", "exe child in order", "m_bexechildinorder"))
			gameEffect = portuguese ? "No jogo: executa as tarefas subordinadas na ordem definida." : "In game: runs subtasks in the order listed.";
		else if (Contains(source, "item not take off", "não remover item equipado", "nao remover item equipado"))
			gameEffect = portuguese ? "No jogo: mantém equipado o item relacionado à missão." : "In game: keeps the quest-related item equipped.";
		else if (Contains(source, "compare item with inventory", "compare item and inventory", "comparar item com inventário", "comparar item com inventario"))
			gameEffect = portuguese ? "No jogo: compara os itens da missão com o inventário do personagem." : "In game: compares the quest items with the character's inventory.";
		else if (Contains(source, "item", "items", "itens", "matter", "goods", "objeto", "objetos", "premitems", "givenitems"))
			gameEffect = portuguese ? "No jogo: seleciona um item exigido, consumido, entregue ou concedido pela missão; quantidade e contexto aparecem no nome do campo ou da tabela." : "In game: selects an item required, consumed, turned in, or granted by the quest; quantity and context are given by the field or table name.";
		else if (Contains(source, "npc", "character", "personagem", "dialog", "diálogo", "dialogo"))
			gameEffect = portuguese ? "No jogo: define o NPC ou diálogo associado à etapa da missão; isso determina com quem o jogador interage ou qual texto é apresentado." : "In game: defines the NPC or dialogue associated with this quest step, determining who the player interacts with or which text appears.";
		else if (IsTaskReference(source))
			gameEffect = portuguese ? "No jogo: vincula outra missão usada como pré-requisito, etapa ou resultado. Confira o espaço e o ID." : "In game: links another quest as a prerequisite, step, or outcome. Check its space and ID.";
		else if (Contains(source, "monster", "mob", "monstro", "kill", "matad", "derrot"))
			gameEffect = portuguese ? "No jogo: define o monstro ou a condição de combate contabilizada como objetivo da missão." : "In game: defines the monster or combat condition counted as a quest objective.";
		else if (Contains(source, "level", "lev", "nivel", "nível", "grade"))
			gameEffect = portuguese ? "No jogo: estabelece o nível mínimo, máximo ou aplicado para liberar esta missão ou seu efeito." : "In game: sets the minimum, maximum, or applied level used to unlock this quest or its effect.";
		else if (Contains(source, "prob", "chance", "random", "rand", "aleator", "probabilidade"))
			gameEffect = portuguese ? "No jogo: controla a chance de o resultado ou a opção aleatória ocorrer. Confirme a escala da versão antes de alterar o valor." : "In game: controls the chance of this result or random option occurring. Confirm this version's scale before changing it.";
		else if (Contains(source, "time", "hour", "minute", "day", "tempo", "hora", "minuto", "period", "cooldown"))
			gameEffect = portuguese ? "No jogo: define quando, por quanto tempo ou com que intervalo esta etapa da missão pode ocorrer." : "In game: defines when, how long, or how often this quest step can occur.";
		else if (Contains(source, "title", "name", "text", "msg", "message", "desc", "texto", "mensagem", "nome", "titulo", "título"))
			gameEffect = portuguese ? "No jogo: fornece o texto ou nome apresentado ao jogador nesta etapa da missão; a localização depende dos dados de idioma do cliente." : "In game: supplies the text or name shown to the player for this quest step; localization depends on the client's language data.";
		else if (Contains(source, "fail", "failure", "falha", "m_bcan", "m_bis", "check", "enable", "disable", "flag", "switch", "pode", "permit"))
			gameEffect = portuguese ? "No jogo: ativa, bloqueia ou altera uma regra da missão. O efeito específico depende do significado deste campo nesta versão." : "In game: enables, blocks, or changes a quest rule. The exact effect depends on this field's meaning in this version.";
		else if (Contains(source, "pos", "coord", "point", "radius", "range", "position", "local"))
			gameEffect = portuguese ? "No jogo: define uma posição, área ou distância usada para validar ou executar esta etapa; confirme o sistema de coordenadas do campo." : "In game: defines a position, area, or distance used to validate or run this step; confirm this field's coordinate system.";
		else if (Contains(source, "reward", "award", "recompensa", "premio", "prêmio", "m_award"))
			gameEffect = portuguese ? "No jogo: define o que o personagem recebe quando esta condição de sucesso ou falha da missão é alcançada." : "In game: defines what the character receives when this quest success or failure outcome is reached.";
		else
			gameEffect = portuguese ? "No jogo: configura uma regra da missão; confirme a função específica na documentação desta versão." : "In game: configures a quest rule; confirm the exact purpose in this version's documentation.";

		string stored = portuguese
			? "Arquivo: salva esta opção em tasks.data."
			: "File: saves this option to tasks.data.";
		return gameEffect + Environment.NewLine + stored;
	}

	private static bool IsTaskReference(string source)
	{
		if (Contains(source, "subtask", "sub task", "subquest", "sub quest", "previous task", "pre task", "mutex task", "needed task", "tarefa anterior", "tarefas anteriores", "missão anterior", "missões anteriores", "missao anterior", "missoes anteriores"))
		{
			return true;
		}

		bool mentionsTask = Contains(source, "task", "quest", "tarefa", "tarefas", "missão", "missões", "missao", "missoes");
		return mentionsTask && Contains(source, "id", "space", "espaço", "espaco", "vínculo", "vinculo", "pré-requisito", "pre-requisito", "prerequisite");
	}

	private static string NormalizeWords(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return string.Empty;
		}

		string separated = Regex.Replace(value, "([a-z0-9])([A-Z])", "$1 $2");
		return Regex.Replace(separated.ToLowerInvariant(), "[^\\p{L}\\p{N}]+", " ").Trim();
	}

	private static bool Contains(string value, params string[] terms)
	{
		string normalizedValue = NormalizeWords(value);
		if (normalizedValue.Length == 0)
		{
			return false;
		}
		string paddedValue = " " + normalizedValue + " ";
		foreach (string term in terms)
		{
			string normalizedTerm = NormalizeWords(term);
			if (normalizedTerm.Length > 0 && paddedValue.IndexOf(" " + normalizedTerm + " ", StringComparison.Ordinal) >= 0)
			{
				return true;
			}
		}
		return false;
	}
}
