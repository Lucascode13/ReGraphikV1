namespace RegraphikApp.Models;

public class SugestaoResiduo
{
    public int ID { get; set; }
    public int IdCadastroResiduo { get; set; }
    public int IdSugestao { get; set; }
    public DateTime? DataAplicacao { get; set; }
}