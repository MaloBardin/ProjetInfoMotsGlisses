namespace ProjetInfoMotsCroises
{

    using System;
    using System.Dynamic;
    using NAudio.Wave;


    internal class Program
    {


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
                InstanceDeJeu.PlateauDeJeu.AffichageConsole();//affichage console


                //verif qu'il existe au moins 1 mot


                string player1Word = "";
                string player2Word = "";

                do
                {
                    Console.WriteLine(joueur1.nom + ", merci de rentrer votre mot !");
                    player1Word = Console.ReadLine();

                } while (InstanceDeJeu.Dico.RechercheDichoRecursif(player1Word) != true || joueur1.Contient(player1Word) != false || InstanceDeJeu.PlateauDeJeu.Recherche_Mot(player1Word) != true);

                joueur1.CalculScore(player1Word);
                joueur1.Add_Mot(player1Word);

                Console.WriteLine("Mot validé votre score est désormais de : " + joueur1.score + " !");
                InstanceDeJeu.PlateauDeJeu.AffichageConsole();
                do
                {
                    Console.WriteLine(joueur2.nom + ", merci de rentrer votre mot !");
                    player2Word = Console.ReadLine();

                } while (InstanceDeJeu.Dico.RechercheDichoRecursif(player2Word) != true || joueur1.Contient(player2Word) != false || InstanceDeJeu.PlateauDeJeu.Recherche_Mot(player2Word) != true);

                joueur2.CalculScore(player2Word);
                joueur2.Add_Mot(player1Word);
                Console.WriteLine("Mot validé votre score est désormais de : " + joueur2.score + " !");








            }
        }

        static void Quit()
        {
            Environment.Exit(0);
        }

        

        static void Main(string[] args)
        {

            Console.SetCursorPosition(40, 20);
            Console.WriteLine("Ce jeu est jouable à deux, munissez vous d'un compère et préparez vos dictionnaires avant de mener une bataille sanglante pour la victoire !");
            Console.SetCursorPosition(40, 21);
            Console.WriteLine("N'oubliez pas que certains paramètres sont disponible dans la section PARAMETRES du menu principal ! Bon jeu !");
            Console.SetCursorPosition(40, 24);
            Console.WriteLine("Merci d'appuyer sur une touche une fois la lecture des règles terminées.");
            Console.ReadKey();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
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
               // outputDevice.Play();

               
            }


            

        }
    }
}