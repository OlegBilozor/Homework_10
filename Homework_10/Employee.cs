using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public override string ToString()
        {
            return $"Employee: {Name} - {Position} - {Age} - {Salary}";
        }
    }
}
