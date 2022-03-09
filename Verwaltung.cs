namespace Hotelreservierung
{
    public abstract class IVerwaltung
    {
        public abstract void Anlegen(List<IVerwaltung> verwaltungsList);
        public abstract void Bearbeiten(List<IVerwaltung> verwaltungsList);
        public abstract void Loeschen(List<IVerwaltung> verwaltungsList);
        public abstract void Ausgeben(List<IVerwaltung> verwaltungsList);

    }
    public class GaesteVerwaltung
    {
        public uint Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname{ get; set; }
        public string [] Adresse { get; set; } = new string [3];
        public DateTime Geburtstag { get; set; }
        public ulong Kreditkartennummer { get; set; }

        public GaesteVerwaltung(uint id, string vorname, string nachname, string strasse, string hausnummer, string postleitzahl, DateTime geburtstag, ulong kreditkartennummer)
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Adresse[0] = strasse;
            Adresse[1] = hausnummer;
            Adresse[2] = postleitzahl;
            Geburtstag = geburtstag;
            Kreditkartennummer = kreditkartennummer;
        }
        public override string ToString()
        {
            return Vorname + " " + Nachname;
        }

        public static void Anlegen(List<GaesteVerwaltung> gaesteListe)
        {
            uint id;
            string vorname, nachname, strasse, hausnummer, postleitzahl;
            DateTime geburtstag;
            ulong kreditkartennummer;
            Console.WriteLine("Sie haben ausgewählt, dass Sie einen Gast anlegen wollen.");
            Console.WriteLine("Bitte geben Sie die ID des Gastes an:");
            id = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie den Vornamen des Gastes an:");
            vorname = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Nachnamen des Gastes an:");
            nachname = Console.ReadLine();
            Console.WriteLine("Im Folgenden wird nun die Adresse des Gastes abgefragt.");
            Console.WriteLine("Bitte geben Sie zunächst die Straße des Gastes an");
            strasse= Console.ReadLine();
            Console.WriteLine("Bitte geben Sie die Hausnummer des Gastes an");
            hausnummer = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie die Postleitzahl des Gastes an");
            postleitzahl = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie das Geburtsdatum des Gastes an:");
            geburtstag = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie die Kreditkartennummer des Gastes an:");
            kreditkartennummer = Convert.ToUInt64(Console.ReadLine());
            gaesteListe.Add(new GaesteVerwaltung(id, vorname, nachname, strasse, hausnummer, postleitzahl, geburtstag, kreditkartennummer));
        }

        public static void Bearbeiten(List<GaesteVerwaltung> gaesteListe)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie einen Gast bearbeiten wollen.");
            Console.WriteLine("Bitte geben Sie die ID des Gastes an, den Sie bearbeiten wollen.");
            uint temp = Convert.ToUInt32(Console.ReadLine());
            var element = gaesteListe.Find(e => e.Id == temp);
            Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Was wollen Sie ändern?");
            Console.WriteLine("Schreiben Sie 'Vorname', 'Nachname', 'Adresse', 'Geburtstag' oder 'Kreditkartennummer'.");
            string eingabe = Console.ReadLine();
            Console.WriteLine("Geben Sie den gewünschten neuen Wert ein.");
            if (eingabe == "Vorname")
            {
                element.Vorname = Console.ReadLine();
                Console.WriteLine("Sie haben den Vornamen auf " + element.Vorname + " geändert.");
            }
            else if (eingabe == "Nachname")
            {
                element.Nachname = Console.ReadLine();
                Console.WriteLine("Sie haben den Nachnamen auf " + element.Nachname + " geändert.");
            }
            else if (eingabe == "Adresse")
            {
                Console.WriteLine("Geben Sie den gewünschten neuen Wert für die Straße ein");
                element.Adresse[0] = Console.ReadLine();
                Console.WriteLine("Geben Sie den gewünschten neuen Wert für die Hausnummer ein");
                element.Adresse[1] = Console.ReadLine();
                Console.WriteLine("Geben Sie den gewünschten neuen Wert für die Postleitzahl ein");
                element.Adresse[2] = Console.ReadLine();
                Console.WriteLine("Sie haben die Adresse auf " + element.Adresse[0] + " " + element.Adresse[1] + " " + element.Adresse[2] +" geändert.");
            }
            else if (eingabe == "Geburtstag")
            {
                element.Geburtstag = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Sie haben den Geburtstag auf " + element.Geburtstag + " geändert.");
            }
            else if (eingabe == "Kreditkartennummer")
            {
                element.Kreditkartennummer = Convert.ToUInt64(Console.ReadLine());
                Console.WriteLine("Sie haben den angestrebten Abschluss auf " + element.Kreditkartennummer + " geändert.");
            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + eingabe + " ist ungültig");
            }
        }

        public static void Loeschen(List<GaesteVerwaltung> gaesteListe)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie einen Gast löschen wollen.");
            Console.WriteLine("Bitte geben Sie die ID des Gastes an, den Sie löschen wollen.");
            int temp = Convert.ToInt32(Console.ReadLine());
            var element = gaesteListe.Find(e => e.Id == temp);
            Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Wollen Sie diesen Gast löschen? Geben Sie Ja oder Nein ein.");
            string eingabe = Console.ReadLine();
            if (eingabe == "Ja")
            {
                gaesteListe.Remove(element);
                Console.WriteLine("Der Gast wurde erfolgreich gelöscht.");
            }
            else if (eingabe == "Nein")
            {

            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + eingabe + " ist falsch. Bitte wiederholen Sie den Vorgang.");
                Program.Intro();
            }
        }

        public static void Ausgeben(List<GaesteVerwaltung> gaesteListe)
        {
            for (int i = 0; i < gaesteListe.Count; i++)
            {
                Console.WriteLine(gaesteListe[i].Id + "/t" + gaesteListe[i].Vorname + "/t" + gaesteListe[i].Nachname + "/t" + gaesteListe[i].Adresse[0]+ "/t" + gaesteListe[i].Adresse[1] + "/t" + gaesteListe[i].Adresse[2] + "/t" + gaesteListe[i].Kreditkartennummer);
            }
        }
    }

    public class ZimmerVerwaltung 
    {
        public ZimmerKategorieVerwaltung Kategorie;
        public ushort ZimmerNummer { get; set; }
        public ushort Groesse { get; set; }
        public string Ausrichtung { get; set; }

        public ZimmerVerwaltung(ushort zimmerNummer, ushort groesse, string ausrichtung, ZimmerKategorieVerwaltung kategorie)
        {
            ZimmerNummer = zimmerNummer;
            Groesse = groesse;
            Ausrichtung = ausrichtung;
            Kategorie = kategorie;
        }

        public override string ToString()
        {
            return Convert.ToString(ZimmerNummer);
        }

        public static void Anlegen(List<ZimmerVerwaltung> zimmerVerwaltungsListe, List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe)
        {
            string ausrichtung;
            ushort groesse, zimmerNummer;
            ZimmerKategorieVerwaltung kategorie;
            Console.WriteLine("Sie haben ausgewählt, dass Sie ein Zimmer anlegen wollen.");
            Console.WriteLine("Bitte geben Sie die Nummer des Zimmers an:");
            zimmerNummer = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie die Größe des Zimmers an:");
            groesse = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie die Ausrichtung des Zimmers an:");
            ausrichtung = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Namen der Zimmerkategorie an, der dieses Zimmer angehört.");
            string temp = Console.ReadLine();
            kategorie = zimmerKategorieVerwaltungsListe.Find(e => e.Name == temp);
            zimmerVerwaltungsListe.Add(new ZimmerVerwaltung(zimmerNummer, groesse, ausrichtung, kategorie));
        }

        public static void Bearbeiten(List<ZimmerVerwaltung> zimmerVerwaltungsListe, List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie ein Zimmer bearbeiten wollen.");
            Console.WriteLine("Bitte geben Sie die Nummer des Zimmers an, das Sie bearbeiten wollen.");
            ushort zimmerNummerEingabe = Convert.ToUInt16(Console.ReadLine());
            var element = zimmerVerwaltungsListe.Find(e => e.ZimmerNummer == zimmerNummerEingabe);
            Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Was wollen Sie ändern?");
            Console.WriteLine("Schreiben Sie 'Zimmernummer', 'Größe', 'Ausrichtung' oder 'Kategorie'.");
            string eingabe = Console.ReadLine();
            if (eingabe == "Kategorie")
            {
                Console.WriteLine("Bitte geben Sie den Namen der Zimmerkategorie an, der dieses Zimmer zugewiesen werden soll.");
                string zimmerKategorieEingabe = Console.ReadLine();
                element.Kategorie = zimmerKategorieVerwaltungsListe.Find(e => e.Name == zimmerKategorieEingabe);
                Console.WriteLine("Sie haben die Zimmerkategorie auf " + element.ToString() + " geändert.");
            }
            else
            {
                Console.WriteLine("Geben Sie den gewünschten neuen Wert ein.");
                if (eingabe == "Zimmernummer")
                {
                    element.ZimmerNummer = Convert.ToUInt16(Console.ReadLine());
                    Console.WriteLine("Sie haben die Zimmernummer auf " + element.ZimmerNummer + " geändert.");
                }
                else if (eingabe == "Größe")
                {
                    element.Groesse = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("Sie haben die Größe auf " + element.Groesse + " geändert.");
                }
                else if (eingabe == "Ausrichtung")
                {
                    element.Ausrichtung = Console.ReadLine();
                    Console.WriteLine("Sie haben die Ausrichtung auf " + element.Ausrichtung + " geändert.");
                }
                else
                {
                    Console.WriteLine("Ihre Eingabe " + eingabe + " ist ungültig");
                }
            }
        }

        public static void Loeschen(List<ZimmerVerwaltung> zimmerVerwaltungsListe)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie ein Zimmer löschen wollen.");
            Console.WriteLine("Bitte geben Sie die Zimmernummer des Zimmers an, das Sie löschen wollen.");
            ushort temp = Convert.ToUInt16(Console.ReadLine());
            var element = zimmerVerwaltungsListe.Find(e => e.ZimmerNummer == temp);
            Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Wollen Sie dieses Zimmer löschen? Geben Sie Ja oder Nein ein.");
            string eingabe = Console.ReadLine();
            if (eingabe == "Ja")
            {
                zimmerVerwaltungsListe.Remove(element);
                Console.WriteLine("Das Zimmer wurde erfolgreich gelöscht.");
            }
            else if (eingabe == "Nein")
            {

            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + eingabe + " ist falsch. Bitte wiederholen Sie den Vorgang.");
                Program.Intro();
            }
        }

        public static void Ausgeben(List<ZimmerVerwaltung> zimmerVerwaltungsListe)
        {
            for (int i = 0; i < zimmerVerwaltungsListe.Count; i++)
            {
                Console.WriteLine(zimmerVerwaltungsListe[i].ZimmerNummer + "/t" + zimmerVerwaltungsListe[i].Groesse+ "/t" + zimmerVerwaltungsListe[i].Ausrichtung+ "/t" + zimmerVerwaltungsListe[i].Kategorie.ToString());
            }
        }

    }

    public class ZimmerKategorieVerwaltung 
    {
        public string Name { get; set; }
        public byte MaxPersonenAnzahl { get; set; }
        public string BeschreibungAusstattung { get; set; }
        public double PreisNacht { get; set; }
        public double PreisWoche { get; set; }

        public ZimmerKategorieVerwaltung(string name, byte maxPersonenAnzahl, string beschreibungAusstattung, double preisNacht, double preisWoche)
        {
            Name = name;
            MaxPersonenAnzahl = maxPersonenAnzahl;
            BeschreibungAusstattung = beschreibungAusstattung;
            PreisNacht = preisNacht;
            PreisWoche = preisWoche;
        }

        public override string ToString()
        {
            return Name;
        }
        public static void Anlegen(List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe)
        {
            string name, beschreibungAusstattung;
            byte maxPersonenAnzahl;
            double preisNacht, preisWoche;
            Console.WriteLine("Sie haben ausgewählt, dass Sie eine Zimmerkategorie anlegen wollen.");
            Console.WriteLine("Bitte geben Sie den Namen der Zimmerkategorie an:");
            name = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie die maximale Personenanzahl der Zimmerkategorie an:");
            maxPersonenAnzahl = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie eine Beschreibung der Ausstattung an:");
            beschreibungAusstattung = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie den Preis pro Nacht für diese Zimmerkategorie an");
            preisNacht = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie den Preis pro Woche für diese Zimmerkategorie an");
            preisWoche = Convert.ToDouble(Console.ReadLine());
            zimmerKategorieVerwaltungsListe.Add(new ZimmerKategorieVerwaltung(name, maxPersonenAnzahl, beschreibungAusstattung, preisNacht, preisWoche));
        }

        public static void Bearbeiten(List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie eine Zimmerkategorie bearbeiten wollen.");
            Console.WriteLine("Bitte geben Sie den Namen der Zimmerkategorie an, die Sie bearbeiten wollen.");
            string temp = Console.ReadLine();
            var element = zimmerKategorieVerwaltungsListe.Find(e => e.Name == temp);
            Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Was wollen Sie ändern?");
            Console.WriteLine("Schreiben Sie 'Name', 'Max Personenanzahl', 'Beschreibung Ausstattung', 'Preis Nacht' oder 'Preis Woche'.");
            Console.WriteLine("Bitte beachten Sie, dass in den Feldern Preis Nacht und Preis Woche nur Zahlenwerte stehen dürfen.");
            string eingabe = Console.ReadLine();
            Console.WriteLine("Geben Sie den gewünschten neuen Wert ein.");
            if (eingabe == "Name")
            {
                element.Name = Console.ReadLine();
                Console.WriteLine("Sie haben den Namen auf " + element.Name + " geändert.");
            }
            else if (eingabe == "Max Personenanzahl")
            {
                element.MaxPersonenAnzahl = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Sie haben die maximale Personenanzahl auf " + element.MaxPersonenAnzahl + " geändert.");
            }
            else if (eingabe == "Beschreibung Ausstattung")
            {
                element.BeschreibungAusstattung = Console.ReadLine();
                Console.WriteLine("Sie haben die Beschreibung der Ausstattung auf " + element.BeschreibungAusstattung + " geändert.");
            }
            else if (eingabe == "Preis Nacht")
            {
                element.PreisNacht = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Sie haben den Preis pro Nacht auf " + element.PreisNacht + "€ geändert.");
            }
            else if (eingabe == "Preis Woche")
            {
                element.PreisWoche = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Sie haben den Preis pro Woche auf " + element.PreisWoche + " geändert.");
            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + eingabe + " ist ungültig");
            }
        }

        public static void Loeschen(List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie eine Zimmerkategorie löschen wollen.");
            Console.WriteLine("Bitte geben Sie die den Namen der Kategorie an, die Sie löschen wollen.");
            string temp = Console.ReadLine();
            var element = zimmerKategorieVerwaltungsListe.Find(e => e.Name == temp);
            Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Wollen Sie diese Kategorie löschen? Geben Sie Ja oder Nein ein.");
            string eingabe = Console.ReadLine();
            if (eingabe == "Ja")
            {
                zimmerKategorieVerwaltungsListe.Remove(element);
                Console.WriteLine("Die Kategorie wurde erfolgreich gelöscht.");
            }
            else if (eingabe == "Nein")
            {

            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + eingabe + " ist falsch. Bitte wiederholen Sie den Vorgang.");
                Program.Intro();
            }
        }

        public static void Ausgeben(List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe)
        {
            for (int i = 0; i < zimmerKategorieVerwaltungsListe.Count; i++)
            {
                Console.WriteLine(zimmerKategorieVerwaltungsListe[i].Name + "/t" + zimmerKategorieVerwaltungsListe[i].MaxPersonenAnzahl + "/t" + zimmerKategorieVerwaltungsListe[i].BeschreibungAusstattung + "/t" + zimmerKategorieVerwaltungsListe[i].PreisNacht + "/t" + zimmerKategorieVerwaltungsListe[i].PreisWoche);
            }
        }
    }

    public class ReservierungsVerwaltung 
    {
        public uint ReservierungsNummer { get; set; }
        public byte AnzahlPersonen { get; set; }
        public DateTime AnreiseDatum { get; set; }
        public DateTime AbreiseDatum { get; set; }
        public string Verpflegung { get; set; }
        public double Gesamtkosten { get; set; }
        public GaesteVerwaltung Gast { get; set; }
        public ZimmerVerwaltung Zimmer { get; set; }

        public ReservierungsVerwaltung(uint reservierungsnummer, GaesteVerwaltung gast, ZimmerVerwaltung zimmer, byte anzahlPersonen, DateTime anreiseDatum, DateTime abreiseDatum, string verpflegung, double gesamtkosten)
        {
            ReservierungsNummer = reservierungsnummer;
            Gast = gast;
            Zimmer = zimmer;
            AnzahlPersonen = anzahlPersonen;
            AnreiseDatum = anreiseDatum;
            AbreiseDatum = abreiseDatum;
            Verpflegung = verpflegung;
            Gesamtkosten = gesamtkosten;
        }

        //Überladung der ToString Methode zur Ausgabe der Reservierungsnummer
        public override string ToString()
        {
            return Convert.ToString(ReservierungsNummer);
        }

        //Anlegen einer Reservierung
        public static void Anlegen(List<ReservierungsVerwaltung> reservierungsListe, List<GaesteVerwaltung> gaesteListe, List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe, List<ZimmerVerwaltung> zimmerVerwaltungsListe)
        {
            uint reservierungsnummer;
            byte anzahlPersonen;
            string verpflegung;
            DateTime anreiseDatum, abreiseDatum;
            double gesamtkosten;
            GaesteVerwaltung gast;
            ZimmerKategorieVerwaltung zimmerKategorie;
            ZimmerVerwaltung zimmer;

            Console.WriteLine("Sie haben ausgewählt, dass Sie eine Reservierung anlegen wollen.");
            Console.WriteLine("Bitte geben Sie die Reservierungsnummer an:");
            reservierungsnummer = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie die ID des Gastes an, den Sie dieser Reservierung zuweisen wollen.");
            uint gastId = Convert.ToUInt32(Console.ReadLine());
            gast = gaesteListe.Find(e => e.Id == gastId);
            Console.WriteLine("Bitte geben Sie die Nummer des Zimmers an, das Sie dieser Reservierung zuweisen wollen.");
            ushort zimmerNummer = Convert.ToUInt16(Console.ReadLine());
            zimmer = zimmerVerwaltungsListe.Find(e => e.ZimmerNummer == zimmerNummer);
            Console.WriteLine("Bitte geben Sie die Anzahl der Personen, für die der Platz reserviert wird, an:");
            anzahlPersonen = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie das Anreisedatum der Gäste an:");
            anreiseDatum = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie das Abreisedatum der Gäste an");
            abreiseDatum= Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie die Verpflegungsauswahl der Gäste an. Zur Auswahl stehen Ohne | Früstück | Halbpension");
            verpflegung = Console.ReadLine();
            if (verpflegung == "Ohne" || verpflegung == "Frühstück" || verpflegung == "Halbpension")
            {

            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + verpflegung + " ist ungültig. Versuchen Sie es bitte errneut.");
                Anlegen(reservierungsListe, gaesteListe, zimmerKategorieVerwaltungsListe, zimmerVerwaltungsListe);
            }
            Console.WriteLine("Bitte geben Sie die Gesamtkosten der Reservierung an");
            gesamtkosten = Convert.ToDouble(Console.ReadLine());
            reservierungsListe.Add(new ReservierungsVerwaltung(reservierungsnummer, gast, zimmer, anzahlPersonen, anreiseDatum, abreiseDatum, verpflegung, gesamtkosten));
        }

        public static void Bearbeiten(List<ReservierungsVerwaltung> reservierungsListe, List<GaesteVerwaltung> gaesteListe, List<ZimmerKategorieVerwaltung> zimmerKategorieVerwaltungsListe, List<ZimmerVerwaltung> zimmerVerwaltungsListe)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie eine Reservierung bearbeiten wollen.");
            Console.WriteLine("Bitte geben Sie die Nummer der Reservierung an, die Sie bearbeiten wollen.");
            uint temp = Convert.ToUInt32(Console.ReadLine());
            var reservierungsListenElement = reservierungsListe.Find(e => e.ReservierungsNummer == temp);
            Console.WriteLine("Sie haben " + reservierungsListenElement.ToString() + " ausgewählt. Was wollen Sie ändern?");
            Console.WriteLine("Schreiben Sie 'Gast', 'Zimmer', 'Reservierungsnummer', 'Anzahl Personen', 'Anreisedatum', 'Abreisedatum', 'Verpflegung' oder 'Gesamtkosten'.");
            string eingabe = Console.ReadLine();
            if (eingabe == "Gast")
            {
                Console.WriteLine("Welchen Gast wollen Sie dieser Reservierung zuweisen? Geben Sie hier die ID des Gastes ein.");
                uint gastId = Convert.ToUInt32(Console.ReadLine());
                var gaesteListenElement = gaesteListe.Find(e => e.Id == gastId);
                reservierungsListenElement.Gast = gaesteListenElement;
                Console.WriteLine("Sie haben den Gast auf " + gaesteListenElement.ToString + " geändert.");
            }
            else if(eingabe == "Zimmer")
            {
                Console.WriteLine("Welches Zimmer wollen Sie dieser Reservierung zuweisen? Geben Sie hier die Zimmernummer ein.");
                uint zimmerNummer = Convert.ToUInt32(Console.ReadLine());
                var zimmerListenElement = zimmerVerwaltungsListe.Find(e => e.ZimmerNummer == zimmerNummer);
                reservierungsListenElement.Zimmer = zimmerListenElement;
                Console.WriteLine("Sie haben das Zimmer auf " + zimmerListenElement.ToString + " geändert.");
            }
            else
            {
                Console.WriteLine("Geben Sie den gewünschten neuen Wert ein.");
                if (eingabe == "Reservierungsnummer")
                {
                    reservierungsListenElement.ReservierungsNummer = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Sie haben die Reservierungsnummer auf " + reservierungsListenElement.ReservierungsNummer + " geändert.");
                }
                else if (eingabe == "Anzahl Personen")
                {
                    reservierungsListenElement.AnzahlPersonen = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("Sie haben die Anzahl der Personen auf " + reservierungsListenElement.AnzahlPersonen+ " geändert.");
                }
                else if (eingabe == "Anreisedatum")
                {
                    reservierungsListenElement.AnreiseDatum = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Sie haben das Anreisedatum auf " + reservierungsListenElement.AnreiseDatum + " geändert.");
                }
                else if (eingabe == "Abreisedatum")
                {
                    reservierungsListenElement.AbreiseDatum = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Sie das Abreisedatum auf " + reservierungsListenElement.AbreiseDatum + " geändert.");
                }
                else if (eingabe == "Verpflegung")
                {
                    reservierungsListenElement.Verpflegung = Console.ReadLine();
                    Console.WriteLine("Sie haben die Verpflegung auf " + reservierungsListenElement.Verpflegung + " geändert.");
                }
                else if (eingabe == "Gesamtkosten")
                {
                    reservierungsListenElement.Gesamtkosten = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Sie haben die Gesamtkosten auf" + eingabe + " geändert.");
                }
                else
                {
                    Console.WriteLine("Ihre Eingabe " + eingabe + " ist ungültig");
                }
            }
            
        }

        public static void Loeschen(List<ReservierungsVerwaltung> reservierungsList)
        {
            Console.WriteLine("Sie haben ausgewählt, dass Sie eine Reservierung löschen wollen.");
            Console.WriteLine("Bitte geben Sie die Reservierungsnummer an, die Sie löschen wollen.");
            uint temp = Convert.ToUInt32(Console.ReadLine());
            var element = reservierungsList.Find(e => e.ReservierungsNummer == temp);
            Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Wollen Sie diese Reservierung löschen? Geben Sie Ja oder Nein ein.");
            string eingabe = Console.ReadLine();
            if (eingabe == "Ja")
            {
                reservierungsList.Remove(element);
                Console.WriteLine("Die Reservierung wurder erfolgreich gelöscht.");
            }
            else if (eingabe == "Nein")
            {

            }
            else
            {
                Console.WriteLine("Ihre Eingabe " + eingabe + " ist falsch. Bitte wiederholen Sie den Vorgang.");
                Program.Intro();
            }
        }

        public static void Ausgeben(List<ReservierungsVerwaltung> reservierungsListe)
        {
            var header = new System.Text.StringBuilder();
            header.Append(String.Format("{0,10} {1,20} {2,10} {3,10} {4,10} {5,10} {6,10} {7,10} {8,10} \n \n", "Res.Nr", "Gast", "ZimmerNr", "Zimmer Kateg.", "Anz. Pers", "Anreise", "Abreise", "Verpflegung", "Ges.Kosten"));
            for (int i = 0; i < reservierungsListe.Count; i++)
            {
                header.Append(String.Format("{0,10} {1,20} {2,10} {3,10} {4,10} {5,10} {6,10} {7,10} {8,10} \n", reservierungsListe[i].ReservierungsNummer, reservierungsListe[i].Gast.ToString(), reservierungsListe[i].Zimmer.ToString(), reservierungsListe[i].Zimmer.Kategorie.ToString(), reservierungsListe[i].AnzahlPersonen, reservierungsListe[i].AnreiseDatum, reservierungsListe[i].AbreiseDatum, reservierungsListe[i].Verpflegung, reservierungsListe[i].Gesamtkosten));            
            }
            Console.WriteLine(header);
        }
    }
}