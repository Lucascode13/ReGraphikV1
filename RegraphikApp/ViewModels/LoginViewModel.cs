using System;
using System.Windows;
using RegraphikApp.Commands;
using RegraphikApp.Data; 

namespace RegraphikApp.ViewModels;

public class LoginViewModel : BaseViewModel
{
    public RelayCommand EntrarCommand { get; set; }

    private string login;
    public string Login
    {
        get => login;
        set
        {
            login = value;
            OnPropertyChanged();
        }
    }

    private string senha;
    public string Senha
    {
        get => senha;
        set
        {
            senha = value;
            OnPropertyChanged();
        }
    }

    // 🔵 CONSTRUTOR OBRIGATÓRIO
    public LoginViewModel()
    {
        EntrarCommand = new RelayCommand(Entrar);
    }

    private void Entrar()
    {
        // 1. Evita que o programa trave se o usuário clicar em Entrar sem digitar nada
        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Senha))
        {
            MessageBox.Show("Por favor, preencha o login e a senha.");
            return;
        }

        // 2. Chama o banco de dados
        var repo = new UsuarioRepository();
        
        // 3. Verifica se o login é válido usando o método que criamos (retorna true ou false)
        bool loginValido = repo.AutenticarUsuario(Login, Senha);

        if (loginValido)
        {
            MessageBox.Show("Login realizado com sucesso! Bem-vindo.");
            // O código para fechar a tela de login e abrir a tela principal vai entrar aqui depois
        }
        else
        {
            MessageBox.Show("Usuário ou senha inválidos.");
        }
    }
}