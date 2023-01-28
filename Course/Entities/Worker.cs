using Course.Entities.Enums;
using Course.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Course.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        
        public List<HourContract> contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            contracts.Add(contract);
        }

        public void removeContract(HourContract contract)
        {
            contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach(HourContract c in contracts) // c é o iterador, contracts é a lista de contratos.
            {
                if(c.Date.Year == year && c.Date.Month == month)
                {
                    sum += c.TotalValue();
                }
            }

            return sum;
        }
    }
}
