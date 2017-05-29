using System;

namespace HealthTracker.ConsoleApp
{
    internal static class Program
    {
        private static string _newName = string.Empty;

        private static void Main()
        {
            GetNameInput();
            var personId = Examples.FindPerson(_newName);

            if (personId == 0)
            {
                Examples.CreatePerson(_newName);
                personId = Examples.FindPerson(_newName);
            }

            Examples.CreateActivity(personId);
            Examples.CreateMeals(personId);
            Examples.UpdateOrAddHydration(personId);

            Console.WriteLine("Click any key to quit.");
            Console.ReadKey();
        }

        private static void GetNameInput()
        {
            while (true)
            {
                Console.Write("Input Person's Name: ");
                var readLine = Console.ReadLine();
                if (readLine != null) _newName = readLine.Trim();
                if (_newName.Length > 2) return;
                Console.WriteLine("Name to short. Exiting program.");
            }
        }
    }
}