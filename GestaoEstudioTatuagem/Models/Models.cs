using System;
using System.Collections.Generic;
using SQLite;
using System.Text.Json;

namespace GestaoEstudioTatuagem.Models
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

        [Ignore]
        public List<Sessao> Sessoes { get; set; } = new();

        [Ignore]
        public List<FichaAnamnese> FichasAnamnese { get; set; } = new();

        [Ignore]
        public ProntuarioEletronico Prontuario { get; set; }
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

        public string DescricaoTatuagem { get; set; }
        public DateTime DataSessao { get; set; }

        [Ignore]
        public Tatuadores Tatuador { get; set; }

        [Ignore]
        public Clientes Cliente { get; set; }
    }

    public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Ignore]
        public List<Sessao> Sessoes { get; set; } = new();
    }

    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public string ClienteNome { get; set; }
        public int ClienteId { get; set; }
        public string TatuadorNome { get; set; }
        public int TatuadorId { get; set; }
    }

    public class FichaAnamnese
    {
        public bool Preenchida { get; set; }
        public string Observacoes { get; set; }
    }

    public class ProntuarioEletronico
    {
        public string DetalhesProcedimento { get; set; }
        public DateTime DataRegistro { get; set; }
    }

    public class Equipamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataAquisicao { get; set; }
        public string Status { get; set; }

        public string UltimaManutencaoDescricao { get; set; }
        public DateOnly UltimaManutencaoData { get; set; }
    }

    public class Horario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TatuadorId { get; set; }
        public string DiaSemana { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }

        [Ignore]
        public Tatuadores Tatuador { get; set; }
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