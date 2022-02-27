namespace Hotelreservierung
{
    class Program
    {
        static void Main()
        {
            string auswahl;
            Console.WriteLine("Willkommen zum Hausarbeitsprojekt von Florian Uhl!");
            auswahl = Intro();
        }

        public static string Intro()
        {
            Console.WriteLine("Bitte wählen Sie aus folgenden Aktionen aus:");
            Console.WriteLine("Gast | Zimmer | Zimmerkategorie | Reservierung");
            var temp = Console.ReadLine();
            if (temp == "Reservierung")
            {
                Console.WriteLine("Bitte geben Sie an, welche Aktion Sie durchführen wollen.");
                Console.WriteLine("anlegen | bearbeiten | löschen | zuordnen | ausgeben");
                temp += Console.ReadLine();
            }
            else if (temp == "Zimmer" || temp == "Zimmerkategorie" || temp == "Gast")
            {
                Console.WriteLine("Bitte geben Sie an, welche Aktion Sie durchführen wollen.");
                Console.WriteLine("anlegen | bearbeiten | löschen | ausgeben");
                temp += Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ihre Eingabe ist ungültig. Bitte versuchen Sie es noch einmal.");
            }
            Console.WriteLine("Bitte geben Sie an, welche Aktion Sie durchführen wollen.");
            Console.WriteLine("anlegen | bearbeiten | löschen | ausgeben");
            temp += Console.ReadLine();
            return temp;
        }
    }
}