using System;
using System.Collections.Generic;
using System.Linq;

namespace Football
{
    class Program
    {
        private static Random randm = new Random();

        static void Main(string[] args)
        {
            List<FootballPlayer> footballPlayers = new List<FootballPlayer>();

            var ronaldo = new FootballPlayer("Ronaldo", 33, GetFootballPlayerLevel());
            var messi = new FootballPlayer("Messi", 22, GetFootballPlayerLevel());
            var mbappe = new FootballPlayer("Mbappé", 36, GetFootballPlayerLevel());
            var hazard = new FootballPlayer("Hazard", 31, GetFootballPlayerLevel());
            var bale = new FootballPlayer("Bale", 29, GetFootballPlayerLevel());
            var sterling = new FootballPlayer("Sterling", 26, GetFootballPlayerLevel());

            footballPlayers.Add(ronaldo);
            footballPlayers.Add(messi);
            footballPlayers.Add(mbappe);
            footballPlayers.Add(hazard);
            footballPlayers.Add(bale);
            footballPlayers.Add(sterling);

            var team1 = new Team("team1" , new Coach("Levin", GetCoachLuckyLevel()));
            var team2 = new Team("team2", new Coach("Borisov", GetCoachLuckyLevel()));

            team1.AddTeamMember(ronaldo);
            team1.AddTeamMember(messi);
            team1.AddTeamMember(mbappe);
            team2.AddTeamMember(hazard);
            team2.AddTeamMember(bale);
            team2.AddTeamMember(sterling);

            Judge judge = new Judge("Alehandro", GetJudgeChoice());
            Game game = new Game(team1, team2, judge);
            game.GetGameResult();
            Console.WriteLine("\nИгроки первой команды старше 30ти\n");
            team1.ShowPlayersOver30();
            Console.WriteLine("\nИгроки второй команды в алфавитном порядке\n");
            team2.ShowAllPlayers();

            Console.ReadKey();
        }

        public static int GetFootballPlayerLevel()
        {
            int rand = randm.Next(1, 100);
            return rand;
        }

        public static double GetCoachLuckyLevel()
        {
            double rand = randm.Next(5 , 16);
            rand /= 10;
            return rand;
        }

        public static int GetJudgeChoice()
        {
            int rand = randm.Next(0, 3);
            return rand;
        }
    }

    class FootballPlayer
    {
        public FootballPlayer(string surname, int age, int level)
        {
            Surname = surname;
            Age = age;
            Level = level;
        }

        public string Surname { get; }
        public int Age { get; set; }
        public int Level { get; }

        public override string ToString()
        {
            return Surname;
        }
    }

    class Team
    {
        public Team(string name, Coach coach)
        {
            Name = name;
            Coach = coach;
        }
        Coach Coach;
        public string Name { get; }
        List<FootballPlayer> team = new List<FootballPlayer>();
        private int TeamLevel { get; set; }
        public double TeamLevelWithCoach => this.TeamLevel * Coach.LuckyLevel;
        public void AddTeamMember(FootballPlayer footballPlayer)
        {
            team.Add(footballPlayer);
            TeamLevel += footballPlayer.Level;
        }
        public void ShowAllPlayers()
        {
            var teamPlayers = team.OrderBy(t => t.Surname);
            foreach (FootballPlayer f in teamPlayers)
            {
                Console.WriteLine(f);
            }
        }

        public void ShowPlayersOver30()
        {
            var teamPlayers = team.Where(t => t.Age > 30).OrderByDescending(s => s.Level);
            foreach (FootballPlayer f in teamPlayers)
            {
                Console.WriteLine(f + " "+ f.Age);
            }
        }

    }

    class Coach
    {
        public Coach(string surname, double luckyLevel)
        {
            Surname = surname;
            LuckyLevel = luckyLevel;
        }

        public string Surname { get; }
        public double LuckyLevel{get;}
    }

    class Judge
    {
        public Judge(string surname, int judgeChoice)
        {
            Surname = surname;
            JudgeChoice = judgeChoice;
        }
        public string Surname { get; }
        public int JudgeChoice{ get; }
    }

    class Game
    {
        public Game(Team firstTeam, Team secondTeam, Judge judge)
        {
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
            Judge = judge;
        }
        const int range = 10;
        Team FirstTeam;
        Team SecondTeam;
        Judge Judge;


        public void GetGameResult()
        {
            var firstTeamLevel = FirstTeam.TeamLevelWithCoach;
            var secondTeamLevel = SecondTeam.TeamLevelWithCoach;

            if (Judge.JudgeChoice == 1)
            {
                firstTeamLevel += (firstTeamLevel * 10) / 100;
            }
            else if (Judge.JudgeChoice == 2)
            {
                secondTeamLevel += (secondTeamLevel * 10) / 100;
            }

            double result = (secondTeamLevel * 100) / firstTeamLevel;

            Console.WriteLine($"Результат первой команды - {firstTeamLevel}, результат второй команды - {secondTeamLevel}");

            if (100 + range < result)
            {
                Console.WriteLine("Вторая команда победила");
            }
            else if (100 - range > result)
            {
                Console.WriteLine("Первая команда победила");
            }
            else
            {
                Console.WriteLine("Ничья");
            }
        }
    }
}
