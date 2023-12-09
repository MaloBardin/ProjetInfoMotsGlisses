﻿namespace ProjetInfoMotsCroises
{

    using System;
    using System.ComponentModel.Design;
    using System.Dynamic;
    using NAudio.Wasapi.CoreAudioApi;
    using NAudio.Wave;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {

        bool sound = true;

        static void Settings()
        {





        }



        static void Play()
        {



            string fileName = "Test1";

            Jeu InstanceDeJeu = new Jeu(fileName); // création du jeu



            Console.WriteLine("Comment s'appellera le premier joueur ?");
            string namePlayer1 = Console.ReadLine();
            Console.WriteLine("Et quel est le nom du second protagoniste ?");
            string namePlayer2 = Console.ReadLine();

            Joueur joueur1 = new Joueur(namePlayer1);
            Joueur joueur2 = new Joueur(namePlayer2);

            Console.WriteLine("Vous êtes fin prêt à débuter la partie ! Que le grand jeu commence !");

            bool gameIsFinished = false;

            while (gameIsFinished == false)
            {
                


                //verif qu'il existe au moins 1 mot


                string player1Word = "";
                string player2Word = "";

                do
                {
                    Console.Clear();
                    InstanceDeJeu.PlateauDeJeu.AffichageConsole();
                    Console.WriteLine(joueur1.nom + ", merci de rentrer votre mot !");
                    player1Word = Console.ReadLine();

                } while (InstanceDeJeu.Dico.RechercheDichoRecursif(player1Word) != true || joueur1.Contient(player1Word) != false || InstanceDeJeu.PlateauDeJeu.Recherche_Mot(player1Word) != true);

                joueur1.CalculScore(player1Word);
                joueur1.Add_Mot(player1Word);
                string mp3FilePathClapping = "clap.mp3";
                using (var audioFile = new AudioFileReader(mp3FilePathClapping))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    Console.WriteLine("Mot validé votre score est désormais de : " + joueur1.score + " !");
                    outputDevice.Play();
                    Thread.Sleep(700);
                   
                }


                //TOUR DU JOUEUR 2
                gameIsFinished = InstanceDeJeu.PlateauDeJeu.IsTabEmpty();
                Console.Clear();
                InstanceDeJeu.PlateauDeJeu.AffichageConsole();
                do
                {
                    
                    
                    Console.WriteLine(joueur2.nom + ", merci de rentrer votre mot !");
                    player2Word = Console.ReadLine();

                    bool isInMatrice=

                    if (joueur1.Contient(player2Word) == true)
                    {
                        Console.WriteLine("Vous avez déja joué le mot : "+player2Word + ", merci de jouer un autre mot");
                    } else if (InstanceDeJeu.Dico.RechercheDichoRecursif(player2Word) == false)
                    {
                        Console.WriteLine(player2Word + " n'est pas dans le dictionnaire français !");
                    } else if 

                } while (InstanceDeJeu.Dico.RechercheDichoRecursif(player2Word) != true || joueur1.Contient(player2Word) != false || InstanceDeJeu.PlateauDeJeu.Recherche_Mot(player2Word) != true|| gameIsFinished==true);//bouger la detection de la matrice en bas

                joueur2.CalculScore(player2Word);
                joueur2.Add_Mot(player2Word);

                
                using (var audioFile = new AudioFileReader(mp3FilePathClapping))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    Console.WriteLine("Mot validé votre score est désormais de : " + joueur2.score + " !");
                    outputDevice.Play();
                    Thread.Sleep(700);
                }



                gameIsFinished = InstanceDeJeu.PlateauDeJeu.IsTabEmpty();






            }
            
            Console.Clear();
            Console.SetCursorPosition(10, 20);
            if (joueur1.score > joueur2.score)
            {
                Console.WriteLine("Le gagnant de cette glaciale partie est : " + joueur1.nom + " et son score est de : " + joueur1.score);
            } else
            {
                Console.WriteLine("Le gagnant de cette glaciale partie est : " + joueur2.nom + " et son score est de : " + joueur2.score);
            }

            Console.SetCursorPosition(10, 25);

            Console.WriteLine("Voulez-vous rejouer ? 1 = Oui |  2 = Non");

            Console.SetCursorPosition(10, 27);
            int selectionReturn = int.Parse(Console.ReadLine());
            if (selectionReturn == 1)
            {
                Console.Clear();
                Play();
            } else
            {
                Console.Clear();
                Quit();
            }
        }

        static void Quit()
        {
            Environment.Exit(0);
        }

        

        static void Main(string[] args)
        {

            Console.SetCursorPosition(10, 20);
            Console.WriteLine("Ce jeu est jouable à deux, munissez vous d'un compère et préparez vos dictionnaires avant de mener une bataille sanglante pour la victoire !");
            Console.SetCursorPosition(10, 21);
            Console.WriteLine("N'oubliez pas que certains paramètres sont disponible dans la section PARAMETRES du menu principal ! Bon jeu !");
            Console.SetCursorPosition(30, 24);
            Console.WriteLine("Merci d'appuyer sur une touche une fois la lecture des règles terminées.");
            Console.ReadKey();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(0, 10);
            Console.WriteLine(" ███▄ ▄███▓ ▒█████  ▄▄▄█████▓  ██████                  ▄████  ██▓    ▄▄▄       ▄████▄   ██▓ ▄▄▄       ██▓ ██▀███  ▓█████   ██████    \r\n▓██▒▀█▀ ██▒▒██▒  ██▒▓  ██▒ ▓▒▒██    ▒                 ██▒ ▀█▒▓██▒   ▒████▄    ▒██▀ ▀█  ▓██▒▒████▄    ▓██▒▓██ ▒ ██▒▓█   ▀ ▒██    ▒    \r\n▓██    ▓██░▒██░  ██▒▒ ▓██░ ▒░░ ▓██▄                  ▒██░▄▄▄░▒██░   ▒██  ▀█▄  ▒▓█    ▄ ▒██▒▒██  ▀█▄  ▒██▒▓██ ░▄█ ▒▒███   ░ ▓██▄      \r\n▒██    ▒██ ▒██   ██░░ ▓██▓ ░   ▒   ██▒               ░▓█  ██▓▒██░   ░██▄▄▄▄██ ▒▓▓▄ ▄██▒░██░░██▄▄▄▄██ ░██░▒██▀▀█▄  ▒▓█  ▄   ▒   ██▒   \r\n▒██▒   ░██▒░ ████▓▒░  ▒██▒ ░ ▒██████▒▒               ░▒▓███▀▒░██████▒▓█   ▓██▒▒ ▓███▀ ░░██░ ▓█   ▓██▒░██░░██▓ ▒██▒░▒████▒▒██████▒▒   \r\n░ ▒░   ░  ░░ ▒░▒░▒░   ▒ ░░   ▒ ▒▓▒ ▒ ░                ░▒   ▒ ░ ▒░▓  ░▒▒   ▓▒█░░ ░▒ ▒  ░░▓   ▒▒   ▓▒█░░▓  ░ ▒▓ ░▒▓░░░ ▒░ ░▒ ▒▓▒ ▒ ░   \r\n░  ░      ░  ░ ▒ ▒░     ░    ░ ░▒  ░ ░                 ░   ░ ░ ░ ▒  ░ ▒   ▒▒ ░  ░  ▒    ▒ ░  ▒   ▒▒ ░ ▒ ░  ░▒ ░ ▒░ ░ ░  ░░ ░▒  ░ ░   \r\n░      ░   ░ ░ ░ ▒    ░      ░  ░  ░                 ░ ░   ░   ░ ░    ░   ▒   ░         ▒ ░  ░   ▒    ▒ ░  ░░   ░    ░   ░  ░  ░     \r\n       ░       ░ ░                 ░                       ░     ░  ░     ░  ░░ ░       ░        ░  ░ ░     ░        ░  ░      ░     \r\n                                                                              ░                                                      ");
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(40, 20);
            Console.WriteLine("1)    JOUER ");
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("2)    PARAMETRES ");
            Console.SetCursorPosition(40, 24);
            Console.WriteLine("3)    QUITTER ");



            string mp3FilePath = "introCR.mp3"; // Replace this with the actual path to your MP3 file

          
                using (var audioFile = new AudioFileReader(mp3FilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                int selection = 0;
                do
                {
                    Console.SetCursorPosition(40, 28);
                    Console.WriteLine("Dans quel menu voulez-vous aller ?");

                    Console.SetCursorPosition(40, 30);
                    selection = int.Parse(Console.ReadLine());//FIX LE INT EN STRING PRB
                } while (selection < 1 || selection > 3);

                if (selection == 1)
                {
                    Console.Clear();
                    Play();
                } else if (selection == 2){
                    Console.Clear();
                    Settings();
                }  else 
                {
                
                    Quit();
                } 
                
            }







        }
    }
}