using Microsoft.Data.Sqlite;
using RegraphikApp.Models;

namespace RegraphikApp.Data;

public class ResiduoRepository
{
    public void Inserir(Residuo residuo)
    {
        using var conn = Database.GetConnection();
        conn.Open();

        var cmd = new SqliteCommand(@"
            INSERT INTO CadastroResiduos
            (IdUsuario, IdTipoMaterial, Origem, Especificacao,
             Projeto, Quantidade, DataCadastro, Condicao, Status)
            VALUES (@u, @t, @o, @e, @p, @q, @d, @c, @s)", conn);

        cmd.Parameters.AddWithValue("@u", residuo.IdUsuario);
        cmd.Parameters.AddWithValue("@t", residuo.IdTipoMaterial);
        cmd.Parameters.AddWithValue("@o", residuo.Origem);
        cmd.Parameters.AddWithValue("@e", residuo.Especificacao ?? "");
        cmd.Parameters.AddWithValue("@p", residuo.Projeto ?? "");
        cmd.Parameters.AddWithValue("@q", residuo.Quantidade);
        cmd.Parameters.AddWithValue("@d", residuo.DataCadastro.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@c", residuo.Condicao);
        cmd.Parameters.AddWithValue("@s", "Em Estoque");

        cmd.ExecuteNonQuery();
    }

    public List<Residuo> Listar()
    {
        var lista = new List<Residuo>();

        using var conn = Database.GetConnection();
        conn.Open();

        var cmd = new SqliteCommand("SELECT * FROM CadastroResiduos", conn);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            lista.Add(new Residuo
            {
                ID = reader.GetInt32(0),
                IdUsuario = reader.GetInt32(1),
                IdTipoMaterial = reader.GetInt32(2),
                Origem = reader.GetString(3),
                Quantidade = reader.GetDouble(6),
                Status = reader.GetString(12)
            });
        }

        return lista;
    }
}