using MCFMAF_01.Database.MasterDB;
using MCFMAF_01.Models;

namespace MCFMAF_01.Services
{
    public interface AccountService
    {
        public MsUser Login(string username, string password);
       
    }
}
