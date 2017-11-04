using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Teamwork_Projects
{
    class Team
    {
        public string CreatorName { get; set; }

        public List<string> TeamMembers { get; set; }

        public string TeamName { get; set; }

    }

    class TeamworkProject
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            var teams = new List<Team>();

            GetTeams(countOfTeams, teams);

            NewMethod(teams);

            PrintResults(teams);
        }

        private static void NewMethod(List<Team> teams)
        {
            string members = Console.ReadLine();

            while (members != "end of assignment")

            {
                var commandArgs = members.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

                var member = commandArgs[0];
                var team = commandArgs[1];

                bool doesExist = false;
                bool userAlreadyHasATeam = false;
                bool isCreater = false;


                foreach (var t in teams)
                {
                    if (t.TeamName == team)
                    {

                        doesExist = true;
                    }
                    if (member == t.CreatorName)
                    {

                        isCreater = true;

                    }
                    if (t.TeamMembers.Contains(member))
                    {
                        userAlreadyHasATeam = true;
                    }


                }
                if (!doesExist)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (isCreater || userAlreadyHasATeam)
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else
                {
                    foreach (var t in teams)
                    {
                        if (t.TeamName == team)
                        {

                            t.TeamMembers.Add(member);

                        }
                    }
                }

                members = Console.ReadLine();
            }
        }

        private static void PrintResults(List<Team> teams)
        {
            foreach (var team in teams
                .Where(c => c.TeamMembers.Count > 0)
                .OrderByDescending(t => t.TeamMembers.Count)
                .ThenBy(n => n.TeamName))

            {

                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.CreatorName}");
                foreach (var member in team.TeamMembers.OrderBy(a => a))
                {

                    Console.WriteLine(string.Join(" ", "--", member));
                }
            }
            Console.WriteLine($"Teams to disband: ");
            foreach (var team in teams
                .Where(t => t.TeamMembers.Count < 1)
                .OrderBy(t => t.TeamName))
            {

                Console.WriteLine($"{team.TeamName}");
            }
        }

        private static void GetTeams(int countOfTeams, List<Team> teams)
        {
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('-')
                    .ToArray();

                var creatorName = input[0];
                var teamName = input[1];

                bool isCreated = false;
                bool isCreator = false;
                var team = new Team()
                {

                    TeamName = teamName,
                    CreatorName = creatorName,
                    TeamMembers = new List<string>()
                };
                foreach (var t in teams)
                {
                    if (teamName == t.TeamName)
                    {
                        
                        isCreated = true;
                      

                    }
                    if (creatorName == t.CreatorName)
                    {
                        
                        isCreator = true;
                        
                    }
                }

                if (isCreated)
                {

                    Console.WriteLine($"Team {team.TeamName  } was already created!");
                    continue;

                }
                else if (isCreator)
                {
                    Console.WriteLine($"{team.CreatorName} cannot create another team!");
                    continue;
                }
                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {team.TeamName} has been created by {team.CreatorName}!");
                }
            }
        }
    }
}
