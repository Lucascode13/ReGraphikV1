using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace RegraphikApp.Data;

public static class Database
{
    private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "regraphik.db");
    
    private static string connectionString = $"Data Source={dbPath}";

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(connectionString);
    }

    public static void InitializeDatabase()
    {
        // Agora ele vai conectar e rodar a checagem toda vez. 
        // O "IF NOT EXISTS" no código SQL abaixo já garante que ele não vai duplicar a tabela se ela já existir!
        using var conn = GetConnection();
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS CadastroUsuarios (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                CPF TEXT NOT NULL,
                Email TEXT NOT NULL,
                Login TEXT NOT NULL UNIQUE,
                Senha TEXT NOT NULL,
                DataCadastro DATETIME DEFAULT CURRENT_TIMESTAMP -- Isso preenche a data sozinho!
            );";
        
        cmd.ExecuteNonQuery();
    }
}