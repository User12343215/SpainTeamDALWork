using DAL;
using DAL.Entities;

namespace ConsoleApp8
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            var teamSv = new TeamService();

            var teams = new[]
                {
                    new Team { TeamName = "Real Madrid", City = "Мадрид", Wins = 12, Losses = 3, Draws = 3, GoalsScored = 40, GoalsConceded = 15},
                    new Team { TeamName = "FC Barcelona", City = "Барселона", Wins = 11, Losses = 4, Draws = 3, GoalsScored = 38, GoalsConceded = 16 },
                    new Team { TeamName = "Atletico Madrid", City = "Мадрид", Wins = 9, Losses = 5, Draws = 4, GoalsScored = 33, GoalsConceded = 20},
                    new Team { TeamName = "Sevilla FC", City = "Севілья", Wins = 8, Losses = 6, Draws = 4, GoalsScored = 30, GoalsConceded = 22 }
                };

            foreach(var team in teams)
            {
                //teamSv.Add(team);
            }

            //Show(teamSv);

            List<Team> AllTeams = teamSv.GetAll();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Функції:");

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
                Console.WriteLine(":");
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
            var teams = teamSv.GetAll();
            teams.ForEach(team=> Console.WriteLine($"Id: {team.Id}, Team name: {team.TeamName}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}\nDraws: {team.Draws}\nGoals Scored: {team.GoalsScored}\nGoals Conceded: {team.GoalsConceded}\n"));
        }

        private static void AddNewTeam(TeamService teamSv)
        {
            Console.WriteLine("Додати нову команду:");
            Console.Write("Введіть назву команди: ");
            string teamName = Console.ReadLine();
            Console.Write("Введіть місто: ");
            string city = Console.ReadLine();

            var existingTeam = teamSv.GetAll().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

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

                teamSv.Add(newTeam);
                Console.WriteLine("Команду успішно додано.");
            }
        }
        private static void UpdateTeam(TeamService teamSv)
        {
            Console.WriteLine("Зміна даних існуючої команди.");
            Console.Write("Введіть назву команди для редагування: ");
            string teamName = Console.ReadLine();
            Console.Write("Введіть місто: ");
            string city = Console.ReadLine();

            var teamToUpdate = teamSv.GetAll().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

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

                teamSv.Update(teamToUpdate);
                Console.WriteLine("Дані команди успішно оновлено.");
            }
            else
            {
                Console.WriteLine("Команду не знайдено.");
            }
        }
        private static void DeleteTeam(TeamService teamSv)
        {
            Console.WriteLine("Видалення команди.");
            Console.Write("Введіть назву команди для видалення: ");
            string teamName = Console.ReadLine();
            Console.Write("Введіть місто: ");
            string city = Console.ReadLine();

            var teamToDelete = teamSv.GetAll().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (teamToDelete != null)
            {
                Console.WriteLine($"Знайдена команда: {teamToDelete.TeamName} з міста {teamToDelete.City}");
                Console.Write("Ви впевнені, що хочете видалити цю команду? (y/n): ");
                string confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    teamSv.Delete(teamToDelete);
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
        }
    }
}
