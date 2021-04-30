namespace Refactoring.Lib
{
    public class ClientRepository
    {
        public Client GetClientById(int id)
        {
            return new Client()
            {
                ClientId = 2,
                Name = "testClient"
            };
        }
    }
}