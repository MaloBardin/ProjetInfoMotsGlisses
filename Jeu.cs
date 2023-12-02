using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Jeu
    {    
        int tailleX;
        int tailleY;
        Affichage plateau;
        Dictionnaire dictionnaire;
        public Jeu(int tailleX, int tailleY, Affichage plateau, Dictionnaire dictionnaire)
        {
            this.tailleX = tailleX;
            this.tailleY = tailleY;
            this.plateau = plateau;
            this.dictionnaire = dictionnaire;
        }

        public Jeu()
        {
            Console.WriteLine("Création d'une instance jeu et d'une matrice");
        }




        public int TailleX
        {
            get { return this.tailleX; }
            set { this.tailleX = value; }
        }

        public int TailleY
        {
            get { return this.tailleY; }
            set { this.tailleY = value; }
        }

        public char[,] Plateau
        {
            get { return this.plateau; }
            set { this.plateau = value; }
        }


    }
}
