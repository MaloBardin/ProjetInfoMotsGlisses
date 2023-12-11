namespace ProjetInfoMotsCroises
{

    using System;
    using System.ComponentModel.Design;
    using System.Dynamic;
    using NAudio.Wasapi.CoreAudioApi;
    using NAudio.Wave;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Runtime.CompilerServices;
    

    internal class Program
    {
        



        static string Settings(string fileName)
        {
                       
            Console.Clear();
            Console.SetCursorPosition(55, 12);
            Console.Write("Travail effectué par ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Pierre-Antoine");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" et ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Malo !");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(57, 17);
            Console.Write("Le fichier actuel de la matrice est "+fileName);
            Console.SetCursorPosition(35, 18);
            Console.Write("Quel est le chemin de votre fichier matrice ? (un .csv sera ajouté à la fin de votre fichier)");
            Console.SetCursorPosition(55, 19);
            fileName = Console.ReadLine();


            Console.SetCursorPosition(57, 22);
            Console.WriteLine("Voulez-vous activer le son ? 1=Oui 2=Non");
            Console.SetCursorPosition(57, 23);
            int tempoSound = int.Parse(Console.ReadLine());
            bool sound;
            if (tempoSound == 1)
            {
                 sound = true;
            } else
            {
                 sound = false;
            }

            Console.SetCursorPosition(57, 24);
            Console.WriteLine("Quel est le temps maximum que peut durer une partie ? (en minutes)");
            Console.SetCursorPosition(57, 25);
            int tempoTimeGame = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(57, 26);
            Console.Write("Combien de temps dispose chaque joueur pour jouer son tour ? "); Console.ForegroundColor = ConsoleColor.DarkRed;Console.Write("( en secondes ) "); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(57, 27);
            int tempoTimeTour = int.Parse(Console.ReadLine());


            Console.Clear();
            Play(fileName,sound, tempoTimeGame, tempoTimeTour);
            return fileName;
        }



        static void Play(string fileName, bool sound,int tempoTimeGame, int tempoTimeTour)
        {







            Jeu InstanceDeJeu = new Jeu(fileName); // création du jeu

            

            Console.SetCursorPosition(60, 20);
            Console.WriteLine("Comment s'appellera le premier joueur ?");
            Console.SetCursorPosition(60, 21);
            string namePlayer1 = Console.ReadLine();
            Console.SetCursorPosition(60, 22);
            Console.WriteLine("Et quel est le nom du second protagoniste ?");
            Console.SetCursorPosition(60, 23);
            string namePlayer2 = Console.ReadLine();

            Random random = new Random();
            int randomPlayer = random.Next(1, 3);

            

           
            if (randomPlayer == 1) //permet de savoir qui va commencer a jouer de façon aléatoire
            {
                 InstanceDeJeu.Joueur1.nom = namePlayer1;
                 InstanceDeJeu.Joueur2.nom = namePlayer2;
            } else
            {
                InstanceDeJeu.Joueur1.nom = namePlayer2;
                InstanceDeJeu.Joueur2.nom = namePlayer1;
            }

            Console.WriteLine("Vous êtes fin prêt à débuter la partie ! Que le grand jeu commence !");




            DateTime HeureDuDebutDeJeu = DateTime.Now;
            TimeSpan ChronoFinJeu = TimeSpan.FromMinutes(tempoTimeGame); // 10 MINUTES DE BASE
            DateTime HeureDuDebutDeTour = DateTime.Now;


            bool gameIsFinished = false;
            
            while (gameIsFinished == false && DateTime.Now - HeureDuDebutDeJeu < ChronoFinJeu) // CONDITIONS
            {
                
                TimeSpan ChronoFinTour = TimeSpan.FromSeconds(tempoTimeTour); // 60sec de BASE

                //verif qu'il existe au moins 1 mot dans la matrice


                string player1Word = "";
                string player2Word = "";

                gameIsFinished = InstanceDeJeu.PlateauDeJeu.IsTabEmpty();
                Console.Clear();

                if (DateTime.Now - HeureDuDebutDeTour > ChronoFinTour)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(0, 2);
                    Console.Write("Votre temps a été écoulé ! C'est à " + InstanceDeJeu.Joueur1.nom + " de jouer !");
                    Console.ForegroundColor = ConsoleColor.White;
                }


                Console.SetCursorPosition(0, 5);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Le score de " + InstanceDeJeu.Joueur1.nom + " est de : ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(InstanceDeJeu.Joueur1.score);
                Console.SetCursorPosition(0, 6);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Le score de " + InstanceDeJeu.Joueur2.nom + " est de : ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(InstanceDeJeu.Joueur2.score);
                Console.ForegroundColor = ConsoleColor.White;



                HeureDuDebutDeTour = DateTime.Now;


                InstanceDeJeu.PlateauDeJeu.AffichageConsole();
                Console.WriteLine("");
                Console.WriteLine("C'est à " + InstanceDeJeu.Joueur1.nom + " de jouer !");
                InstanceDeJeu.PlateauDeJeu.ToFile("coucou");


                while (Console.KeyAvailable==false && DateTime.Now -HeureDuDebutDeTour < ChronoFinTour)
                {
                    Thread.Sleep(100); //on temporise 0.1 sec
                    
                }
                if (gameIsFinished == false && DateTime.Now - HeureDuDebutDeJeu < ChronoFinJeu && DateTime.Now - HeureDuDebutDeTour < ChronoFinTour)//on verifie si le tab n'est pas vide !
                {
                    
                    do
                    {
                       

                        Console.WriteLine(InstanceDeJeu.Joueur1.nom + " , merci de rentrer votre mot !");
                        player1Word = Console.ReadLine().ToLower();
                        


                        if (InstanceDeJeu.PlateauDeJeu.SearchWordTab(player1Word) == null && InstanceDeJeu.Dico.RechercheDichoRecursif(player1Word) == false)
                        {
                            Console.WriteLine("Votre mot n'est ni dans le plateau ni dans le dictionnaire c'est pitoyable");
                        }
                        else if (InstanceDeJeu.Joueur1.Contient(player1Word) == true)
                        {
                            Console.WriteLine("Vous avez déja joué le mot : " + player1Word + ", merci de jouer un autre mot");
                        }
                        else if (InstanceDeJeu.Dico.RechercheDichoRecursif(player1Word) == false)
                        {
                            Console.WriteLine(player1Word + " n'est pas dans le dictionnaire français !");
                        }
                        else if (InstanceDeJeu.PlateauDeJeu.SearchWordTab(player1Word) == null)
                        {
                            Console.WriteLine(player1Word + " n'est pas dans le jeu !");
                        } 

                    } while (InstanceDeJeu.Dico.RechercheDichoRecursif(player1Word) != true || InstanceDeJeu.Joueur1.Contient(player1Word) != false || InstanceDeJeu.PlateauDeJeu.Recherche_Mot(player1Word) != true);//bouger la detection de la matrice en bas

                    InstanceDeJeu.Joueur1.CalculScore(player1Word);
                    InstanceDeJeu.Joueur1.Add_Mot(player1Word);


                    string mp3FilePathClapping = "clap.mp3";
                    using (var audioFile = new AudioFileReader(mp3FilePathClapping))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);
                        Console.WriteLine("Mot validé votre score est désormais de : " + InstanceDeJeu.Joueur1.score + " !");
                        if (sound == true)
                        {
                            outputDevice.Play();
                        }
                    
                        Thread.Sleep(1000);

                    }

                }

                Console.Clear();

                if (DateTime.Now - HeureDuDebutDeTour > ChronoFinTour)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(0, 2);
                    Console.Write("Votre temps a été écoulé ! C'est à " + InstanceDeJeu.Joueur2.nom + " de jouer !");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(0, 5);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Le score de " + InstanceDeJeu.Joueur1.nom + " est de : ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(InstanceDeJeu.Joueur1.score);
                Console.SetCursorPosition(0, 6);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Le score de " + InstanceDeJeu.Joueur2.nom + " est de : ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(InstanceDeJeu.Joueur2.score);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;




                //TOUR DU JOUEUR 2


                gameIsFinished = InstanceDeJeu.PlateauDeJeu.IsTabEmpty();
                HeureDuDebutDeTour = DateTime.Now;
                InstanceDeJeu.PlateauDeJeu.AffichageConsole();
                Console.WriteLine("\n");
                Console.WriteLine("C'est à " + InstanceDeJeu.Joueur2.nom + " de jouer !");
                while (Console.KeyAvailable == false && DateTime.Now - HeureDuDebutDeTour < ChronoFinTour)
                {
                    Thread.Sleep(100); //on temporise 0.1 sec

                }

                if (gameIsFinished == false && DateTime.Now-HeureDuDebutDeJeu< ChronoFinJeu && DateTime.Now - HeureDuDebutDeTour < ChronoFinTour){ //on verifie si le tab n'est pas vide !
                    do
                    {

                        
                        Console.WriteLine(InstanceDeJeu.Joueur2.nom + ", merci de rentrer votre mot !");
                        player2Word = Console.ReadLine().ToLower();


                        if (InstanceDeJeu.PlateauDeJeu.SearchWordTab(player2Word) == null && InstanceDeJeu.Dico.RechercheDichoRecursif(player2Word) == false)
                        {
                            Console.WriteLine("Votre mot n'est ni dans le plateau ni dans le dictionnaire c'est pitoyable");
                        }
                        else if (InstanceDeJeu.Joueur2.Contient(player2Word) == true)
                        {
                            Console.WriteLine("Vous avez déja joué le mot : " + player2Word + ", merci de jouer un autre mot");
                        }
                        else if (InstanceDeJeu.Dico.RechercheDichoRecursif(player2Word) == false)
                        {
                            Console.WriteLine(player2Word + " n'est pas dans le dictionnaire français !");
                        }
                        else if (InstanceDeJeu.PlateauDeJeu.SearchWordTab(player2Word) == null)
                        {
                            Console.WriteLine(player2Word + " n'est pas dans le jeu !");
                        } 

                    } while (InstanceDeJeu.Dico.RechercheDichoRecursif(player2Word) != true || InstanceDeJeu.Joueur2.Contient(player2Word) != false || InstanceDeJeu.PlateauDeJeu.Recherche_Mot(player2Word) != true);//bouger la detection de la matrice en bas

                    InstanceDeJeu.Joueur2.CalculScore(player2Word);
                    InstanceDeJeu.Joueur2.Add_Mot(player2Word);

                    string mp3FilePathClapping = "clap.mp3";
                    using (var audioFile = new AudioFileReader(mp3FilePathClapping))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);
                        Console.WriteLine("Mot validé votre score est désormais de : " + InstanceDeJeu.Joueur2.score + " !");
                        if (sound == true)
                        {
                            outputDevice.Play();
                        }
                        Thread.Sleep(1000);

                    }


                }



                gameIsFinished = InstanceDeJeu.PlateauDeJeu.IsTabEmpty();






            }
            
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\r\n ▄▄▄▄    ██▀███   ▄▄▄    ██▒   █▓ ▒█████                                 ▐██▌ \r\n▓█████▄ ▓██ ▒ ██▒▒████▄ ▓██░   █▒▒██▒  ██▒                               ▐██▌ \r\n▒██▒ ▄██▓██ ░▄█ ▒▒██  ▀█▄▓██  █▒░▒██░  ██▒                               ▐██▌ \r\n▒██░█▀  ▒██▀▀█▄  ░██▄▄▄▄██▒██ █░░▒██   ██░                               ▓██▒ \r\n░▓█  ▀█▓░██▓ ▒██▒ ▓█   ▓██▒▒▀█░  ░ ████▓▒░                               ▒▄▄  \r\n░▒▓███▀▒░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ▐░  ░ ▒░▒░▒░                                ░▀▀▒ \r\n▒░▒   ░   ░▒ ░ ▒░  ▒   ▒▒ ░░ ░░    ░ ▒ ▒░                                ░  ░ \r\n ░    ░   ░░   ░   ░   ▒     ░░  ░ ░ ░ ▒                                    ░ \r\n ░         ░           ░  ░   ░      ░ ░                                 ░    \r\n      ░                      ░                                                \r\n");
            Console.ForegroundColor= ConsoleColor.White;
            Console.SetCursorPosition(10, 20);
            if (InstanceDeJeu.Joueur1.score > InstanceDeJeu.Joueur2.score)
            {
                Console.WriteLine("Le gagnant de cette glaciale partie est : " + InstanceDeJeu.Joueur1.nom + " et son score est de : " + InstanceDeJeu.Joueur1.score);
            } else
            {
                Console.WriteLine("Le gagnant de cette glaciale partie est : " + InstanceDeJeu.Joueur2.nom + " et son score est de : " + InstanceDeJeu.Joueur2.score);
            }

            Console.SetCursorPosition(10, 25);

            Console.WriteLine("Voulez-vous rejouer ? 1 = Oui |  2 = Parametre | 3 = Non");

            Console.SetCursorPosition(10, 27);
            int selectionReturn = int.Parse(Console.ReadLine());
            if (selectionReturn == 1)
            {
                Console.Clear();
                Play(fileName,sound, tempoTimeGame, tempoTimeTour); // 10 et 60 de base
            } else if (selectionReturn == 2)
            {
                Console.Clear();
                Settings(fileName);
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

            //Console.SetWindowSize(1880, 1020);
            string fileName = "Test1";
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("Ce jeu est jouable à deux, munissez vous d'un compère et préparez vos dictionnaires avant de mener une bataille sanglante pour la victoire !");
            Console.SetCursorPosition(10, 21);
            Console.WriteLine("N'oubliez pas que certains paramètres sont disponible dans la section PARAMETRES du menu principal ! Bon jeu !");
            Console.SetCursorPosition(30, 24);
            Console.WriteLine("Merci d'appuyer sur une touche une fois la lecture des règles terminées.");
            Console.SetCursorPosition(30, 26);
            Console.ReadKey();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(0, 10);
            Console.WriteLine(" ███▄ ▄███▓ ▒█████  ▄▄▄█████▓  ██████                  ▄████  ██▓    ▄▄▄       ▄████▄   ██▓ ▄▄▄       ██▓ ██▀███  ▓█████   ██████    \r\n▓██▒▀█▀ ██▒▒██▒  ██▒▓  ██▒ ▓▒▒██    ▒                 ██▒ ▀█▒▓██▒   ▒████▄    ▒██▀ ▀█  ▓██▒▒████▄    ▓██▒▓██ ▒ ██▒▓█   ▀ ▒██    ▒    \r\n▓██    ▓██░▒██░  ██▒▒ ▓██░ ▒░░ ▓██▄                  ▒██░▄▄▄░▒██░   ▒██  ▀█▄  ▒▓█    ▄ ▒██▒▒██  ▀█▄  ▒██▒▓██ ░▄█ ▒▒███   ░ ▓██▄      \r\n▒██    ▒██ ▒██   ██░░ ▓██▓ ░   ▒   ██▒               ░▓█  ██▓▒██░   ░██▄▄▄▄██ ▒▓▓▄ ▄██▒░██░░██▄▄▄▄██ ░██░▒██▀▀█▄  ▒▓█  ▄   ▒   ██▒   \r\n▒██▒   ░██▒░ ████▓▒░  ▒██▒ ░ ▒██████▒▒               ░▒▓███▀▒░██████▒▓█   ▓██▒▒ ▓███▀ ░░██░ ▓█   ▓██▒░██░░██▓ ▒██▒░▒████▒▒██████▒▒   \r\n░ ▒░   ░  ░░ ▒░▒░▒░   ▒ ░░   ▒ ▒▓▒ ▒ ░                ░▒   ▒ ░ ▒░▓  ░▒▒   ▓▒█░░ ░▒ ▒  ░░▓   ▒▒   ▓▒█░░▓  ░ ▒▓ ░▒▓░░░ ▒░ ░▒ ▒▓▒ ▒ ░   \r\n░  ░      ░  ░ ▒ ▒░     ░    ░ ░▒  ░ ░                 ░   ░ ░ ░ ▒  ░ ▒   ▒▒ ░  ░  ▒    ▒ ░  ▒   ▒▒ ░ ▒ ░  ░▒ ░ ▒░ ░ ░  ░░ ░▒  ░ ░   \r\n░      ░   ░ ░ ░ ▒    ░      ░  ░  ░                 ░ ░   ░   ░ ░    ░   ▒   ░         ▒ ░  ░   ▒    ▒ ░  ░░   ░    ░   ░  ░  ░     \r\n       ░       ░ ░                 ░                       ░     ░  ░     ░  ░░ ░       ░        ░  ░ ░     ░        ░  ░      ░     \r\n                                                                              ░                                                      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n");

            Console.SetCursorPosition(60, 22);
            Console.WriteLine("1)    JOUER ");
            Console.SetCursorPosition(60, 24);
            Console.WriteLine("2)    PARAMETRES ");
            Console.SetCursorPosition(60, 26);
            Console.WriteLine("3)    QUITTER ");



            string mp3FilePath = "introCR.mp3"; // Replace this with the actual path to your MP3 file

          
            using (var audioFile = new AudioFileReader(mp3FilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                string selection = "";

                do
                {
                    Console.SetCursorPosition(60, 30);
                    Console.WriteLine("Dans quel menu voulez-vous aller ?");

                    Console.SetCursorPosition(60, 32);
                    selection = Console.ReadLine();

                    if (selection != "1" && selection != "2" && selection != "3")
                    {
                        Console.SetCursorPosition(60, 34);
                        Console.WriteLine("Saisie incorrecte. Veuillez entrer 1, 2 ou 3.");
                    }

                } while (selection != "1" && selection != "2" && selection != "3");

                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        Play(fileName,true,10,60); // le son est activé par défaut
                        break;

                    case "2":
                        Console.Clear();
                        fileName=Settings(fileName);
                        break;

                    case "3":
                        Quit();
                        break;
                }

            }







        }
    }
}