namespace Public_AllInOneManager
{
    class MainMenu
    {
        int ileOpcji;
        string komunikat = "";
        ConsoleKey klawisz;
        int wybranaOpcjaInt = 0;
        //int poprzednioWybranaOpcjaInt =0;
        string wybranaOpcja;
        string[] opcje;


        public MainMenu(string komunikat, int ileOpcji, params string[] opcjeString)
        {
            this.komunikat = komunikat;
            this.ileOpcji = ileOpcji;
            opcje = new string[ileOpcji];

            for (int i = 0; i < ileOpcji; i++)
            {
                opcje[i] = opcjeString[i];
            }
        }

        public void MenuWyswietl()
        {
            wybranaOpcjaInt = 0;
            Console.Clear();
            wybranaOpcja = opcje[0];
            OpcjaZaznaczona(wybranaOpcjaInt, komunikat);

            while (true)
            {

                klawisz = Console.ReadKey(intercept: true).Key;
                if (klawisz == ConsoleKey.UpArrow || klawisz == ConsoleKey.W)
                {
                    if (ileOpcji > 1)
                    {
                        if (wybranaOpcjaInt > 0) { wybranaOpcjaInt--; }
                        else { wybranaOpcjaInt = 0; }
                    }
                    else { }
                }

                else if (klawisz == ConsoleKey.DownArrow || klawisz == ConsoleKey.S)
                {
                    if (ileOpcji > 1)
                    {
                        if (wybranaOpcjaInt < ileOpcji - 1) { wybranaOpcjaInt++; }
                        else { wybranaOpcjaInt = ileOpcji - 1; }
                    }
                    else { }
                }
                OpcjaZaznaczona(wybranaOpcjaInt, komunikat);
                if ((klawisz == ConsoleKey.Enter || klawisz == ConsoleKey.Spacebar) && wybranaOpcjaInt != ileOpcji - 2)
                {
                    Console.Clear();
                    break;
                }
                else { /*PASS*/ }
            }


        }
        public void SubMenuWyswietl()
        {
            Console.Clear();
            wybranaOpcjaInt = 0;
            wybranaOpcja = opcje[0];
            OpcjaZaznaczona(wybranaOpcjaInt, komunikat);

            while (true)
            {

                klawisz = Console.ReadKey(intercept: true).Key;
                if (klawisz == ConsoleKey.UpArrow || klawisz == ConsoleKey.W)
                {
                    if (ileOpcji > 1)
                    {
                        if (wybranaOpcjaInt > 0) { wybranaOpcjaInt--; }
                        else { wybranaOpcjaInt = 0; }
                    }
                    else { }
                }

                else if (klawisz == ConsoleKey.DownArrow || klawisz == ConsoleKey.S)
                {
                    if (ileOpcji > 1)
                    {
                        if (wybranaOpcjaInt < ileOpcji - 1) { wybranaOpcjaInt++; }
                        else { wybranaOpcjaInt = ileOpcji - 1; }
                    }
                    else { }
                }
                OpcjaZaznaczona(wybranaOpcjaInt, komunikat);
                if ((klawisz == ConsoleKey.Enter || klawisz == ConsoleKey.Spacebar))
                {
                    Console.Clear();
                    break;
                }
                else { /*PASS*/ }
            }


        }
        public void OpcjaZaznaczona(int opcja, string komun)
        {

            Console.Clear();
            Console.WriteLine(komun);
            for (int i = 0; i < ileOpcji; i++)
            {
                if (opcja == i)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{opcje[i],-26} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;

                    wybranaOpcja = opcje[i];
                }


                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"{opcje[i],-26} ");
                }
            }

            Console.WriteLine();
        }
        public string MenuWybor()
        {
            return wybranaOpcja;
        }
    }
}



