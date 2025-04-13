using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace Public_AllInOneManager
{
    class SystemInfo
    {
        public string wybrane;
        public bool powrot;
        public void Menu()
        {
            do
            {
                string[] opcjeMenu = new string[3]{
                    "> Informacje o urządzeniu",
                    "",
                    "<< Powrót"};

                string tytul1 = "M-Diag 1.0\n" +
                    "Program do diagnostyki systemu i hardware.\n" +
                    "Wybierz funkcje:\n";
                MainMenu menuGlowne = new MainMenu($"{tytul1}", 3, opcjeMenu);

                // wyswietlanie
                menuGlowne.MenuWyswietl();

                // return wybranej opcji
                wybrane = menuGlowne.MenuWybor();

                if (wybrane == opcjeMenu[0])
                {
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\t-- SYSTEM OPERACYJNY --");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"OS: {RuntimeInformation.OSDescription}");
                    Console.WriteLine($"Wersja: {Environment.OSVersion}");
                    Console.WriteLine($"Architektura systemu: {RuntimeInformation.OSArchitecture,12}");
                    Console.WriteLine($"Zalogowany użytkownik: {Environment.UserName,11}");
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\t-- CPU --");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        Console.WriteLine($"Procesor: {obj["Name"]}");
                        Console.WriteLine($"Liczba rdzeni: {obj["NumberOfCores"],19}");
                        Console.WriteLine($"Liczba wątków: {obj["NumberOfLogicalProcessors"],19}");
                        Console.WriteLine($"Aktualne taktowanie: {obj["CurrentClockSpeed"],9} MHz");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"Producent: {obj["Manufacturer"]}");
                        Console.WriteLine($"Architektura: {RuntimeInformation.ProcessArchitecture,20}");
                        Console.WriteLine($"Seria: {obj["Caption"]}");
                        Console.WriteLine($"Typ: {obj["ProcessorType"],29}");
                    }
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\t-- HDD --");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
                    foreach (ManagementObject disk in searcher1.Get())
                    {
                        Console.WriteLine($"Dysk: {disk["DeviceID"],28}");
                        try { Console.WriteLine($"Model: {disk["Model"]}"); }
                        catch (Exception) { Console.WriteLine("Nie znaleziono modelu."); }
                        try { Console.WriteLine($"Typ interfejsu: {disk["InterfaceType"],19}"); }
                        catch (Exception) { Console.WriteLine("Nie znaleziono interfejsu."); }
                        try { Console.WriteLine($"Typ nośnika: {disk["MediaType"],21}"); }
                        catch (Exception) { Console.WriteLine("Nie ustalono typu nośnika."); }
                        try { Console.WriteLine($"System plików: {disk["FileSystem"],19}"); }
                        catch (Exception) { Console.WriteLine("Nie ustalono systemu plików."); }

                        Console.WriteLine($"Wolne miejsce: {Convert.ToInt64(disk["FreeSpace"]) / (1024 * 1024 * 1024),16} GB");
                        Console.WriteLine($"Całkowity rozmiar: {Convert.ToInt64(disk["Size"]) / (1024 * 1024 * 1024),12} GB");
                        Console.WriteLine("----------------------------------");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nNaciśnij dowolny klawisz aby zamknąć.");
                    Console.ReadKey();

















                }
                else if (wybrane == opcjeMenu[2])
                {
                    powrot = true;
                }
            } while (powrot == false);

        }

        public bool Powrot()
        {
            return powrot;
        }
    }
}
