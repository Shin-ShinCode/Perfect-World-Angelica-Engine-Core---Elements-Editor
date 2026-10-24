using System;
using System.Collections.Generic;

namespace ACE.MainWindow;

/// <summary>
/// Supplies contextual explanations for element fields without changing their values.
/// </summary>
internal static class FIELD_HELP
{
	private static readonly Dictionary<string, string> NpcFieldsPtBr = new(StringComparer.OrdinalIgnoreCase)
	{
		["ID"] = "Identificador do registro do NPC; determina qual entrada está sendo editada.",
		["Name"] = "Nome do NPC exibido pelo jogo e pelo Editor.",
		["unk"] = "O esquema desta versão marca esta posição como desconhecida. O Editor não tem informação suficiente para atribuir uma finalidade segura; evite alterar sem documentação compatível.",
		["id_type"] = "Define a categoria funcional do NPC.",
		["refresh_time"] = "Define o intervalo para o NPC ou recurso reaparecer, conforme o tipo.",
		["attack_rule"] = "Seleciona a regra de comportamento de ataque do NPC.",
		["file_model"] = "Aponta para o arquivo visual do modelo usado pelo NPC.",
		["tax_rate"] = "Define a taxa de imposto aplicada pelos serviços comerciais deste NPC.",
		["id_src_monster"] = "Referencia o monstro usado como origem para dados ou comportamento do NPC.",
		["hello_msg"] = "Texto de saudação apresentado na janela de diálogo ao interagir com o NPC.",
		["id_to_discover"] = "Referencia o conteúdo que pode ser descoberto por meio deste NPC.",
		["domain_related"] = "Associa este NPC a um domínio ou território específico.",
		["id_talk_service"] = "Vincula o serviço de diálogo oferecido pelo NPC.",
		["id_sell_service"] = "Vincula a lista ou serviço de venda do NPC.",
		["id_buy_service"] = "Vincula o serviço usado para comprar itens do jogador.",
		["id_repair_service"] = "Vincula o serviço de reparo de equipamentos.",
		["id_install_service"] = "Vincula o serviço de instalação ou montagem de equipamento.",
		["id_uninstall_service"] = "Vincula o serviço de remoção ou desmontagem de equipamento.",
		["id_task_out_service"] = "Vincula o serviço que entrega tarefas ao jogador.",
		["id_task_in_service"] = "Vincula o serviço que recebe ou conclui tarefas do jogador.",
		["id_task_matter_service"] = "Vincula o serviço de itens necessários para tarefas.",
		["id_skill_service"] = "Vincula o serviço de habilidades oferecido pelo NPC.",
		["id_heal_service"] = "Vincula o serviço de cura oferecido pelo NPC.",
		["id_transmit_service"] = "Vincula o serviço de teleporte ou transmissão.",
		["id_transport_service"] = "Vincula o serviço de transporte oferecido pelo NPC.",
		["id_proxy_service"] = "Vincula o serviço de intermediação do NPC.",
		["id_storage_service"] = "Vincula o serviço de armazenamento ou armazém.",
		["id_make_service"] = "Vincula o serviço de fabricação ou produção.",
		["id_decompose_service"] = "Vincula o serviço de decomposição de itens.",
		["id_identify_service"] = "Vincula o serviço de identificação de itens.",
		["id_war_towerbuild_service"] = "Vincula o serviço de construção de torres de guerra.",
		["id_resetprop_service"] = "Vincula o serviço de redefinição de atributos.",
		["id_petname_service"] = "Vincula o serviço de alteração do nome de mascotes.",
		["id_petlearnskill_service"] = "Vincula o serviço de aprendizado de habilidades de mascotes.",
		["id_petforgetskill_service"] = "Vincula o serviço de remoção de habilidades de mascotes.",
		["id_equipbind_service"] = "Vincula o serviço de vinculação de equipamentos.",
		["id_equipdestroy_service"] = "Vincula o serviço de destruição de equipamentos.",
		["id_equipundestroy_service"] = "Vincula o serviço de restauração de equipamentos destruídos.",
		["id_goblin_skill_service"] = "Vincula o serviço de habilidades de gênios.",
		["id_cross_server_service"] = "Vincula um serviço disponível entre servidores.",
		["id_waypoint_active_interact_service"] = "Vincula o serviço de ativação e interação com pontos de passagem.",
		["combined_services"] = "Lista serviços adicionais associados ao NPC.",
		["id_mine"] = "Referencia a mina associada ao NPC, quando aplicável.",
		["no_collision"] = "Controla se o NPC ignora colisões com personagens e objetos.",
		["id_engrave_service"] = "Vincula o serviço de gravação de equipamentos.",
		["id_randprop_service"] = "Vincula o serviço de alteração aleatória de atributos.",
		["combined_services2"] = "Lista uma segunda configuração de serviços combinados.",
		["id_force_service"] = "Vincula o serviço relacionado a facções ou forças.",
		["combined_switch"] = "Controla uma opção de ativação dos serviços combinados.",
		["arena_sell_services"] = "Define os serviços de venda disponíveis na arena.",
		["statue_create_service"] = "Vincula o serviço de criação de estátuas.",
		["lib_produce_service"] = "Vincula o serviço de produção da biblioteca.",
		["mysterious_shop_service"] = "Vincula o serviço da loja misteriosa.",
		["pridict_engrave_service"] = "Vincula o serviço especial de gravação previsto por esta versão do esquema.",
		["combined_services3"] = "Lista uma terceira configuração de serviços combinados.",
		["faction_sell_service"] = "Vincula o serviço de venda da facção.",
		["faction_combined_services"] = "Define serviços combinados disponíveis para a facção.",
		["park_enter_service"] = "Vincula o serviço de entrada no parque.",
		["book_shelf_service"] = "Vincula o serviço de estante ou biblioteca de livros.",
		["id_skill"] = "Referencia a habilidade associada a este NPC.",
		["tasks_data_1_taskIDSpace"] = "Indica o espaço ou categoria da primeira tarefa vinculada ao NPC.",
		["tasks_data_1_taskID"] = "ID da primeira tarefa vinculada ao NPC.",
	};

	private static readonly Dictionary<string, string> NpcFieldsEn = new(StringComparer.OrdinalIgnoreCase)
	{
		["ID"] = "Identifier of the NPC record; it determines which entry is being edited.",
		["Name"] = "NPC name displayed by the game and the editor.",
		["unk"] = "This schema version marks this position as unknown. The editor cannot safely determine its purpose; avoid changing it without matching documentation.",
		["id_type"] = "Selects the NPC's functional category.",
		["refresh_time"] = "Sets how long this NPC or resource takes to respawn, depending on its type.",
		["attack_rule"] = "Selects the NPC's attack behavior rule.",
		["file_model"] = "Points to the visual model file used by this NPC.",
		["tax_rate"] = "Sets the tax rate applied by this NPC's commerce services.",
		["id_src_monster"] = "References the monster used as the source for NPC data or behavior.",
		["hello_msg"] = "Text shown in the dialogue window when the player interacts with this NPC.",
		["id_to_discover"] = "References content that can be discovered through this NPC.",
		["domain_related"] = "Associates this NPC with a specific domain or territory.",
		["id_talk_service"] = "Links the dialogue service offered by this NPC.",
		["id_sell_service"] = "Links the NPC's item sale list or service.",
		["id_buy_service"] = "Links the service used to buy items from the player.",
		["id_repair_service"] = "Links the equipment repair service.",
		["id_install_service"] = "Links the equipment installation or assembly service.",
		["id_uninstall_service"] = "Links the equipment removal or disassembly service.",
		["id_task_out_service"] = "Links the service that gives quests to the player.",
		["id_task_in_service"] = "Links the service that receives or completes player quests.",
		["id_task_matter_service"] = "Links the service for quest-related items.",
		["id_skill_service"] = "Links the skill service offered by this NPC.",
		["id_heal_service"] = "Links the healing service offered by this NPC.",
		["id_transmit_service"] = "Links the teleport or transmission service.",
		["id_transport_service"] = "Links the transportation service offered by this NPC.",
		["id_proxy_service"] = "Links the NPC's intermediary service.",
		["id_storage_service"] = "Links the storage service.",
		["id_make_service"] = "Links the crafting or production service.",
		["id_decompose_service"] = "Links the item decomposition service.",
		["id_identify_service"] = "Links the item identification service.",
		["id_war_towerbuild_service"] = "Links the war tower construction service.",
		["id_resetprop_service"] = "Links the attribute reset service.",
		["id_petname_service"] = "Links the pet renaming service.",
		["id_petlearnskill_service"] = "Links the pet skill learning service.",
		["id_petforgetskill_service"] = "Links the pet skill removal service.",
		["id_equipbind_service"] = "Links the equipment binding service.",
		["id_equipdestroy_service"] = "Links the equipment destruction service.",
		["id_equipundestroy_service"] = "Links the equipment restoration service.",
		["id_goblin_skill_service"] = "Links the genie skill service.",
		["id_cross_server_service"] = "Links a service available across servers.",
		["id_waypoint_active_interact_service"] = "Links the waypoint activation and interaction service.",
		["combined_services"] = "Lists additional services associated with this NPC.",
		["id_mine"] = "References the mine associated with this NPC, when applicable.",
		["no_collision"] = "Controls whether the NPC ignores collisions with characters and objects.",
		["id_engrave_service"] = "Links the equipment engraving service.",
		["id_randprop_service"] = "Links the random attribute change service.",
		["combined_services2"] = "Lists a second configuration of combined services.",
		["id_force_service"] = "Links the service related to factions or forces.",
		["combined_switch"] = "Controls an option that enables combined services.",
		["arena_sell_services"] = "Defines the sale services available in the arena.",
		["statue_create_service"] = "Links the statue creation service.",
		["lib_produce_service"] = "Links the library production service.",
		["mysterious_shop_service"] = "Links the mysterious shop service.",
		["pridict_engrave_service"] = "Links the special engraving service defined by this schema version.",
		["combined_services3"] = "Lists a third configuration of combined services.",
		["faction_sell_service"] = "Links the faction sale service.",
		["faction_combined_services"] = "Defines combined services available to the faction.",
		["park_enter_service"] = "Links the park entry service.",
		["book_shelf_service"] = "Links the bookshelf or book library service.",
		["id_skill"] = "References the skill associated with this NPC.",
		["tasks_data_1_taskIDSpace"] = "Identifies the category or space of the first quest linked to this NPC.",
		["tasks_data_1_taskID"] = "ID of the first quest linked to this NPC.",
	};

	internal static string GetDescription(string listName, string rawFieldName, string displayName, string schemaType, int languageIndex)
	{
		bool portuguese = languageIndex == 3;
		Dictionary<string, string> descriptions = portuguese ? NpcFieldsPtBr : NpcFieldsEn;
		string field = rawFieldName ?? string.Empty;
		string explanation;
		bool isNpcList = (listName ?? string.Empty).IndexOf("NPC_ESSENCE", StringComparison.OrdinalIgnoreCase) >= 0;
		if (isNpcList && TryGetNpcDescription(field, descriptions, portuguese, out explanation))
		{
			return FormatDescription(listName, field, displayName, schemaType, explanation, portuguese);
		}
		if (TryGetTaskServiceDescription(listName, field, portuguese, out explanation))
		{
			return FormatDescription(listName, field, displayName, schemaType, explanation, portuguese);
		}
		if (TryGetSchemaDescription(listName, field, portuguese, out explanation))
		{
			return FormatDescription(listName, field, displayName, schemaType, explanation, portuguese);
		}

		string localizedName = string.IsNullOrWhiteSpace(displayName) ? field : displayName.TrimEnd(':', ' ');
		string meaning = GetMeaning(field, portuguese);
		return FormatDescription(listName, field, localizedName, schemaType, meaning, portuguese);
	}

	private static string FormatDescription(string listName, string field, string displayName, string schemaType, string explanation, bool portuguese)
	{
		string localizedName = string.IsNullOrWhiteSpace(displayName) ? field : displayName.TrimEnd(':', ' ');
		string type = string.IsNullOrWhiteSpace(schemaType) ? (portuguese ? "não informado" : "not provided") : schemaType;
		if (portuguese)
		{
			return localizedName + "\nLista/esquema: " + (listName ?? "não informado") + "\nCampo técnico: " + field + "\nTipo no esquema: " + type + "\nNo jogo: " + explanation + "\nNo arquivo: alterar este controle modifica o campo correspondente do registro em elements.data.";
		}
		return localizedName + "\nList/schema: " + (listName ?? "not provided") + "\nTechnical field: " + field + "\nSchema type: " + type + "\nIn game: " + explanation + "\nIn file: changing this control updates the corresponding field in the elements.data record.";
	}

	private static bool TryGetNpcDescription(string field, Dictionary<string, string> descriptions, bool portuguese, out string explanation)
	{
		if (descriptions.TryGetValue(field, out explanation))
		{
			return true;
		}

		const string prefix = "tasks_data_";
		if (field.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
		{
			int suffixStart = field.IndexOf('_', prefix.Length);
			if (suffixStart > prefix.Length && int.TryParse(field.Substring(prefix.Length, suffixStart - prefix.Length), out int taskSlot))
			{
				string suffix = field.Substring(suffixStart + 1);
				if (string.Equals(suffix, "taskIDSpace", StringComparison.OrdinalIgnoreCase))
				{
					explanation = portuguese
						? "Indica o espaço ou a categoria da tarefa de número " + taskSlot + " vinculada ao NPC."
						: "Identifies the category or space of quest number " + taskSlot + " linked to this NPC.";
					return true;
				}
				if (string.Equals(suffix, "taskID", StringComparison.OrdinalIgnoreCase))
				{
					explanation = portuguese
						? "ID da tarefa de número " + taskSlot + " vinculada ao NPC."
						: "ID of quest number " + taskSlot + " linked to this NPC.";
					return true;
				}
			}
		}

		explanation = null;
		return false;
	}

	private static bool TryGetTaskServiceDescription(string listName, string field, bool portuguese, out string explanation)
	{
		string schema = (listName ?? string.Empty).ToUpperInvariant();
		bool receivesTasks = schema == "NPC_TASK_IN_SERVICE";
		if (!receivesTasks && schema != "NPC_TASK_OUT_SERVICE")
		{
			explanation = null;
			return false;
		}

		const string prefix = "tasks_data_";
		if (field.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
		{
			int suffixStart = field.IndexOf('_', prefix.Length);
			if (suffixStart > prefix.Length && int.TryParse(field.Substring(prefix.Length, suffixStart - prefix.Length), out int slot))
			{
				string suffix = field.Substring(suffixStart + 1);
				if (string.Equals(suffix, "id_tasks_space", StringComparison.OrdinalIgnoreCase))
				{
					explanation = portuguese
						? "Define o espaço/categoria da tarefa no vínculo de número " + slot + ". O jogo usa esse valor junto com o ID para localizar a tarefa correta em tasks.data."
						: "Defines the task space/category for link " + slot + ". The game uses it with the ID to locate the correct task in tasks.data.";
					return true;
				}
				if (string.Equals(suffix, "id_tasks", StringComparison.OrdinalIgnoreCase))
				{
					string action = receivesTasks
						? (portuguese ? "receber ou concluir" : "turn in or complete")
						: (portuguese ? "oferecer ou iniciar" : "offer or start");
					explanation = portuguese
						? "Seleciona a tarefa de número " + slot + " associada a este NPC. Neste serviço, o NPC permite ao jogador " + action + " a tarefa; o espaço correspondente define em qual conjunto de tasks.data o ID é procurado."
						: "Selects task link " + slot + " for this NPC. This service lets the player " + action + " the task; the matching space selects the task set in tasks.data.";
					return true;
				}
			}
		}

		explanation = null;
		return false;
	}

	private static bool TryGetSchemaDescription(string listName, string field, bool portuguese, out string explanation)
	{
		string schema = (listName ?? string.Empty).ToUpperInvariant();
		string key = (field ?? string.Empty).ToLowerInvariant();
		bool equipment = schema == "WEAPON_ESSENCE" || schema == "ARMOR_ESSENCE" || schema == "DECORATION_ESSENCE";
		bool weapon = schema == "WEAPON_ESSENCE";
		bool armor = schema == "ARMOR_ESSENCE";
		bool decoration = schema == "DECORATION_ESSENCE";
		if (schema == "PLAYER_ACTION_INFO_CONFIG")
		{
			if (key == "id") return Set(out explanation, portuguese, "Identifica esta configuração de ação do personagem, referenciada pelos dados que a utilizam.", "Identifies this character-action configuration for records that reference it.");
			if (key == "name") return Set(out explanation, portuguese, "Nome de identificação desta configuração no Editor; não altera por si só o nome exibido pelo personagem no jogo.", "Editor-facing name for this configuration; it does not by itself change the character's displayed name in game.");
			if (key == "action_name") return Set(out explanation, portuguese, "Define o nome-base da ação/animação do personagem usada por esta configuração.", "Defines the base character action/animation name used by this configuration.");
			if (key == "action_prefix") return Set(out explanation, portuguese, "Define o prefixo usado para compor o identificador dos recursos de ação do personagem.", "Defines the prefix used to build the character action resource identifier.");
			if (key.StartsWith("action_weapon_suffix_", StringComparison.Ordinal) && key.EndsWith("_suffix", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o sufixo de ação associado ao espaço numerado de arma; o cliente usa essa combinação para selecionar a variação correspondente.", "Defines the action suffix for this numbered weapon slot; the client uses the combination to select the corresponding variant.");
			if (key == "hide_weapon") return Set(out explanation, portuguese, "Controla se a arma fica oculta durante a ação do personagem.", "Controls whether the weapon is hidden while the character performs this action.");
			if (key.StartsWith("reserved", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Campo reservado desta versão da CFG. Sua finalidade não está documentada; mantenha o valor original para evitar incompatibilidade.", "Reserved field in this CFG version. Its purpose is undocumented; preserve the original value to avoid incompatibility.");
		}
		if (schema == "FASHION_SUB_TYPE")
		{
			if (key == "id") return Set(out explanation, portuguese, "Identifica o subtipo de vestimenta usado para classificar os registros de moda.", "Identifies the fashion subtype used to classify fashion records.");
			if (key == "name") return Set(out explanation, portuguese, "Nome exibido para este subtipo de vestimenta.", "Display name for this fashion subtype.");
			if (key == "equip_fashion_mask") return Set(out explanation, portuguese, "Máscara que define quais categorias ou espaços de vestimenta pertencem a este subtipo.", "Mask that defines which fashion categories or equipment slots belong to this subtype.");
		}
		if (schema == "FACEPILL_ESSENCE")
		{
			if (key == "id") return Set(out explanation, portuguese, "Identifica esta pílula de aparência nos dados do jogo.", "Identifies this appearance pill in the game data.");
			if (key == "id_major_type") return Set(out explanation, portuguese, "Vincula a pílula à categoria principal usada para classificar e organizar o item.", "Links the pill to the major category used to classify and organize it.");
			if (key == "id_sub_type") return Set(out explanation, portuguese, "Vincula a pílula ao subtipo que determina sua classificação específica.", "Links the pill to the subtype that determines its specific classification.");
			if (key == "name") return Set(out explanation, portuguese, "Nome do item apresentado pelo jogo e pelo Editor.", "Item name displayed by the game and editor.");
			if (key == "file_matter") return Set(out explanation, portuguese, "Aponta para o recurso do item usado pelo cliente para representar a pílula no inventário e nas telas do jogo.", "Points to the item resource used by the client to represent the pill in the inventory and game screens.");
			if (key == "file_icon") return Set(out explanation, portuguese, "Aponta para o ícone exibido para a pílula na interface do jogo.", "Points to the icon shown for the pill in the game interface.");
			if (key == "duration") return Set(out explanation, portuguese, "Define por quanto tempo o efeito de aparência permanece ativo após o uso.", "Defines how long the appearance effect remains active after use.");
			if (key == "camera_scale") return Set(out explanation, portuguese, "Ajusta a escala da câmera usada na visualização do personagem para esta aparência.", "Adjusts the character-preview camera scale for this appearance.");
			if (key == "character_combo_id") return Set(out explanation, portuguese, "Define as classes/personagens compatíveis com esta aparência.", "Defines which classes/characters are compatible with this appearance.");
			if (key.StartsWith("pllfiles_", StringComparison.Ordinal) && key.EndsWith("_file", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Aponta para o recurso do espaço numerado usado pela configuração da aparência. O significado exato do prefixo PLLFILES depende do cliente desta versão; confirme o recurso antes de alterar.", "Points to the numbered resource used by the appearance configuration. The exact meaning of the PLLFILES prefix depends on this client version; verify the resource before changing it.");
			if (key == "price" || key == "shop_price") return Set(out explanation, portuguese, "Define o valor-base ou preço de venda da pílula nos serviços de loja.", "Defines the pill's base value or shop selling price.");
			if (key == "pile_num_max") return Set(out explanation, portuguese, "Define o limite de unidades deste item que podem ocupar uma pilha no inventário.", "Defines the maximum number of units of this item that can stack in inventory.");
			if (key == "has_guid") return Set(out explanation, portuguese, "Controla se cada unidade recebe um identificador único, o que pode impedir o empilhamento comum.", "Controls whether each unit receives a unique identifier, which can prevent normal stacking.");
			if (key == "proc_type") return Set(out explanation, portuguese, "Seleciona as regras de processamento/uso do item definidas pelo jogo para esta versão.", "Selects the item processing/use rules defined by the game for this version.");
			if (key.StartsWith("reserved_", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Campo reservado da estrutura desta versão. A CFG não documenta seu efeito; preserve o valor original.", "Reserved field in this version's structure. The CFG does not document its effect; preserve the original value.");
		}

		if (equipment)
		{
			if (key == "id_major_type") return Set(out explanation, portuguese, "Vincula o equipamento à categoria principal usada para agrupamento e classificação.", "Links the equipment to its major category for grouping and classification.");
			if (key == "id_sub_type") return Set(out explanation, portuguese, "Vincula o equipamento ao subtipo, que pode determinar regras de uso e equipamento.", "Links the equipment to its subtype, which can determine use and equipment rules.");
			if (key == "require_projectile") return Set(out explanation, portuguese, "Indica o tipo ou requisito de munição/projétil necessário para usar esta arma.", "Specifies the projectile or ammunition requirement for using this weapon.");
			if (key == "equip_location") return Set(out explanation, portuguese, "Define o espaço do equipamento em que a peça pode ser equipada.", "Defines the equipment slot where this item can be equipped.");
			if (key == "character_combo_id") return Set(out explanation, portuguese, "Limita ou associa o equipamento às classes/personagens indicados pelo identificador combinado.", "Restricts or associates the equipment with the classes/characters listed by the combined identifier.");
			if (key == "fixed_props") return Set(out explanation, portuguese, "Define propriedades fixas aplicadas ao equipamento, além dos atributos variáveis.", "Defines fixed properties applied to the equipment in addition to variable attributes.");
			if (key == "levelup_addon") return Set(out explanation, portuguese, "Vincula o bônus ou efeito aplicado quando este equipamento é aprimorado.", "Links the bonus or effect applied when this equipment is upgraded.");
			if (key == "material_need") return Set(out explanation, portuguese, "Define a quantidade de material exigida para fabricar ou aprimorar este equipamento.", "Defines the amount of material required to craft or upgrade this equipment.");
			if (key == "price") return Set(out explanation, portuguese, "Define o valor-base do equipamento nos dados do jogo.", "Defines the equipment's base value in the game data.");
			if (key == "shop_price") return Set(out explanation, portuguese, "Define o preço usado pelo serviço de loja para vender este equipamento.", "Defines the price used by shop services to sell this equipment.");
			if (key == "repairfee") return Set(out explanation, portuguese, "Define o custo de reparo do equipamento.", "Defines the equipment repair cost.");
			if (key.StartsWith("addons_", StringComparison.Ordinal) && key.EndsWith("_id_addon", StringComparison.Ordinal))
				return Set(out explanation, portuguese, "Vincula o bônus adicional deste espaço do equipamento. O número no nome do campo identifica o espaço; confirme o limite aceito pelo jogo antes de alterar.", "Links the additional bonus assigned to this equipment slot. The number in the field name identifies the slot; verify the game's supported limit before changing it.");
			if (key.StartsWith("addons_", StringComparison.Ordinal) && key.EndsWith("_probability_addon", StringComparison.Ordinal))
				return Set(out explanation, portuguese, "Define a probabilidade associada ao bônus do mesmo espaço numerado.", "Defines the probability associated with the bonus in the matching numbered slot.");
			if (key.StartsWith("rands_", StringComparison.Ordinal) && key.Contains("_id_rand"))
				return Set(out explanation, portuguese, "Vincula um bônus aleatório disponível para este equipamento; o número indica o espaço da lista.", "Links a random bonus available for this equipment; the number identifies its list slot.");
			if (key.StartsWith("rands_", StringComparison.Ordinal) && key.Contains("_probability_rand"))
				return Set(out explanation, portuguese, "Define a chance de seleção do bônus aleatório no espaço correspondente.", "Defines the selection chance for the random bonus in the matching slot.");
			if (key.StartsWith("uniques_", StringComparison.Ordinal) && key.Contains("_id_unique"))
				return Set(out explanation, portuguese, "Vincula um bônus único possível para este equipamento; o número identifica o espaço.", "Links a possible unique bonus for this equipment; the number identifies the slot.");
			if (key.StartsWith("uniques_", StringComparison.Ordinal) && key.Contains("_probability_unique"))
				return Set(out explanation, portuguese, "Define a chance do bônus único no espaço correspondente.", "Defines the chance for the unique bonus in the matching slot.");
			if (key.StartsWith("hides_", StringComparison.Ordinal) && key.Contains("_id_hide"))
				return Set(out explanation, portuguese, "Vincula um efeito oculto possível para este equipamento; o número identifica o espaço.", "Links a possible hidden effect for this equipment; the number identifies the slot.");
			if (key.StartsWith("hides_", StringComparison.Ordinal) && key.Contains("_probability_hide"))
				return Set(out explanation, portuguese, "Define a chance do efeito oculto no espaço correspondente.", "Defines the chance for the hidden effect in the matching slot.");
			if (key.StartsWith("drop_probability_socket", StringComparison.Ordinal))
				return Set(out explanation, portuguese, "Define a chance de obter um espaço de encaixe deste índice quando o item é encontrado como saque.", "Defines the chance of receiving a socket of this index when the item drops.");
			if (key.StartsWith("make_probability_socket", StringComparison.Ordinal))
				return Set(out explanation, portuguese, "Define a chance de criar um espaço de encaixe deste índice durante a fabricação.", "Defines the chance of creating a socket of this index during crafting.");
			if (key == "durability_min") return Set(out explanation, portuguese, "Define a durabilidade mínima inicial do equipamento.", "Defines the equipment's minimum initial durability.");
			if (key == "durability_max") return Set(out explanation, portuguese, "Define a durabilidade máxima inicial do equipamento.", "Defines the equipment's maximum initial durability.");
			if (key == "durability_drop_min") return Set(out explanation, portuguese, "Define a durabilidade mínima do equipamento quando obtido como saque.", "Defines the equipment's minimum durability when obtained as a drop.");
			if (key == "durability_drop_max") return Set(out explanation, portuguese, "Define a durabilidade máxima do equipamento quando obtido como saque.", "Defines the equipment's maximum durability when obtained as a drop.");
			if (key == "decompose_price") return Set(out explanation, portuguese, "Define o valor recebido ou aplicado ao decompor o equipamento.", "Defines the value received or applied when the equipment is decomposed.");
			if (key == "decompose_time") return Set(out explanation, portuguese, "Define o tempo necessário para decompor o equipamento.", "Defines the time required to decompose the equipment.");
			if (key == "element_id") return Set(out explanation, portuguese, "Indica o ID do material ou elemento produzido/consumido na operação associada ao equipamento.", "Identifies the material or element produced/consumed by the operation associated with this equipment.");
			if (key == "element_num") return Set(out explanation, portuguese, "Define a quantidade do material ou elemento indicado por element_id.", "Defines the quantity of the material or element identified by element_id.");
			if (key == "pile_num_max") return Set(out explanation, portuguese, "Define a quantidade máxima que pode ser agrupada em uma pilha, quando aplicável.", "Defines the maximum quantity that can be grouped into a stack, when applicable.");
			if (key == "proc_type") return Set(out explanation, portuguese, "Seleciona o tipo de processamento do item pelo jogo; valores dependem da versão e não devem ser alterados sem referência compatível.", "Selects how the game processes the item; values are version-specific and should not be changed without a matching reference.");
			if (weapon && (key == "damage_low" || key == "damage_high_min" || key == "damage_high_max"))
				return Set(out explanation, portuguese, "Define um limite do dano físico desta arma. Os campos low/high_min/high_max compõem a faixa usada pelo jogo.", "Defines a physical damage bound for this weapon. The low/high_min/high_max fields form the range used by the game.");
			if (weapon && (key == "magic_damage_low" || key == "magic_damage_high_min" || key == "magic_damage_high_max"))
				return Set(out explanation, portuguese, "Define um limite do dano mágico desta arma; os campos de mínimo e máximo formam a faixa de dano.", "Defines a magic damage bound for this weapon; the minimum and maximum fields form its damage range.");
			if (weapon && key == "attack_range") return Set(out explanation, portuguese, "Define o alcance de ataque da arma.", "Defines the weapon's attack range.");
			if (weapon && key == "attack_speed") return Set(out explanation, portuguese, "Define o parâmetro de velocidade de ataque da arma, conforme a escala usada pelo jogo.", "Defines the weapon attack-speed parameter using the game's scale.");
			if (armor && (key == "defence_low" || key == "defence_high")) return Set(out explanation, portuguese, "Define o limite inferior/superior da defesa física fornecida pela armadura.", "Defines the lower/upper bound of the physical defense provided by this armor.");
			if (armor && key.StartsWith("magic_defences_", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o limite inferior ou superior de uma das cinco defesas mágicas fornecidas pela armadura; o número identifica o elemento.", "Defines the lower or upper bound of one of the five magic defenses provided by this armor; the number identifies the element.");
			if (key.StartsWith("require_", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o atributo mínimo exigido para equipar este item.", "Defines the minimum attribute required to equip this item.");
			if (key == "level") return Set(out explanation, portuguese, "Define o nível associado ao equipamento e usado pelas regras do jogo.", "Defines the equipment level used by game rules.");
			if (key == "require_level") return Set(out explanation, portuguese, "Define o nível mínimo do personagem para equipar este item.", "Defines the minimum character level required to equip this item.");
			if (key == "require_reputation") return Set(out explanation, portuguese, "Define a reputação mínima exigida para equipar este item.", "Defines the minimum reputation required to equip this item.");
			if (key == "file_matter" || key == "file_icon" || key == "file_model") return Set(out explanation, portuguese, "Aponta para o recurso visual ou modelo usado para representar este equipamento no jogo.", "Points to the visual resource or model used to represent this equipment in the game.");
			if (key == "realname" || key == "subname") return Set(out explanation, portuguese, "Armazena um nome alternativo ou complementar exibido para este equipamento.", "Stores an alternate or secondary name displayed for this equipment.");
		}

		if (schema == "MEDICINE_ESSENCE")
		{
			if (key == "cool_time") return Set(out explanation, portuguese, "Define o intervalo de recarga antes que esta medicina possa ser usada novamente.", "Defines the cooldown before this medicine can be used again.");
			if (key == "hp_add_total") return Set(out explanation, portuguese, "Define o total de pontos de vida restaurados por esta medicina.", "Defines the total health restored by this medicine.");
			if (key == "hp_add_time") return Set(out explanation, portuguese, "Define o período em que a restauração de vida é aplicada.", "Defines the period over which health restoration is applied.");
			if (key == "mp_add_total") return Set(out explanation, portuguese, "Define o total de pontos de mana restaurados por esta medicina.", "Defines the total mana restored by this medicine.");
			if (key == "mp_add_time") return Set(out explanation, portuguese, "Define o período em que a restauração de mana é aplicada.", "Defines the period over which mana restoration is applied.");
		}

		if (schema == "MATERIAL_ESSENCE")
		{
			if (key == "decompose_price") return Set(out explanation, portuguese, "Define o valor associado à decomposição deste material.", "Defines the value associated with decomposing this material.");
			if (key == "decompose_time") return Set(out explanation, portuguese, "Define o tempo necessário para decompor este material.", "Defines the time required to decompose this material.");
			if (key == "element_id") return Set(out explanation, portuguese, "ID do material ou elemento relacionado à produção/decomposição deste registro.", "ID of the material or element related to producing/decomposing this record.");
			if (key == "element_num") return Set(out explanation, portuguese, "Quantidade do material ou elemento associado ao element_id.", "Quantity of the material or element associated with element_id.");
		}

		if (schema == "TOWNSCROLL_ESSENCE" || schema == "UNIONSCROLL_ESSENCE" || schema == "REVIVESCROLL_ESSENCE")
		{
			if (key == "use_time") return Set(out explanation, portuguese, "Define o tempo de uso antes que o efeito do pergaminho seja aplicado.", "Defines the use time before the scroll effect is applied.");
			if (key == "cool_time") return Set(out explanation, portuguese, "Define o intervalo de recarga antes que este pergaminho possa ser usado novamente.", "Defines the cooldown before this scroll can be used again.");
			if (key == "price" || key == "shop_price") return Set(out explanation, portuguese, "Define o valor/preço deste pergaminho nos dados e serviços de loja.", "Defines this scroll's base/shop price in the game data.");
		}
		if (schema == "SKILLTOME_ESSENCE" && key == "id_sub_type")
			return Set(out explanation, portuguese, "Vincula o livro de habilidade ao subtipo que determina sua classificação.", "Links the skill tome to the subtype that determines its classification.");
		if (schema == "PROJECTILE_ESSENCE")
		{
			if (key == "type") return Set(out explanation, portuguese, "Classifica o tipo de projétil e as regras de uso associadas.", "Classifies the projectile type and its associated use rules.");
			if (key == "require_weapon_level_min" || key == "require_weapon_level_max") return Set(out explanation, portuguese, "Define o limite inferior/superior de nível da arma exigido para usar este projétil.", "Defines the lower/upper weapon-level bound required to use this projectile.");
			if (key == "damage_enhance" || key == "damage_scale_enhance") return Set(out explanation, portuguese, "Define um bônus ou multiplicador de dano aplicado pelo projétil.", "Defines a damage bonus or multiplier applied by the projectile.");
			if (key.StartsWith("id_addon", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Vincula o efeito adicional desta posição do projétil; o sufixo numérico identifica o espaço.", "Links the additional effect in this projectile slot; the numeric suffix identifies the slot.");
			if (key.StartsWith("file_", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Aponta para um modelo, efeito visual ou recurso de áudio usado pelo projétil.", "Points to a model, visual effect, or audio resource used by the projectile.");
		}
		if (schema == "QUIVER_ESSENCE")
		{
			if (key == "id_projectile") return Set(out explanation, portuguese, "Define qual projétil é fornecido ou utilizado por esta aljava.", "Defines which projectile is supplied or used by this quiver.");
			if (key == "num_min" || key == "num_max") return Set(out explanation, portuguese, "Define a quantidade mínima/máxima de projéteis associada à aljava.", "Defines the minimum/maximum number of projectiles associated with this quiver.");
		}
		if (schema == "STONE_ESSENCE")
		{
			if (key == "level") return Set(out explanation, portuguese, "Define o nível da pedra, usado pelas regras de encaixe e efeito.", "Defines the stone level used by socketing and effect rules.");
			if (key == "color") return Set(out explanation, portuguese, "Define a cor ou categoria visual da pedra.", "Defines the stone's visual color or category.");
			if (key == "install_price" || key == "uninstall_price") return Set(out explanation, portuguese, "Define o custo para instalar/remover esta pedra de um equipamento.", "Defines the cost to install/remove this stone from equipment.");
			if (key.StartsWith("id_addon_", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Vincula o bônus que esta pedra aplica ao equipamento, conforme a categoria indicada no campo.", "Links the bonus this stone applies to equipment, according to the category in the field name.");
			if (key.EndsWith("_desc", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Armazena o texto descritivo exibido para o efeito da pedra na categoria indicada.", "Stores the descriptive text displayed for the stone effect in the indicated category.");
		}
		if (schema == "FLYSWORD_ESSENCE" || schema == "WINGMANWING_ESSENCE")
		{
			if (key == "require_player_level_min") return Set(out explanation, portuguese, "Define o nível mínimo do personagem para usar este item de voo.", "Defines the minimum character level required to use this flight item.");
			if (key == "speed_increase" || key.StartsWith("speed_increase_", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o aumento de velocidade de voo fornecido pelo item.", "Defines the flight speed increase provided by this item.");
			if (key.StartsWith("speed_rush_increase", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o aumento de velocidade durante a aceleração rápida do item de voo.", "Defines the speed increase during this flight item's speed boost.");
			if (key.StartsWith("time_max_", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o limite de duração do modo de aceleração rápida.", "Defines the duration limit for the speed-boost mode.");
			if (key == "time_increase_per_element") return Set(out explanation, portuguese, "Define quanto tempo é acrescentado por unidade do recurso indicado pelo jogo.", "Defines how much time is added per unit of the resource specified by the game.");
			if (key == "fly_mode" || key == "fly_type") return Set(out explanation, portuguese, "Seleciona o modo/tipo de voo compatível com este item.", "Selects the flight mode/type supported by this item.");
			if (key.StartsWith("improve_config_", StringComparison.Ordinal) && key.EndsWith("_require_item_num", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define a quantidade de itens exigida neste nível de aprimoramento do voo.", "Defines the item quantity required at this flight upgrade level.");
			if (key.StartsWith("improve_config_", StringComparison.Ordinal) && key.EndsWith("_speed_increase", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o aumento de velocidade normal concedido neste nível de aprimoramento.", "Defines the normal speed increase granted at this upgrade level.");
			if (key.StartsWith("improve_config_", StringComparison.Ordinal) && key.EndsWith("_speed_rush_increase", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o aumento de velocidade rápida concedido neste nível de aprimoramento.", "Defines the boost speed increase granted at this upgrade level.");
		}
		if (schema == "PET_ESSENCE")
		{
			if (key == "level_max" || key == "level_require") return Set(out explanation, portuguese, "Define o nível máximo/requerido associado a este mascote.", "Defines the maximum/required level associated with this pet.");
			if (key.StartsWith("hp_inherit_") || key.StartsWith("attack_inherit_") || key.StartsWith("defence_inherit_") || key.StartsWith("attack_level_inherit_") || key.StartsWith("defence_level_inherit_")) return Set(out explanation, portuguese, "Define a taxa mínima, máxima ou aplicada de herança do atributo do mascote ao personagem, conforme o sufixo.", "Defines the minimum, maximum, or applied inheritance rate for this pet attribute, as indicated by the suffix.");
			if (key.StartsWith("specific_skill") || key == "born_skill_id" || key == "born_skill_level") return Set(out explanation, portuguese, "Define uma habilidade específica ou concedida ao mascote ao nascer.", "Defines a specific skill or a skill granted to the pet at birth.");
			if (key == "attack_range" || key == "sight_range") return Set(out explanation, portuguese, "Define o alcance de ataque/visão usado pelo comportamento do mascote.", "Defines the attack/vision range used by the pet's behavior.");
			if (key == "speed_a" || key == "speed_b") return Set(out explanation, portuguese, "Define um parâmetro de velocidade do mascote; a variante é determinada pelo sufixo.", "Defines a pet speed parameter; the variant is identified by the suffix.");
			if (key == "file_model" || key == "extra_model" || key == "file_gfx_short") return Set(out explanation, portuguese, "Aponta para o modelo ou recurso visual usado pelo mascote.", "Points to the model or visual resource used by the pet.");
		}
		if (schema == "PET_EGG_ESSENCE")
		{
			if (key == "id_pet") return Set(out explanation, portuguese, "Define qual mascote será obtido ao abrir este ovo.", "Defines which pet is obtained when this egg is opened.");
			if (key == "money_hatched" || key == "money_restored" || key == "honor_point") return Set(out explanation, portuguese, "Define a moeda ou pontos exigidos para chocar/restaurar o ovo ou concedidos pela ação.", "Defines the currency or points required to hatch/restore the egg or granted by the action.");
			if (key.StartsWith("skills_", StringComparison.Ordinal) && key.EndsWith("_id_skill", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Vincula a habilidade inicial neste espaço numerado do mascote.", "Links the initial skill in this numbered pet skill slot.");
			if (key.StartsWith("skills_", StringComparison.Ordinal) && key.EndsWith("_level", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o nível inicial da habilidade no espaço numerado correspondente.", "Defines the starting level for the skill in the matching numbered slot.");
		}
		if (schema == "PET_FOOD_ESSENCE")
		{
			if (key == "food_type") return Set(out explanation, portuguese, "Classifica o tipo de alimento que pode ser usado pelo mascote.", "Classifies the food type that can be used by the pet.");
			if (key == "exp") return Set(out explanation, portuguese, "Define a experiência concedida ao mascote por este alimento.", "Defines the experience granted to the pet by this food.");
			if (key == "hornor") return Set(out explanation, portuguese, "Define os pontos de honra concedidos ao mascote por este alimento.", "Defines the honor points granted to the pet by this food.");
		}
		if (schema == "RECIPE_ESSENCE")
		{
			if (key == "recipe_level") return Set(out explanation, portuguese, "Define o nível exigido para a receita.", "Defines the level requirement for this recipe.");
			if (key == "id_skill" || key == "skill_level") return Set(out explanation, portuguese, "Vincula a habilidade e o nível necessários para executar a receita.", "Links the skill and skill level required to use this recipe.");
			if (key.StartsWith("targets_", StringComparison.Ordinal) && key.EndsWith("_id_to_make", StringComparison.Ordinal)) return Set(out explanation, portuguese, "ID do resultado possível produzido por esta receita; o número indica a alternativa.", "ID of a possible output produced by this recipe; the number identifies the outcome slot.");
			if (key.StartsWith("targets_", StringComparison.Ordinal) && key.EndsWith("_probability", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Probabilidade de obter o resultado da receita na alternativa numerada correspondente.", "Probability of obtaining the recipe outcome in the matching numbered slot.");
			if (key == "fail_probability") return Set(out explanation, portuguese, "Define a chance de falha ao executar a receita.", "Defines the chance that crafting the recipe fails.");
			if (key.StartsWith("materials_", StringComparison.Ordinal) && key.EndsWith("_id", StringComparison.Ordinal)) return Set(out explanation, portuguese, "ID do material exigido pela receita na posição numerada.", "ID of the material required by the recipe in this numbered slot.");
			if (key.StartsWith("materials_", StringComparison.Ordinal) && key.EndsWith("_num", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Quantidade do material exigido na posição numerada correspondente.", "Quantity of the material required in the matching numbered slot.");
			if (key == "num_to_make") return Set(out explanation, portuguese, "Define quantas unidades do resultado são produzidas por execução da receita.", "Defines how many output units are produced per recipe execution.");
			if (key == "duration") return Set(out explanation, portuguese, "Define o tempo necessário para executar a receita.", "Defines the time required to complete the recipe.");
		}
		if (schema == "NPC_MAKE_SERVICE")
		{
			if (key == "id_make_skill") return Set(out explanation, portuguese, "Define a habilidade de fabricação exigida pelo serviço deste NPC.", "Defines the crafting skill required by this NPC service.");
			if (key == "produce_type") return Set(out explanation, portuguese, "Seleciona a categoria de fabricação exibida pelo serviço; os valores válidos dependem da versão do jogo.", "Selects the crafting category shown by this service; valid values depend on the game version.");
			if (key.StartsWith("pages_", StringComparison.Ordinal) && key.EndsWith("_page_title", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define o título de uma aba de receitas apresentada no serviço de fabricação do NPC.", "Defines a recipe-tab title displayed in the NPC crafting service.");
			if (key.StartsWith("pages_", StringComparison.Ordinal) && key.Contains("_id_goods_")) return Set(out explanation, portuguese, "Vincula uma receita exibida nesta aba do serviço. O valor é o ID da receita; o resultado e os materiais são definidos no registro da receita correspondente.", "Links a recipe displayed on this service tab. The value is the recipe ID; its output and materials are defined in the matching recipe record.");
		}
		if (schema == "MINE_ESSENCE")
		{
			if (key == "id_equipment_required") return Set(out explanation, portuguese, "ID do equipamento necessário para coletar neste recurso.", "ID of the equipment required to gather this resource.");
			if (key == "eliminate_tool") return Set(out explanation, portuguese, "Define a ferramenta ou condição de coleta exigida para esgotar o recurso.", "Defines the tool or gathering condition required to deplete the resource.");
			if (key == "time_min" || key == "time_max") return Set(out explanation, portuguese, "Define o tempo mínimo/máximo da ação de coleta.", "Defines the minimum/maximum duration of the gathering action.");
			if (key.StartsWith("materials_", StringComparison.Ordinal) && key.EndsWith("_id", StringComparison.Ordinal)) return Set(out explanation, portuguese, "ID do material que pode ser obtido neste espaço da tabela de coleta.", "ID of the material that can be obtained from this gathering table slot.");
			if (key.StartsWith("materials_", StringComparison.Ordinal) && key.EndsWith("_probability", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Chance de obtenção do material no espaço numerado correspondente.", "Chance of obtaining the material in the matching numbered slot.");
			if (key.StartsWith("materials_", StringComparison.Ordinal) && key.EndsWith("_life", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Define a duração ou vida útil do material/recurso no espaço numerado, conforme a regra desta versão.", "Defines the duration or lifetime for the material/resource in this numbered slot, according to this version's rules.");
			if (key.StartsWith("npcgen_", StringComparison.Ordinal) && key.Contains("_id_monster")) return Set(out explanation, portuguese, "ID do monstro que pode surgir associado à coleta deste recurso.", "ID of the monster that may spawn while gathering this resource.");
			if (key.StartsWith("npcgen_", StringComparison.Ordinal) && key.EndsWith("_probability", StringComparison.Ordinal)) return Set(out explanation, portuguese, "Chance de surgimento do monstro no espaço numerado correspondente.", "Spawn chance for the monster in the matching numbered slot.");
		}

		if (schema.EndsWith("_MAJOR_TYPE", StringComparison.Ordinal))
		{
			if (key == "id") return Set(out explanation, portuguese, "ID da categoria principal, referenciado pelos registros desta família.", "ID of the major category referenced by records in this family.");
			if (key == "name") return Set(out explanation, portuguese, "Nome exibido para a categoria principal desta família de dados.", "Display name of this data family's major category.");
		}
		if (schema.EndsWith("_SUB_TYPE", StringComparison.Ordinal))
		{
			if (key == "id") return Set(out explanation, portuguese, "ID do subtipo, usado por registros desta família para classificação mais específica.", "ID of the subtype used by records in this family for more specific classification.");
			if (key == "name") return Set(out explanation, portuguese, "Nome exibido para este subtipo.", "Display name of this subtype.");
			if (key == "equip_mask") return Set(out explanation, portuguese, "Máscara de bits que define os espaços ou condições de equipamento aceitos por este subtipo.", "Bit mask defining the equipment slots or conditions accepted by this subtype.");
		}

		explanation = null;
		return false;
	}

	private static bool Set(out string explanation, bool portuguese, string ptBr, string english)
	{
		explanation = portuguese ? ptBr : english;
		return true;
	}

	private static string GetMeaning(string field, bool portuguese)
	{
		string key = (field ?? string.Empty).ToLowerInvariant();
		if (key == "id")
			return portuguese ? "Identifica este registro dentro da lista." : "Identifies this record within the list.";
		if (key == "name")
			return portuguese ? "Armazena o nome associado a este registro." : "Stores the name associated with this record.";
		if (key.Contains("tasks_data") || key.Contains("taskid") || key.Contains("quest"))
			return portuguese ? "Armazena um vínculo, categoria ou identificador de tarefa/missão." : "Stores a link, category, or identifier for a task or quest.";
		if (key.StartsWith("id_", StringComparison.Ordinal) || key.EndsWith("_id", StringComparison.Ordinal) || key.Contains("_service"))
			return portuguese ? "Armazena um identificador ou vínculo com outro registro ou serviço do jogo." : "Stores an identifier or link to another game record or service.";
		if (key.Contains("prob") || key.Contains("chance") || key.Contains("rate") || key.Contains("ratio"))
			return portuguese ? "Define uma probabilidade, taxa ou proporção aplicada pelo jogo." : "Defines a probability, rate, or ratio used by the game.";
		if (key.Contains("time") || key.Contains("duration") || key.Contains("delay") || key.Contains("interval") || key.Contains("cooldown"))
			return portuguese ? "Define um horário, intervalo, duração ou recarga." : "Defines a time, interval, duration, or cooldown.";
		if (key.Contains("price") || key.Contains("cost") || key.Contains("money") || key.Contains("gold") || key.Contains("silver"))
			return portuguese ? "Define um valor monetário, preço, custo ou recompensa." : "Defines a currency amount, price, cost, or reward.";
		if (key.Contains("require") || key.Contains("required") || key.Contains("need") || key.Contains("condition"))
			return portuguese ? "Define um requisito ou condição para liberar ou aplicar este registro." : "Defines a requirement or condition for unlocking or applying this record.";
		if (key.Contains("level") || key.EndsWith("_lv", StringComparison.Ordinal))
			return portuguese ? "Define um nível, faixa de níveis ou requisito de nível." : "Defines a level, level range, or level requirement.";
		if (key.Contains("count") || key.Contains("amount") || key.StartsWith("num_", StringComparison.Ordinal) || key.StartsWith("max_", StringComparison.Ordinal) || key.StartsWith("min_", StringComparison.Ordinal) || key.Contains("quantity"))
			return portuguese ? "Define uma quantidade ou limite numérico." : "Defines a quantity or numeric limit.";
		if (key.Contains("attack") || key.Contains("damage") || key.Contains("dmg") || key.Contains("hurt") || key.Contains("atk"))
			return portuguese ? "Define um parâmetro ofensivo, de ataque ou dano." : "Defines an offensive, attack, or damage parameter.";
		if (key.Contains("defense") || key.Contains("defence") || key.Contains("armor") || key.Contains("resist"))
			return portuguese ? "Define um parâmetro defensivo, de defesa, armadura ou resistência." : "Defines a defense, armor, or resistance parameter.";
		if (key.Contains("hp") || key.Contains("mp") || key.Contains("health") || key.Contains("mana") || key.Contains("energy"))
			return portuguese ? "Define um valor relacionado a vida, mana ou energia." : "Defines a health, mana, or energy value.";
		if (key.Contains("exp") || key.Contains("experience"))
			return portuguese ? "Define uma quantidade ou regra de experiência." : "Defines an experience amount or rule.";
		if (key.Contains("file") || key.Contains("path") || key.Contains("model") || key.Contains("texture") || key.Contains("icon") || key.Contains("gfx"))
			return portuguese ? "Armazena um caminho ou referência a recurso visual/arquivo usado pelo cliente." : "Stores a path or reference to a visual or file resource used by the client.";
		if (key.Contains("name") || key.Contains("msg") || key.Contains("text") || key.Contains("desc") || key.Contains("title"))
			return portuguese ? "Armazena um nome, texto, mensagem, descrição ou título apresentado pelo jogo." : "Stores a name, text, message, description, or title displayed by the game.";
		if (key.Contains("type") || key.Contains("subtype") || key.Contains("category"))
			return portuguese ? "Classifica este registro por tipo, subtipo ou categoria." : "Classifies this record by type, subtype, or category.";
		if (key.StartsWith("is_", StringComparison.Ordinal) || key.StartsWith("no_", StringComparison.Ordinal) || key.StartsWith("enable", StringComparison.Ordinal) || key.StartsWith("disable", StringComparison.Ordinal) || key.EndsWith("_flag", StringComparison.Ordinal) || key.EndsWith("_switch", StringComparison.Ordinal) || key.StartsWith("can_", StringComparison.Ordinal))
			return portuguese ? "Controla um estado, permissão ou opção de ativação." : "Controls a state, permission, or enable/disable option.";
		if (key.Contains("pos") || key.Contains("coord") || key.Contains("offset") || key.Contains("radius") || key.Contains("range") || key.Contains("distance"))
			return portuguese ? "Define uma posição, distância, alcance ou dimensão espacial." : "Defines a position, distance, range, or spatial dimension.";
		if (key.Contains("speed") || key.Contains("velocity") || key.Contains("move"))
			return portuguese ? "Define um parâmetro de velocidade ou movimento." : "Defines a speed or movement parameter.";
		if (key.Contains("skill") || key.Contains("spell"))
			return portuguese ? "Define uma habilidade, magia ou vínculo relacionado a habilidades." : "Defines a skill, spell, or skill-related link.";
		if (key.Contains("item") || key.Contains("物品"))
			return portuguese ? "Define um item, quantidade de itens ou vínculo com um item." : "Defines an item, item quantity, or item reference.";
		return portuguese
			? "A finalidade não é identificável com segurança pelo nome. Consulte a documentação desta lista e versão antes de alterar este dado."
			: "The field purpose cannot be safely determined from its name. Check documentation for this list and version before changing it.";
	}
}
