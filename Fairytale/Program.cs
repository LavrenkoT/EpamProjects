using System;
using System.Collections.Generic;
using System.Linq;

namespace Fairytale
{
    class Program
    {

        static void Main()
        {
            Stepmother evilWoman = new Stepmother();
            Cinderella stepdaughter = new Cinderella();
            var tasks = evilWoman.GetTasks();
            Console.WriteLine(" В одном царстве, некотором государстве жила-была Золушка, и была у нее Мачеха.\n " +
                "Как-то случился в этом царстве бал, и хотела Золушка на него попасть, \n" +
                "но злая Мачеха выдала Золушке список поручений:\n");
            tasks.ToList().ForEach(i => Console.Write($"- {i}\n"));
            Console.WriteLine("\n Взгруснула Золушка, но решила, что все успеет и принялась за дело.\n" +
                " Сделала бедная падчирица все задания злобной мачухи.");
            if (stepdaughter.TryExecute(tasks.Union(new[] { new Task("Бал", 10) })))
            {
                Console.WriteLine(" И у Золушки хватило енергии и она поехала на бал.");
            }
            else
            {
                Console.WriteLine(" Но у Золушки не хватило енергии на бал и она грустная пошла спатоньки.");
            }

            Console.ReadLine();
        }
    }
    class Cinderella
    {
        public Cinderella() : this(115)
        {
        }
        public Cinderella(int energy)
        {
            Energy = energy;
        }
        public int Energy { get; private set; }

        public bool TryExecute(IEnumerable<Task> tasks)
        {
            var requiredEnergy = tasks.Sum(i => i.RequiredEnergy);
            var restEnergy = Energy - requiredEnergy;
            var isEnergyEnough = restEnergy >= 0;
            Energy = isEnergyEnough ? restEnergy : Energy;
            return isEnergyEnough;
        }
    }
    class Task
    {
        public Task(string name, int requiredEnergy)
        {
            Name = name;
            RequiredEnergy = requiredEnergy;
        }
        public string Name { get; }
        public int RequiredEnergy { get; }

        public override string ToString()
        {
            return Name + " " + "- енергия" + " " + RequiredEnergy;
        }
    }
    class Stepmother
    {
        List<Task> tasks = new List<Task>
        {
            new Task( "Помыть пол", 5),
            new Task( "Постирать", 15),
            new Task( "Испечь пирог", 10),
            new Task( "Помыть окна", 25),
            new Task( "Погулять с псом", 30),
            new Task( "Связать носки", 15),
            new Task( "Приготовить квас", 10),
            new Task( "Почистить печку", 40),
            new Task( "Сделать икебану", 25),
            new Task( "Вычесать пса", 30),
        };

        public IEnumerable<Task> GetTasks()
        {
            var currentTasks = tasks.PickRandom(5);
            return currentTasks;
        }
    }
}
