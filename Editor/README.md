# Módulo Editor

Aplicação WinForms x64 para abrir e editar arquivos de dados da Angelica Engine. A implementação compilada está em `src_deobf/`; a interface utiliza configurações e recursos de `runtime/`.

## Módulos

- `elements.data` e referências entre registros.
- `tasks.data` e arquivos compactados de exportação JSON.
- Políticas de IA, NPCGen, GShop, PCK, mapas e ferramentas auxiliares.

A compatibilidade depende da versão do arquivo e da CFG selecionada. Nem todas as combinações foram verificadas com dados reais. Trabalhe em cópias e mantenha backups.

## Compilação

Na raiz do repositório:

```powershell
dotnet build Editor/AngelicaEditor.csproj -c Release
```

O executável é gerado em `dist/Editor/`. Os arquivos de runtime necessários são copiados pelo projeto durante o build.

## Organização

- `src_deobf/`: fonte compilada do Editor.
- `runtime/`: CFGs, catálogos de idioma e recursos de execução.
- `RAW/DEOBF_NOTES.md` e `RAW/typelist.txt`: notas de proveniência e inventário de tipos.

Cópias antigas da recuperação e arquivos temporários foram removidos por não serem necessários ao build. O código foi reconstruído a partir de um executável; valide especialmente mudanças de serialização binária com dados de teste.
