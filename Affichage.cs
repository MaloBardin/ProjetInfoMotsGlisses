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

        public Affichage(int x, int y)
        {
            this.tailleX = x;
            this.tailleY = y ;
            this.plateau = new char[tailleX, tailleY];


        }

        public Affichage(string filename)
        {
            ToRead(filename);
        }
       
        public void AffichageConsole()
        {
            //AFFICHAGE
            for (int u = 0; u < tailleY; u++)
            {
                Console.Write("- - ");
            }
            Console.WriteLine();

            for (int i = 0; i < tailleX; i++)
            {


                for (int j = 0; j < tailleY; j++)
                {
                    if (i == tailleX - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(this.plateau[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" | ");
                }
                Console.WriteLine("");
                if (i < tailleX - 1)
                {
                    for (int u = 0; u < tailleY; u++)
                    {
                        Console.Write("- + ");
                    }
                    Console.WriteLine();
                }



            }


            for (int u = 0; u < tailleY; u++)
            {
                Console.Write("- - ");
            }
            Console.WriteLine();

        }

        public void RandomGen()
        {

            this.tailleX = 8;
            this.tailleY = 8; //TAILLE PAR DEFAUT A SAVOIR SI ELLE DOIT ETRE RANDOM OU NOM
            this.plateau = new char[tailleX, tailleY];
            int[] tabProba = new int[26];
            char[] tabLettre = new char[26];


            Random random = new Random();
            string filename = "Lettre";
            try
            {
                string[] lines = File.ReadAllLines(filename + ".txt");
                //string cheminFichier = filename + ".txt";
                
                int posLigne = 0;
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(',');
                    tabLettre[posLigne] = char.Parse(TabTemp[0]);
                    tabProba[posLigne] = int.Parse(TabTemp[1]);
                    
                    

                    
                    posLigne++;
                }

                int compteur = 0;

                for (int i = 0; i < tailleX; i++)
                {
                    for (int j = 0; j < tailleY; j++)
                    {
                        int stop = 0;
                        do
                        {
                            
                            int randomChar = random.Next(97, 122);
                           
                            if (tabProba[randomChar - 97] > 0)
                            {
                                tabProba[randomChar - 97] = tabProba[randomChar - 97] - 1;
                                this.plateau[i, j] = tabLettre[randomChar - 97];
                                stop = 1;
                                compteur++;
                            }
                            
                            
                        } while (stop==0);

                        


                    }
                }

                AffichageConsole();

                


            }

            catch (FileNotFoundException f)
            {
                Console.WriteLine("Le fichier de pondération n'existe pas " + f.Message);
                Console.WriteLine("Nous allons procéder à la génération aléatoire pondérée du plateau");
                

            }
            finally { Console.WriteLine(""); };







        }


        public void ToRead(string filename)
        {
            try
            {
                //SETUP TAILLE X TAILLE Y
                string[] lines = File.ReadAllLines(filename + ".csv");
                //string cheminFichier = filename + ".csv";
                this.tailleY = lines.Length;
                foreach (string line in lines)
                {
                    string[] TabTemp = line.Split(';');
                    this.tailleX = TabTemp.Length;  
                }

                this.plateau = new char[tailleX, tailleY];


                int x = 0; //position x tab
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(';');
                    
                    for (int i = 0; i < TabTemp.Length; i++)// 
                    {
                        this.plateau[x, i] = TabTemp[i][0];

                    }

                    x++;
                }

                AffichageConsole();




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
