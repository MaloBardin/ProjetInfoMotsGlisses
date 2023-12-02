namespace ProjetInfoMotsCroises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");




            //initialisation d'un plateau via jeu.cs
            Jeu InstanceDeJeu = new Jeu();

            //Affichage cs (to read (stringname))
            Plateau AffichageJeu = new Plateau("Test1");

            //-> renvoie automatiquement tout ce qu'il faut ( matrice gen dans jeu)
            //Console.WriteLine(AffichageJeu.SearchWord("maison"));
            //Dictionnaire.toString();
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