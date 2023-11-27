using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Affichage
    {
        Jeu jeu;

        public Affichage(Jeu jeu, string filename)
        {
            this.jeu = jeu;
            ToRead(filename);
        }
       
        public void AffichageConsole()
        {
            //AFFICHAGE
            for (int u = 0; u < jeu.TailleY; u++)
            {
                Console.Write("- - ");
            }
            Console.WriteLine();

            for (int i = 0; i < jeu.TailleX; i++)
            {


                for (int j = 0; j < jeu.TailleY; j++)
                {
                    if (i == jeu.TailleX - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(jeu.Plateau[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" | ");
                }
                Console.WriteLine("");
                if (i < jeu.TailleX - 1)
                {
                    for (int u = 0; u < jeu.TailleY; u++)
                    {
                        Console.Write("- + ");
                    }
                    Console.WriteLine();
                }



            }


            for (int u = 0; u < jeu.TailleY; u++)
            {
                Console.Write("- - ");
            }
            Console.WriteLine();

        }

        public void RandomGen()
        {


            jeu.TailleX = 8;
            jeu.TailleY = 8; //TAILLE PAR DEFAUT A SAVOIR SI ELLE DOIT ETRE RANDOM OU NOM
            jeu.Plateau = new char[jeu.TailleX, jeu.TailleY];
            int[] tabProba = new int[26];
            char[] tabLettre = new char[26];


            Random random = new Random();
            string filename = "Lettre";
            try
            {
                string[] lines = File.ReadAllLines(filename + ".txt");
                //string cheminFichier = filename + ".txt";
                

                //LECTURE FICHIER LETTRE PONDERATION
                int posLigne = 0;
                int compteursommetab=0;
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(',');
                    tabLettre[posLigne] = char.Parse(TabTemp[0]);
                    tabProba[posLigne] = int.Parse(TabTemp[1]);

                    compteursommetab += tabProba[posLigne];


                    posLigne++;
                }

                char[] TabLettrePonderée = new char[compteursommetab] ;


                // A TERMINER  //
                //création du tab Lettre pondérée avec A*pondération B*Pondération etc
                int sommeposporba = 0; // il sert à décaler 
                
                for (int i = 0; i < 26; i++)
                {
                    for (int pos = 0; pos < tabProba[i]; pos++)
                    {
                        TabLettrePonderée[sommeposporba] = tabLettre[i];
                        sommeposporba++;
                    }
                    
                }




                // RANDOM PAS RANDOM//
                /*int compteur = 0;

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
                }*/

                //Affichage pondéré en prenant les stats du tableau : TabLettrePonderée
                for (int i = 0; i < jeu.TailleX; i++)
                {
                    for (int j = 0; j < jeu.TailleY; j++)
                    {
                        int randomChar = random.Next(0, compteursommetab);
                        jeu.Plateau[i, j] = TabLettrePonderée[randomChar];
                        Console.WriteLine(TabLettrePonderée[randomChar]);
                     }
                }




                        AffichageConsole();

                


            }

            catch (FileNotFoundException f)
            {
                Console.WriteLine("Le fichier de pondération n'existe pas " + f.Message);
                Console.WriteLine("Nous allons procéder à la génération aléatoire pondérée du plateau");
                //A  FINIR !!!!

            }
            finally { Console.WriteLine(""); };







        }


        public void ToRead(string filename)
        {
            try
            {
                //SETUP TAILLE X TAILLE Y
                string[] lines = File.ReadAllLines(filename + ".ccsv");
                //string cheminFichier = filename + ".csv";
                jeu.TailleY = lines.Length;
                foreach (string line in lines)
                {
                    string[] TabTemp = line.Split(';');
                    jeu.TailleX = TabTemp.Length;  
                }

                jeu.Plateau = new char[jeu.TailleX, jeu.TailleY];


                int x = 0; //position x tab
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(';');
                    
                    for (int i = 0; i < TabTemp.Length; i++)// 
                    {
                        jeu.Plateau [x, i] = TabTemp[i][0];

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
