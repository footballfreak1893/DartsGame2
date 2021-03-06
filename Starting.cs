﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Starting
    {
        private static GameX01 x01 = new GameX01();
        private static GameCricket cricket = new GameCricket();
        private static GameShanghai shanghai = new GameShanghai();
        private static Games.GameHighscore highscore = new Games.GameHighscore();
        private static Games.GameScoring scoring = new Games.GameScoring();
        private static Starting starting = new Starting();

        static void Main(string[] args)
        {
            Start();
        }
        static public void Start()
        {
            while (true)
            {
                Console.WriteLine("-----Dartsprogramm-----");
                Console.WriteLine("Kategorie auswählen");
                Console.WriteLine("X01 -->press X01");
                Console.WriteLine("Shanghai -->press SHA");
                Console.WriteLine("Highscore -->press HI");
                Console.WriteLine("Highscore -->press SCO");
                // Console.WriteLine("Cricket -->press CRI");
                string eingabekategorie = Console.ReadLine();
                Console.Clear();

                if (eingabekategorie == "X01")
                {
                    x01.X01();
                }
                else if (eingabekategorie == "SHA")
                {
                    shanghai.SHA();
                }
                else if (eingabekategorie == "HI")
                {
                    highscore.High();
                }
                else if (eingabekategorie == "SCO")
                {
                    scoring.TrainingZahl();
                }
                else
                {
                    starting.InvalidValue();
                }
            }

        }

        public int ÜberprüfungDatentyp(string eingabewuerfe)
        {
            int punkte = 0;

            bool CanConvert = false;

            while (!CanConvert)
            {
                try
                {
                    punkte = Convert.ToInt32(eingabewuerfe);
                    CanConvert = true;
                    break;
                }
                catch
                {
                    Console.WriteLine("Ungültiger Wert: --> Ganze Zahl eingeben");
                }
                eingabewuerfe = Console.ReadLine();
            }
            return punkte;
        }

        public int ÜberprüfungMax_Min(int wuerfe, string eingabewuerfe)
        {
            while (wuerfe > 60 || wuerfe < 0)
            {
                InvalidValue();
                Console.WriteLine("MAX/MIN");
                Console.WriteLine("Punkezahl eingeben");
                eingabewuerfe = Console.ReadLine();
                wuerfe = ÜberprüfungDatentyp(eingabewuerfe);
            }
            return wuerfe;
        }

        public int ÜberprüfungZahlSHA(int anzeigezahl, string eingabewuerfe, int wuerfe, int mode)
        {
            if (mode == 0)
            {
                while ((wuerfe != anzeigezahl * 1) && (wuerfe != anzeigezahl * 2) && (wuerfe != anzeigezahl * 3) && (wuerfe != 0) && eingabewuerfe != "exit" && eingabewuerfe != "reset")
                {
                    InvalidValue();
                    eingabewuerfe = Console.ReadLine();
                    wuerfe = Convert.ToInt16(eingabewuerfe);
                }
            }

            else
            {
                while ((wuerfe != anzeigezahl * mode) && (wuerfe != 0) && eingabewuerfe != "exit" && eingabewuerfe != "reset")
                {
                    InvalidValue();
                    eingabewuerfe = Console.ReadLine();
                    wuerfe = Convert.ToInt16(eingabewuerfe);
                }
            }

            return wuerfe;
        }

        public void InvalidValue()
        {
            Console.WriteLine("Ungültiger Wert");
        }

        public void FunktioniertTest()
        {
            Console.WriteLine("Funktioniert bisher");
        }

        public string GameFinished(string gameMenu, string eingabeX01)
        {
            Console.WriteLine("Spiel beendet");
            Console.WriteLine("Spiel erneut starten -->press: reset");
            Console.WriteLine("Zurück zum Menü " + gameMenu + " -->press exit");
            eingabeX01 = Console.ReadLine();
            Console.Clear();
            return eingabeX01;

        }
        public void Wertelöschen()
        {
            shanghai.punktestand = 0;
            shanghai.anzeigezahl = 1;
            shanghai.runde = 0;
        }
    }


}




