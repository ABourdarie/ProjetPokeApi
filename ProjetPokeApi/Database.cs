using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PokeApiNet;
using ProjetPokeApi.Models;
using SQLite;

namespace ProjetPokeApi
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pokemon>().Wait();
        }

        public static Task<Database> Instance { get; internal set; }

        public Task<List<Pokemon>> GetPeopleAsync()
        {
            return _database.Table<Pokemon>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Pokemon person)
        {
            return _database.InsertAsync(person);
        }

        internal Task<IEnumerable<MyPokemon>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        internal Task SaveItemAsync(MyPokemon pokemon)
        {
            throw new NotImplementedException();
        }

        internal Task<MyPokemon> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
