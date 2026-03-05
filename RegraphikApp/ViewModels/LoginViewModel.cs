using System;
using System.Windows;
using RegraphikApp.Commands;
using RegraphikApp.Data;
using RegraphikApp.Models;

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
        var repo = new UsuarioRepository();
        var usuario = repo.Autenticar(Login, Senha);

        if (usuario != null)
        {
            MessageBox.Show($"Bem-vindo, {usuario.Nome}!");
        }
        else
        {
            MessageBox.Show("Usuário ou senha inválidos.");
        }
    }
}