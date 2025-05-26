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
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;

        // Relacionamento com o Prontuário
        [Ignore]
        public List<ProntuarioEletronico> Prontuarios { get; set; } = new List<ProntuarioEletronico>();
    }

    public class ProntuarioEletronico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public int ClienteId { get; set; } // Relacionamento com Cliente
        public string DetalhesProcedimento { get; set; } = string.Empty;
    }

    public class Tatuadores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
    }

    public class Sessao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string DescricaoTatuagem { get; set; } = string.Empty;
        public DateTime DataSessao { get; set; } = DateTime.Now;
        public int ClienteId { get; set; }
        public int TatuadorId { get; set; }

        [Ignore]
        public Tatuadores Tatuador { get; set; } = new Tatuadores();
        [Ignore]
        public Clientes Cliente { get; set; } = new Clientes();
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
        public DateTime Horario { get; set; } = DateTime.Now;
        public string ClienteNome { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public string TatuadorNome { get; set; } = string.Empty;
        public int TatuadorId { get; set; }
    }

    public class FichaAnamnese
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClienteId { get; set; } // Relacionamento com Cliente
        public bool Preenchida { get; set; } = false;
        public string Observacoes { get; set; } = string.Empty;
        public string CuidadosPosteriores { get; set; } = string.Empty;
    }

    public class Equipamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataAquisicao { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Ativo";
        public string UltimaManutencaoDescricao { get; set; } = string.Empty;
        public DateTime UltimaManutencaoData { get; set; } = DateTime.Now;
    }

    public class Horario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TatuadorId { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }

        [Ignore]
        public Tatuadores Tatuador { get; set; } = new Tatuadores();
    }

    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PermissoesJson { get; set; } = "[]";

        [Ignore]
        public List<string> Permissoes
        {
            get => JsonSerializer.Deserialize<List<string>>(PermissoesJson ?? "[]") ?? new List<string>();
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
