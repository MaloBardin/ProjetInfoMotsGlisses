﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Jeu
    {    
        
        Plateau plateau;
        Dictionnaire dictionnaire;
        public Jeu(int tailleX, int tailleY, Plateau plateau, Dictionnaire dictionnaire)
        {
            
            this.plateau = plateau;
            this.dictionnaire = dictionnaire;
        }

        public Jeu()
        {
            Console.WriteLine("Création d'une instance jeu et d'une matrice");
        }




        
        


    }
}
