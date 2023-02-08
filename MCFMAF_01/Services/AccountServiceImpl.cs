using MCFMAF_01.Database.MasterDB;
using MCFMAF_01.Models;
using Microsoft.EntityFrameworkCore;

namespace MCFMAF_01.Services
{
    public class AccountServiceImpl : AccountService
    {
        MasterDbContext masterDb = new MasterDbContext();        

        public MsUser Login(string username, string password)
        {
            var user = masterDb.MsUsers.Where(d => d.Username == username && d.Password == password).FirstOrDefault();
            return user;
        }
    }
} 
