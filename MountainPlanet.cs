namespace helloapp
{
    public static class MountainNavigation
    {
        private static Random random = new Random();
        private static (int, int) shipPosition;
        private static int[,] map;

        static MountainNavigation()
        {
            shipPosition = new(5, 4);
            map = new int[,] {
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };
        }

        public static void LetsStartNewJourney()
        {
            shipPosition = new(5, 4);
            map = new int[,] {
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain(), BuildTerrain() },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            Console.Clear();
            Console.WriteLine("Вітаю, капітане!");
            Console.WriteLine("Ми досліджуємо цю планету вже декілька років, але через її гористу місцевість це вкрай складно. Тим не менш ми вже поділили її на квадрати і перед вами");
            Console.WriteLine("Сканер вже обробив ваш квадрат. Погляньте.");
            Console.WriteLine("");
            DrawTheMap();
            Console.WriteLine("");
            Console.WriteLine("Ваша задача, капітане, дослідити ці гори та долини і прокласти безпечний маршрут уникнувши зіткнення");
            Console.WriteLine("На мапі ваш корабель позначений як Н, рухайтесь на північ до перемоги.");
            Console.WriteLine("Команда GetShipPosition поверне позицію вашого зорельоту");
            Console.WriteLine("Команда MoveTheSpaceShip змусить його рухатись. Перший параметр по вертикалі (наприклад -1 це крок на північ), а другий параметр по горизонталі.");
            Console.WriteLine("Але будь обережним. При зіткненням з горою тебе чекає смерть.");
            Console.WriteLine("Щоб продовжити натисніть Enter");
            Console.ReadLine();
        }

        private static int BuildTerrain() => random.Next(0, 4) == 0 ? 1 : 0;

        public static (int, int) GetShipPosition()
        {
            return shipPosition;
        }

        public static void DrawTheMap()
        {
            Console.WriteLine("PEREMOGA!!");

            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    Console.Write(shipPosition.Item1 == i && shipPosition.Item2 == j ? "H" : map[i, j] == 0 ? "_" : "W");
                }
                Console.WriteLine();
            }
        }

        public static bool MoveTheSpaceShip(int vertical = 0, int horizontal = 0)
        {
            Console.Clear();

            if (vertical < -1 || vertical > 1 || horizontal < -1 || horizontal > 1)
                throw new ArgumentOutOfRangeException("Рух човна можливий лише на одне ділення за раз, від'ємний рух допустимий");

            if (shipPosition.Item1 == 0)
            {
                Console.WriteLine("Ви вже у фінальній точці, подальший рух не доцільний.");
            }
            else if (
                shipPosition.Item1 + vertical > 5 ||
                shipPosition.Item2 + horizontal < 0 ||
                shipPosition.Item2 + horizontal > 8)
            {
                Console.WriteLine("Рух за межі розвіданого квадрату надто небезпечний. Запит руху відхилино");
                Console.ReadLine();
                return false;
            }
            else
            {
                shipPosition.Item1 += vertical;
                shipPosition.Item2 += horizontal;
            }

            Console.WriteLine("Обробка маршруту, почекайте...");
            Console.WriteLine("");

            Thread.Sleep(4000);

            if (map[shipPosition.Item1, shipPosition.Item2] == 1)
            {
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("Небезпека зіткнення!!!!");
                    Console.WriteLine("");
                    Thread.Sleep(2000);
                }
                Console.WriteLine("Ви загинули при дослідженні планети. Ви герой!");
                Thread.Sleep(2000);
                throw new Exception("Ви загинули при дослідженні планети");
            }
            else
            {
                Console.WriteLine("Карта оновлена");
                Console.WriteLine("");

                DrawTheMap();
                Console.WriteLine("");

                if (shipPosition.Item1 == 0)
                {
                    Console.WriteLine("Єєєєєєє! Вітання! Ви зробили це капітане! Ваш внесок у планетарні дослідження важко переоцінити!");
                    Console.ReadLine();
                    return true;
                }
                Console.WriteLine("Щоб продовжити натисніть Enter");
                Console.ReadLine();
                return false;
            }
        }

        public static int[,] GetThePlanetMap()
        {
            return map;
        }
    }
}
