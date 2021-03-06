﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GameShanghai
    {
        Starting starting = new Starting();
        //vars
        public int anzeigezahl = 1;
         public int punktestand = 0;
         public string eingabekategorie;
       public int runde = 1;
        int[] wuerfe = new int[3];
        string[] eingabewuerfe = new string[3];
        string[] wuerfeString = { "1", "2", "3" };

        public void SHA()
        {
            while (true)
            {
                Console.WriteLine("-----Shanghai-----");
                Console.WriteLine("Spielmodus auswählen:");
                Console.WriteLine("Classic --> press: classic");
                Console.WriteLine("Around the Clock --> press: clock");
                Console.WriteLine("Zurück zum Hauptmenü: --> press: exit");
                eingabekategorie = Console.ReadLine();
                Console.Clear();

                if (eingabekategorie == "classic")
                {
                    Console.Clear();
                    SHAClassic(eingabekategorie, 0);

                }
                else if (eingabekategorie == "clock")
                {
                    Console.Clear();
                    ClockMenu();

                }
                else if (eingabekategorie == "exit")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    starting.InvalidValue();
                }
            }
        }
        public void SHAClassic(string eingabekageorie, int mode)
        {
            Console.WriteLine("-----SHA Classic-----");

            starting.Wertelöschen();
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
                        Console.Clear();
                        return; //-->funktioniert nicht korrekt
                    }
                    if (eingabewuerfe[wurf] == "exit")
                    {
                        Console.Clear();
                        SHA();
                        return;
                    }
                    wuerfe[wurf] = starting.ÜberprüfungDatentyp(eingabewuerfe[wurf]);
                    wuerfe[wurf] = starting.ÜberprüfungZahlSHA(anzeigezahl, eingabewuerfe[wurf], wuerfe[wurf], mode );

                    anzeigezahl++;
                    punktestand = wuerfe[0] + wuerfe[1] + wuerfe[2];

                    Console.WriteLine("Punktestand: " + punktestand);
                }
            }

            starting.GameFinished("SHA",eingabekategorie);

            if (eingabekategorie == "exit")
            {
                Console.Clear();
                SHA();
            }
            else if (eingabekategorie == "reset") //--> muss noch überprüft werden !!!!!
            {
                Console.Clear();
                return;
            }
            else
            {
                starting.InvalidValue(); 
                starting.GameFinished("SHA", eingabekategorie);
            }
        }
        public void ClockMenu()
        {
            while (true)
            {
                Console.WriteLine("-----ClockMenu-----");
                Console.WriteLine("Spielmodus auswählen:");
                Console.WriteLine("3x Singletreffer --> press: 3s");
                Console.WriteLine("3x Doubletreffer --> press: 3d");
                Console.WriteLine("3x Trippletreffer --> press: 3t");
                Console.WriteLine("Zurück zum Menü SHA --> press: exit");
                eingabekategorie = Console.ReadLine();
                Console.Clear();

                if (eingabekategorie == "3s")
                {
                    Console.Clear();
                    AroundTheClock(1,"Single");
                }

                else if (eingabekategorie == "3d")
                {
                    AroundTheClock(2, "Double");
                }

                else if (eingabekategorie == "3t")
                {
                    Console.Clear();
                    AroundTheClock(3, "Triple");
                }

                else
                {
                    starting.InvalidValue();
                }
            }
        }

        public void AroundTheClock(int mode, string clockmode)
        {
            Console.WriteLine("-----Around the Clock 3 Fach-----");
            Console.WriteLine("-----3x " + clockmode + "treffer-----");

            starting.Wertelöschen();
            while (anzeigezahl < 22)
            {
                for (int wurf = 0; wurf <= 2; wurf++)
                {
                    Console.WriteLine("Runde " + runde);
                    Console.WriteLine("Zuwerfende Zahl: Single " + anzeigezahl);
                    Console.WriteLine(wuerfeString[wurf] + ".Pfeil -->Punkte eingeben");
                    eingabewuerfe[wurf] = Console.ReadLine();

                    //Überprüfung  reset, exit
                    if (eingabewuerfe[wurf] == "reset") //--> muss noch überprüft werden !!!!!
                    {
                        //noch offen
                        Console.Clear();
                        return;
                    }
                    if (eingabewuerfe[wurf] == "exit")
                    {
                        Console.Clear();
                        ClockMenu();
                    }
                    wuerfe[wurf] = starting.ÜberprüfungDatentyp(eingabewuerfe[wurf]);
                    wuerfe[wurf] = starting.ÜberprüfungZahlSHA(anzeigezahl, eingabewuerfe[wurf], wuerfe[wurf], mode);
                }

                punktestand = punktestand + wuerfe[0] + wuerfe[1] + wuerfe[2];

                Console.WriteLine("Punktestand: " + punktestand);
                //anzeigezahl++;

                anzeigezahl++;
                runde++;
            }
          
            starting.GameFinished("ClockMenu", eingabekategorie);

            if (eingabekategorie == "reset")
            {
                return;
            }
            else if (eingabekategorie == "exit")
            {
                return;
            }
        }
    }
}



