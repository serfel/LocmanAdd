#!/usr/bin/env bash
# push_to_github.sh — публикация исправленных файлов (Index.cs, Scripts.cs)
# в репозиторий GitHub.
#
# Использование:
#   ./push_to_github.sh https://github/<владелец>/<репозиторий>.git [имя_ветки]
#
# Пример:
#   ./push_to_github.sh https://github.com/me/locman.git main
#
# Аутентификация — через токен GitHub (Personal Access Token):
#   export GITHUB_TOKEN=ghp_xxxxxxxxxxxxxxxxxxxx
set -euo pipefail

REPO_URL="${1:-}"
BRANCH="${2:-main}"

if [ -z "$REPO_URL" ]; then
    echo "Ошибка: укажите URL репозитория GitHub." >&2
    echo "Использование: $0 https://github/<владелец>/<репозиторий>.git [ветка]" >&2
    exit 1
fi

cd "$(dirname "$0")"

# --- 1. Фиксация изменений (если есть незакоммиченные) ---------------------
if ! git diff --quiet || ! git diff --cached --quiet; then
    git add LocmanWebServer/Index.cs LocmanWebServer/Scripts.cs
    git commit -m "Align action row above document row; consistent label widths"
else
    echo "Незакоммиченных изменений нет — коммит уже создан (HEAD: $(git log --oneline -1))."
fi

# --- 2. Подстановка токена в URL (без хранения в истории) -------------------
if [ -n "${GITHUB_TOKEN:-}" ]; then
    PUSH_URL=$(echo "$REPO_URL" | sed -E "s#https://#https://x-access-token:${GITHUB_TOKEN}@#")
else
    PUSH_URL="$REPO_URL"
    echo "Внимание: GITHUB_TOKEN не задан — git запросит логин/пароль или SSH-ключ."
fi

# --- 3. Добавление удалённого репозитория (origin), если его нет ------------
if git remote get-url origin >/dev/null 2>&1; then
    git remote set-url origin "$PUSH_URL"
else
    git remote add origin "$PUSH_URL"
fi

# --- 4. Слияние в целевую ветку и отправка ----------------------------------
CURRENT=$(git branch --show-current)
if [ "$CURRENT" != "$BRANCH" ]; then
    git checkout "$BRANCH" 2>/dev/null || git checkout -b "$BRANCH"
    git merge --ff-only "$CURRENT" || git merge "$CURRENT" -m "Merge $CURRENT into $BRANCH"
fi

git push -u origin "$BRANCH"

# --- 5. Убираем токен из конфигурации (безопасность) ------------------------
if [ -n "${GITHUB_TOKEN:-}" ]; then
    CLEAN_URL=$(echo "$REPO_URL" | sed -E "s#https://#https://#")
    git remote set-url origin "$CLEAN_URL"
fi

echo "Готово: изменения опубликованы в $REPO_URL (ветка $BRANCH)."
