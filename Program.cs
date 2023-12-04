namespace ProjetInfoMotsCroises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jeu InstanceDeJeu = new Jeu();
            Joueur joueur1 = new Joueur();
            Joueur joueur2 = new Joueur();
            Console.WriteLine("Entrez le nom du joueur 1 : ");
            joueur1.nom = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Entrez le nom du joueur 2 : ");
            joueur2.nom = Convert.ToString(Console.ReadLine());
            DateTime dateTime = DateTime.Now;
            int temps0 = dateTime.Minute;
            while(DateTime.Now.Minute <temps0+5)
            {
                Console.WriteLine("Joueur 1, saisissez votre mot : ");
                string motj1 = Console.ReadLine();
                if (InstanceDeJeu.Dico.RechercheDichoRecursif(0, 120000,  , motj1)==true)
                {
                    joueur1.mots.Add(motj1);
                    Console.WriteLine("Bien joué ! ");
                }
                else
                {
                    Console.WriteLine("Ce mot n'existe pas, vous avez perdu la main ");
                }
                Console.WriteLine("Joueur 2, saisissez votre mot : ");
                string motj2 = Console.ReadLine();
                if (InstanceDeJeu.Dico.RechercheDichoRecursif(0, 120000,  , motj2) == true)
                {
                    joueur1.mots.Add(motj2);
                    Console.WriteLine("Bien joué ! ");
                }
                else
                {
                    Console.WriteLine("Ce mot n'existe pas, vous avez perdu la main ");
                }
            }


            
            Plateau AffichageJeu = new Plateau("Test1");

            //-> renvoie automatiquement tout ce qu'il faut ( matrice gen dans jeu)
            //Console.WriteLine(AffichageJeu.SearchWord("maison"));
            Console.WriteLine(Dictionnaire.toString());
/*
            int[,] test=AffichageJeu.SearchWordTab("maison");

            if (test == null)
            {
                Console.WriteLine("Pas de mot dans le tab");
            } else
            {
                for (int i = 0; i < test.GetLength(0); i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.Write(test[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            */


        }
    }
}