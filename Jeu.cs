using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Jeu
    {    
        
        Plateau plateau;
        Dictionnaire dico;
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
        public Dictionnaire Dico
        {

            get { return this.dico; }
            set { this.dico = value; }
        }

        public Plateau PlateauDeJeu
        {

            get { return this.plateau; }
            set { this.plateau = value; }
        }









    }
}
