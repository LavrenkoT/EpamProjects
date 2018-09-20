using System;
using System.Collections.Generic;
using System.Linq;


namespace ITCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Individual> individuals = new List<Individual>();
            var alex = new Individual("Алексей", "Developer", "Middle", 300);
            var andrey = new Individual("Андрей", "Developer", "Junior", 200);
            var igor = new Individual("Игорь", "Developer", "Senior", 700);
            var bogdan = new Individual("Богдан", "Developer", "Trainee", 50);
            var nikita = new Individual("Никита", "QA", "Middle", 200);
            var alina = new Individual("Алина", "QA", "Junior", 100);
            var kristina = new Individual("Кристина", "QA", "Trainee", 50);
            var dmitry = new Individual("Дмитрий", "PM", "Middle", 300);
            var kiril = new Individual("Кирил", "PM", "Junior", 150);
            var maks = new Individual("Макс", "Developer", "Architect", 1500);

            individuals.Add(alex);
            individuals.Add(andrey);
            individuals.Add(igor);
            individuals.Add(bogdan);
            individuals.Add(nikita);
            individuals.Add(alina);
            individuals.Add(kristina);
            individuals.Add(dmitry);
            individuals.Add(kiril);
            individuals.Add(maks);

            List<Project> projects = new List<Project>();
            var alpha = new Project("Alpha", new DateTime(2015, 07, 09));
            var beta = new Project("Beta", new DateTime(2016, 12, 23));
            var gamma = new Project("Gamma", new DateTime(2013, 01, 30));

            projects.Add(alpha);
            projects.Add(beta);
            projects.Add(gamma);

            List<Department> departments = new List<Department>();
            var devDepartment = new Department("Dev");
            var qaDepartment = new Department("QA");
            var pmDepartment = new Department("PM");

            departments.Add(devDepartment);
            departments.Add(qaDepartment);
            departments.Add(pmDepartment);

            alpha.AddEmployee(alex);
            alpha.AddEmployee(andrey);
            alpha.AddEmployee(alina);
            alpha.AddEmployee(kiril);

            beta.AddEmployee(bogdan);
            beta.AddEmployee(andrey);
            beta.AddEmployee(igor);
            beta.AddEmployee(kristina);
            beta.AddEmployee(nikita);
            beta.AddEmployee(dmitry);

            gamma.AddEmployee(dmitry);
            gamma.AddEmployee(alina);
            gamma.AddEmployee(nikita);
            gamma.AddEmployee(igor);
            gamma.AddEmployee(andrey);
            gamma.AddEmployee(bogdan);

            devDepartment.AddEmployee(alex);
            devDepartment.AddEmployee(maks);
            devDepartment.AddEmployee(andrey);
            devDepartment.AddEmployee(igor);
            devDepartment.AddEmployee(bogdan);
            qaDepartment.AddEmployee(nikita);
            qaDepartment.AddEmployee(alina);
            qaDepartment.AddEmployee(kristina);
            pmDepartment.AddEmployee(dmitry);
            pmDepartment.AddEmployee(kiril);

            var selectedEmp = individuals.Where(i => i.Salary < 200);
            var selectProj = projects.Where(x => x.StartDate.Year == 2015).SelectMany(i => i.employees);
            var selectEmp1 = individuals.Where(i => i.projects.Count > 1 && i.Salary > 100); //получить всех сотрудников которые работали больше чем на одном проекте с зарплатой выше чем 100
            var selectProj1 = projects.GroupBy(e => e.employees.Count).OrderByDescending(x=>x.Key).First(); // получить проект в котором количество девов наибольшое
            var selectEmp2 = individuals.Where(p => p.Position == "QA" && p.Name.StartsWith("К")); //пoлучить тестировщика имя которого начинается на К
            var selectDep = departments.Where(e => e.Name == "PM").SelectMany(i => i.employees).Count(); // получить количество пм в пм департаманте
            var selectAllEmp = individuals.Except(projects.SelectMany(e=>e.employees));// получить сотрудника не задействованного ни на одном проекте 
            Console.ReadKey();
        }

        class Individual
        {
            public Individual(string name, string position, string level, int salary)
            {
                Name = name;
                Position = position;
                Level = level;
                Salary = salary;
            }
            public string Name { get; }
            public string Position { get;}
            string Level { get; set; }
            public List<Project> projects = new List<Project>();
            public int Salary { get; }
        }

        class Project
        {
            public Project(string name, DateTime startDate)
            {
                Name = name;
                StartDate = startDate;
            }
            string Name { get; set; }
            public List<Individual> employees = new List<Individual>();
            public DateTime StartDate { get; }

            public void AddEmployee(Individual individual)
            {
                employees.Add(individual);
            }
        }

        class Department
        {
            public Department(string name)
            {
                Name = name;
            }
            public string Name { get;}
            public List<Individual> employees = new List<Individual>();

            public void AddEmployee(Individual individual)
            {
                employees.Add(individual);
            }
        }

    }
}
