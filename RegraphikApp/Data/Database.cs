using Microsoft.Data.Sqlite;
using System.IO;

namespace RegraphikApp.Data;

public static class Database
{
    private static string dbPath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "regraphik.db");

    private static string connectionString =
        $"Data Source={dbPath}";

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(connectionString);
    }

    public static void InitializeDatabase()
    {
        if (!File.Exists(dbPath))
        {
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
                DataCadastro TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS TipoMaterial (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DescricaoMaterial TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS CadastroResiduos (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                IdUsuario INTEGER NOT NULL,
                IdTipoMaterial INTEGER NOT NULL,
                Origem TEXT NOT NULL,
                Especificacao TEXT,
                Projeto TEXT,
                Quantidade REAL NOT NULL,
                DataCadastro TEXT NOT NULL,
                Condicao TEXT NOT NULL,
                DimensoesCm REAL,
                DimensoesLm REAL,
                Observacao TEXT,
                Anexo TEXT,
                Status TEXT DEFAULT 'Em Estoque',
                FOREIGN KEY (IdUsuario) REFERENCES CadastroUsuarios(ID),
                FOREIGN KEY (IdTipoMaterial) REFERENCES TipoMaterial(Id)
            );

            CREATE TABLE IF NOT EXISTS Sugestoes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdTipoMaterial INTEGER NOT NULL,
                DescricaoSugestao TEXT NOT NULL,
                FOREIGN KEY (IdTipoMaterial) REFERENCES TipoMaterial(Id)
            );

            CREATE TABLE IF NOT EXISTS SugestoesResiduos (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                IdCadastroResiduo INTEGER NOT NULL,
                IdSugestao INTEGER NOT NULL,
                DataAplicacao TEXT,
                FOREIGN KEY (IdCadastroResiduo) REFERENCES CadastroResiduos(ID),
                FOREIGN KEY (IdSugestao) REFERENCES Sugestoes(Id)
            );

            ";

            cmd.ExecuteNonQuery();
        }
    }
}