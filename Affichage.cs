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



                for (int i = 0; i < tabProba.Length; i++)
                {

                    Console.WriteLine(tabLettre[i] + " : " + tabProba[i]);
                }

                int compteur = 0;

                for (int i = 0; i < tailleX; i++)
                {
                    for (int j = 0; j < tailleY; j++)
                    {
                        int stop = 0;
                        do
                        {
                            Console.WriteLine("Boucle une fois");
                            int randomChar = random.Next(97, 122);
                            Console.WriteLine(" random :" + randomChar);
                            
                            Console.WriteLine("on est dedans");
                            Console.WriteLine(" omg : " + randomChar);
                            Console.WriteLine(" random proba :" + tabProba[randomChar-97]);
                            if (tabProba[randomChar - 97] > 0)
                            {
                                tabProba[randomChar - 97] = tabProba[randomChar - 97] - 1;
                                this.plateau[i, j] = tabLettre[randomChar - 97];
                                stop = 1;
                                compteur++;
                            }
                            
                            
                        } while (stop==0);

                        Console.WriteLine("Boucle réussie");


                    }
                }
                for (int i = 0; i < tabProba.Length; i++)
                {
                    Console.WriteLine((i + 97) + " " + tabProba[i]);
                }

                Console.WriteLine("compteur : " + compteur);

                for (int i = 0; i < tailleX; i++)
                {
                    for (int j=0;j< tailleY; j++)
                    {
                        Console.Write(this.plateau[i, j] + " ");
                    }
                    Console.WriteLine("");
                }



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


                this.plateau = new char[tailleX, tailleY];

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
