# Estrutura do projeto

## Conteúdo mantido

| Caminho | Conteúdo | Uso |
|---|---|---|
| `Editor/src_deobf/` | Fonte C# do Editor. | Compilação do executável. |
| `Editor/runtime/` | CFGs, catálogos de idioma e recursos. | Execução dos editores. |
| `Editor/RAW/DEOBF_NOTES.md`, `typelist.txt` | Proveniência e inventário de tipos. | Referência técnica. |
| `McpServer/` | Adaptador MCP opcional. | Só para integração MCP; não é requisito do Editor. |
| `verification/` | Relatórios e ferramentas de validação. | Manutenção do projeto. |
| `dist/` | Distribuição compilada do Editor e do servidor MCP opcional. | Versionada; sem históricos, logs, símbolos ou cópias de verificação. |

## Removido nesta limpeza

- `Editor/src/` e `Editor/RAW/decompile-extras/`: árvores históricas duplicadas; não são compiladas.
- `scripts/windows-maintenance/`: utilitários genéricos sem relação com o Editor.
- `Updater/`: documentação de atualizador comercial de terceiros, sem fonte do produto.
- `docs/history/`, patches antigos, relatórios de build com caminhos pessoais e snapshots `verification/build-*`.
- Caches locais `.dotnet-cli/`, `verification/obj/` e `verification/__pycache__/`.

Os backups em `verification/originals/` permanecem locais, fora do Git, até que as alterações correspondentes estejam validadas. `dist/` contém a distribuição atual; históricos, logs, símbolos e saídas de verificação foram retirados do pacote.

As duas árvores `Editor/runtime/Configs/configs/` e `Editor/runtime/Configs/PW/configs/` permanecem: apesar dos nomes coincidentes, há diferenças entre elas e o aplicativo pode consultar ambos os caminhos.

## Compilação

- Editor: `dotnet build Editor/AngelicaEditor.csproj -c Release`
- Solução completa, incluindo o servidor opcional: `dotnet build AngelicaCore.sln -c Release`

Ambos produzem saídas sob `dist/`. Consulte [BUILD-AND-RUN.md](BUILD-AND-RUN.md).

