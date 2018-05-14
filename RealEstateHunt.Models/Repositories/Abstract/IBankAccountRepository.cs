using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Models.Repositories
{
    interface IBankAccountRepository : IRepository<BankAccount>
    {
        BankAccount FindByNumber(string number);
        BankAccount FindByNumberLike(string numberSubstring);
    }
}
