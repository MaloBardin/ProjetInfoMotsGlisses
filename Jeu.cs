using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    /// <summary>
    /// La classe jeu contient les joueurs mais également le plateau et l'instance de dictionnaire
    /// </summary>
    internal class Jeu
    {    
        
        Plateau plateau;
        Dictionnaire dico;
        Joueur joueur1;
        Joueur joueur2;

        /// <summary>
        /// Le constructeur du jeu qui permet de créer un jeu, un plateau, une instance de dico 
        /// </summary>
        /// <param name="filename">le nom du fichier à lire </param>
        public Jeu(string filename)
        {

            Dictionnaire dico = new Dictionnaire();
            this.dico = dico;
            Plateau plateauDeJeu = new Plateau(filename);
            this.plateau = plateauDeJeu;
            
        }

        public Jeu()
        {
            Console.WriteLine("Création d'une instance jeu et d'une matrice");
        }
        /// <summary>
        /// Propriété pour communiquer avec le main
        /// </summary>
        public Dictionnaire Dico
        {

            get { return this.dico; }
            set { this.dico = value; }
        }

        /// <summary>
        /// Propriété pour communiquer avec le main
        /// </summary>
        public Plateau PlateauDeJeu
        {

            get { return this.plateau; }
            set { this.plateau = value; }
        }

        public Joueur Joueur1
        {
            get { return this.joueur1; }
            set { this.joueur1 = value; }
        }

        public Joueur Joueur2
        {
            get { return this.joueur2; }
            set { this.joueur2 = value; }
        }







    }
}
