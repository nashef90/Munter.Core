cd /d %~dp0
cls
echo %~dp0
rmdir /q /s Data\Migrations
dotnet-ef migrations add MyDbMigration -o Data\Migrations --context MyDbContext
dotnet-ef database update