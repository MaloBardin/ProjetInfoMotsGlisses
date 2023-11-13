using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Affichage
    {

        int tailleX;
        int tailleY;
        char[,] plateau;

        public Affichage()
        {
            this.tailleX = 0;
            this.tailleY = 0;

            
        }
       

        public void RandomGen()
        {

            this.tailleX = 8;
            this.tailleY = 8; //TAILLE PAR DEFAUT A SAVOIR SI ELLE DOIT ETRE RANDOM OU NOM

            
            Random random = new Random();



            for (int i=0; i < tailleX; i++)
            {
                for (int j=0; j < tailleY; j++)
                {

                    //this.plateau[i, j] = char.Parse(random.Next(97, 122));
                    Console.WriteLine(random.Next(97,122));//gen parmi 97 et 122 (nombre en ascii)
                }
            }





        }


        public void ToRead(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename + ".csdv");
                //string cheminFichier = filename + ".csv";

                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(';');
                   
                    for (int i = 0; i < TabTemp.Length; i++)// 
                    {
                        Console.Write(TabTemp[i]+ " "); 

                    }

                    Console.WriteLine("");
                    this.tailleX = TabTemp.Length;
                }

                
                this.tailleY = lines.Length;


                //TEST

            }

            catch (FileNotFoundException f)
            {
                Console.WriteLine("Le fichier n'existe pas " + f.Message);
                Console.WriteLine("Nous allons procéder à la génération aléatoire pondérée du plateau");
                RandomGen();

            }
            finally { Console.WriteLine(""); };
        }
    }
}
