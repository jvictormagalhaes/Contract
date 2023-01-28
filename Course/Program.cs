using Course.Entities;
using Course.Entities.Enums;
using System;
using System.Globalization;

namespace Course { 
  
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior | MidLevel | Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, salary, dept);

            Console.Write("How to many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1 ; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value Per Hour: ");
                double valueperhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hour = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valueperhour, hour);
                worker.addContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to caculate income(MM/YYYY): ");
            string dateincome = Console.ReadLine();
            int year = int.Parse(dateincome.Substring(0, 2));
            int month = int.Parse(dateincome.Substring(3));
            Console.WriteLine(year);
            Console.WriteLine(month);
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Nome);
            Console.WriteLine("Income for " + dateincome +": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)); 
        }
    }
}
