using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using ETS.Models;
using System.ComponentModel;

namespace ETS
{
    public class CompanyContactRepository
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null)
            {
                return;
            }

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<CompanyContact>();
        }

        public CompanyContactRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewContact(string name, string company, string email, string officenumber, string phonenumber)
        {
            int result = 0;

            try
            {
                await Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");
                if (string.IsNullOrEmpty(company))
                    throw new Exception("Valid company required");
                if (string.IsNullOrEmpty(email))
                    throw new Exception("Valid email required");
                if (string.IsNullOrEmpty(officenumber))
                    throw new Exception("Valid company number required");
                if (string.IsNullOrEmpty(phonenumber))
                    throw new Exception("Valid personal number required");


                result = await conn.InsertAsync(new CompanyContact { Name = name, Company = company, Email = email, OfficeNumber = officenumber, PhoneNumber = phonenumber });
                StatusMessage = string.Format("Records Added Succesfully");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to Add records");
            }
        }

        public async Task<List<CompanyContact>> GetAllPeople()
        {
            try
            {
                await Init();
                return await conn.Table<CompanyContact>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data");
            }
            return new List<CompanyContact>();

        }


    }
}
