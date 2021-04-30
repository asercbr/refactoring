using System;
using Refactoring.Lib;

namespace RefactoringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AddUser(args);
        }

        public static void AddUser(string[] args)
        {
            var userService = new UserService();
            var addResult = userService.AddUser("testName", "testLastName", "some@email.com",
                DateTime.Now.AddYears(-25), 1);
            Console.WriteLine($"Adding result: {addResult}");
            Console.ReadLine();
        }
    }
}
