using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> start = new List<Employee>(); //create list with few employees to filter them
            start.Add(new Employee { Name = "Viktor", Age = 33, Salary = 6000.5, Position = "Programmer" });
            start.Add(new Employee { Name = "Olga", Age = 25, Salary = 5500.5, Position = "Manager" });
            start.Add(new Employee { Name = "Petro", Age = 21, Salary = 4000.42, Position = "Programmer" });
            start.Add(new Employee { Name = "Ivan", Age = 29, Salary = 6200.5, Position = "Manager" });
            start.Add(new Employee { Name = "Oleg", Age = 38, Salary = 12000.5, Position = "Director" });
            Console.WriteLine("Before filtration:");
            start.ForEach(Console.WriteLine);
            Console.WriteLine("\n--------------------------------\n");

            List<Employee> end= new List<Employee>(); //create list to contain filtrated employees
            
            //create chain of filters
            PositionFilter posFil = new PositionFilter(null);
            SalaryFilter salFil = new SalaryFilter(posFil);
            AgeFilter ageFil = new AgeFilter(salFil);
            //

            //filtration by age
            foreach (var employee in start)
            {
                ageFil.Filtration(end, employee, "30");
            }
            Console.WriteLine("Filtrated by age:");
            end.ForEach(Console.WriteLine);
            Console.WriteLine("\n--------------------------------\n");
            end.Clear();
            //
            //filtration by salary
            foreach (var employee in start)
            {
                ageFil.Filtration(end, employee, "6000,00");
            }
            Console.WriteLine("Filtrated by salary:");
            end.ForEach(Console.WriteLine);
            Console.WriteLine("\n--------------------------------\n");
            end.Clear();
            //
            //filtration by position
            foreach (var employee in start)
            {
                ageFil.Filtration(end, employee, "Programmer");
            }
            Console.WriteLine("Filtrated by position:");
            end.ForEach(Console.WriteLine);
            Console.WriteLine("\n--------------------------------\n");
            end.Clear();
            //
            Console.ReadLine();
        }
    }
}
