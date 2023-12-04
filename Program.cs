namespace ProjetInfoMotsCroises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ici, on déclare tout, les noms des joueurs, et l'heure pour suivre le temps
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
                //tour du joueur 1saisie du mot
                Console.WriteLine("Joueur 1, saisissez votre mot : ");
                string motj1 = Console.ReadLine();
                //Vérification du mot dans le dictionnaire
                //     Malo    il faudra faire la vérification dans le plateau avec un "&&"
                if (InstanceDeJeu.Dico.RechercheDichoRecursif(0, 120000,  , motj1)==true)
                {
                    joueur1.mots.Add(motj1);
                    Console.WriteLine("Bien joué ! ");
                    joueur1.score += motj1.Length;
                    Console.WriteLine("Le score de " + joueur1.nom + " est de " + joueur1.score);
                    Console.WriteLine("Voici le tableau après ce tour : ");
                    Plateau AffichageJeu = new Plateau("Test");
                }
                else
                {
                    Console.WriteLine("Ce mot n'existe pas, vous avez perdu la main ");
                }
                Console.WriteLine("Joueur 2, saisissez votre mot : ");
                string motj2 = Console.ReadLine();


                if (InstanceDeJeu.Dico.RechercheDichoRecursif(0, 120000,  , motj2) == true)
                {
                    joueur2.mots.Add(motj2);
                    Console.WriteLine("Bien joué ! ");
                    joueur2.score += motj2.Length;
                    Console.WriteLine("Le score de " + joueur2.nom + " est de " + joueur2.score);
                    Console.WriteLine("Voici le tableau après ce tour : ");
                    Plateau AffichageJeu=new Plateau("Test");
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