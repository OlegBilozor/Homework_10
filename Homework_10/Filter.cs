using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    public class Filter //Base class for filters
    {
        private readonly Filter _nextFilter; //next filter in the chain

        public Filter(Filter nextFilter)
        {
            _nextFilter = nextFilter;
        }

        public virtual void Filtration(List<Employee> employees, Employee employee, string rule) //filtration
        {
            _nextFilter?.Filtration(employees, employee, rule);
        }
    }

    public class AgeFilter : Filter //filter by age
    {
        public AgeFilter(Filter nextFilter) : base(nextFilter)
        {
        }

        public override void Filtration(List<Employee> employees, Employee employee, string rule)
        {
            if (int.TryParse(rule, out int age)) //if criterion can be age
            {
                if (employee.Age <= age) //if employee is specified age or younger
                {
                    employees.Add(employee);
                }
                return;
            }
            base.Filtration(employees, employee, rule);
        }
    }

    public class SalaryFilter : Filter //filter by salary
    {
        public SalaryFilter(Filter nextFilter) : base(nextFilter)
        {
        }

        public override void Filtration(List<Employee> employees, Employee employee, string rule)
        {
            if (double.TryParse(rule, out double salary)) //if criterion can be salary
            {

                if (employee.Salary >= salary) //if employee's salary is equal or bigger than specified 
                {
                    employees.Add(employee);
                }


                return;
            }
            base.Filtration(employees, employee, rule);
        }
    }

    public class PositionFilter : Filter //filter by position
    {
        public PositionFilter(Filter nextFilter) : base(nextFilter)
        {
        }

        public override void Filtration(List<Employee> employees, Employee employee, string rule)
        {

            if (employee.Position == rule) //if employee has the specified position
            {
                employees.Add(employee);

            }


            base.Filtration(employees, employee, rule);
        }
    }

}
