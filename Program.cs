using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Public_AllInOneManager
{
    internal class Program
    {
        static string system;
        static string konsolaClear;
        static string osLong = RuntimeInformation.OSDescription;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            string osLongl = RuntimeInformation.OSDescription;

            string[] tablical = osLongl.Split(' ');
            string osShortl = tablical[2];
            string NWIN1l = Convert.ToString(osShortl[5]);
            string NWIN2l = Convert.ToString(osShortl[6]);
            if (NWIN1l == "2" && (NWIN2l == "2" || NWIN2l == "6"))
            {
                system = "Win11";
                konsolaClear = "\x1b[3J";
            }
            else
            {
                system = "Win10";
                konsolaClear = "";
            }


            string wybrane;
            bool powrot;

            Console.WriteLine("<<AllInOne Manager by M93.pl>>\n\nWpisz frazę 'M93' aby udowodnić że nie jesteś botem:\n");
            string haslo = Console.ReadLine();
            DateTime czas = DateTime.Now;
            string dzien = $"{czas:dddd}".ToLower();
            string dziendata = $"{czas:dd}";
            string miesiac = $"{czas:MMMM}";
            string rok = $"{czas:yyyy}";
            string godzina = $"{czas:T}";


            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log_list.m93");

            if (haslo == "m93" || haslo == "M93" || haslo == "m 93" || haslo == "M 93")
            {
                Console.Clear();
                string load = $"ładuje zasoby...";
                string logo = $"||||||||||||||||||||||{load,36}\n" +
                                $"|||| Witaj M93.pl ||||\n" +
                                $"||||||||||||||||||||||\n";

                string logo2 = $"||||||||||||||||||||||\n" +
                                 $"|||| Witaj M93.pl ||||\n" +
                                 $"||||||||||||||||||||||\n";


                SlowWrite(logo, 5);
                Console.Clear();
                Console.WriteLine(logo2);


                czas = DateTime.Now;
                dzien = $"{czas:dddd}".ToLower();
                dziendata = $"{czas:dd}";
                miesiac = $"{czas:MMMM}";
                rok = $"{czas:yyyy}";
                godzina = $"{czas:T}";

                Console.WriteLine($"Dziś jest {dzien}.\n" +
                                    $"{dziendata} {miesiac} {rok}r.\n" +
                                    $"Godzina {godzina}\n\n");


                // log w dzienniku
                string log_in = $"\n\nUżytkownik zalogowany dnia: {dziendata}/{miesiac}/{rok}" +
                                $"\nGodzina logowania: {godzina}" +
                                $"\nLogIn";
                File.AppendAllText(logPath, log_in);

                SlowWrite("Ładowanie zasobów zakończone.", 20);
                Console.Beep(800, 120);
                Console.WriteLine("Naciśnij dowolny klawisz aby rozpocząć.");

                Console.Beep(1800, 100);
                Console.ReadKey();

                powrot = true;

                do
                {
                    string[] opcjeMenu = new string[7]{
                    "> M-Diag - SystemInfo",
                    "> Fold8 - Tworzenie folderów",
                    "> Instrukcja obsługi",
                    "> Historia logowania",
                    "> O programie",
                    "",
                    "<< Wyjście"};

                    // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))
                    MainMenu menuGlowne = new MainMenu("Wybierz funkcje:\n", 7, opcjeMenu);

                    // wyswietlanie
                    menuGlowne.MenuWyswietl();

                    // return wybranej opcji
                    wybrane = menuGlowne.MenuWybor();


                    if (wybrane == opcjeMenu[0])
                    {
                        Console.Clear();
                        Console.WriteLine(konsolaClear);
                        SystemInfo DG = new SystemInfo();
                        DG.Menu();
                        powrot = DG.Powrot();
                    }
                    else if (wybrane == opcjeMenu[1])
                    {
                        Console.Clear();
                        Console.WriteLine(konsolaClear);
                        FolderKreator FK = new FolderKreator();
                        FK.Menu();
                        powrot = FK.Powrot();
                    }
                    else if (wybrane == opcjeMenu[2])
                    {
                        Console.Clear();
                        Console.WriteLine(konsolaClear);
                        Instruction II = new Instruction();
                        II.Menu();
                        powrot = II.Powrot();
                    }
                    else if (wybrane == opcjeMenu[3])
                    {
                        Console.Clear();
                        Console.WriteLine(konsolaClear);
                        Log HL = new Log();
                        HL.Menu(logPath);
                        powrot = HL.Powrot();
                    }
                    else if (wybrane == opcjeMenu[4])
                    {
                        Debug.WriteLine("rrr");
                        Console.Clear();
                        Console.WriteLine(konsolaClear);
                        Autor AU = new Autor();
                        AU.Menu();
                        powrot = AU.Powrot();
                    }
                    else if (wybrane == opcjeMenu[6])
                    {
                        Console.Clear();
                        SlowWrite("Wylogowuję...", 50);
                        czas = DateTime.Now;
                        dziendata = $"{czas:dd}";
                        miesiac = $"{czas:MMMM}";
                        rok = $"{czas:yyyy}";
                        godzina = $"{czas:T}";
                        string log_out = $"\nUżytkownik wylogowany dnia: {dziendata}/{miesiac}/{rok}" +
                                         $"\nGodzina wylogowania: {godzina}" +
                                         $"\nLogOut";
                        File.AppendAllText(logPath, log_out);
                        Console.Beep(1500, 200);
                        Console.Beep(1500, 200);
                        Thread.Sleep(300);
                        Environment.Exit(0);
                    }
                } while (powrot == true);



                Console.ReadKey();
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Beep(3000, 100);
                Console.WriteLine("Błąd!\n\n\tBłędne hasło ! ! !\n");
                czas = DateTime.Now;
                dziendata = $"{czas:dd}";
                miesiac = $"{czas:MMMM}";
                rok = $"{czas:yyyy}";
                godzina = $"{czas:T}";
                string log_out = $"\n\nNieautoryzowana próba logowania dnia: {dziendata}/{miesiac}/{rok}" +
                                 $"\nNIEPOPRAWNE HASŁO" +
                                 $"\nGodzina wystąpienia: {godzina}" +
                                 $"\nBadPassword";
                File.AppendAllText(logPath, log_out);
                Console.Beep(800, 100);
                Console.Beep(3000, 100);
                Console.Beep(800, 100);
                Console.Beep(3000, 100);
                Console.ReadKey();
            }


        }


        static void SlowWrite(string tekst, int czas)
        {
            foreach (char litera in tekst)
            {
                Console.Write(litera);
                Thread.Sleep(czas);
            }
            Console.WriteLine();
        }
        static void SlowWrite(string tekst, int czas, int bep)
        {
            foreach (char litera in tekst)
            {
                Console.Beep(bep, czas);
                Console.Write(litera);
                Thread.Sleep(czas);
            }
            Console.WriteLine();
        }
    }
}
