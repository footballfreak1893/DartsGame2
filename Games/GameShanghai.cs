﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GameShanghai
    {
        //vars
        int anzeigezahl = 1;
        int punktestand = 0;
        int wurf;
        string eingabekategorie;
        int runde =1;
        int[] wuerfe = new int[3];
        string[] eingabewuerfe = new string[3];
        string[] wuerfeString = { "1", "2", "3" };

        public void SHA()
        {
            Console.WriteLine("-----Shanghai-----");
            Console.WriteLine("Spielmodus auswählen:");
            Console.WriteLine("Classic --> press: classic");
            Console.WriteLine("Around the Clock --> press: clock");
            Console.WriteLine("Zurück zum Hauptmenü: --> press: exit");
            eingabekategorie = Console.ReadLine();
            Console.Clear();

            while (true)
            {
                if (eingabekategorie != "classic" && eingabekategorie != "exit" && eingabekategorie != "clock")
                {
                    Console.WriteLine("Ungültiger Wert");
                    Console.WriteLine("Classic --> press: classic");
                    Console.WriteLine("Around the Clock --> press: clock");
                    Console.WriteLine("Zurück zum Hauptmenü: --> press: exit");
                    eingabekategorie = Console.ReadLine();
                    Console.Clear();
                }
                else if (eingabekategorie == "classic")
                {
                    SHAClassic(eingabekategorie);
                }
                else if (eingabekategorie == "clock")
                {
                    ClockMenu();
                }
                else if (eingabekategorie == "exit")
                {
                    return; //--> Soll Hauptmenü aufrufen
                }
            }
        }

        public void SHAClassic(string eingabekageorie)
        {
            Console.WriteLine("-----SHA Classic-----");

            for (runde = 1; runde < 8; runde++)
            {
                for (int wurf = 0; wurf <= 2; wurf++)
                {
                    Console.WriteLine("Runde " + runde);
                    Console.WriteLine("Zuwerfende Zahl " + anzeigezahl);
                    Console.WriteLine(wuerfeString[wurf] + ".Pfeil -->Punkte eingeben");
                    eingabewuerfe[wurf] = Console.ReadLine();

                    //Überprüfung  reset, exit
                    if (eingabewuerfe[wurf] == "reset")
                    {
                        SHAClassic(eingabekategorie);
                    }
                    if (eingabewuerfe[wurf] == "exit")
                    {
                        SHA();
                    }
                    //Überprüfung Datentyp 
                    bool canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);

                    while (canConvert == false)
                    {
                        Console.WriteLine("Ungültiger Wert");
                        Console.WriteLine("Punkezahl eingeben");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);
                    }

                    //Überprüfung Zahl 
                    while ((wuerfe[wurf] != anzeigezahl * 1) && (wuerfe[wurf] != anzeigezahl * 2) && (wuerfe[wurf] != anzeigezahl * 3) && (wuerfe[wurf] != 0) && eingabewuerfe[wurf] != "exit" && eingabewuerfe[wurf] != "reset")
                    {
                        Console.WriteLine("Ungültige Zahl: ");
                        Console.WriteLine("Eingabe wiederholen");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        wuerfe[wurf] = Convert.ToInt16(eingabewuerfe[wurf]);
                    }
                    if (wuerfe[wurf] > 0)
                    {
                        anzeigezahl++;
                    }

                    //Console.Clear();
                    punktestand =   wuerfe[0] + wuerfe[1] + wuerfe[2];

                    Console.WriteLine("Punktestand: " + punktestand);
                }
            }

            Console.WriteLine("Spiel beendet");
            Console.WriteLine("Spiel erneut starten -->press: reset");
            Console.WriteLine("Zurück zum Menü SHA -->press exit");
            eingabekategorie = Console.ReadLine();
            Console.Clear();

            while (eingabekategorie != "SHA" && eingabekategorie != "exit")
            {
                Console.WriteLine("Ungültiger Wert");
                Console.WriteLine("Spiel erneut starten -->press: reset");
                Console.WriteLine("Zurück zum Menü SHA -->press exit");
                eingabekategorie = Console.ReadLine();
                Console.Clear();
            }

            if (eingabekategorie == "exit")
            {
                SHA();
            }
            else if (eingabekategorie == "reset") ;
            {
                SHAClassic(eingabekategorie);
            }

        }
        public void ClockMenu()
        {
            Console.WriteLine("-----ClockMenu-----");
            Console.WriteLine("Spielmodus auswählen:");
            Console.WriteLine("3x Singletreffer --> press: 3s");
            Console.WriteLine("3x Doubletreffer --> press: 3d");
            Console.WriteLine("3x Trippletreffer --> press: 3t");
            Console.WriteLine("Zurück zum Menü SHA --> press: exit");

            eingabekategorie = Console.ReadLine();
            Console.Clear();

            while (true)
            {
                if (eingabekategorie != "3s" && eingabekategorie !="3d" && eingabekategorie != "3t" && eingabekategorie != "exit")
                {
                    Console.WriteLine("Ungültiger Wert");
                    Console.WriteLine("Spielmodus auswählen:");
                    Console.WriteLine("3x Singletreffer --> press: 3s");
                    Console.WriteLine("3x Doubletreffer --> press: 3d");
                    Console.WriteLine("3x Trippletreffer --> press: exit");
                    eingabekategorie = Console.ReadLine();
                    Console.Clear();
                }
                else if (eingabekategorie == "3s")
                {
                    TrippleSingle();

                }
                else if (eingabekategorie =="3d")
                {
                    TrippleDouble();
                }
                else if (eingabekategorie == "3t")
                {
                    TrippleTripple();
                }
                else if (eingabekategorie == "clock")
                {
                    //return; //--> Soll Hauptmenü aufrufen
                }
                else if (eingabekategorie == "exit")
                {
                    return;
                }
            }
        }

        public void TrippleSingle()
        {
            Console.WriteLine("-----Around the Clock 3 Fach-----");
            Console.WriteLine("-----3x Singletreffer-----");

            while (anzeigezahl < 22)
            {
                for (int wurf = 0; wurf <= 2; wurf++)
                {
                    Console.WriteLine("Runde " + runde);
                    Console.WriteLine("Zuwerfende Zahl " + anzeigezahl);
                    Console.WriteLine(wuerfeString[wurf] + ".Pfeil -->Punkte eingeben");
                    eingabewuerfe[wurf] = Console.ReadLine();

                    //Überprüfung  reset, exit
                    if (eingabewuerfe[wurf] == "reset")
                    {
                        TrippleSingle();
                    }
                    if (eingabewuerfe[wurf] == "exit")
                    {
                        ClockMenu();
                    }
                    //Überprüfung Datentyp 
                    bool canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);

                    while (canConvert == false)
                    {
                        Console.WriteLine("Ungültiger Wert");
                        Console.WriteLine("Punkezahl eingeben");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);
                    }

                    //Überprüfung Zahl 
                    while ((wuerfe[wurf] != anzeigezahl) && (wuerfe[wurf] != 0) && eingabewuerfe[wurf] != "exit" && eingabewuerfe[wurf] != "reset")
                    {
                        Console.WriteLine("Ungültige Zahl: ");
                        Console.WriteLine("Eingabe wiederholen");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        wuerfe[wurf] = Convert.ToInt16(eingabewuerfe[wurf]);
                    }
                }
                    punktestand = punktestand + wuerfe[0] + wuerfe[1] + wuerfe[2];
                    Console.WriteLine("Punktestand: " + punktestand);
                    //anzeigezahl++;
                
                anzeigezahl++;
                runde++;
            }
            Console.WriteLine("Spiel beendet");
            Console.WriteLine("Spiel erneut starten -->press: reset");
            Console.WriteLine("Zurück zum Menü ClockMenu -->press exit");
            eingabekategorie = Console.ReadLine();
            Console.Clear();

            while (eingabekategorie != "SHA" && eingabekategorie != "exit")
            {
                Console.WriteLine("Ungültiger Wert");
                Console.WriteLine("Spiel erneut starten -->press: reset");
                Console.WriteLine("Zurück zum Menü ClockMenu -->press exit");
                eingabekategorie = Console.ReadLine();
                Console.Clear();
            }

            if (eingabekategorie == "reset")
            {
                TrippleSingle();
            }
            else if (eingabekategorie == "exit") ;
            {
                ClockMenu();
            }
        }

        public void TrippleDouble()
        {
            Console.WriteLine("-----Around the Clock 3 Fach-----");
            Console.WriteLine("-----3x Doubletreffer-----");

            while (anzeigezahl < 22)
            {
                for (int wurf = 0; wurf <= 2; wurf++)
                {
                    Console.WriteLine("Runde " + runde);
                    Console.WriteLine("Zuwerfende Zahl " + anzeigezahl);
                    Console.WriteLine(wuerfeString[wurf] + ".Pfeil -->Punkte eingeben");
                    eingabewuerfe[wurf] = Console.ReadLine();

                    //Überprüfung  reset, exit
                    if (eingabewuerfe[wurf] == "reset")
                    {
                        TrippleDouble();
                    }
                    if (eingabewuerfe[wurf] == "exit")
                    {
                        ClockMenu();
                    }
                    //Überprüfung Datentyp 
                    bool canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);

                    while (canConvert == false)
                    {
                        Console.WriteLine("Ungültiger Wert");
                        Console.WriteLine("Punkezahl eingeben");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);
                    }


                    //Überprüfung Zahl 
                    while ((wuerfe[wurf] != anzeigezahl*2) && (wuerfe[wurf] != 0) && eingabewuerfe[wurf] != "exit" && eingabewuerfe[wurf] != "reset")
                    {
                        Console.WriteLine("Ungültige Zahl: ");
                        Console.WriteLine("Eingabe wiederholen");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        wuerfe[wurf] = Convert.ToInt16(eingabewuerfe[wurf]);
                    }


                }
                punktestand = punktestand + wuerfe[0] + wuerfe[1] + wuerfe[2];
                Console.WriteLine("Punktestand: " + punktestand);
                //anzeigezahl++;

                anzeigezahl++;
                runde++;
            }
            Console.WriteLine("Spiel beendet");
            Console.WriteLine("Spiel erneut starten -->press: reset");
            Console.WriteLine("Zurück zum ClockMenu -->press exit");
            eingabekategorie = Console.ReadLine();
            Console.Clear();

            while (eingabekategorie != "SHA" && eingabekategorie != "exit")
            {
                Console.WriteLine("Ungültiger Wert");
                Console.WriteLine("Spiel erneut starten -->press: reset");
                Console.WriteLine("Zurück zum ClockMenu -->press exit");
                eingabekategorie = Console.ReadLine();
                Console.Clear();
            }

            if (eingabekategorie == "reset")
            {
                TrippleDouble();
            }
            else if (eingabekategorie == "exit") ;
            {
                ClockMenu();
            }
        }
        public void TrippleTripple()
        {
            Console.WriteLine("-----Around the Clock 3 Fach-----");
            Console.WriteLine("-----3x Trippletreffer-----");

            while (anzeigezahl < 22)
            {
                for (int wurf = 0; wurf <= 2; wurf++)
                {
                    Console.WriteLine("Runde " + runde);
                    Console.WriteLine("Zuwerfende Zahl " + anzeigezahl);
                    Console.WriteLine(wuerfeString[wurf] + ".Pfeil -->Punkte eingeben");
                    eingabewuerfe[wurf] = Console.ReadLine();

                    //Überprüfung  reset, exit
                    if (eingabewuerfe[wurf] == "reset")
                    {
                        TrippleTripple();
                    }
                    if (eingabewuerfe[wurf] == "exit")
                    {
                        ClockMenu();
                    }
                    //Überprüfung Datentyp 
                    bool canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);

                    while (canConvert == false)
                    {
                        Console.WriteLine("Ungültiger Wert");
                        Console.WriteLine("Punkezahl eingeben");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        canConvert = int.TryParse(eingabewuerfe[wurf], out wuerfe[wurf]);
                    }

                    //Überprüfung Zahl 
                    while ((wuerfe[wurf] != anzeigezahl * 3) && (wuerfe[wurf] != 0) && eingabewuerfe[wurf] != "exit" && eingabewuerfe[wurf] != "reset")
                    {
                        Console.WriteLine("Ungültige Zahl: ");
                        Console.WriteLine("Eingabe wiederholen");
                        eingabewuerfe[wurf] = Console.ReadLine();
                        wuerfe[wurf] = Convert.ToInt16(eingabewuerfe[wurf]);
                    }
                }
                punktestand = punktestand + wuerfe[0] + wuerfe[1] + wuerfe[2];
                Console.WriteLine("Punktestand: " + punktestand);
                //anzeigezahl++;

                anzeigezahl++;
                runde++;
            }
            Console.WriteLine("Spiel beendet");
            Console.WriteLine("Spiel erneut starten -->press: reset");
            Console.WriteLine("Zurück zum ClockMenu -->press exit");
            eingabekategorie = Console.ReadLine();
            Console.Clear();

            while (eingabekategorie != "SHA" && eingabekategorie != "exit")
            {
                Console.WriteLine("Ungültiger Wert");
                Console.WriteLine("Spiel erneut starten -->press: reset");
                Console.WriteLine("Zurück zum ClockMenu -->press exit");
                eingabekategorie = Console.ReadLine();
                Console.Clear();
            }

            if (eingabekategorie == "reset")
            {
                TrippleTripple();
            }
            else if (eingabekategorie == "exit") ;
            {
                ClockMenu();
            }
        }
    }
}



