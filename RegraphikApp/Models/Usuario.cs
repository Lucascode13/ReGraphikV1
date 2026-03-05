namespace RegraphikApp.Models;

public class Usuario
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public DateTime DataCadastro { get; set; }
}