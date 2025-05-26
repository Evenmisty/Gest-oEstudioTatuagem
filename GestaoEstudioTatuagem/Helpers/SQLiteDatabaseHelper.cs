using GestaoEstudioTatuagem.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string path)
        {
            // Cria a conexão com o banco de dados
            _connection = new SQLiteAsyncConnection(path);

            // Cria as tabelas, se não existirem
            _connection.CreateTableAsync<Clientes>().Wait();
            _connection.CreateTableAsync<Tatuadores>().Wait();
            _connection.CreateTableAsync<Sessao>().Wait();
            _connection.CreateTableAsync<Agenda>().Wait();
            _connection.CreateTableAsync<FichaAnamnese>().Wait();
            _connection.CreateTableAsync<ProntuarioEletronico>().Wait();
            _connection.CreateTableAsync<Equipamento>().Wait();
            _connection.CreateTableAsync<Horario>().Wait();
            _connection.CreateTableAsync<Usuario>().Wait();
            _connection.CreateTableAsync<ControleAcesso>().Wait();
        }

        // Métodos para Clientes
        public Task<int> InsertCliente(Clientes cliente)
        {
            return _connection.InsertAsync(cliente);
        }

        public Task<int> UpdateCliente(Clientes cliente)
        {
            return _connection.UpdateAsync(cliente);
        }

        public Task<int> DeleteCliente(Clientes cliente)
        {
            return _connection.DeleteAsync(cliente);
        }

        public Task<List<Clientes>> GetAllClientesAsync()
        {
            return _connection.Table<Clientes>().ToListAsync();
        }

        public Task<Clientes> GetClienteByIdAsync(int id)
        {
            return _connection.Table<Clientes>().FirstOrDefaultAsync(c => c.Id == id);
        }

        // Métodos para Tatuadores
        public Task<int> InsertTatuador(Tatuadores tatuador)
        {
            return _connection.InsertAsync(tatuador);
        }

        public Task<int> UpdateTatuador(Tatuadores tatuador)
        {
            return _connection.UpdateAsync(tatuador);
        }

        public Task<int> DeleteTatuador(Tatuadores tatuador)
        {
            return _connection.DeleteAsync(tatuador);
        }

        public Task<List<Tatuadores>> GetAllTatuadoresAsync()
        {
            return _connection.Table<Tatuadores>().ToListAsync();
        }

        public Task<Tatuadores> GetTatuadorByIdAsync(int id)
        {
            return _connection.Table<Tatuadores>().FirstOrDefaultAsync(t => t.Id == id);
        }

        // Métodos para Sessões
        public Task<int> InsertSessao(Sessao sessao)
        {
            return _connection.InsertAsync(sessao);
        }

        public Task<int> UpdateSessao(Sessao sessao)
        {
            return _connection.UpdateAsync(sessao);
        }

        public Task<int> DeleteSessao(Sessao sessao)
        {
            return _connection.DeleteAsync(sessao);
        }

        public Task<List<Sessao>> GetAllSessoesAsync()
        {
            return _connection.Table<Sessao>().ToListAsync();
        }

        // Métodos para Prontuário Eletrônico
        public Task<int> InsertProntuario(ProntuarioEletronico prontuario)
        {
            return _connection.InsertAsync(prontuario);
        }

        public Task<int> UpdateProntuario(ProntuarioEletronico prontuario)
        {
            return _connection.UpdateAsync(prontuario);
        }

        public Task<int> DeleteProntuario(ProntuarioEletronico prontuario)
        {
            return _connection.DeleteAsync(prontuario);
        }

        public Task<List<ProntuarioEletronico>> GetProntuariosByClienteIdAsync(int clienteId)
        {
            return _connection.Table<ProntuarioEletronico>().Where(p => p.ClienteId == clienteId).ToListAsync();
        }

        // Métodos para Usuários
        public Task<int> SaveUsuarioAsync(Usuario usuario)
        {
            return _connection.InsertOrReplaceAsync(usuario);
        }

        public Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return _connection.Table<Usuario>().FirstOrDefaultAsync(u => u.Login == email);
        }

        // Métodos para Controle de Acesso
        public Task<int> SaveControleAcessoAsync(ControleAcesso controle)
        {
            return _connection.InsertOrReplaceAsync(controle);
        }

        public Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return _connection.Table<Usuario>().ToListAsync();
        }

        // Métodos para Equipamentos
        public Task<int> InsertEquipamento(Equipamento equipamento)
        {
            return _connection.InsertAsync(equipamento);
        }

        public Task<int> UpdateEquipamento(Equipamento equipamento)
        {
            return _connection.UpdateAsync(equipamento);
        }

        public Task<int> DeleteEquipamento(Equipamento equipamento)
        {
            return _connection.DeleteAsync(equipamento);
        }

        public Task<List<Equipamento>> GetAllEquipamentosAsync()
        {
            return _connection.Table<Equipamento>().ToListAsync();
        }

        // Métodos para Horários dos Tatuadores
        public Task<int> InsertHorario(Horario horario)
        {
            return _connection.InsertAsync(horario);
        }

        public Task<int> UpdateHorario(Horario horario)
        {
            return _connection.UpdateAsync(horario);
        }

        public Task<int> DeleteHorario(Horario horario)
        {
            return _connection.DeleteAsync(horario);
        }

        public Task<List<Horario>> GetHorariosByTatuadorIdAsync(int tatuadorId)
        {
            return _connection.Table<Horario>().Where(h => h.TatuadorId == tatuadorId).ToListAsync();
        }

        // Métodos para Agenda
        public Task<int> InsertAgenda(Agenda agenda)
        {
            return _connection.InsertAsync(agenda);
        }

        public Task<List<Agenda>> GetAllAgendasAsync()
        {
            return _connection.Table<Agenda>().ToListAsync();
        }

        // Métodos para Ficha Anamnese
        public Task<int> InsertFichaAnamnese(FichaAnamnese ficha)
        {
            return _connection.InsertAsync(ficha);
        }

        public Task<List<FichaAnamnese>> GetFichasByClienteIdAsync(int clienteId)
        {
            return _connection.Table<FichaAnamnese>().Where(f => f.ClienteId == clienteId).ToListAsync();
        }
    }
}
