using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Fairytale
{
    class Program
    {
        private static void SelectItem()
        {
            Console.WriteLine("Спросила Фея у Золушки, о которой карете она мечтает?");
            Console.WriteLine("1. Красная\n2. Зеленая");
        }
        static void Main()
        {
            Stepmother evilWoman = new Stepmother();
            Cinderella stepdaughter = new Cinderella();
            Fairy godmother = new Fairy();
            stepdaughter.onCount += godmother.Magic;
            var tasks = evilWoman.GetTasks();
            Console.WriteLine(" В одном царстве, некотором государстве жила-была Золушка, и была у нее Мачеха.\n " +
                "Как-то случился в этом царстве бал, и хотела Золушка на него попасть, \n" +
                "но злая Мачеха выдала Золушке список поручений:\n");
            tasks.ToList().ForEach(i => Console.Write($"- {i}\n"));
            Console.WriteLine("\n Взгруснула Золушка, но решила, что все успеет и принялась за дело.\n" +
                " Сделала бедная падчирица все задания злобной мачехи.");
            if (!stepdaughter.TryExecute(tasks.Union(new[] { new Task("Бал", 10) })))
            {
                Console.WriteLine(" Но у Золушки не хватило енергии на бал и она грустная пошла спатоньки.");
                Console.ReadLine();
            }
            else
            {
                Thread.Sleep(5000);
                Console.Clear();
                SelectItem();
                int choice;
                while (!Int32.TryParse(Console.ReadLine(), out choice) && choice !=1 && choice != 2)
                {
                    Console.WriteLine("Ой ошибочка");
                    Thread.Sleep(3000);
                    Console.Clear();
                    SelectItem();
                }
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Золушка уехала на балл на красной карете.");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Золушка уехала на балл на зеленой карете.");
                        break;
                }
                Console.ReadLine();
            }
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
            if (isEnergyEnough)
            {
                onCount();
            }

            return isEnergyEnough;
        }

        public delegate void MethodContainer();

        public event MethodContainer onCount;
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

    class Fairy
    {
        public void Magic()
        {
            Console.WriteLine(" И у Золушки хватило енергии и к ней пришла Фея Крестная");
        }

        public void WhatCoachNeed() { }
    }
}
