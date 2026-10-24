# Dependências e atualização

## Situação em 22/10/2026

Os projetos compilam com as versões fixadas em `Editor/AngelicaEditor.csproj` e `McpServer/ACE.McpServer.csproj`. Elas foram mantidas nesta organização para preservar o comportamento do Editor e o contrato das ferramentas MCP.

| Componente | Versão do projeto | Situação |
|---|---:|---|
| Editor | .NET Framework 4.8 | Alvo do executável original recuperado. Migrar a interface para outro runtime é um projeto separado. |
| MCPServer | .NET 10 | Alvo atual do servidor. |
| [ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol/) e [AspNetCore](https://www.nuget.org/packages/ModelContextProtocol.AspNetCore/) | 1.3.0 | A linha 2.x publicada envolve uma mudança maior de API; requer revisão das ferramentas e validação com o Editor em execução. |
| [YamlDotNet](https://www.nuget.org/packages/YamlDotNet/) | 13.7.1 | Há versões mais recentes compatíveis com .NET Framework, mas alterações de serialização precisam de validação com arquivos reais. |

Uma compilação limpa comprova compatibilidade de código, mas não garante que importação, exportação, leitura de dados e as 87 ferramentas MCP tenham o mesmo comportamento após uma troca de dependências. Por isso, atualizações de pacotes devem ocorrer em alterações isoladas, com comparação do resultado antes da adoção.

O MCPServer continua opcional e local. Nenhuma atualização online automática foi adicionada.
