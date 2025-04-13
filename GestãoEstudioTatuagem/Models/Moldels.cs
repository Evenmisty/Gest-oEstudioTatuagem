using System;
using System.Collections.Generic;
using SQLite;
using System.Text.Json;

namespace GestãoEstudioTatuagem.Models
{
    public class Clientes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public int FichaAnamneseId { get; set; }
        public int ProntuarioId { get; set; }
    }

    public class Tatuadores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
    }

    public class Sessao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TatuadorId { get; set; }
        public DateTime DataHora { get; set; }
        public string DescricaoTatuagem { get; set; }
        public string LocalCorpo { get; set; }
        public decimal Preco { get; set; }
        public string Status { get; set; } 

        public decimal? ValorPago { get; set; }
        public string FormaPagamento { get; set; }

        public int? ProntuarioId { get; set; }

        [Ignore] public Clientes Cliente { get; set; }
        [Ignore] public Tatuadores Tatuador { get; set; }
    }

    public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Ignore] public List<Sessao> Sessoes { get; set; } = new();
    }

    public class FichaAnamnese
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataCriacao { get; set; }

        public string PerguntasRespostasJson { get; set; }

        [Ignore]
        public Dictionary<string, string> PerguntasRespostas
        {
            get => JsonSerializer.Deserialize<Dictionary<string, string>>(PerguntasRespostasJson ?? "{}");
            set => PerguntasRespostasJson = JsonSerializer.Serialize(value);
        }

        [Ignore] public Clientes Cliente { get; set; }
    }

    public class ProntuarioEletronico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int SessaoId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string DetalhesProcedimento { get; set; }
        public string FotosJson { get; set; }
        public string Observacoes { get; set; }

        [Ignore]
        public List<string> Fotos
        {
            get => JsonSerializer.Deserialize<List<string>>(FotosJson ?? "[]");
            set => FotosJson = JsonSerializer.Serialize(value);
        }

        [Ignore] public Clientes Cliente { get; set; }
        [Ignore] public Sessao Sessao { get; set; }
    }

    public class Equipamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataAquisicao { get; set; }
        public string Status { get; set; } // Disponivel, EmUso, Manutencao, Inativo

        public string UltimaManutencaoDescricao { get; set; }
        public DateOnly UltimaManutencaoData { get; set; }
    }

    public class Horario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TatuadorId { get; set; }
        public string DiaSemana { get; set; } // Segunda, Terca, etc.
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }

        [Ignore] public Tatuadores Tatuador { get; set; }
    }

    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Login { get; set; }
        public string SenhaHash { get; set; }
        public string PermissoesJson { get; set; }

        [Ignore]
        public List<string> Permissoes
        {
            get => JsonSerializer.Deserialize<List<string>>(PermissoesJson ?? "[]");
            set => PermissoesJson = JsonSerializer.Serialize(value);
        }
    }

    public class ControleAcesso
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Ignore]
        public List<Usuario> Usuarios { get; set; } = new();
    }
}
