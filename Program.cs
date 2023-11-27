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
            Affichage AffichageJeu = new Affichage(InstanceDeJeu,"Test1");

            //-> renvoie automatiquement tout ce qu'il faut ( matrice gen dans jeu)
            //
            //salut c pa



        }
    }
}