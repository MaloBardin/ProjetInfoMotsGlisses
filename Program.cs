namespace ProjetInfoMotsCroises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ici, on déclare tout, les noms des joueurs, et l'heure pour suivre le temps


            Jeu InstanceDeJeu = new Jeu("Test1");
            InstanceDeJeu.Dico.ToString();
          


            Joueur joueur1 = new Joueur();
            Joueur joueur2 = new Joueur();

            Console.WriteLine("Entrez le nom du joueur 1 : ");
            joueur1.nom = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Entrez le nom du joueur 2 : ");
            joueur2.nom = Convert.ToString(Console.ReadLine());
            DateTime dateTime = DateTime.Now;
            int temps0 = dateTime.Minute;


            while (DateTime.Now.Minute < temps0 + 1)
            {
                //tour du joueur 1saisie du mot
                Console.WriteLine("Joueur 1, saisissez votre mot : ");
                string motj1 = Console.ReadLine();
                //Vérification du mot dans le dictionnaire
                //     Malo    il faudra faire la vérification dans le plateau avec un "&&"
                if (InstanceDeJeu.Dico.RechercheDichoRecursif(0, 120000, motj1) == true && InstanceDeJeu.PlateauDeJeu.SearchWord(motj1)==true)
                {
                    joueur1.mots.Add(motj1);
                    Console.WriteLine("Bien joué ! ");
                    joueur1.score += motj1.Length;
                    Console.WriteLine("Le score de " + joueur1.nom + " est de " + joueur1.score);
                    Console.WriteLine("Voici le tableau après ce tour : ");
                    InstanceDeJeu.PlateauDeJeu.AffichageConsole();

                }
                else
                {
                    Console.WriteLine("Ce mot n'existe pas, vous avez perdu la main ");
                }
                Console.WriteLine("Joueur 2, saisissez votre mot : ");
                string motj2 = Console.ReadLine();


                if (InstanceDeJeu.Dico.RechercheDichoRecursif(0, 130557, motj2) == true && InstanceDeJeu.PlateauDeJeu.SearchWord(motj2) == true) // si ça existe dans le dico (mot francais)
                {
                    joueur2.mots.Add(motj2);
                    Console.WriteLine("Bien joué ! ");
                    joueur2.score += motj2.Length;
                    Console.WriteLine("Le score de " + joueur2.nom + " est de " + joueur2.score);
                    Console.WriteLine("Voici le tableau après ce tour : ");
                    InstanceDeJeu.PlateauDeJeu.AffichageConsole();

                }
                else
                {
                    Console.WriteLine("Ce mot n'existe pas, vous avez perdu la main ");
                }
            }



        }
    }
}