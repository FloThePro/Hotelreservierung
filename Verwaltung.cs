using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelreservierung
{
    public interface IVerwaltung
    {
        public abstract void Anlegen(List<IVerwaltung> verwaltungsList);
        public void Bearbeiten(List<IVerwaltung> verwaltungsList);
        public void Loeschen(List<IVerwaltung> verwaltungsList);
        public void Ausgeben(List<IVerwaltung> verwaltungsList);

    }
    public class GaesteVerwaltung : IVerwaltung
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
        Console.WriteLine("Sie haben " + element.ToString() + " ausgewählt. Wollen Sie diesen Kurs löschen? Geben Sie Ja oder Nein ein.");
        string eingabe = Console.ReadLine();
        if (eingabe == "Ja")
        {
            gaesteListe.Remove(element);
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

    public class ZimmerVerwaltung:ZimmerKategorieVerwaltung
    {
        public ZimmerKategorieVerwaltung Kategorie;
        public ushort ZimmerNummer { get; set; }
        public ushort Groesse { get; set; }
        public string Ausrichtung { get; set; }

        public ZimmerVerwaltung(ushort zimmerNummer, ushort groesse, string ausrichtung, ZimmerKategorieVerwaltung kategorie) : base
        {
            ZimmerNummer = zimmerNummer;
            Groesse = groesse;
            Ausrichtung = ausrichtung;
            Kategorie = kategorie;
        }


    }

    public class ZimmerKategorieVerwaltung :IVerwaltung
    {
        public string Name { get; set; }
        public int MaxPesonenAnzahl { get; set; }
        public string BeschreibungAusstattung { get; set; }
        public double PreisNacht { get; set; }
        public double PreisWoche { get; set; }

        public ZimmerKategorieVerwaltung(string name, int maxPersonenAnzahl, string beschreibungAusstattung, double preisNacht, double preisWoche)
        {
            Name = name;
            MaxPesonenAnzahl = maxPersonenAnzahl;
            BeschreibungAusstattung = beschreibungAusstattung;
            PreisNacht = preisNacht;
            PreisWoche = preisWoche;
        }

        void IVerwaltung.Anlegen(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }

        void IVerwaltung.Bearbeiten(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }

        void IVerwaltung.Loeschen(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }

        void IVerwaltung.Ausgeben(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }
    }

    public class ReservierungsVerwaltung : IVerwaltung
    {
        public int AnzahlPersonen { get; set; }
        public DateOnly AnreiseDatum { get; set; }
        public DateOnly AbreiseDatum { get; set; }
        public string Verpflegung { get; set; }
        public double Gesamtkosten { get; set; }

        public ReservierungsVerwaltung( int anzahlPersonen, DateOnly anreiseDatum, DateOnly abreiseDatum, string verpflegung, double gesamtkosten)
        {
            AnzahlPersonen = anzahlPersonen;
            AnreiseDatum = anreiseDatum;
            AbreiseDatum = abreiseDatum;
            Verpflegung = verpflegung;
            Gesamtkosten = gesamtkosten;
        }

        public void Anlegen(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }

        void IVerwaltung.Anlegen(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }

        void IVerwaltung.Bearbeiten(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }

        void IVerwaltung.Loeschen(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }

        void IVerwaltung.Ausgeben(List<IVerwaltung> verwaltungsList)
        {
            throw new NotImplementedException();
        }
    }
}
