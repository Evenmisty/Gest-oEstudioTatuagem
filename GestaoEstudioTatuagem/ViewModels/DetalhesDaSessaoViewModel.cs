using CommunityToolkit.Mvvm.ComponentModel;
using GestaoEstudioTatuagem.Models;
using System;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class DetalhesDaSessaoViewModel : ObservableObject
    {
        [ObservableProperty]
        private Sessao sessaoAtual;

        public DetalhesDaSessaoViewModel()
        {
            SessaoAtual = new Sessao
            {
                DataSessao = DateTime.Now,
                DescricaoTatuagem = "Tatuagem de dragão no braço",
                Tatuador = new Tatuadores
                {
                    Id = 1,
                    Nome = "Carlos Silva",
                    Especialidade = "Realismo"
                },
                Cliente = new Clientes
                {
                    Id = 1,
                    Nome = "Ana Paula",
                    CPF = "123.456.789-00",
                    Email = "ana@example.com",
                    Telefone = "(11) 99999-9999",
                    Endereco = "Rua Exemplo, 123"
                }
            };
        }
    }
}
