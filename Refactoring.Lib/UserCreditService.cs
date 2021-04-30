using System;

namespace Refactoring.Lib
{
    public class UserCreditService
    {
        public decimal GetCreditLimit(string firstName, string surName, DateTime dateOfBirth)
        {
            return 300;
        }
    }
}