@echo off
echo 🗑️ Removendo containers existentes...
docker-compose down -v --rmi all --remove-orphans

echo 🚀 Iniciando docker-compose...
docker-compose up -d

echo 🐳 Containers em execução:
docker ps

echo 🧹 Removendo migracao anterior...
dotnet ef migrations remove -f

echo 📝 Criando nova migracao: InitialCreate
dotnet ef migrations add InitialCreate

echo 💾 Atualizando banco de dados...
dotnet ef database update

echo ✅ Processo concluído com sucesso!
pause
