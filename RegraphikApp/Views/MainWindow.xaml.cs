using System.Windows;
using RegraphikApp.Data; // 1. Adicionamos essa linha para ele enxergar a pasta Data

namespace RegraphikApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // 2. Mágica aqui: Cria o banco de dados e a tabela assim que o app abrir!
        Database.InitializeDatabase();
    }
}