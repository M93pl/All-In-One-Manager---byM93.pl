using System.Diagnostics;

namespace Public_AllInOneManager
{
    public class FolderKreator
    {
        public string wybrane;
        public bool powrot = false;
        public void Menu()
        {
            do
            {
                string[] opcjeMenuFK = new string[7]{
                    "> Wyświetl listę folderów",
                    "> Dodaj nowy folder",
                    "> DODAJ WIELE FOLDERÓW",
                    "> Zmień nazwę folderu",
                    "> Usuń folder",
                    " ",
                    "<< Powrót"};

                string tytul = "Fold8 2.0\n" +
                    "Program do tworzenia wielu folderów w krótkim czasie.\n" +
                    "Wybierz funkcje:\n";
                // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))


                // wyswietlanie
                MainMenu menuGlowneFK = new MainMenu(tytul, 7, opcjeMenuFK);
                menuGlowneFK.MenuWyswietl();

                // return wybranej opcji
                wybrane = menuGlowneFK.MenuWybor();

                if (wybrane == opcjeMenuFK[0]) // listowanie folderów
                {
                    bool powrot1 = false;
                    do
                    {
                        Console.Clear();
                        string sciezkaPulpit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Fold8");

                        if (Directory.Exists(sciezkaPulpit))
                        {
                            string[] folderyLista = Directory.GetDirectories(sciezkaPulpit);
                            int counter = 0;

                            Console.WriteLine("Foldery w katalogu \"Fold8\":\n");
                            foreach (string folder in folderyLista)
                            {
                                string folderName = folder.Split('\\').Last();
                                counter++;
                                Console.WriteLine($"{counter}. {folderName}");
                            }
                            Console.WriteLine($"\nNaciśnij dowolny przycisk aby zamknąć.");
                            Console.ReadKey();
                            powrot1 = true;
                        }
                        else
                        {
                            Console.WriteLine($"Brak folderów\nNaciśnij dowolny przycisk.");
                            Console.ReadKey();
                            powrot1 = true;
                        }
                    } while (powrot1 == false);

                }
                else if (wybrane == opcjeMenuFK[1]) // tworzenie pojedyńczeog folderu
                {
                    bool powrot1 = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Podaj nazwę folderu i naciśnij enter:\n");
                        string nazwaFolderu = Convert.ToString(Console.ReadLine());
                        Console.Clear();

                        string sciezkaPulpit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Fold8/{nazwaFolderu}");
                        Directory.CreateDirectory(sciezkaPulpit);
                        SlowWrite("Tworzę 1 folder", 50);

                        string[] opcje2 = new string[2]{
                                    "> Tak",
                                    "> Nie"};

                        // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))
                        MainMenu subMenu1 = new MainMenu("Czy dodać kolejny folder?\n", 2, opcje2);

                        // wyswietlanie
                        subMenu1.SubMenuWyswietl();
                        string wybrana1 = subMenu1.MenuWybor();
                        if (wybrana1 == opcje2[0]) { powrot1 = false; }
                        else if (wybrana1 == opcje2[1]) { powrot1 = true; }
                    } while (powrot1 == false);
                }
                else if (wybrane == opcjeMenuFK[2]) // tworzenie wielu folderów
                {
                    bool powrot1 = false;
                    do
                    {
                        Console.Clear();
                        string[] opcje3 = new string[9]{
                        "> \"Nowy folder 1\", \"Nowy folder 2\", \"Nowy folder 3\"...",
                        "> \"Nowy1\", \"Nowy2\", \"Nowy3\"...",
                        "> \"Folder 1\", \"Folder 2\", \"Folder 3\"...",
                        "> \"FOLDER 1\", \"FOLDER 2\", \"FOLDER 3\"...",
                        "> \"folder 1\", \"folder 2\", \"folder 3\"...",
                        "> \"1\", \"2\", \"3\"...",
                        "> \"CD01\", \"CD02\", \"CD03\"...",
                        " ",
                        "> Własna nazwa 1, Własna nazwa 2, Własna nazwa 3..."};

                        // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))
                        MainMenu subMenu2 = new MainMenu("Jak chcesz nazwać foldery?\n", 9, opcje3);

                        string nazwaFolderow = "ERROR";

                        // wyswietlanie
                        subMenu2.MenuWyswietl();
                        string wybrana2 = subMenu2.MenuWybor();
                        if (wybrana2 == opcje3[0]) { nazwaFolderow = "Nowy folder "; }
                        else if (wybrana2 == opcje3[1]) { nazwaFolderow = "Nowy"; }
                        else if (wybrana2 == opcje3[2]) { nazwaFolderow = "Folder "; }
                        else if (wybrana2 == opcje3[3]) { nazwaFolderow = "FOLDER "; }
                        else if (wybrana2 == opcje3[4]) { nazwaFolderow = "folder "; }
                        else if (wybrana2 == opcje3[5]) { nazwaFolderow = ""; }
                        else if (wybrana2 == opcje3[6]) { nazwaFolderow = "CD0"; }
                        else if (wybrana2 == opcje3[7]) { Debug.WriteLine("ERROR: pusta opcja"); }
                        else if (wybrana2 == opcje3[8])
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj własną nazwę: (pamiętaj o spacji na końcu jeżeli takiej wymagasz)\n");
                            nazwaFolderow = Convert.ToString(Console.ReadLine());
                        }

                        Console.Clear();
                        Console.WriteLine("Ile folderów chcesz utworzyć?\n");

                        try
                        {
                            int iloscFolderow = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Naciśnij enter aby zatwierdzić.");
                            Console.Clear();

                            string sciezkaPulpit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Fold8/{nazwaFolderow}");
                            if (iloscFolderow <= 10) { SlowWrite($"Tworzę {iloscFolderow} folderów...", 40); }
                            else if (iloscFolderow <= 100) { SlowWrite($"Tworzę {iloscFolderow} folderów...", 80); }
                            else if (iloscFolderow > 100) { SlowWrite($"Tworzę {iloscFolderow} folderów...", 160); }


                            for (int i = 1; i <= iloscFolderow; i++)
                            {
                                string nowaNF = nazwaFolderow + $"{Convert.ToString(i)}";
                                sciezkaPulpit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Fold8/{nowaNF}");
                                Directory.CreateDirectory(sciezkaPulpit);
                            }
                        }
                        catch (System.IO.DirectoryNotFoundException)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Błąd! Nie ma takiego folderu!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        catch (System.IO.IOException)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        catch (System.ArgumentException)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        catch (System.FormatException)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        finally
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nNaciśnij dowolny klawisz aby zamknąć.");
                            Console.ReadKey();
                        }


                        string[] opcje2 = new string[2]{
                                    "> Tak",
                                    "> Nie"};

                        // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))
                        MainMenu subMenu1 = new MainMenu("Czy chcesz stworzyć więcej folderów?\n", 2, opcje2);

                        // wyswietlanie
                        subMenu1.SubMenuWyswietl();
                        string wybrana1 = subMenu1.MenuWybor();
                        if (wybrana1 == opcje2[0]) { powrot1 = false; }
                        else if (wybrana1 == opcje2[1]) { powrot1 = true; }
                    } while (powrot1 == false);
                }
                else if (wybrane == opcjeMenuFK[3]) // zmiana nazwy folderu
                {
                    bool powrot4 = false;

                    do
                    {
                        Console.Clear();
                        string sciezkaPulpit4 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Fold8");

                        if (Directory.Exists(sciezkaPulpit4))
                        {
                            string[] folderyLista = Directory.GetDirectories(sciezkaPulpit4);
                            int counter = 0;

                            Console.WriteLine("Foldery w katalogu \"Fold8\":\n");
                            foreach (string folder in folderyLista)
                            {
                                string folderName = folder.Split('\\').Last();
                                counter++;
                                Console.WriteLine($"{counter}. {folderName}");
                            }



                            Console.WriteLine("\nPodaj nazwę folderu który chcesz zmienić i  naciśnij enter:");
                            string staryFolderNazwa = Console.ReadLine();
                            Console.WriteLine("\nPodaj nową nazwę i  naciśnij enter:");
                            string nowyFolderNazwa = Console.ReadLine();
                            powrot4 = true;

                            try
                            {
                                string sciezkaStara = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Fold8", staryFolderNazwa);
                                string sciezkaNowa = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Fold8", nowyFolderNazwa);
                                Directory.Move(sciezkaStara, sciezkaNowa);
                                Console.Clear();
                                Console.WriteLine($"\nGotowe!");
                            }
                            catch (System.IO.DirectoryNotFoundException)
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Błąd! Nie ma takiego folderu!");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            catch (System.IO.IOException)
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            catch (System.ArgumentException)
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            catch (System.FormatException)
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            finally
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nNaciśnij dowolny klawisz aby zamknąć.");
                                Console.ReadKey();
                            }




                        }
                        else
                        {
                            Console.WriteLine($"Brak folderów które można by modyfikować!\nNaciśnij dowolny przycisk.");
                            Console.ReadKey();
                            powrot4 = true;
                        }
                    } while (powrot4 == false);

                }
                else if (wybrane == opcjeMenuFK[4]) // usuwanie folderów
                {
                    bool powrot3 = false;
                    do
                    {
                        Dictionary<int, string> folderyUsun = new Dictionary<int, string>();
                        Console.Clear();
                        string sciezkaPulpit3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Fold8");

                        if (Directory.Exists(sciezkaPulpit3))
                        {
                            string[] folderyLista = Directory.GetDirectories(sciezkaPulpit3);
                            int counter = 0;

                            Console.WriteLine("Foldery w katalogu \"Fold8\":\n");
                            foreach (string folder in folderyLista)
                            {
                                string folderName = folder.Split('\\').Last();
                                counter++;
                                folderyUsun.Add(counter, folderName);
                                Console.WriteLine($"{counter}. {folderName}");
                            }

                            Console.WriteLine("\nPodaj numer bądź wpisz nazwę folderu do usunięcia.\nNastępnie naciśnij enter:\n");

                            string wybor = Console.ReadLine();
                            int wybranyDoUsunieciaInt;
                            string wybranyDoUsunieciaString;
                            try
                            {
                                wybranyDoUsunieciaInt = Convert.ToInt32(wybor);
                                try
                                {
                                    string wybranyDoUsunieciaI = folderyUsun[wybranyDoUsunieciaInt];
                                    sciezkaPulpit3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Fold8", wybranyDoUsunieciaI);
                                    Directory.Delete(sciezkaPulpit3, true);
                                    Console.WriteLine($"Folder \"{wybranyDoUsunieciaI}\" usunięty, naciśnij dowolny klawisz.");
                                }
                                catch (System.Collections.Generic.KeyNotFoundException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Nie ma takiego folderu!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.IO.DirectoryNotFoundException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Nie ma takiego folderu!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.IO.IOException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.ArgumentException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.FormatException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                finally
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nNaciśnij dowolny klawisz.");
                                    Console.ReadKey();
                                }
                            }
                            catch (System.FormatException)
                            {
                                wybranyDoUsunieciaString = Convert.ToString(wybor);
                                try
                                {
                                    sciezkaPulpit3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Fold8", wybranyDoUsunieciaString);
                                    Directory.Delete(sciezkaPulpit3, true);
                                    Console.WriteLine($"Folder \"{wybranyDoUsunieciaString}\" usunięty, naciśnij dowolny klawisz.");
                                    Console.ReadKey();
                                }
                                catch (System.Collections.Generic.KeyNotFoundException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Nie ma takiego folderu!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.IO.DirectoryNotFoundException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Nie ma takiego folderu!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.IO.IOException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.ArgumentException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                catch (System.FormatException)
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Błąd! Niepoprawne znaki w nazwie!");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                finally
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nNaciśnij dowolny klawisz.");
                                    Console.ReadKey();
                                }
                            }

                        }

                        string[] opcje2 = new string[2]{
                                    "> Tak",
                                    "> Nie"};

                        // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))
                        MainMenu subMenu1 = new MainMenu("Czy chcesz usunąć kolejny folder?\n", 2, opcje2);

                        // wyswietlanie
                        subMenu1.SubMenuWyswietl();
                        string wybrana1 = subMenu1.MenuWybor();
                        if (wybrana1 == opcje2[0]) { powrot3 = false; }
                        else if (wybrana1 == opcje2[1]) { powrot3 = true; }

                    } while (powrot3 == false);

                }
                else if (wybrane == opcjeMenuFK[5])
                {
                    Debug.WriteLine("ERROR: pusta opcja");
                }
                else if (wybrane == opcjeMenuFK[6])
                {
                    powrot = true;
                }
            } while (powrot == false);
        }

        public bool Powrot()
        {
            return powrot;
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
    }
}
