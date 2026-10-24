"""Gera nomes de listas do PW em PT-BR sem modificar os arquivos .cfg.

As traduções de campos, revisadas separadamente, ficam no mesmo catálogo.
"""
import json
import re
from collections import Counter
from pathlib import Path

root = Path(__file__).resolve().parents[1]
configs = root / "Editor/runtime/Configs/PW/configs"
reference = configs / "PW_1.8.9_v623.cfg"
target = root / "Editor/runtime/i18n/pt-BR/elements/PW.json"
coverage_file = root / "verification/pw-v623-localization-coverage.json"

words = dict(line.split("=", 1) for line in """
ABILITY=Habilidade
ACC=Conta
ACHIEVEMENT=Conquista
ACROSS=Entre
ACTION=Ação
ACTIVE=Ativo
ACTIVITY=Atividade
ADDON=Bônus
ADDONRUNE=Runa de bônus
ADJUST=Ajuste
ADVANCE=Avanço
ANNIVERSARY=Aniversário
APPEARANCE=Aparência
AREA=Área
ARENA=Arena
ARMOR=Armadura
ARMORRUNE=Runa de armadura
ARRAY=Matriz
AWARD=Prêmio
AWARDS=Prêmios
BATTLE=Batalha
BEAST=Fera
BEST=Melhor
BIBLE=Bíblia
BLACK=Negra
BLACKLIST=Lista negra
BLESS=Bênção
BOOK=Livro
BOOKCARD=Cartão de livro
BOSSRUSH=Corrida de chefes
BOTTLE=Garrafa
BOX=Caixa
BRANCH=Ramo
BREAK=Quebra
BUILDING=Construção
BUY=Compra
CAMP=Acampamento
CAPTURE=Captura
CARRIER=Transportador
CERTIFICATE=Certificado
CHALLENGE=Desafio
CHANGE=Alteração
CHANGED=Alterado
CHARIOT=Carruagem
CHARRACTER=Personagem
CHESS=Xadrez
CHRISTMAS=Natal
CLASS=Classe
COLOR=Cor
COLORPICKER=Seletor de cores
COMPLEX=Complexo
CONFIG=Configuração
CONGREGATE=Reunião
CONSUME=Consumo
CONSUMPTION=Consumo
CONTROLLER=Controlador
CONVERT=Conversão
CONVERTIBLE=Conversível
COORD=Coordenada
COST=Custo
COUNTRY=País
COUPLE=Casal
COURSE=Percurso
COVER=Cobertura
CREATE=Criação
CROSS=Entre
CURRENCY=Moeda
CUSTOMIZEDATA=Dados personalizados
DAMAGERUNE=Runa de dano
DEATH=Morte
DEBRIS=Fragmentos
DECOMPOSE=Decomposição
DECORATION=Acessório
DEFAULT=Padrão
DESTROYING=Destruição
DIALOG=Diálogo
DICE=Dado
DISPLAY=Exibição
DOUBLE=Duplo
DRIFT=Deriva
DROP=Queda
DYE=Tintura
EASY=Simples
EGG=Ovo
ELEMENT=Elemento
EMOTION=Emoção
ENCHANT=Encantamento
ENEMY=Inimigo
ENGRAVE=Gravação
ENTER=Entrada
ENTITY=Entidade
EQUIP=Equipamento
EQUIPMENT=Equipamento
ESSENCE=Item
EVENT=Evento
EVIL=Mal
EVOLVE=Evolução
EVOLVED=Evoluído
EXP=Experiência
EXPLORE=Exploração
EXPRESSION=Expressão
EXTRA=Extra
FACE=Rosto
FACTION=Facção
FACTORY=Fábrica
FAST=Rápido
FEATURE=Recurso
FEED=Alimentação
FIREWORKS=Fogos de artifício
FIX=Correção
FLYING=Voador
FOOD=Comida
FOR=Para
FORBID=Proibição
FORCE=Força
FORMULAS=Fórmulas
FORTRESS=Fortaleza
GENERATOR=Gerador
GM=GM
GOBLIN=Gênio
GOD=Deus
GRASS=Grama
GROWTH=Crescimento
GUARDIAN=Guardião
HAIR=Cabelo
HEAL=Cura
HERO=Herói
HIGH=Alto
HINT=Dica
HISTORY=Histórico
HOLE=Orifício
HOME=Casa
IDENTIFY=Identificação
ILLUSTRATED=Ilustrado
INC=Aumento
INFO=Informação
INNER=Interno
INSTALL=Instalação
INSTANCE=Instância
INTERACT=Interação
INTERFACE=Interface
INVITECARD=Convite
ITEM=Item
LEVEL=Nível
LEVELEXP=Experiência por nível
LEVELUP=Refinamento
LIMIT=Limite
LINE=Linha
LIST=Lista
LOOK=Aparência
LOTTERY=Loteria
LOTTORY=Loteria
MAJOR=Principal
MAKE=Fabricação
MAP=Mapa
MATCH=Partida
MATERIAL=Material
MATTER=Material
MAX=Máximo
MEDICINE=Consumível
MENTAL=Mental
MENTOR=Mentor
MERIDIAN=Meridiano
METHOD=Método
MINE=Mina
MONEY=Dinheiro
MONSTER=Monstro
MOUSTACHE=Bigode
MULTI=Múltiplo
MYSTERIOUS=Misteriosa
NEW=Novo
NORMAL=Normal
NPC=NPC
OBJECT=Objeto
OFFLINEBATTLE=Batalha offline
ONLINE=On-line
OPEN=Abertura
OTHER=Outro
PACKAGE=Pacote
PACKET=Pacote
PAGE=Página
PAPER=Papel
PARAM=Parâmetro
PARK=Parque
PEAK=Pico
PET=Mascote
PICTURE=Imagem
PLAYER=Jogador
POINT=Ponto
POINTS=Pontos
POLICY=Política
PORTRAIT=Retrato
POSITION=Posição
POWER=Poder
PROB=Probabilidade
PROC=Processo
PRODUCE=Produção
PRODUCTION=Produção
PRODUCTS=Produtos
PROFESSION=Profissão
PROFIT=Lucro
PROGRESS=Progresso
PROJECTILE=Projétil
PROP=Propriedade
PROPERTY=Propriedade
PROXY=Representante
PVP=PvP
PVE=PvE
QUALITY=Qualidade
QUESTION=Pergunta
RACE=Raça
RAND=Aleatório
RANDOM=Aleatório
REALM=Reino
RECIPE=Receita
RED=Vermelho
REFINE=Refinamento
REGION=Região
REINCARNATION=Reencarnação
REMOVE=Remoção
REPAIR=Reparo
REPUTATION=Reputação
RESOURCE=Recurso
RESPAWN=Reaparecimento
RESULT=Resultado
RETURN=Retorno
REWARD=Recompensa
ROAD=Caminho
ROLLBACK=Reversão
ROOM=Sala
RUNE=Runa
SCENE=Cena
SCORE=Pontuação
SEARCH=Busca
SEASON=Temporada
SECONDLEVEL=Segundo nível
SELF=Próprio
SELL=Venda
SERIES=Série
SERVER=Servidor
SERVICE=Serviço
SETTING=Configuração
SHAPE=Forma
SHIELD=Escudo
SHOP=Loja
SHOW=Exibição
SIGN=Sinal
SIMULATOR=Simulador
SINGLE=Único
SKILL=Habilidade
SKILLTOME=Livro de habilidade
SKIN=Aparência
SLIDE=Deslizamento
SLOT=Espaço
SOLO=Solo
SOURCE=Origem
SPEAK=Fala
SPEAKER=Alto-falante
SPECIAL=Especial
SPIRIT=Espírito
STAGE=Etapa
STAR=Estrela
STATE=Estado
STATUE=Estátua
STONE=Pedra
STORAGE=Armazém
STORY=História
STUDENT=Estudante
SUB=Subtipo
SUIT=Conjunto
SUITE=Conjunto
SURVIVAL=Sobrevivência
SYSTEM=Sistema
TABOO=Tabu
TALENT=Talento
TALK=Conversa
TARGET=Alvo
TASK=Tarefa
TECH=Técnica
TEMPL=Modelo
TEXTURE=Textura
TICKET=Bilhete
TILLAGE=Cultivo
TIME=Tempo
TIP=Dica
TITLE=Título
TOKEN=Símbolo
TOWER=Torre
TRANSFER=Transferência
TRANSMIT=Teleporte
TRANSPORT=Transporte
TREASURE=Tesouro
TREE=Árvore
TRIBUTE=Tributo
TYPE=Tipo
UNINSTALL=Desinstalação
UNIVERSAL=Universal
UNLOCK=Desbloqueio
UPGRADE=Melhoria
USE=Uso
USED=Utilizado
VALUE=Valor
VARIABLE=Variável
VIRTUAL=Virtual
VOTE=Votação
WAR=Guerra
WATCH=Visualização
WAYPOINT=Ponto de passagem
WEAPON=Arma
WEDDING=Casamento
WEIGHT=Peso
WHITE=Branca
WHITELIST=Lista branca
WIKI=Wiki
WILDERNESS=Região selvagem
WING=Asa
WISH=Desejo
WORLD=Mundo
""".strip().splitlines())
words.update({
    "EXPUP": "bônus de experiência", "GAME": "jogo", "JUMPTO": "teleporte",
    "POST": "posterior", "TREASUREBOX": "caixa de tesouro", "GREENSERVER": "servidor verde",
    "THIRDEYE": "terceiro olho", "EXPPILL": "pílula de experiência",
    "HIGHPOLY": "alta resolução", "POLY": "poligonal", "MAINCUSTOMIZE": "personalização principal",
    "HAND": "iniciante", "PROCTYPE": "tipo de proteção", "SHELF": "estante",
    "EQUIPBIND": "vincular equipamento", "EQUIPDESTROY": "destruir equipamento",
    "EQUIPUNDESTROY": "restaurar equipamento", "PETFORGETSKILL": "esquecer habilidade de mascote",
    "PETLEARNSKILL": "aprender habilidade de mascote", "PETNAME": "nome de mascote",
    "RANDPROP": "propriedade aleatória", "RESETPROP": "redefinir propriedades",
    "TOWERBUILD": "construção de torre", "FACETICKET": "bilhete de aparência",
    "MULTIRIDE": "montaria compartilhada", "TANKCALLIN": "convocação de tanque",
    "BATTLEGROUND": "campo de batalha", "FASHION": "visual", "IN": "entrada",
    "OUT": "saída", "LIB": "biblioteca", "PRIDICTABLE": "previsível",
})

phrases = {
    "TALK_PROC": "Processos de diálogo",
    "2026年5月单人平衡竞技活动": "Evento competitivo individual equilibrado de maio de 2026",
    "活动商店配置表": "Configuração da loja de eventos",
    "活动抽奖配置表": "Configuração do sorteio de eventos",
    "2026愚人节活动抽卡": "Sorteio de cartas do evento de 1º de abril de 2026",
    "活动战令配置表": "Configuração do passe de batalha de eventos",
    "2026东陆挑战玩法配置": "Configuração do desafio Donglu de 2026",
    "GM测试": "Teste de GM",
    "EQUIPMENT_ADDON": "Bônus de equipamento", "WEAPON_MAJOR_TYPE": "Categorias de armas",
    "WEAPON_SUB_TYPE": "Subtipos de armas", "WEAPON_ESSENCE": "Armas",
    "ARMOR_MAJOR_TYPE": "Categorias de armaduras", "ARMOR_SUB_TYPE": "Subtipos de armaduras",
    "ARMOR_ESSENCE": "Armaduras", "DECORATION_MAJOR_TYPE": "Categorias de acessórios",
    "DECORATION_SUB_TYPE": "Subtipos de acessórios", "DECORATION_ESSENCE": "Acessórios",
    "MEDICINE_MAJOR_TYPE": "Categorias de consumíveis", "MEDICINE_SUB_TYPE": "Subtipos de consumíveis",
    "MEDICINE_ESSENCE": "Consumíveis", "MATERIAL_MAJOR_TYPE": "Categorias de materiais",
    "MATERIAL_SUB_TYPE": "Subtipos de materiais", "MATERIAL_ESSENCE": "Materiais",
    "DAMAGERUNE_SUB_TYPE": "Subtipos de runas de dano", "DAMAGERUNE_ESSENCE": "Runas de dano",
    "ARMORRUNE_SUB_TYPE": "Subtipos de runas de armadura", "ARMORRUNE_ESSENCE": "Runas de armadura",
    "SKILLTOME_SUB_TYPE": "Subtipos de livros de habilidades", "SKILLTOME_ESSENCE": "Livros de habilidades",
    "FLYSWORD_ESSENCE": "Espadas voadoras", "WINGMANWING_ESSENCE": "Asas",
    "TOWNSCROLL_ESSENCE": "Pergaminhos de retorno à cidade",
    "UNIONSCROLL_ESSENCE": "Pergaminhos de união",
    "REVIVESCROLL_ESSENCE": "Pergaminhos de ressurreição",
    "ELEMENT_ESSENCE": "Elementos", "TASKMATTER_ESSENCE": "Itens de tarefa",
    "TOSSMATTER_ESSENCE": "Itens arremessáveis", "PROJECTILE_TYPE": "Tipos de projéteis",
    "PROJECTILE_ESSENCE": "Projéteis", "QUIVER_SUB_TYPE": "Subtipos de aljavas",
    "QUIVER_ESSENCE": "Aljavas", "STONE_SUB_TYPE": "Subtipos de pedras",
    "STONE_ESSENCE": "Pedras", "MONSTER_ADDON": "Bônus de monstros",
    "MONSTER_TYPE": "Tipos de monstros", "MONSTER_ESSENCE": "Monstros",
}

fields = {
    "ID": "ID", "Name": "Nome", "num_params": "Quantidade de parâmetros",
    "param1": "Parâmetro 1", "param2": "Parâmetro 2", "param3": "Parâmetro 3",
    "id_major_type": "Tipo", "id_sub_type": "Subtipo", "equip_location": "Local de equipamento",
    "level": "Nível", "require_strength": "Força necessária", "require_agility": "Agilidade necessária",
    "require_energy": "Energia necessária", "require_tili": "Vitalidade necessária",
    "character_combo_id": "Classes permitidas", "require_level": "Nível necessário",
    "require_reputation": "Reputação necessária", "fixed_props": "Propriedades fixas",
    "defence_low": "Defesa mínima", "defence_high": "Defesa máxima",
    "mp_enhance_low": "Bônus mínimo de MP", "mp_enhance_high": "Bônus máximo de MP",
    "hp_enhance_low": "Bônus mínimo de HP", "hp_enhance_high": "Bônus máximo de HP",
    "armor_enhance_low": "Bônus mínimo de defesa", "armor_enhance_high": "Bônus máximo de defesa",
    "durability_min": "Durabilidade mínima", "durability_max": "Durabilidade máxima",
    "levelup_addon": "Bônus de refinamento", "material_need": "Materiais necessários",
    "price": "Preço", "shop_price": "Preço na loja", "repairfee": "Custo de reparo",
    "file_matter": "Arquivo do modelo", "file_icon": "Arquivo do ícone",
    "file_model_right": "Modelo da mão direita", "file_model_left": "Modelo da mão esquerda",
    "require_projectile": "Projétil necessário", "probability_hide": "Probabilidade de bônus oculto",
    "damage_low": "Dano mínimo", "damage_high_min": "Dano máximo mínimo",
    "damage_high_max": "Dano máximo", "magic_damage_low": "Dano mágico mínimo",
    "magic_damage_high_min": "Dano mágico máximo mínimo",
    "magic_damage_high_max": "Dano mágico máximo", "attack_range": "Alcance do ataque",
    "short_range_mode": "Modo de curta distância", "proc_type": "Proteção",
    "pile_num_max": "Quantidade máxima por pilha", "has_guid": "Possui GUID",
    "decompose_price": "Preço de decomposição", "decompose_time": "Tempo de decomposição",
    "force_all_magic_defences": "Todas as defesas mágicas obrigatórias",
}

for i in range(1, 6):
    fields[f"magic_defences_{i}_low"] = f"Defesa mágica {i} mínima"
    fields[f"magic_defences_{i}_high"] = f"Defesa mágica {i} máxima"

# O carregador do editor interpreta "$" como índice numérico em nomes de campos.
# Uma regra cobre famílias inteiras sem alterar os identificadores gravados no jogo.
field_patterns = {
    "reserved$_$": "Reservado $1, $2", "reserved_$": "Reservado $1",
    "extra_reserved_$": "Reservado extra $1", "task_id_space_$": "Espaço de ID de tarefa $1",
    "question_$_answer_$_answer_id": "Pergunta $1, resposta $2: ID",
    "list_$_id": "Lista $1: ID", "list_$_point": "Lista $1: pontos",
    "exp_$": "Experiência $1", "page_infos_$_id_$": "Página $1: ID $2",
    "choice_$_exp_$": "Escolha $1: experiência $2",
    "hair_texture_map_$_model_id": "Mapa de cabelo $1: ID do modelo",
    "hair_texture_map_$_texture_id": "Mapa de cabelo $1: ID da textura",
    "task_$_id": "Tarefa $1: ID", "item_$_id": "Item $1: ID",
    "essence_$": "Item $1", "list_$": "Lista $1", "task_list_$": "Lista de tarefas $1",
    "task_$_id_space": "Tarefa $1: espaço de ID",
    "item_$_time_stamp": "Item $1: data e hora",
    "blacklist_$": "Lista negra $1",
    "vip_level_award_$_item_id": "Prêmio VIP $1: ID do item",
    "vip_level_award_$_item_count": "Prêmio VIP $1: quantidade de itens",
    "vip_level_award_$_award_type": "Prêmio VIP $1: tipo",
    "level_award_$_item_id": "Prêmio de nível $1: ID do item",
    "level_award_$_item_count": "Prêmio de nível $1: quantidade de itens",
    "level_award_$_award_type": "Prêmio de nível $1: tipo",
    "lists_$": "Listas $1",
    "steps_$_playing_method_controller_$": "Etapa $1: controlador do método $2",
    "question_$_question_id": "Pergunta $1: ID",
    "prev_level_award_$_item_id": "Prêmio do nível anterior $1: ID do item",
}

def read_schema(config):
    lines = config.read_text(encoding="utf-8-sig", errors="replace").splitlines()
    names, fields = set(), set()
    heading_count = 0
    for index, line in enumerate(lines):
        match = re.match(r"^\d+\s+-\s+(.+?)\s*$", line)
        if match:
            heading_count += 1
            names.add(match.group(1))
            if index + 2 < len(lines):
                fields.update(lines[index + 2].split(";"))
    if config == reference and (heading_count != int(lines[0]) or len(names) != heading_count):
        raise ValueError("A quantidade de listas da configuração de referência não confere")
    return names, fields

reference_names, reference_fields = read_schema(reference)
names = set(reference_names)
# Preserve compatibility with configurations PW older and newer than the reference.
for config in configs.rglob("*.cfg"):
    if config != reference:
        names.update(read_schema(config)[0])

def translate(name):
    if name in phrases:
        return phrases[name]
    parts = name.split("_")
    is_npc_service = parts[0] == "NPC" and parts[-1] == "SERVICE"
    if is_npc_service:
        parts = parts[1:-1]
        prefix, suffix = "Serviço de ", " de NPC"
    elif parts[-2:] == ["MAJOR", "TYPE"]:
        parts = parts[:-2]
        prefix, suffix = "Categorias de ", ""
    elif parts[-2:] == ["SUB", "TYPE"]:
        parts = parts[:-2]
        prefix, suffix = "Subtipos de ", ""
    elif parts[-1] == "TYPE":
        parts = parts[:-1]
        prefix, suffix = "Tipos de ", ""
    elif parts[-1] == "CONFIG":
        parts = parts[:-1]
        prefix, suffix = "Configuração de ", ""
    elif parts[-1] == "ESSENCE":
        parts = parts[:-1]
        prefix, suffix = "Itens de ", ""
    elif parts[-1] == "SERVICE":
        parts = parts[:-1]
        prefix, suffix = "Serviço de ", ""
    else:
        prefix, suffix = "", ""
    body = " ".join(words.get(token, token) for token in parts)
    if body.startswith("NPC "):
        body = body.replace("NPC ", "", 1) + " de NPC"
    body = re.sub(r"\b(npc|gm|pvp|pve)\b", lambda match: {"npc": "NPC", "gm": "GM", "pvp": "PvP", "pve": "PvE"}[match.group()], body.lower())
    return prefix + body + suffix

strings = {"@" + name: translate(name) for name in sorted(names)}
strings.update(fields)
strings.update(field_patterns)
target.parent.mkdir(parents=True, exist_ok=True)
target.write_text(json.dumps({"strings": strings}, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
untranslated_fields = reference_fields - set(fields)
compiled_patterns = [re.compile("^" + re.escape(key).replace(r"\$", r"(\d+)") + "$") for key in field_patterns]
pattern_translated_fields = {field for field in untranslated_fields if any(pattern.fullmatch(field) for pattern in compiled_patterns)}
untranslated_fields -= pattern_translated_fields
patterns = Counter(re.sub(r"\d+", "$", field) for field in untranslated_fields)
coverage = {
    "reference": str(reference.relative_to(root)).replace("\\", "/"),
    "reference_lists": len(reference_names),
    "translated_reference_lists": sum("@" + name in strings for name in reference_names),
    "reference_distinct_fields": len(reference_fields),
    "explicitly_translated_reference_fields": len(reference_fields & set(fields)),
    "pattern_translated_reference_fields": len(pattern_translated_fields),
    "remaining_untranslated_reference_fields": len(untranslated_fields),
    "untranslated_field_patterns_top_30": [
        {"pattern": pattern, "count": count} for pattern, count in patterns.most_common(30)
    ],
    "catalog_lists_all_pw_configs": len(names),
}
coverage_file.write_text(json.dumps(coverage, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
print(f"Referência {reference.name}: {coverage['translated_reference_lists']}/{coverage['reference_lists']} listas, {coverage['explicitly_translated_reference_fields']} campos exatos e {coverage['pattern_translated_reference_fields']} campos por padrão")
print(f"Catálogo PW: {len(names)} listas, {len(fields)} campos exatos e {len(field_patterns)} padrões; relatório: {coverage_file}")
