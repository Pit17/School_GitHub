﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppLancioDeiDadi
{
    internal class Program
    {
        static void Main(string[] args)
        {



            #region Nome
            Console.Title = ("AleaIactaEstAutorePietroMalzone3H");
            Console.WriteLine("Autore Progetto Pietro Malzone 3H 03/10/2023\n");

            #endregion



            #region Dichiarazioni
            const int WINMULTIPLIER = 10;
            int puntata = 0;
            int initialMoney = 50;
            int wallet;
            string stInput;
            bool inputOK;
            int varInt;
            bool credit = true;
            int winNumber1;
            int winNumber2;
            int winNumberTot;
            char rematchInput;
            int rematch;//dichiaro
            Random rnd = new Random();//comando per randomizzare i dadi

            #endregion



            #region game
            wallet = initialMoney;
            while (credit == true && wallet > 0)
            {
                do
                {
                    Console.Write("\nHai " + wallet + " sesterzi");
                    Console.Write("\nQuanti sesterzi vuoi puntare? -->");

                    stInput = Console.ReadLine();

                    inputOK = int.TryParse(stInput, out varInt);
                    if (!inputOK) Console.WriteLine("\nInput non valido :( \nRiprovi");
                    else if (varInt <= 0 || varInt > wallet)//verifico sia compresa nel range
                    {
                        Console.WriteLine("\nNon dispone di questa cifra.");
                        inputOK = false;
                    }

                } while (!inputOK);//ricicla se non valido

                puntata = varInt;
                do
                {
                    Console.Write("\nSu quale numero vuoi puntare da 2 a 12? --> ");
                    stInput = Console.ReadLine();
                    // conversione stringa in int
                    inputOK = int.TryParse(stInput, out varInt);
                    if (!inputOK) Console.WriteLine("\nInput non valido! Riprova");
                    else if (varInt < 2 || varInt > 12)//verifico il numero sia nel range
                    {

                        Console.WriteLine("\nIl numero da lei inserito non può uscire");
                        Console.WriteLine("Il numero deve essere compreso tra 2 e 12");
                        inputOK = false;

                    }
                } while (!inputOK);//ricicla se non valido

                winNumber1 = rnd.Next(1, 7);
                winNumber2 = rnd.Next(1, 7);
                winNumberTot = winNumber1 + winNumber2;//lancio dei dadi e risultato

                Console.WriteLine("Lancio dei dadi...");
                Thread.Sleep(1000);
                Console.WriteLine("E' uscito il numero " + winNumberTot);
                if (winNumberTot == puntata)
                {

                    wallet += puntata * WINMULTIPLIER;
                    Console.WriteLine("Complimenti hai vinto ora hai " + wallet + " sesterzi");

                }
                else
                {

                    Console.WriteLine("Hai perso");
                    wallet = wallet - puntata;  

                }
                Console.WriteLine("Se vuoi rigiocare scrivere S oppure N per abbandonare\n");

                rematchInput = Console.ReadKey().KeyChar;//chiedo se desidera rigiocare
                
                if(rematchInput != 's' && rematchInput != 'S')
                {
                    credit = false;

                }else credit = true;
            }
            if (wallet == 0)
            {

                Console.WriteLine("\nHai finito i sesterzi ci dispiace la prossima volta gestisci meglio i tuoi soldi.");


            }

            Console.WriteLine("\nHai " + wallet + " sesterzi");
            Console.WriteLine("\nArrivederci e grazie per aver giocato!");//saluto e mostro i sesterzi restanti
            Console.WriteLine("\nPremere un tasto per terminare il programma");
            Console.ReadKey();  
           
        }
        #endregion



    }
}

