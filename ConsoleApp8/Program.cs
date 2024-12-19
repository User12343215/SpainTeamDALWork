using DAL;
using DAL.Entities;
using System.Text.RegularExpressions;
using Match = DAL.Entities.Match;

namespace ConsoleApp8
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            var teamSv = new TeamService();
            var playerSv = new PlayerService();
            var matchSv = new MatchService();

            var teams = new[]
                {
                    new Team { TeamName = "Real Madrid", City = "Мадрид", Wins = 12, Losses = 3, Draws = 3, GoalsScored = 40, GoalsConceded = 15},
                    new Team { TeamName = "FC Barcelona", City = "Барселона", Wins = 11, Losses = 4, Draws = 3, GoalsScored = 38, GoalsConceded = 16 },
                    new Team { TeamName = "Atletico Madrid", City = "Мадрид", Wins = 9, Losses = 5, Draws = 4, GoalsScored = 33, GoalsConceded = 20},
                    new Team { TeamName = "Sevilla FC", City = "Севілья", Wins = 8, Losses = 6, Draws = 4, GoalsScored = 30, GoalsConceded = 22 }
                };

            var players = new[]
                {
                   new Player { PlayerNumber = 1, FullName = "Player 1", Country = "Spain", Position = "Forward", TeamId = 1, Team = teams[0] },
                    new Player { PlayerNumber = 2, FullName = "Player 2", Country = "Spain", Position = "Midfielder", TeamId = 1, Team = teams[0] },
                    new Player { PlayerNumber = 3, FullName = "Player 3", Country = "Spain", Position = "Defender", TeamId = 2, Team = teams[1] },
                    new Player { PlayerNumber = 4, FullName = "Player 4", Country = "Spain", Position = "Goalkeeper", TeamId = 3, Team = teams[2] },
                    new Player { PlayerNumber = 5, FullName = "Player 5", Country = "Spain", Position = "Midfielder", TeamId = 4, Team = teams[3] }
                };

            List<Goal> goals = new List<Goal>
                {
                    new Goal { Player = players[0], MatchId = 1 },
                    new Goal { Player = players[1], MatchId = 1 },
                    new Goal { Player = players[2], MatchId = 2 },
                    new Goal { Player = players[3], MatchId = 3 },
                    new Goal { Player = players[4], MatchId = 3 }
                };

            var matches = GenerateMatches(teams, players, 10);

            //foreach (var team in teams)
             //   teamSv.AddTeam(team);

            //foreach (var match in matches)
            //    matchSv.AddMatch(match);

            //foreach (var player in players)
             //   playerSv.AddPlayer(player);

            List<Team> AllTeams = teamSv.GetAllTeams();

            while(true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Функції:\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 - Пошук інформації про команду за назвою.");
                Console.WriteLine("2 - Пошук команд за назвою міста.");
                Console.WriteLine("3 - Пошук інформації за назвою команди і міста.");
                Console.WriteLine("4 - Відображення команди з найбільшою кількістю перемог");
                Console.WriteLine("5 - Відображення команди з найбільшою кількістю поразок.");
                Console.WriteLine("6 - Відображення команди з найбільшою кількістю ігор у нічию.");
                Console.WriteLine("7 - Відображення команди з найбільшою кількістю забитих голів.");
                Console.WriteLine("8 - Відображення команди з найбільшою кількістю пропущених голів.");
                Console.WriteLine("9 - Додати нову команду. Перед додаванням потрібно перевірити таку команду на наявність у додатку.");
                Console.WriteLine("10 - Зміна даних існуючої команди. Користувач може змінити будь-який параметр команди.");
                Console.WriteLine("11 - Видалити команду. Пошук команди для видалення проводиться за назвою команди і міста. Перед видаленням,\r\nдодаток має запитати користувача, чи потрібно видаляти\r\nкоманду.");
                Console.WriteLine("12 - Добавити матч.");
                Console.WriteLine("13 - Оновити матч.");
                Console.WriteLine("14 - Видалити матч.");
                Console.WriteLine("15 - Показати різницю забитих та пропущених голів для кожної команди.");
                Console.WriteLine("16 - Показати повну інформацію про матч.");
                Console.WriteLine("17 - Показати інформацію про матчі у конкретну дату.");
                Console.WriteLine("18 - Показати всі матчі конкретної команди.");
                Console.WriteLine("19 - Показати всіх гравців, які забили голи у конкретну дату.");
                Console.WriteLine("20 - Показати Топ-3 найкращих бомбардирів конкретної команди.");
                Console.WriteLine("21 - Покажіть найкращого бомбардира конкретної команди.");
                Console.WriteLine("22 - Покажіть Топ-3 команди, які набрали найбільше очок.");
                Console.WriteLine("23 - Покажіть команду, яка набрала найбільше очок.");
                Console.WriteLine("24 - Покажіть Топ-3 команди, які набрали найменшу кількість\r\nочок");
                Console.WriteLine("25 - Покажіть команду, яка набрала найменшу кількість очок.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n:");

                Console.ResetColor();
                string x = Console.ReadLine();

                try
                {
                    switch (x)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Пошук інформації про команду за назвою. \n Введіть назву:");
                            string getName = Console.ReadLine();
                            Print(AllTeams.FirstOrDefault(t => t.TeamName.Equals(getName)));
                            Console.ReadLine();
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("\nПошук команд за назвою міста. \nВведіть назву міста:");
                            string getCity = Console.ReadLine();
                            Print(AllTeams.Where(t => t.City.Equals(getCity)).ToList());
                            Console.ReadLine();
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("\nПошук інформації за назвою команди і міста. \nВведіть назву команди:");
                            string getNameAndCity = Console.ReadLine();
                            Console.WriteLine("Введіть назву міста:");
                            string getCityAndTeam = Console.ReadLine();
                            Print(AllTeams.FirstOrDefault(t => t.TeamName.Equals(getNameAndCity) && t.City.Equals(getCityAndTeam)));
                            Console.ReadLine();
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Команда з найбільшою кількістю перемог:");
                            Print(AllTeams.OrderByDescending(t => t.Wins).FirstOrDefault());
                            Console.ReadLine();
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Команда з найбільшою кількістю поразок");
                            Print(AllTeams.OrderByDescending(t => t.Losses).FirstOrDefault());
                            Console.ReadLine();
                            break;
                        case "6":
                            Console.Clear();
                            Console.WriteLine("Команда з найбільшою кількістю ігор у нічию");
                            Print(AllTeams.OrderByDescending(t => t.Draws).FirstOrDefault());
                            Console.ReadLine();
                            break;
                        case "7":
                            Console.Clear();
                            Console.WriteLine("Команда з найбільшою кількістю забитих голів");
                            Print(AllTeams.OrderByDescending(t => t.GoalsScored).FirstOrDefault());
                            Console.ReadLine();
                            break;
                        case "8":
                            Console.Clear();
                            Console.WriteLine("Команда з найбільшою кількістю пропущених голів");
                            Print(AllTeams.OrderByDescending(t => t.GoalsConceded).FirstOrDefault());
                            Console.ReadLine();
                            break;
                        case "9":
                            Console.Clear();
                            AddNewTeam(teamSv);
                            Console.ReadLine();
                            break;
                        case "10":
                            Console.Clear();
                            UpdateTeam(teamSv);
                            Console.ReadLine();
                            break;
                        case "11":
                            Console.Clear();
                            DeleteTeam(teamSv);
                            Console.ReadLine();
                            break;
                        case "12":
                            AddNewMatch(matchSv);
                            break;
                        case "13":
                            UpdateMatch(matchSv);
                            break;
                        case "14":
                            DeleteMatch(matchSv);
                            break;
                        case "15":
                            ShowGoalDifference(teamSv);
                            break;
                        case "16":
                            ShowMatchInfo(matchSv);
                            break;
                        case "17":
                            ShowMatchesByDate(matchSv);
                            break;
                        case "18":
                            ShowMatchesForTeam(matchSv);
                            break;
                        case "19":
                            ShowPlayersScoredOnDate(matchSv);
                            break;
                        case "20":
                            Console.Clear();
                            Console.WriteLine("Введіть назву команди:");
                            string teamNameForTopScorers = Console.ReadLine();
                            ShowTopScorersByTeam(playerSv, teamSv, teamNameForTopScorers);
                            break;
                        case "21":
                            ShowTopScorersOverall(playerSv);
                            break;
                        case "22":
                            ShowTopTeamsByGoals(teamSv);
                            break;
                        case "23":
                            ShowTopTeamsByDefense(teamSv);
                            break;
                        case "24":
                            ShowTopTeamsByPoints(teamSv);
                            break;
                        case "25":
                            ShowLowestTeamsByPoints(teamSv);
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.ReadLine();
                }
            }
        }

        private static void Print(List<Team> teams)
        {
            foreach (var team in teams)
                Console.WriteLine($"Id: {team.Id}, Team name: {team.TeamName}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}\nDraws: {team.Draws}\nGoals Scored: {team.GoalsScored}\nGoals Conceded: {team.GoalsConceded}\n");
        }
        private static void Print(Team team)
        {

            Console.WriteLine($"Id: {team.Id}, Team name: {team.TeamName}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}\nDraws: {team.Draws}\nGoals Scored: {team.GoalsScored}\nGoals Conceded: {team.GoalsConceded}\n");
        }
        private static void Show(TeamService teamSv)
        {
            var teams = teamSv.GetAllTeams();
            teams.ForEach(team=> Console.WriteLine($"Id: {team.Id}, Team name: {team.TeamName}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}\nDraws: {team.Draws}\nGoals Scored: {team.GoalsScored}\nGoals Conceded: {team.GoalsConceded}\n"));
        }

        private static void AddNewTeam(TeamService teamSv)
        {
            Console.WriteLine("Додати нову команду:");
            Console.Write("Введіть назву команди: ");
            string teamName = Console.ReadLine();
            Console.Write("Введіть місто: ");
            string city = Console.ReadLine();

            var existingTeam = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (existingTeam != null)
            {
                Console.WriteLine("Команда вже існує у додатку.");
            }
            else
            {
                Console.Write("Введіть кількість перемог: ");
                int wins = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість поразок: ");
                int losses = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість нічиїх: ");
                int draws = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість забитих голів: ");
                int goalsScored = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість пропущених голів: ");
                int goalsConceded = int.Parse(Console.ReadLine());

                var newTeam = new Team
                {
                    TeamName = teamName,
                    City = city,
                    Wins = wins,
                    Losses = losses,
                    Draws = draws,
                    GoalsScored = goalsScored,
                    GoalsConceded = goalsConceded
                };

                teamSv.AddTeam(newTeam);
                Console.WriteLine("Команду успішно додано.");

                Console.ReadLine();
            }
        }
        private static void UpdateTeam(TeamService teamSv)
        {
            Console.WriteLine("Зміна даних існуючої команди.");
            Console.Write("Введіть назву команди для редагування: ");
            string teamName = Console.ReadLine();
            Console.Write("Введіть місто: ");
            string city = Console.ReadLine();

            var teamToUpdate = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (teamToUpdate != null)
            {
                Console.WriteLine($"Знайдена команда: {teamToUpdate.TeamName} з міста {teamToUpdate.City}");

                Console.Write("Введіть нову кількість перемог: ");
                teamToUpdate.Wins = int.Parse(Console.ReadLine());
                Console.Write("Введіть нову кількість поразок: ");
                teamToUpdate.Losses = int.Parse(Console.ReadLine());
                Console.Write("Введіть нову кількість нічиїх: ");
                teamToUpdate.Draws = int.Parse(Console.ReadLine());
                Console.Write("Введіть нову кількість забитих голів: ");
                teamToUpdate.GoalsScored = int.Parse(Console.ReadLine());
                Console.Write("Введіть нову кількість пропущених голів: ");
                teamToUpdate.GoalsConceded = int.Parse(Console.ReadLine());

                teamSv.UpdateTeam(teamToUpdate);
                Console.WriteLine("Дані команди успішно оновлено.");
            }
            else
            {
                Console.WriteLine("Команду не знайдено.");
            }
            Console.ReadLine();
        }
        private static void DeleteTeam(TeamService teamSv)
        {
            Console.WriteLine("Видалення команди.");
            Console.Write("Введіть назву команди для видалення: ");
            string teamName = Console.ReadLine();
            Console.Write("Введіть місто: ");
            string city = Console.ReadLine();

            var teamToDelete = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (teamToDelete != null)
            {
                Console.WriteLine($"Знайдена команда: {teamToDelete.TeamName} з міста {teamToDelete.City}");
                Console.Write("Ви впевнені, що хочете видалити цю команду? (y/n): ");
                string confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    teamSv.DeleteTeam(teamToDelete);
                    Console.WriteLine("Команду успішно видалено.");
                }
                else
                {
                    Console.WriteLine("Видалення скасовано.");
                }
            }
            else
            {
                Console.WriteLine("Команду не знайдено.");
            }
            Console.ReadLine();
        }

        private static void AddNewMatch(MatchService matchSv)
        {
            Console.WriteLine("Додати новий матч:");
            Console.Write("Введіть ім'я першої команди: ");
            string team1Name = Console.ReadLine();
            Console.Write("Введіть ім'я другої команди: ");
            string team2Name = Console.ReadLine();
            Console.Write("Введіть дату матчу: ");
            DateTime matchDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введіть голи першої команди: ");
            int team1Goals = int.Parse(Console.ReadLine());
            Console.Write("Введіть голи другої команди: ");
            int team2Goals = int.Parse(Console.ReadLine());

            var existingMatch = matchSv.GetAllMatches().FirstOrDefault(m =>
                (m.Team1.TeamName == team1Name && m.Team2.TeamName == team2Name && m.MatchDate.Date == matchDate.Date));

            if (existingMatch != null)
            {
                Console.WriteLine("Матч вже існує.");
            }
            else
            {
                var match = new DAL.Entities.Match
                {
                    Team1 = new Team { TeamName = team1Name },
                    Team2 = new Team { TeamName = team2Name },
                    MatchDate = matchDate,
                    Team1Goals = team1Goals,
                    Team2Goals = team2Goals
                };
                matchSv.AddMatch(match);
                Console.WriteLine("Матч добавлено.");
            }
            Console.ReadLine();
        }

        private static void UpdateMatch(MatchService matchSv)
        {
            Console.WriteLine("Оновити матч.");
            Console.Write("Введіть ім'я першої команди: ");
            string team1Name = Console.ReadLine();
            Console.Write("Введіть ім'я другої команди: ");
            string team2Name = Console.ReadLine();
            Console.Write("Введіть дату матча: ");
            DateTime matchDate = DateTime.Parse(Console.ReadLine());

            var matchToUpdate = matchSv.GetAllMatches().FirstOrDefault(m =>
                m.Team1.TeamName == team1Name && m.Team2.TeamName == team2Name && m.MatchDate.Date == matchDate.Date);

            if (matchToUpdate != null)
            {
                Console.Write("Введіть голи першої команди: ");
                matchToUpdate.Team1Goals = int.Parse(Console.ReadLine());
                Console.Write("Enter new Team 2 goals: ");
                matchToUpdate.Team2Goals = int.Parse(Console.ReadLine());
                Console.WriteLine("Матч оновлен.");
            }
            else
            {
                Console.WriteLine("Матч не знайдено.");
            }
            
            Console.ReadLine();
        }

        private static void DeleteMatch(MatchService matchSv)
        {
            Console.WriteLine("Введіть данні матчу.");
            Console.Write("Введіть ім'я першої команди: ");
            string team1Name = Console.ReadLine();
            Console.Write("Введіть ім'я другої команди ");
            string team2Name = Console.ReadLine();
            Console.Write("Введіть дату матча: ");
            DateTime matchDate = DateTime.Parse(Console.ReadLine());

            var matchToDelete = matchSv.GetAllMatches().FirstOrDefault(m =>
                m.Team1.TeamName == team1Name && m.Team2.TeamName == team2Name && m.MatchDate.Date == matchDate.Date);

            if (matchToDelete != null)
            {
                matchSv.DeleteMatch(matchToDelete);
                Console.WriteLine("Матч видален.");
            }
            else
            {
                Console.WriteLine("Матч не знайдено.");
            }
            Console.ReadLine();
        }

        private static void ShowGoalDifference(TeamService teamSv)
        {
            Console.Clear();
            Console.WriteLine("Різниця забитих та пропущених голів для кожної команди:");

            foreach (var team in teamSv.GetAllTeams())
            {
                int goalDifference = team.GoalsScored - team.GoalsConceded;
                Console.WriteLine($"Команда: {team.TeamName}, Різниця: {goalDifference}");
            }

            Console.ReadLine();
        }

        private static void ShowMatchInfo(MatchService matchSv)
        {
            Console.Clear();
            Console.WriteLine("Введіть id матчу");
            int MatchId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Відображення повної інформації про матч:");

            foreach (var match in matchSv.GetAllMatches().Where(m=>m.Id==MatchId))
            {
                Console.WriteLine($"Матч: {match.Team1.TeamName} vs {match.Team2.TeamName}");
                Console.WriteLine($"Дата матчу: {match.MatchDate}");
                Console.WriteLine($"Голи: {match.Team1Goals} - {match.Team2Goals}");
                Console.WriteLine($"Місто: {match.Team1.City} vs {match.Team2.City}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void ShowMatchesByDate(MatchService matchSv)
        {
            Console.Clear();
            Console.WriteLine("Введіть дату для пошуку матчів:");
            DateTime searchDate = DateTime.Parse(Console.ReadLine());

            var matchesOnDate = matchSv.GetAllMatches().Where(m => m.MatchDate.Date == searchDate.Date).ToList();

            if (matchesOnDate.Any())
            {
                Console.WriteLine($"Матчі на {searchDate.ToShortDateString()}:");
                foreach (var match in matchesOnDate)
                {
                    Console.WriteLine($"{match.Team1.TeamName} vs {match.Team2.TeamName} - {match.Team1Goals} : {match.Team2Goals}");
                }
            }
            else
            {
                Console.WriteLine("Матчів на цю дату не знайдено.");
            }

            Console.ReadLine();
        }

        private static void ShowMatchesForTeam(MatchService matchSv)
        {
            Console.Clear();
            Console.WriteLine("Введіть назву команди для пошуку матчів:");
            string teamName = Console.ReadLine();

            var teamMatches = matchSv.GetAllMatches().Where(m => m.Team1.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) || m.Team2.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (teamMatches.Any())
            {
                Console.WriteLine($"Матчі команди {teamName}:");
                foreach (var match in teamMatches)
                {
                    Console.WriteLine($"{match.Team1.TeamName} vs {match.Team2.TeamName} - {match.Team1Goals} : {match.Team2Goals} на {match.MatchDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("Матчів для цієї команди не знайдено.");
            }

            Console.ReadLine();
        }

        private static void ShowPlayersScoredOnDate(MatchService matchSv)
        {
            Console.WriteLine("Введіть дату для пошуку гравців, які забили голи:");
            DateTime searchDate;
            if (!DateTime.TryParse(Console.ReadLine(), out searchDate))
            {
                Console.WriteLine("Невірний формат дати.");
                return;
            }

            var matchesOnDate = matchSv.GetAllMatches().Where(m => m.MatchDate.Date == searchDate.Date).ToList();

            if (matchesOnDate.Any())
            {
                Console.WriteLine($"Матчі на {searchDate.ToShortDateString()}:");
                foreach (var match in matchesOnDate)
                {
                    Console.WriteLine($"Матч: {match.Team1.TeamName} vs {match.Team2.TeamName}, Дата: {match.MatchDate}");
                    Console.WriteLine("Гравці, які забили голи:");

                    var playersWhoScored = match.Goals.Select(g => g.Player.FullName).Distinct();

                    foreach (var player in playersWhoScored)
                    {
                        Console.WriteLine(player);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Немає матчів на {searchDate.ToShortDateString()}.");
            }
            Console.ReadLine();
        }

        private static void ShowTopScorersByTeam(PlayerService playerSv, TeamService teamSv, string teamName)
        {
                Console.Clear();
                var team = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName == teamName);
                if (team == null)
                {
                    Console.WriteLine("Команда не найдена.");
                    return;
                }

                var topScorers = playerSv.GetAllPlayers().Where(p=>p.TeamId == team.Id)
                    .GroupBy(p => p)
                    .OrderByDescending(g => g.Count())
                    .Take(3);

                Console.WriteLine($"Топ-3 бомбардиров команды {team.TeamName}:");
                foreach (var scorer in topScorers)
                    Console.WriteLine($"{scorer.Key.FullName}: {scorer.Count()} голов");
                Console.ReadLine();
        }

        private static void ShowTopScorersOverall(PlayerService playerSv)
        {
            Console.Clear();
            var topScorers = playerSv.GetAllPlayers()
                .GroupBy(p => p)
                .OrderByDescending(g => g.Count())
                .Take(3);

            Console.WriteLine("Топ-3 бомбардиров всего чемпионата:");
            foreach (var scorer in topScorers)
                Console.WriteLine($"{scorer.Key.FullName}: {scorer.Count()} голов");
            Console.ReadLine();
        }

        private static void ShowTopTeamsByGoals(TeamService teamSv)
        {
            Console.Clear();
            var topTeams = teamSv.GetAllTeams()
                .OrderByDescending(t => t.GoalsScored)
                .Take(3);

            Console.WriteLine("Топ-3 команды по количеству забитых голов:");
            foreach (var team in topTeams)
                Console.WriteLine($"{team.TeamName}: {team.GoalsScored} голов");
            Console.ReadLine();
        }

        private static void ShowTopTeamsByDefense(TeamService teamSv)
        {
            Console.Clear();
            var topTeams = teamSv.GetAllTeams()
                .OrderBy(t => t.GoalsConceded)
                .Take(3);

            Console.WriteLine("Топ-3 команды с лучшей защитой:");
            foreach (var team in topTeams)
                Console.WriteLine($"{team.TeamName}: {team.GoalsConceded} пропущенных голов");
            Console.ReadLine();
        }

        private static void ShowTopTeamsByPoints(TeamService teamSv)
        {
            Console.Clear();
            var topTeams = teamSv.GetAllTeams()
                .OrderByDescending(t => t.Wins * 3 + t.Draws)
                .Take(3);

            Console.WriteLine("Топ-3 команды по количеству очков:");
            foreach (var team in topTeams)
            {
                int points = team.Wins * 3 + team.Draws;
                Console.WriteLine($"{team.TeamName}: {points} очков");
            }
            Console.ReadLine();
        }
        private static void ShowLowestTeamsByPoints(TeamService teamSv)
        {
            Console.Clear();
            var bottomTeams = teamSv.GetAllTeams()
                .OrderBy(t => t.Wins * 3 + t.Draws)
                .Take(3);

            Console.WriteLine("Топ-3 команды с наименьшим количеством очков:");
            foreach (var team in bottomTeams)
            {
                int points = team.Wins * 3 + team.Draws;
                Console.WriteLine($"{team.TeamName}: {points} очков");
            }
            Console.ReadLine();
        }

        public static List<Match> GenerateMatches(Team[] teams, Player[] players, int numberOfMatches)
        {
            Random random = new Random();
            List<Match> generatedMatches = new List<Match>();

            for (int i = 0; i < numberOfMatches; i++)
            {
                int team1Index = random.Next(teams.Length);
                int team2Index = random.Next(teams.Length);
                while (team1Index == team2Index)
                {
                    team2Index = random.Next(teams.Length);
                }

                var team1 = teams[team1Index];
                var team2 = teams[team2Index];

                int team1Goals = random.Next(0, 5);
                int team2Goals = random.Next(0, 5);

                var match = new DAL.Entities.Match
                {
                    Team1Id = team1.Id,
                    Team2Id = team2.Id,
                    Team1Goals = team1Goals,
                    Team2Goals = team2Goals,
                    MatchDate = DateTime.Now.AddDays(-random.Next(1, 30))
                };

                List<Goal> matchGoals = new List<Goal>();
                for (int j = 0; j < team1Goals; j++)
                {
                    var randomPlayer = players.Where(p => p.TeamId == team1.Id).OrderBy(p => random.Next()).FirstOrDefault();
                    matchGoals.Add(new Goal { Player = randomPlayer, MatchId = match.Id });
                }

                for (int j = 0; j < team2Goals; j++)
                {
                    var randomPlayer = players.Where(p => p.TeamId == team2.Id).OrderBy(p => random.Next()).FirstOrDefault();
                    matchGoals.Add(new Goal { Player = randomPlayer, MatchId = match.Id });
                }

                match.Goals = matchGoals;

                generatedMatches.Add(match);
            }

            return generatedMatches;
        }
    }
}
