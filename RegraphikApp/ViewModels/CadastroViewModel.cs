using System;
using System.Windows;
using RegraphikApp.Commands;
using RegraphikApp.Data;

namespace RegraphikApp.ViewModels;

public class CadastroViewModel : BaseViewModel
{
    public RelayCommand CadastrarCommand { get; set; }

    // --- PROPRIEDADES DOS CAMPOS ---
    private string nome;
    public string Nome { get => nome; set { nome = value; OnPropertyChanged(); } }

    private string cpf;
    public string CPF { get => cpf; set { cpf = value; OnPropertyChanged(); } }

    private string email;
    public string Email { get => email; set { email = value; OnPropertyChanged(); } }

    private string login;
    public string Login { get => login; set { login = value; OnPropertyChanged(); } }

    private string senha;
    public string Senha { get => senha; set { senha = value; OnPropertyChanged(); } }

    // --- CONSTRUTOR ---
    public CadastroViewModel()
    {
        CadastrarCommand = new RelayCommand(Cadastrar);
    }

    // --- MÉTODO DO BOTÃO CADASTRAR ---
    private void Cadastrar()
    {
        // 1. Validação básica para não deixar campos vazios
        if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Senha))
        {
            MessageBox.Show("Por favor, preencha pelo menos Nome, Login e Senha.");
            return;
        }

        // 2. Chama o banco de dados
        var repo = new UsuarioRepository();
        bool sucesso = repo.CadastrarUsuario(Nome, CPF, Email, Login, Senha);

        // 3. Verifica se deu certo
        if (sucesso)
        {
            MessageBox.Show("Usuário cadastrado com sucesso! Agora você pode fazer login.");
            
            // Limpa os campos da tela depois de salvar
            Nome = string.Empty;
            CPF = string.Empty;
            Email = string.Empty;
            Login = string.Empty;
            Senha = string.Empty;
        }
        else
        {
            MessageBox.Show("Erro ao cadastrar. Talvez esse login já exista no sistema.");
        }
    }
}