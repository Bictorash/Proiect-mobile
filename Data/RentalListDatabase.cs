using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rental_App.Models;
namespace Rental_App.Data
{
    public class RentalListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RentalListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RentalList>().Wait();
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListProduct>().Wait();
        }

        public Task<List<RentalList>> GetRentalListsAsync()
        {
            return _database.Table<RentalList>().ToListAsync();
        }
        public Task<RentalList> GetRentalListAsync(int id)
        {
            return _database.Table<RentalList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRentalListAsync(RentalList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteRentalListAsync(RentalList slist)
        {
            return _database.DeleteAsync(slist);
        }


    }
}