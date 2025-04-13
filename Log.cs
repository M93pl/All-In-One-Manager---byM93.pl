using System.Runtime.InteropServices;

namespace Public_AllInOneManager
{
    class Log
    {
        string system;
        string wybrane;
        bool powrot;
        public void Menu(string log)
        {
            string osLongl = RuntimeInformation.OSDescription;

            string[] tablical = osLongl.Split(' ');
            string osShortl = tablical[2];
            string NWIN1l = Convert.ToString(osShortl[5]);
            string NWIN2l = Convert.ToString(osShortl[6]);
            if (NWIN1l == "2" && NWIN2l == "2")
            {
                system = "Win11";
                Console.WriteLine("\x1b[3J");
            }
            else
            {
                system = "Win10";
                Console.Clear();
            }

            string logPath = log;
            string[] FileOdczyt = File.ReadAllLines(logPath);

            string[] opcjeMenuHL = new string[1] { "\n<< Powrót" };

            string tekst = "Historia logowania:\n(ostatni wpis dotyczy bierzącego logowania)\n";
            int LI = 0;
            int OU = 0;
            int BP = 0;

            foreach (string linia in FileOdczyt)
            {
                if (linia == "LogIn") { LI++; }
                if (linia == "LogOut") { OU++; }
                if (linia == "BadPassword") { BP++; }
                tekst += $"\n-\t{linia}";
            }

            // Dodanie statystyk
            double sredniaLogowan = (double)LI / FileOdczyt.Length * 100;
            double sredniaWylogowan = (double)OU / FileOdczyt.Length * 100;
            double sredniaNieautoryzowanych = (double)BP / FileOdczyt.Length * 100;

            // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))
            MainMenu menuGlowneHL = new MainMenu($"{tekst}\n\n" +
                $"Ilość logowań: {LI,31}\n" +
                $"Ilość wylogowań: {OU,29}\n" +
                $"Ilość nieautoryzowanych prób dostępu: {BP,8}\n" +
                $"Ilość zamknięć aplikacji bez wylogowania: {(LI - OU) - 1,4}\n\n" +
                $"Średnia nieautoryzowanych prób dostępu: {sredniaNieautoryzowanych:F2}%", 1, opcjeMenuHL);

            // wyswietlanie
            menuGlowneHL.MenuWyswietl();

            // return wybranej opcji
            wybrane = menuGlowneHL.MenuWybor();

            if (wybrane == opcjeMenuHL[0])
            {
                powrot = true;
            }
        }

        public bool Powrot()
        {
            return powrot;
        }
    }
}
