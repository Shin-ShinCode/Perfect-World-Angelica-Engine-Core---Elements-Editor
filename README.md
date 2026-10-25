<div align="center">

# ✨ Angelica Core Editor

**Editor desktop para arquivos de dados do Perfect World e da Angelica Engine**

Edite `elements.data`, `tasks.data` e outros recursos do cliente em uma interface WinForms para Windows.

![Windows x64](https://img.shields.io/badge/Windows-x64-0078D4?logo=windows&logoColor=white)
![.NET Framework 4.8](https://img.shields.io/badge/Editor-.NET%20Framework%204.8-512BD4?logo=dotnet&logoColor=white)
![.NET 10](https://img.shields.io/badge/Build%20e%20MCP-.NET%2010-512BD4?logo=dotnet&logoColor=white)
![Idiomas funcionais](https://img.shields.io/badge/Idiomas-Portugu%C3%AAs%20%7C%20English-2E8B57)

</div>

> ⚠️ **Projeto reconstruído:** parte do código do Editor foi recuperada de um executável e reconstruída por decompilação. Uma compilação bem-sucedida não garante que toda versão de CFG ou arquivo do jogo seja compatível. Trabalhe sempre em cópias e valide os arquivos antes de usá-los em um servidor.

## 📚 Conteúdo

- [Visão geral](#-visão-geral)
- [Editores e recursos](#-editores-e-recursos)
- [Melhorias e correções](#-melhorias-e-correções)
- [Requisitos](#-requisitos)
- [Compilar e executar](#-compilar-e-executar)
- [Servidor MCP opcional](#-servidor-mcp-opcional)
- [Verificações e limitações](#-verificações-e-limitações)
- [Estrutura do repositório](#-estrutura-do-repositório)
- [Créditos e licença](#-créditos-e-licença)

## 🔎 Visão geral

O **Angelica Core Editor** reúne ferramentas para visualizar e editar arquivos usados por clientes de jogos baseados na Angelica Engine, incluindo Perfect World. Os arquivos são interpretados conforme as configurações de versão (`CFG`) escolhidas no Editor.

O projeto inclui o executável compilado em `dist/`, o código-fonte reconstruído e os recursos necessários para execução. O **servidor MCP é opcional**: o Editor pode ser usado sem ele.

## 🧰 Editores e recursos

- **Elements** — navegação por listas e campos de itens, NPCs, monstros, habilidades e outros registros; exibição de referências e acesso ao registro relacionado.
- **Tasks** — edição de tarefas e missões, visualização de relações, importação/exportação JSON e identificação visual por tipo.
- **Outros formatos** — ferramentas para IA, geração de NPCs, lojas, arquivos PCK, mapas, modelos e recursos auxiliares, conforme os módulos disponíveis.
- **Configuração por versão** — arquivos CFG e catálogos de idioma ficam em `Editor/runtime/`.
- **Idiomas funcionais:** português e inglês nos editores principal e Tasks. Os demais idiomas estão em desenvolvimento e podem apresentar traduções incompletas.

## 🛠️ Melhorias e correções

As alterações abaixo focam problemas observados no uso do Editor e na manutenção dos arquivos. Elas melhoram a interface e os fluxos de trabalho, mas não substituem a validação com cada versão real do cliente.

| Problema observado | Correção aplicada |
|---|---|
| Referências apareciam apenas como números, dificultando saber a que registro pertenciam. | As referências compatíveis passam a exibir o nome do registro e permitem navegar até ele por duplo clique ou Ctrl+clique nos campos compatíveis. |
| Campos de Tasks mostravam IDs sem contexto e era difícil acompanhar as relações entre missões. | A apresentação das referências foi melhorada e os indicadores visuais da lista de tarefas ajudam a reconhecer os tipos de missão. |
| Avisos de IDs duplicados eram pouco claros durante a abertura de `tasks.data`. | O aviso identifica os grupos duplicados e oferece orientação para que a pessoa decida entre consultar como corrigir ou continuar sem alterar os dados. |
| Algumas dicas e descrições ocupavam espaço, apareciam associadas ao controle errado ou atrapalhavam a leitura. | As dicas foram encurtadas e associadas às opções correspondentes; o layout foi ajustado para manter os controles visíveis. |
| A identificação das versões dos arquivos abertos não ficava clara no editor Tasks. | A janela passou a apresentar as versões de `tasks.data` e `elements.data` quando essas informações estão disponíveis. |
| A gravação interrompida poderia deixar um arquivo parcialmente escrito. | Os fluxos de gravação principais usam arquivo temporário seguido da substituição do destino, reduzindo o risco de saída incompleta em falhas durante a gravação. |
| Exportar `elements.data` podia apagar o destino antes de terminar; extrair uma pasta PCK removia a pasta escolhida, aceitava caminhos internos fora dela e podia reportar sucesso com arquivos faltando. | A exportação agora grava em arquivo temporário e só substitui o destino depois de validar a saída. A extração PCK preserva arquivos existentes, rejeita caminhos fora da pasta e informa falhas por arquivo. |
| Opções coloridas e textos tinham contraste inconsistente entre temas. | Foram feitos ajustes de cores e apresentação para melhorar a leitura nos temas claro e escuro sem remover os rótulos das opções. |

## 💻 Requisitos

- **Sistema:** Windows 10 ou 11, 64 bits.
- **Para executar o Editor:** .NET Framework 4.8.
- **Para compilar a solução completa:** .NET SDK 10 ou compatível.
- **Para compilar apenas o Editor:** use o SDK instalado e os pacotes de referência restaurados pelo NuGet.

## 🚀 Compilar e executar

Abra o PowerShell na raiz do repositório.

### Compilar o Editor

```powershell
dotnet build Editor/AngelicaEditor.csproj -c Release
```

Executável: `dist/Editor/Universal data Editor.exe`.

### Compilar todos os projetos, incluindo o MCP

```powershell
dotnet build AngelicaCore.sln -c Release
```

Ou execute `build.cmd` para compilar a solução pelo Windows. O script `BUILD_TOOL.cmd` também executa verificações e prepara um pacote local.

### Executar

```powershell
& ".\dist\Editor\Universal data Editor.exe"
```

Na primeira execução, configure os caminhos dos arquivos do seu cliente e selecione a CFG compatível com a versão dos dados. O perfil fornecido não deve ser tratado como configuração do seu servidor.

📖 Mais detalhes: [guia de compilação e execução](BUILD-AND-RUN.md), [dependências](DEPENDENCIAS.md) e [build do Editor](Editor/BUILD.md).

## 🔌 Servidor MCP opcional

`McpServer/` contém o adaptador MCP para clientes compatíveis. Ele encaminha solicitações para uma instância local do Editor em execução; não substitui o Editor nem interpreta os arquivos do jogo por conta própria.

Para usar a integração, compile a solução completa, abra o Editor e configure o cliente MCP conforme o [guia do servidor](McpServer/README.md). O projeto MCP não é necessário para editar arquivos pela interface gráfica.

## ✅ Verificações e limitações

- O Editor foi compilado em Release após as alterações documentadas neste repositório.
- `verification/` contém verificações e ferramentas auxiliares; consulte suas instruções antes de executá-las.
- A validação de compilação não equivale a testar todas as funções com todas as versões de `elements.data`, `tasks.data` ou CFG.
- Algumas descrições e traduções dependem do idioma, da versão e dos dados fornecidos pelo cliente. Revise campos desconhecidos antes de salvá-los.
- Faça backup dos arquivos originais. Teste primeiro em cópias e reabra os arquivos salvos para conferir o resultado.
- Não edite arquivos enquanto o cliente ou servidor estiver usando os mesmos dados.

## 🗂️ Estrutura do repositório

| Pasta/arquivo | Finalidade |
|---|---|
| `Editor/src_deobf/` | Código C# reconstruído do Editor. |
| `Editor/runtime/` | CFGs, idiomas e recursos de execução. |
| `McpServer/` | Código do servidor MCP opcional. |
| `verification/` | Ferramentas e verificações do projeto. |
| `dist/` | Executáveis e recursos compilados do Editor e do MCP. |

Mais informações: [estrutura](ESTRUTURA.md) e [preparação para GitHub](GIT.md).

## 🙏 Créditos e licença

O crédito original identificado nos recursos do aplicativo é **Angelica Core (C) 2026**, também apresentado como **Universal data Editor**. A documentação disponível não identifica nominalmente os autores originais; por isso, nenhum nome foi presumido ou removido.

A reconstrução do código utilizou ferramentas de decompilação documentadas em [`Editor/RAW/DEOBF_NOTES.md`](Editor/RAW/DEOBF_NOTES.md), incluindo **ILSpy** e **de4dot-cex**. Créditos e licenças de dependências de terceiros devem ser consultados nos projetos e pacotes correspondentes.

**Este repositório ainda não possui uma licença de redistribuição definida.** Código reconstruído, CFGs, ícones e demais recursos podem estar sujeitos a direitos de terceiros. Confirme a autorização dos respectivos titulares antes de publicar o repositório publicamente ou redistribuir os binários. A ausência de uma licença não concede permissão de uso.

