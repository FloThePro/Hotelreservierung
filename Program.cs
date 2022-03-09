using System.Xml.Linq;

namespace Hotelreservierung
{
    class Program { 
    

        public static void Main()
        {
            var gaesteVerwaltungsListe = new List<GaesteVerwaltung>();
            var zimmerVerwaltungsListe = new List<ZimmerVerwaltung>();
            var zimmerKategorieVerwaltungsListe = new List<ZimmerKategorieVerwaltung>();
            var reservierungsVerwaltungsListe = new List<ReservierungsVerwaltung>();
            Console.WriteLine("Willkommen zum Hausarbeitsprojekt von Florian Uhl!");
            ContinueWorkflow(gaesteVerwaltungsListe, zimmerVerwaltungsListe, zimmerKategorieVerwaltungsListe, reservierungsVerwaltungsListe);
        }

        public static string Intro()
        {
            Console.WriteLine("Bitte wählen Sie aus folgenden Aktionen aus:");
            Console.WriteLine("Gast | Zimmerkategorie | Zimmer | Reservierung");
            var temp = Console.ReadLine();
            if (temp == "Reservierung")
            {
                Console.WriteLine("Bitte geben Sie an, welche Aktion Sie durchführen wollen.");
                Console.WriteLine("anlegen | bearbeiten | löschen | ausgeben");
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
        public static void ContinueWorkflow(List<GaesteVerwaltung> gaesteVerwaltungsListe, List<ZimmerVerwaltung> zimmerVerwaltungsListe, List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe, List<ReservierungsVerwaltung> reservierungsVerwaltungsListe)
        {
            string auswahl = Intro();

            if (auswahl == "Gastanlegen")
            {
                GaesteVerwaltung.Anlegen(gaesteVerwaltungsListe);
            }
            else if (auswahl == "Gastbearbeiten")
            {
                GaesteVerwaltung.Bearbeiten(gaesteVerwaltungsListe);
            }
            else if (auswahl == "Gastlöschen")
            {
                GaesteVerwaltung.Loeschen(gaesteVerwaltungsListe);
            }
            else if (auswahl == "Gastausgeben")
            {
                GaesteVerwaltung.Ausgeben(gaesteVerwaltungsListe);
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
                ReservierungsVerwaltung.Anlegen(reservierungsVerwaltungsListe, gaesteVerwaltungsListe, zimmerKategorieVerwaltungsListe, zimmerVerwaltungsListe);
            }
            else if (auswahl == "Reservierungbearbeiten")
            {
                ReservierungsVerwaltung.Bearbeiten(reservierungsVerwaltungsListe, gaesteVerwaltungsListe, zimmerKategorieVerwaltungsListe, zimmerVerwaltungsListe);
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
                ContinueWorkflow(gaesteVerwaltungsListe, zimmerVerwaltungsListe, zimmerKategorieVerwaltungsListe, reservierungsVerwaltungsListe);
            }
            Console.WriteLine("Wollen Sie weiter machen?");
            Console.WriteLine("Falls ja, schreiben Sie bitte 'Ja'. Ansonsten 'Nein'");
            string continueSelector = Console.ReadLine();
            if (continueSelector == "Ja")
            {
                ContinueWorkflow(gaesteVerwaltungsListe, zimmerVerwaltungsListe, zimmerKategorieVerwaltungsListe, reservierungsVerwaltungsListe);
            }
            else if (continueSelector == "Nein")
            {
                //TODO: Verweis auf XML-Methode mit Verweis auf den Speicherort
                Console.WriteLine("Ihre Hotelverwaltungsliste wird nun als XML-Datei ausgegeben.");
                PrintFile(gaesteVerwaltungsListe, zimmerVerwaltungsListe, zimmerKategorieVerwaltungsListe, reservierungsVerwaltungsListe);
            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + continueSelector + " war ungültig. Die Anwendung wird nun beendet.");
                Console.WriteLine("Ihre Hotelverwaltungsliste wird nun als XML-Datei ausgegeben.");
                PrintFile(gaesteVerwaltungsListe, zimmerVerwaltungsListe, zimmerKategorieVerwaltungsListe, reservierungsVerwaltungsListe);
            }
        }
        public static void PrintFile(List<GaesteVerwaltung> gaesteListe, List<ZimmerVerwaltung> zimmerListe, List<ZimmerKategorieVerwaltung> zimmerKategorieListe, List<ReservierungsVerwaltung> reservierungsListe)
        {
            var gaesteXml = gaesteListe.ToList()
      .Select(m => new XElement("Gast-ID", new XAttribute("ID", m.Id),
            new XAttribute("Vorname", m.Vorname),
            new XAttribute("Nachname", m.Nachname),
            new XAttribute("Geburtstag", m.Geburtstag),
            new XAttribute("Strasse", m.Adresse[0]),
            new XAttribute("Hausnummer", m.Adresse[1]),
            new XAttribute("Postleitzahl", m.Adresse[2]),
            new XAttribute("Kreditkartennummer", m.Kreditkartennummer))).ToList();
            var zimmerXML = zimmerListe.ToList()
               .Select(m => new XElement("ZimmerNummer", new XAttribute("ID", m.ZimmerNummer),
                     new XAttribute("Groesse", m.Groesse),
                     new XAttribute("Ausrichtung", m.Ausrichtung),
                     new XAttribute("Zimmerkategorie", m.Kategorie.ToString()))).ToList();
            var zimmerkategorieXML = zimmerKategorieListe.ToList()
               .Select(m => new XElement("KategorieName", new XAttribute("ID", m.Name),
                     new XAttribute("MaxPersonenAnzahl", m.MaxPersonenAnzahl),
                     new XAttribute("BeschreibungAusstattung", m.BeschreibungAusstattung),
                     new XAttribute("PreisNacht", m.PreisNacht),
                     new XAttribute("PreisWoche", m.PreisWoche)
                     )).ToList();
            var reservierungXML = reservierungsListe.ToList()
               .Select(m => new XElement("ReservierungsNummer", new XAttribute("ID", m.ReservierungsNummer),
                     new XAttribute("Gast", m.Gast.ToString()),
                     new XAttribute("Zimmerkategorie", m.Zimmer.Kategorie.ToString()),
                     new XAttribute("Zimmer", m.Zimmer.ToString()),
                     new XAttribute("AnzahlPersonen", m.AnzahlPersonen),
                     new XAttribute("Anreisedatum", m.AnreiseDatum),
                     new XAttribute("Abreisedatum", m.AbreiseDatum),
                     new XAttribute("Verpflegung", m.Verpflegung),
                     new XAttribute("Gesamtkosten", m.Gesamtkosten)
                     )).ToList();
            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                     new XComment("Hotelreservierung XML representation"),
                     new XElement("Hotel",
                                 new XElement("Gaeste", gaesteXml),
                                 new XElement("Zimmer", zimmerXML),
                                 new XElement("Zimmerkategorien", zimmerkategorieXML),
                                 new XElement("Reservierungen", reservierungXML)
                                 )
                     );
            xmlDoc.Save("Hotelverwaltung.xml");
        }
    }
}