using GestãoEstudioTatuagem.Models;
using SQLite;

namespace GestãoEstudioTatuagem.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string path)
        {
           // Cria tabela no banco se ainda não existir
            _connection = new SQLiteAsyncConnection(path);

            // Cria as tabelas 
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

        public Task<int> Insert(Clientes clientes)
        {
            return _connection.InsertAsync(clientes);

        }

        public Task<int> Update(Clientes clientes) 
        { 
            return _connection.UpdateAsync(clientes);
        }

        public Task<int> Delete(Clientes id)
        {
            return _connection.DeleteAsync(id);
        }






    }
}
