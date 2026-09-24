@echo off
rem push_to_github.cmd - публикация исправленных файлов (Index.cs, Scripts.cs)
rem в репозиторий GitHub. Запускать из командной строки Windows (cmd.exe).
rem
rem Использование:
rem   push_to_github.cmd https://github.com/<владелец>/<репозиторий>.git [имя_ветки]
rem
rem Пример:
rem   push_to_github.cmd https://github.com/serfel/LocmanAdd.git main
rem
rem Аутентификация - через токен GitHub (Personal Access Token):
rem   set GITHUB_TOKEN=ghp_xxxxxxxxxxxxxxxxxxxx
setlocal enabledelayedexpansion

set "REPO_URL=%~1"
set "BRANCH=%~2"
if "%BRANCH%"=="" set "BRANCH=main"

if "%REPO_URL%"=="" (
    echo Ошибка: укажите URL репозитория GitHub. 1>&2
    echo Использование: %~nx0 https://github.com/^<владелец^>/^<репозиторий^>.git [ветка] 1>&2
    exit /b 1
)

cd /d "%~dp0"

rem --- 1. Фиксация изменений (если есть незакоммиченные) --------------------
git diff --quiet -- LocmanWebServer/Index.cs LocmanWebServer/Scripts.cs
if errorlevel 1 (
    git add LocmanWebServer/Index.cs LocmanWebServer/Scripts.cs
    git commit -m "Align action row above document row; consistent label widths"
) else (
    echo Незакоммиченных изменений нет - коммит уже создан.
    git log --oneline -1
)

rem --- 2. Подстановка токена в URL (без хранения в истории) -----------------
set "PUSH_URL=%REPO_URL%"
if not "%GITHUB_TOKEN%"=="" (
    set "PUSH_URL=!REPO_URL:https://=https://x-access-token:%GITHUB_TOKEN%@!"
) else (
    echo Внимание: GITHUB_TOKEN не задан - git запросит логин/пароль или использует SSH-ключ.
)

rem --- 3. Добавление удалённого репозитория (origin), если его нет ----------
git remote get-url origin >nul 2>&1
if errorlevel 1 (
    git remote add origin "%PUSH_URL%"
) else (
    git remote set-url origin "%PUSH_URL%"
)

rem --- 4. Слияние в целевую ветку и отправка ---------------------------------
for /f "delims=" %%I in ('git branch --show-current') do set "CURRENT=%%I"
if not "!CURRENT!"=="%BRANCH%" (
    git checkout "%BRANCH%" 2>nul || git checkout -b "%BRANCH%"
    git merge --ff-only "!CURRENT!" || git merge "!CURRENT!" -m "Merge !CURRENT! into %BRANCH%"
)

git push -u origin "%BRANCH%"
if errorlevel 1 (
    echo Ошибка: git push не выполнен. 1>&2
    goto :cleanup_fail
)

rem --- 5. Убираем токен из конфигурации (безопасность) -----------------------
:cleanup_fail
if not "%GITHUB_TOKEN%"=="" git remote set-url origin "%REPO_URL%"

endlocal
