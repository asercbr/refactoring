using System;

namespace Refactoring.Lib
{
    public class User
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasCreditLimit { get; set; }
        public Client Client { get; set; }
        public decimal CreditLimit { get; set; }
    }
}