using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Public_AllInOneManager
{
    public class Autor
    {
        public string wybrane;
        public bool powrot;

        public void Menu()
        {
            string[] opcjeMenu = new string[1]{
                    "\n<< Powrót"};
            Debug.WriteLine("autoy");
            string tytul1 = "Informacje o autorze:";
            string tytul2 = "www.M93.pl";
            string tytul3 = $"Program napisany w jezyku C#\nWszelkie prawa autorskie zastrzeżone\n\nM93.pl\t(c)\t2025" +
                            $"\n{RuntimeInformation.FrameworkDescription}";
            // (string komunikat na górze, int ile jest elementow menu, array z iloscia elementow jako stringi (string[]))
            MainMenu menuGlowne = new MainMenu($"{tytul1}\n\n{tytul2,12}\n\n{tytul3}", 1, opcjeMenu);

            // wyswietlanie
            menuGlowne.MenuWyswietl();

            // return wybranej opcji
            wybrane = menuGlowne.MenuWybor();

            if (wybrane == opcjeMenu[0])
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
