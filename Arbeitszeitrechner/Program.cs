using System;
using System.Windows;
class Arbeitszeitrechner
{
    static void Main()
    {
        Console.WriteLine("Arbeitszeitrechner");

        // 1. Arbeitsstart Uhrzeit
        Console.Write("Geben Sie die Arbeitsstart-Uhrzeit ein (HH:mm): ");
        string startZeitStr = Console.ReadLine();

        // 2. Zu arbeitende Zeit
        Console.Write("Geben Sie die zu arbeitende Zeit in Stunden ein: ");
        decimal zuArbeitendeZeit = Convert.ToDecimal(Console.ReadLine());

        // 3. Pausezeit in Minuten
        Console.Write("Geben Sie die Pausezeit in Minuten ein: ");
        int pauseZeit = Convert.ToInt32(Console.ReadLine());

        // Konvertiere die Arbeitsstart-Uhrzeit in ein DateTime-Objekt
        DateTime startZeit = DateTime.ParseExact(startZeitStr, "HH:mm", null);

        // Berechne das Arbeitsende
        DateTime endeZeit = startZeit.AddHours((double)zuArbeitendeZeit).AddMinutes(pauseZeit);

        // Aktualisiere alle 1 Sekunden die verbleibende Arbeitszeit
        while (DateTime.Now < endeZeit)
        {
            TimeSpan verbleibendeZeit = endeZeit - DateTime.Now;
            Console.Clear();
            Console.WriteLine($"Arbeitsende: {endeZeit.ToString("HH:mm:ss")}");
            Console.WriteLine($"Verbleibende Zeit: {verbleibendeZeit.Hours} Stunden, {verbleibendeZeit.Minutes} Minuten, {verbleibendeZeit.Seconds} Sekunden");
            System.Threading.Thread.Sleep(1000); // Warte 1 Sekunde, bevor die Ausgabe aktualisiert wird
        }

        

        while (DateTime.Now > endeZeit)
        {
            TimeSpan mehrZeit = DateTime.Now - endeZeit;
            Console.Clear();
            Console.WriteLine($"Mehrzeit: {mehrZeit.Hours} Stunden, {mehrZeit.Minutes} Minuten, {mehrZeit.Seconds} Sekunden");
            Console.WriteLine("Arbeitstag beendet. Gute Arbeit!");
            System.Threading.Thread.Sleep(1000); // Warte 1 Sekunde, bevor die Ausgabe aktualisiert wird
        }
        Console.WriteLine("Arbeitstag beendet. Gute Arbeit!");
    }
 }