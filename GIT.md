# Preparação do GitHub

## Conteúdo do repositório

O pacote mantém a fonte compilada (`Editor/src_deobf/`), projetos, recursos/configurações de runtime, documentação atual e ferramentas de verificação.

Foram removidos materiais duplicados de decompilação, scripts de limpeza do Windows, documentação de atualizador de terceiros, patches históricos e builds de diagnóstico. `dist/` é versionada para oferecer os executáveis e recursos compilados junto ao código. Dados locais, logs, símbolos de depuração e saídas de verificação são ignorados.

## Antes de publicar

1. Confirme os direitos sobre o código recuperado, CFGs, imagens, ícones e demais recursos. Ainda não há licença definida.
2. Revise `git status --short` e `git diff --cached --stat`.
3. Verifique caminhos pessoais, credenciais, dados de cliente e backups.
4. Compile o Editor e confira a saída local em `dist/`.
5. Não torne o repositório público nem publique binários até confirmar a autorização de redistribuição e escolher a licença apropriada.

O repositório local ainda não tem commits nem remoto configurado. Este trabalho não cria commits nem envia arquivos ao GitHub.

## Exclusões

O `.gitignore` cobre saídas intermediárias de build, dados temporários, backups, caches e arquivos locais; a distribuição limpa em `dist/` é versionada. Cópias históricas e artefatos descartáveis removidos nesta limpeza não são necessários para compilar o Editor.

