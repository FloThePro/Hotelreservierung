namespace Hotelreservierung
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Willkommen zum Hausarbeitsprojekt von Florian Uhl!");
            ContinueWorkflow();
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
            return temp;
        }
        public static void ContinueWorkflow()
        {
            var zimmerVerwaltungsListe = new List<ZimmerVerwaltung>();
            var gaesteVerwaltungsListe = new List<GaesteVerwaltung>();
            var zimmerKategorieVerwaltungsListe = new List<ZimmerKategorieVerwaltung>();
            var reservierungsVerwaltungsListe = new List<ReservierungsVerwaltung>();
            string auswahl = Intro();

            if (auswahl == "Gastanlegen")
            {
                GaesteVerwaltung.Anlegen(gaesteVerwaltungsListe);
            }
            else if (auswahl == "Gastbearbeiten")
            {
                GaesteVerwaltung.Anlegen(gaesteVerwaltungsListe);
            }
            else if (auswahl == "Gastlöschen")
            {
                GaesteVerwaltung.Loeschen(gaesteVerwaltungsListe);
            }
            else if (auswahl == "Gastausgeben")
            {
                GaesteVerwaltung.Loeschen(gaesteVerwaltungsListe);
            }
            else if (auswahl == "Zimmeranlegen")
            {
                ZimmerVerwaltung.Anlegen(zimmerVerwaltungsListe, zimmerKategorieVerwaltungsListe);
            }
            else if (auswahl == "Zimmerbearbeiten")
            {
                ZimmerVerwaltung.Bearbeiten(zimmerVerwaltungsListe, zimmerKategorieVerwaltungsListe);
            }
            else if (auswahl == "Zimmerlöschen")
            {
                ZimmerVerwaltung.Loeschen(zimmerVerwaltungsListe);
            }
            else if (auswahl == "Zimmerausgeben")
            {
                ZimmerVerwaltung.Ausgeben(zimmerVerwaltungsListe);
            }
            else if (auswahl == "Zimmerkategorieanlegen")
            {
                ZimmerKategorieVerwaltung.Anlegen(zimmerKategorieVerwaltungsListe);
            }
            else if (auswahl == "Zimmerkategoriebearbeiten")
            {
                ZimmerKategorieVerwaltung.Bearbeiten(zimmerKategorieVerwaltungsListe);
            }
            else if (auswahl == "Zimmerkategorielöschen")
            {
                ZimmerKategorieVerwaltung.Loeschen(zimmerKategorieVerwaltungsListe);
            }
            else if (auswahl == "Zimmerkategorieausgeben")
            {
                ZimmerKategorieVerwaltung.Ausgeben(zimmerKategorieVerwaltungsListe);
            }
            else if (auswahl == "Reservierunganlegen")
            {
                ReservierungsVerwaltung.Anlegen(reservierungsVerwaltungsListe);
            }
            else if (auswahl == "Reservierungbearbeiten")
            {
                ReservierungsVerwaltung.Bearbeiten(reservierungsVerwaltungsListe);
            }
            else if (auswahl == "Reservierunglöschen")
            {
                ReservierungsVerwaltung.Loeschen(reservierungsVerwaltungsListe);
            }
            else if (auswahl == "Reservierungausgeben")
            {
                ReservierungsVerwaltung.Ausgeben(reservierungsVerwaltungsListe);
            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + auswahl + " ist ungültig. Bitte versuchen Sie es noch einmal.");
                ContinueWorkflow();
            }
            Console.WriteLine("Wollen Sie weiter machen?");
            Console.WriteLine("Falls ja, schreiben Sie bitte 'Ja'. Ansonsten 'Nein'");
            string continueSelector = Console.ReadLine();
            if (continueSelector == "Ja")
            {
                ContinueWorkflow();
            }
            else if (continueSelector == "Nein")
            {
                //TODO: Verweis auf XML-Methode mit Verweis auf den Speicherort
            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + continueSelector + " war ungültig. Die Anwendung wird nun beendet.");
                //TODO: Verweis auf XML-Methode
            }
        }
    }
}