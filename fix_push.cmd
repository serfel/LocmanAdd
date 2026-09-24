@echo off
chcp 65001 >nul
setlocal

rem ============================================================
rem  fix_push.cmd - исправление ошибки "rejected (fetch first)"
rem  и отправка локального коммита в GitHub.
rem
rem  Использование:
rem     fix_push.cmd
rem  или с явным указанием репозитория/ветки:
rem     fix_push.cmd https://github.com/serfel/LocmanAdd2.git main
rem ============================================================

cd /d "%~dp0"

set "REPO_URL=%~1"
set "BRANCH=%~2"
if "%BRANCH%"=="" set "BRANCH=main"

rem --- если URL не передан, берём его из текущего origin ---
if "%REPO_URL%"=="" (
    for /f "delims=" %%U in ('git remote get-url origin') do set "REPO_URL=%%U"
)
echo Репозиторий: %REPO_URL%
echo Ветка:       %BRANCH%
echo.

rem --- 1. Исправляем URL origin (у вас add указывал на LocmanAdd,
rem        а push шёл в LocmanAdd2 - из-за путаницы) ---
git remote set-url origin %REPO_URL%
if errorlevel 1 git remote add origin %REPO_URL%

rem --- 2. Если есть незакоммиченные изменения - коммитим их ---
git status --porcelain | findstr /r "." >nul
if not errorlevel 1 (
    echo Есть незакоммиченные изменения, коммичу...
    git add .
    git commit -m "update: Index.cs / Scripts.cs"
)

rem --- 3. Подтягиваем удалённую ветку и сливаем (без этого push отклоняется) ---
echo Забираем изменения из GitHub...
git pull origin %BRANCH% --no-rebase --allow-unrelated-histories -m "merge remote %BRANCH%"
if errorlevel 1 (
    echo.
    echo !!! Конфликт слияния. Разрешите конфликты вручную, затем:
    echo       git add .
    echo       git commit -m "merge"
    echo       git push -u origin %BRANCH%
    pause
    exit /b 1
)

rem --- 4. Отправляем на GitHub ---
echo Пушим в GitHub...
git push -u origin %BRANCH%
if errorlevel 1 (
    echo.
    echo !!! Push не удался. Если требует авторизацию - используйте токен:
    echo       git remote set-url origin https://%GITHUB_TOKEN%@github.com/serfel/LocmanAdd2.git
    pause
    exit /b 1
)

echo.
echo Готово! Изменения отправлены в %REPO_URL% (ветка %BRANCH%).
pause
endlocal
