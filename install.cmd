D:
cd "D:\_Работа\Лоцман добавка v2"
echo "# LocmanAdd" >> README.md
git init
git add .
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/serfel/LocmanAdd.git
git push -u origin main