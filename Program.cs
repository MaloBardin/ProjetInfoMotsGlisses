namespace ProjetInfoMotsCroises
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Bienvenue au jeu des mots croisés !");


            Console.WriteLine("\n\n\n\n");

            Console.Write("Combien de joueur êtes vous ? : ");
            int nombreJoueurs = int.Parse(Console.ReadLine());

            Console.WriteLine("\nParfait, vous serez donc " + nombreJoueurs + " à jouer aujourd'hui. Que le jeu commence !");



            bool GameIsEnded = false;









            //initialisation d'un plateau via jeu.cs
            Jeu InstanceDeJeu = new Jeu();

            //Affichage cs (to read (stringname))
            Plateau AffichageJeu = new Plateau("Test1");

            if (AffichageJeu.SearchWordTab("ma") == null)
            {

                Console.WriteLine("null");
            }





        }
    }
}