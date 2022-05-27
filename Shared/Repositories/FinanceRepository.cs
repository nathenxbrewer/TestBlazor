using BlazorApp.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Repositories
{
    public class FinanceRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }


        public void AddNewBill(Bill bill)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(bill.Name))
                    throw new Exception("Valid name required");

                result = conn.Insert(bill);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, bill.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", bill.Name, ex.Message);
            }
        }

        public async Task<List<Bill>> GetAllBills()
        {
            try
            {
                Init();
                return conn.Table<Bill>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Bill>();
        }

        public FinanceRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Bill>();
        }
    }

}
