using Microsoft.Data.Sqlite;
using RegraphikApp.Models;

namespace RegraphikApp.Data;

public class UsuarioRepository
{
    public Usuario? Autenticar(string login, string senha)
    {
        using var conn = Database.GetConnection();
        conn.Open();

        var cmd = new SqliteCommand(
            "SELECT * FROM CadastroUsuarios WHERE Login=@l AND Senha=@s",
            conn);

        cmd.Parameters.AddWithValue("@l", login);
        cmd.Parameters.AddWithValue("@s", senha);

        var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Usuario
            {
                ID = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Login = reader.GetString(4)
            };
        }

        return null;
    }

    // 🔵 NOVO MÉTODO
    public void Inserir(Usuario usuario)
    {
        using var conn = Database.GetConnection();
        conn.Open();

        var cmd = conn.CreateCommand();

        cmd.CommandText = @"
            INSERT INTO CadastroUsuarios
            (Nome, CPF, Email, Login, Senha, DataCadastro)
            VALUES
            (@Nome, @CPF, @Email, @Login, @Senha, @DataCadastro);
        ";

        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
        cmd.Parameters.AddWithValue("@CPF", usuario.CPF);
        cmd.Parameters.AddWithValue("@Email", usuario.Email);
        cmd.Parameters.AddWithValue("@Login", usuario.Login);
        cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
        cmd.Parameters.AddWithValue("@DataCadastro", 
            usuario.DataCadastro.ToString("yyyy-MM-dd HH:mm:ss"));

        cmd.ExecuteNonQuery();
    }

    // 🔵 NOVO MÉTODO
    public bool ExisteLogin(string login)
    {
        using var conn = Database.GetConnection();
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText =
            "SELECT COUNT(*) FROM CadastroUsuarios WHERE Login = @Login;";
        cmd.Parameters.AddWithValue("@Login", login);

        var count = Convert.ToInt32(cmd.ExecuteScalar());

        return count > 0;
    }
}