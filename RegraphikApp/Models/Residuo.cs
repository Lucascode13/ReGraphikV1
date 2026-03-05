namespace RegraphikApp.Models;

public class Residuo
{
    public int ID { get; set; }
    public int IdUsuario { get; set; }
    public int IdTipoMaterial { get; set; }
    public string Origem { get; set; }
    public string Especificacao { get; set; }
    public string Projeto { get; set; }
    public double Quantidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public string Condicao { get; set; }
    public double? DimensoesCm { get; set; }
    public double? DimensoesLm { get; set; }
    public string Observacao { get; set; }
    public string Anexo { get; set; }
    public string Status { get; set; }
}