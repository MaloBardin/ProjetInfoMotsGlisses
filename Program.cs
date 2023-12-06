namespace ProjetInfoMotsCroises
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string fileName = "Test1";

            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ███▄ ▄███▓ ▒█████  ▄▄▄█████▓  ██████                  ▄████  ██▓     ██▓  ██████   ██████ ▓█████   ██████ \r\n▓██▒▀█▀ ██▒▒██▒  ██▒▓  ██▒ ▓▒▒██    ▒                 ██▒ ▀█▒▓██▒    ▓██▒▒██    ▒ ▒██    ▒ ▓█   ▀ ▒██    ▒ \r\n▓██    ▓██░▒██░  ██▒▒ ▓██░ ▒░░ ▓██▄                  ▒██░▄▄▄░▒██░    ▒██▒░ ▓██▄   ░ ▓██▄   ▒███   ░ ▓██▄   \r\n▒██    ▒██ ▒██   ██░░ ▓██▓ ░   ▒   ██▒               ░▓█  ██▓▒██░    ░██░  ▒   ██▒  ▒   ██▒▒▓█  ▄   ▒   ██▒\r\n▒██▒   ░██▒░ ████▓▒░  ▒██▒ ░ ▒██████▒▒               ░▒▓███▀▒░██████▒░██░▒██████▒▒▒██████▒▒░▒████▒▒██████▒▒\r\n░ ▒░   ░  ░░ ▒░▒░▒░   ▒ ░░   ▒ ▒▓▒ ▒ ░                ░▒   ▒ ░ ▒░▓  ░░▓  ▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░░░ ▒░ ░▒ ▒▓▒ ▒ ░\r\n░  ░      ░  ░ ▒ ▒░     ░    ░ ░▒  ░ ░                 ░   ░ ░ ░ ▒  ░ ▒ ░░ ░▒  ░ ░░ ░▒  ░ ░ ░ ░  ░░ ░▒  ░ ░\r\n░      ░   ░ ░ ░ ▒    ░      ░  ░  ░                 ░ ░   ░   ░ ░    ▒ ░░  ░  ░  ░  ░  ░     ░   ░  ░  ░  \r\n       ░       ░ ░                 ░                       ░     ░  ░ ░        ░        ░     ░  ░      ░  \r\n                                                                                                           ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ce jeu est jouable à deux, munissez vous d'un compère et préparer vos dictionnaire avant une bataille sanglante pour la victoire !");
            Console.WriteLine("N'oubliez pas que certains paramètres sont disponible dans la section PARAMETRE du menu principal ! Bon jeu !");
            //Console.WriteLine("                          ........ \r\n                           ;::;;::;, \r\n                           ;::;;::;;, \r\n                          ;;:::;;::;;, \r\n          .vnmmnv%vnmnv%,.;;;:::;;::;;,  .,vnmnv%vnmnv, \r\n       vnmmmnv%vnmmmnv%vnmmnv%;;;;;;;%nmmmnv%vnmmnv%vnmmnv \r\n     vnmmnv%vnmmmmmnv%vnmmmmmnv%;:;%nmmmmmmnv%vnmmmnv%vnmmmnv \r\n    vnmmnv%vnmmmmmnv%vnmmmmmmmmnv%vnmmmmmmmmnv%vnmmmnv%vnmmmnv \r\n   vnmmnv%vnmmmmmnv%vnmmmmmmmmnv%vnmmmmmmmmmmnv%vnmmmnv%vnmmmnv \r\n  vnmmnv%vnmmmmmnv%vnmm;mmmmmmnv%vnmmmmmmmm;mmnv%vnmmmnv%vnmmmnv, \r\n vnmmnv%vnmmmmmnv%vnmm;' mmmmmnv%vnmmmmmmm;' mmnv%vnmmmnv%vnmmmnv \r\n vnmmnv%vnmmmmmnv%vn;;    mmmmnv%vnmmmmmm;;    nv%vnmmmmnv%vnmmmnv \r\nvnmmnv%vnmmmmmmnv%v;;      mmmnv%vnmmmmm;;      v%vnmmmmmnv%vnmmmnv \r\nvnmmnv%vnmmmmmmnv%vnmmmmmmmmm;;       mmmmmmmmmnv%vnmmmmmmnv%vnmmmnv \r\nvnmmnv%vnmmmmmmnv%vnmmmmmmmmmm;;     mmmmmmmmmmnv%vnmmmmmmnv%vnmmmnv \r\nvnmmnv%vnmmmmm nv%vnmmmmmmmmmmnv;, mmmmmmmmmmmmnv%vn;mmmmmnv%vnmmmnv \r\nvnmmnv%vnmmmmm  nv%vnmmmmmmmmmnv%;nmmmmmmmmmmmnv%vn; mmmmmnv%vnmmmnv \r\n`vnmmnv%vnmmmm,  v%vnmmmmmmmmmmnv%vnmmmmmmmmmmnv%v;  mmmmnv%vnnmmnv' \r\n vnmmnv%vnmmmm;,   %vnmmmmmmmmmnv%vnmmmmmmmmmnv%;'   mmmnv%vnmmmmnv \r\n  vnmmnv%vnmmmm;;,   nmmm;'              mmmm;;'    mmmnv%vnmmmmnv' \r\n  `vnmmnv%vnmmmmm;;,.         mmnv%v;,            mmmmnv%vnmmmmnv' \r\n   `vnmmnv%vnmmmmmmnv%vnmmmmmmmmnv%vnmmmmmmnv%vnmmmmmnv%vnmmmmnv' \r\n     `vnmvn%vnmmmmmmnv%vnmmmmmmmnv%vnmmmmmnv%vnmmmmmnv%vnmmmnv' \r\n         `vn%vnmmmmmmn%:%vnmnmmmmnv%vnmmmnv%:%vnmmnv%vnmnv'");

            Jeu InstanceDeJeu = new Jeu(fileName); // création du jeu
            Console.WriteLine("Comment s'appellera le premier joueur ?");
            string namePlayer1 = Console.ReadLine();
            Console.WriteLine("Et quel est le nom du second protagoniste ?");
            string namePlayer2 = Console.ReadLine();

            Joueur joueur1 = new Joueur(namePlayer1);
            Joueur joueur2 = new Joueur(namePlayer2);

            Console.WriteLine("Vous êtes fin prêt à débuter la partie ! Que le grand jeu commence !");

            bool gameIsFinished = false;

            while (gameIsFinished == true)
            {
                string motj1 = "maison";
                if (InstanceDeJeu.Dico.RechercheDichoRecursif(0, 130557, motj1) == true && InstanceDeJeu.PlateauDeJeu.Recherche_Mot(motj1) == true)
                {
                    int scoremot = joueur1.calculscore(motj1);
                    joueur1.mots.Add(motj1);
                    Console.WriteLine("Bien joué ! ");
                    joueur1.Add_Score(scoremot);
                    Console.WriteLine("Le score de " + joueur1.nom + " est de " + joueur1.score);
                    Console.WriteLine("Voici le tableau après ce tour : ");
                    InstanceDeJeu.PlateauDeJeu.AffichageConsole();

                }

                gameIsFinished = false;



            }

        }
    }
}