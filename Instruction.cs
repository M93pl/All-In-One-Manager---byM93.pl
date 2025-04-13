namespace Public_AllInOneManager;

public class Instruction
{
    public bool powrot = false;

    public void Menu()
    {
        do
        {
            string[] opcjeMenuI = new string[4] {
                "> M-Diag",
                "> Fold8",
                "> Historia logowania",
                "\n<< Powrót" };
            MainMenu subMenuI = new MainMenu("Wybierz instrukcję:\n", 4, opcjeMenuI);
            subMenuI.SubMenuWyswietl();
            string wybrane = subMenuI.MenuWybor();
            if (wybrane == opcjeMenuI[0])
            {
                Console.Clear();
                Console.WriteLine("M - Diag\n");
                Console.WriteLine(
                    "Program do diagnostyki systemu oraz hardware.\n" +
                    "Wyświetla podstawowe informacje o urządzeniu.\n" +
                    "SystemInfo1 sprawdza integralność dysku twardego.\n" +
                    "SystemInfo2 testuje pamięć ram i procesor.\n");
                Console.WriteLine("\nNaciśnij dowolny klawisz aby powrócić do menu głównego.");
                Console.ReadKey();
                powrot = true;
            }
            else if (wybrane == opcjeMenuI[1])
            {
                Console.Clear();
                Console.WriteLine("Fold8\n");
                Console.WriteLine(
                    "Program do tworzenia dużych ilości folderów.\n" +
                    "Zależnie od wybranej opcji program stworzy nowe katalogi,\n" +
                    "w folderze \"Fold8\" na pulpicie komputera.\n" +
                    "Program jest w stanie stworzyć tyle folderów na ile pozwoli\n" +
                    "moc obliczeniowa komputera.\n" +
                    "W testach 40 tysięcy folderów utworzył w 4,5 minuty.\n" +
                    "Maksymalna ilość folderów jaką udało się utworzyć\n" +
                    "w trakcie testów wyniosła ponad 1,2 miliona katalogów.\n" +
                    "Zalecana jest jednak ostrożność:\n" +
                    "usuwanie takiej liczby folderów trwa ponad 40 minut,\n" +
                    "zakładając że używamy komputera wysokiej klasy.\n");
                Console.WriteLine("\nNaciśnij dowolny klawisz aby powrócić do menu głównego.");
                Console.ReadKey();
                powrot = true;
            }
            else if (wybrane == opcjeMenuI[2])
            {
                Console.Clear();
                Console.WriteLine("Historia logowania\n");
                Console.WriteLine(
                    "Wyświetla listę poprawnych zalogowań.\n" +
                    "Pokazuje także statystyki dotyczące uruchomień programu.\n" +
                    "Aby zresetować statystyki, należy usunąć plik \"log_list.m93\".\n" +
                    "Znajduje się on w głównym katalogu z zainstalowanym programem.\n");
                Console.WriteLine("\nNaciśnij dowolny klawisz aby powrócić do menu głównego.");
                Console.ReadKey();
                powrot = true;
            }
            else if (wybrane == opcjeMenuI[3])
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
