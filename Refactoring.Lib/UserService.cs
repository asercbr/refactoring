using System;

namespace Refactoring.Lib
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@"))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;

            if (age < 21)
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetClientById(clientId);

            var user = new User()
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                FirstName = firstName,
                Surname = lastName
            };

            if (client.Name == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }

            if (client.Name == "ImportantClient")
            {
                user.HasCreditLimit = true;
                var userCreditService = new UserCreditService();
                var creditLimit = userCreditService.GetCreditLimit(user.FirstName, user.Surname, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                var userCreditService = new UserCreditService();
                var creditLimit = userCreditService.GetCreditLimit(user.FirstName, user.Surname, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 100)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}