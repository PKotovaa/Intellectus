using Intellectus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intellectus_mvc
{
    public class CompanyAuthService
    {
        public Company LoggedCompany { get; private set; }

        public void AuthenticateCompany(string name, string password)
        {
            BaseRepository<Company> repository = new BaseRepository<Company>();
            LoggedCompany = repository.GetBy(c=>c.ComapanyName==name && c.ComapanyPassword == password);
        }
    }
}