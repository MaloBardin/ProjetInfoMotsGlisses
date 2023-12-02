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
            //Console.WriteLine(SearchWord("coucou"));
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
                int compteursommetab = 0;
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(',');
                    tabLettre[posLigne] = char.Parse(TabTemp[0]);
                    tabProba[posLigne] = int.Parse(TabTemp[1]);

                    compteursommetab += tabProba[posLigne];


                    posLigne++;
                }

                char[] TabLettrePonderée = new char[compteursommetab];


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






                //Affichage pondéré en prenant les stats du tableau : TabLettrePonderée
                for (int i = 0; i < jeu.TailleX; i++)
                {
                    for (int j = 0; j < jeu.TailleY; j++)
                    {
                        int randomChar = random.Next(0, compteursommetab);
                        jeu.Plateau[i, j] = TabLettrePonderée[randomChar];
                        //Console.WriteLine(TabLettrePonderée[randomChar]);
                    }
                }




                AffichageConsole();




            }

            catch (FileNotFoundException f)
            {
                Console.WriteLine("Le fichier de lettre n'existe pas " + f.Message);
                Console.WriteLine("Nous allons ainsi génerer complètement aléatoirement les lettres");
                //A  FINIR !!!!

                for (int i = 0; i < jeu.TailleX; i++)
                {
                    for (int j = 0; j < jeu.TailleY; j++)
                    {


                        int randomChar = random.Next(97, 123);
                        jeu.Plateau[i, j] = (char)randomChar;






                    }
                }


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
                        jeu.Plateau[x, i] = TabTemp[i][0];

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


        public int[,] SearchWordTab(string word, int indiceX = 10, int indiceY = 10, int indiceMot = 0, int[,] wordPos = null)//init a 10 pour montrer que c'est le start
        {
            //init tableau
            if (indiceX == 10 && indiceY == 10)
            {
                wordPos = new int[word.Length, 2];
            }

            bool retour = false;
            //condition d'arret 
            if (indiceMot == word.Length)
            {
                retour = true;
                return wordPos;
            }
            else
            {   //condition de depart
                if (indiceX == 10 && indiceY == 10)
                {
                    //balade premiere ligne
                    for (int i = 0; i < 8; i++)
                    {
                        if (retour == false && word[indiceMot] == jeu.Plateau[7, i])
                        {
                            wordPos[indiceMot, 0] = 7;
                            wordPos[indiceMot, 1] = i;
                          if (SearchWordTab(word, 7, i, indiceMot + 1, wordPos)!=null)
                            {
                                retour = true;
                            }
                        }
                    }


                }
                else
                {

                    //condition pour regarder a gauche et a droite
                    if (retour == false && (indiceY - 1) >= 0 && word[indiceMot] == jeu.Plateau[indiceX, indiceY - 1])
                    {
                        Console.WriteLine("1");
                        wordPos[indiceMot, 0] = indiceX;
                        wordPos[indiceMot, 1] = indiceY;
                        return SearchWordTab(word, indiceX, indiceY - 1, indiceMot + 1, wordPos);
                       
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    }
                    else if (retour == false && (indiceX + 1) >= 0 && word[indiceMot] == jeu.Plateau[indiceX + 1, indiceY])
                    {
                        Console.WriteLine("2");
                        wordPos[indiceMot, 0] = indiceX;
                        wordPos[indiceMot, 1] = indiceY;
                        return SearchWordTab(word, indiceX + 1, indiceY, indiceMot + 1, wordPos);

                        
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    }
                    else if (retour == false && (indiceY + 1) <= 7 && word[indiceMot] == jeu.Plateau[indiceX, indiceY + 1])
                    {
                        Console.WriteLine("3");
                        wordPos[indiceMot, 0] = indiceX;
                        wordPos[indiceMot, 1] = indiceY;
                        return SearchWordTab(word, indiceX, indiceY + 1, indiceMot + 1, wordPos);
                        
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    }





                }

                if (retour == true)
                {
                    return wordPos;
                }
                else
                {
                    return null;
                }


            }








        }
    




    public bool SearchWord(string word, int indiceX = 10, int indiceY = 10, int indiceMot = 0)//init a 10 pour montrer que c'est le start
        {

            bool retour = false;

            if (indiceMot == word.Length)
            {
                retour = true;
                return retour;
            } else
            {
                if (indiceX == 10 && indiceY == 10)
                {

                    for (int i = 0; i < 8; i++)
                    {
                        if (retour == false && word[indiceMot] == jeu.Plateau[7, i]){
                            retour = SearchWord(word, 7, i, indiceMot + 1);
                        }
                    }

                   
                } else
                {

                    //condition pour regarder a gauche et a droite
                    if (retour == false && (indiceY - 1) >= 0 && word[indiceMot] == jeu.Plateau[indiceX, indiceY - 1])
                    {
                        retour = SearchWord(word, indiceX, indiceY - 1, indiceMot + 1);
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    } else if (retour == false && (indiceX + 1) >= 8 && word[indiceMot] == jeu.Plateau[indiceX + 1,indiceY]) {
                        retour = SearchWord(word, indiceX+1, indiceY, indiceMot + 1);
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    } else if (retour == false && (indiceY+1)<= 7 && word[indiceMot]== jeu.Plateau[indiceX, indiceY + 1]){
                        retour = SearchWord(word, indiceX, indiceY + 1, indiceMot + 1);
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    }





                }

                if (retour == true)
                {
                    return true;
                } else
                {
                    return false;
                }
                 

            }




            



            }
        }
        




        

    }

