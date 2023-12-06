using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Plateau
    {
        int tailleX;
        int tailleY;
        char[,] plateau;
        public Plateau(string filename)
        {

            ToRead(filename);
            //Console.WriteLine(SearchWord("coucou"));
        }

        public void AffichageConsole()
        {
            Thread.Sleep(500);
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
                    if (plateau[i, j] == '#')
                    {
                        Console.Write(" ");
                        // ON AFFICHE RIEN CAR CARACTERE NUL
                    }
                    else
                    {
                        Console.Write(plateau[i, j]);
                    }

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


            tailleX = 8;
            tailleY = 8; //TAILLE PAR DEFAUT A SAVOIR SI ELLE DOIT ETRE RANDOM OU NOM
            plateau = new char[tailleX, tailleY];
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
                for (int i = 0; i < tailleX; i++)
                {
                    for (int j = 0; j < tailleY; j++)
                    {
                        int randomChar = random.Next(0, compteursommetab);
                        plateau[i, j] = TabLettrePonderée[randomChar];
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

                for (int i = 0; i < tailleX; i++)
                {
                    for (int j = 0; j < tailleY; j++)
                    {


                        int randomChar = random.Next(97, 123);
                        plateau[i, j] = (char)randomChar;






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
                tailleY = lines.Length;
                foreach (string line in lines)
                {
                    string[] TabTemp = line.Split(';');
                    tailleX = TabTemp.Length;
                }

                plateau = new char[tailleX, tailleY];


                int x = 0; //position x tab
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(';');

                    for (int i = 0; i < TabTemp.Length; i++)// 
                    {
                        plateau[x, i] = TabTemp[i][0];

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

            //condition d'arret 
            if (indiceMot == word.Length)
            {
                return wordPos;
            }
            else
            {   //condition de depart
                if (indiceX == 10 && indiceY == 10)
                {
                    //balade premiere ligne
                    for (int i = 0; i < plateau.GetLength(0); i++)
                    {
                        if (word[indiceMot] == plateau[plateau.GetLength(0) - 1, i])
                        {
                            wordPos[indiceMot, 0] = 7;
                            wordPos[indiceMot, 1] = i;

                            if (SearchWordTab(word, plateau.GetLength(0) - 1, i, indiceMot + 1, wordPos) != null)
                            {
                                return wordPos;
                            }
                        }

                    }


                }
                else
                {
                    //CAS A GAUCHE
                    if (indiceY - 1 >= 0 && word[indiceMot] == plateau[indiceX, indiceY - 1])
                    {

                        wordPos[indiceMot, 0] = indiceX;
                        wordPos[indiceMot, 1] = indiceY - 1;
                        if (SearchWordTab(word, indiceX, indiceY - 1, indiceMot + 1, wordPos) != null)
                        {
                            return wordPos;
                        }

                    }
                    //CAS A GAUCHE EN HAUT
                    if (indiceY - 1 >= 0 && indiceX - 1 >= 0 && word[indiceMot] == plateau[indiceX - 1, indiceY - 1])
                    {
                        wordPos[indiceMot, 0] = indiceX - 1;
                        wordPos[indiceMot, 1] = indiceY - 1;
                        if (SearchWordTab(word, indiceX - 1, indiceY - 1, indiceMot + 1, wordPos) != null)
                        {
                            return wordPos;
                        }

                    }
                    //CAS EN HAUT
                    if (indiceX - 1 >= 0 && word[indiceMot] == plateau[indiceX - 1, indiceY])
                    {
                        wordPos[indiceMot, 0] = indiceX - 1;
                        wordPos[indiceMot, 1] = indiceY;
                        if (SearchWordTab(word, indiceX - 1, indiceY, indiceMot + 1, wordPos) != null)
                        {
                            return wordPos;
                        }

                    }
                    //CAS EN HAUT ET DROITE
                    if (indiceY + 1 <= 7 && indiceX - 1 >= 0 && word[indiceMot] == plateau[indiceX - 1, indiceY + 1])
                    {
                        wordPos[indiceMot, 0] = indiceX - 1;
                        wordPos[indiceMot, 1] = indiceY + 1;
                        if (SearchWordTab(word, indiceX - 1, indiceY + 1, indiceMot + 1, wordPos) != null)
                        {
                            return wordPos;
                        }

                    }
                    //CAS A DROITE
                    if (indiceY + 1 <= 7 && word[indiceMot] == plateau[indiceX, indiceY + 1])
                    {
                        wordPos[indiceMot, 0] = indiceX;
                        wordPos[indiceMot, 1] = indiceY + 1;
                        if (SearchWordTab(word, indiceX, indiceY + 1, indiceMot + 1, wordPos) != null)
                        {
                            return wordPos;
                        }

                    }





                }


            }





            return null;


        }


        //FONCTION NON UTILISéE
        public bool SearchWord(string word, int indiceX = 10, int indiceY = 10, int indiceMot = 0)//init a 10 pour montrer que c'est le start
        {

            bool retour = false;

            if (indiceMot == word.Length)
            {
                retour = true;
                return retour;
            }
            else
            {
                if (indiceX == 10 && indiceY == 10)
                {

                    for (int i = 0; i < 8; i++)
                    {
                        if (retour == false && word[indiceMot] == plateau[7, i])
                        {
                            retour = SearchWord(word, 7, i, indiceMot + 1);
                        }
                    }


                }
                else
                {

                    //condition pour regarder a gauche et a droite
                    if (retour == false && (indiceY - 1) >= 0 && word[indiceMot] == plateau[indiceX, indiceY - 1])
                    {
                        retour = SearchWord(word, indiceX, indiceY - 1, indiceMot + 1);
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    }
                    else if (retour == false && (indiceX + 1) >= 8 && word[indiceMot] == plateau[indiceX + 1, indiceY])
                    {
                        retour = SearchWord(word, indiceX + 1, indiceY, indiceMot + 1);
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    }
                    else if (retour == false && (indiceY + 1) <= 7 && word[indiceMot] == plateau[indiceX, indiceY + 1])
                    {
                        retour = SearchWord(word, indiceX, indiceY + 1, indiceMot + 1);
                        //on redscendre l'indice du mot si jamais ça ne marche aps
                        indiceMot--;
                    }





                }

                if (retour == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }








        }




        public bool Recherche_Mot(string mot)
        {
            int[,] MatriceCoords = SearchWordTab(mot);

            if (MatriceCoords == null)
            {

                return false;
            }
            else //UN MOT VALIDE EST TROUVé
            {
                Console.WriteLine("1");
                //MODIF PLATEAU
                for (int i = 0; i < MatriceCoords.GetLength(0); i++)
                {

                    plateau[MatriceCoords[i, 0], MatriceCoords[i, 1]] = 'ç';


                }

                AffichageConsole();

                //MODIF GRAVITE MATRICE
                //on le fait 8 fois pour etre sur que tout est bien décaler jusqu'en bas
                for (int u = 0; u < plateau.GetLength(0); u++)
                {
                    for (int j = 0; j < plateau.GetLength(1); j++)
                    {
                        for (int i = 0; i < plateau.GetLength(0); i++)
                        {
                            if (i + 1 < plateau.GetLength(0) && (plateau[i + 1, j] == 'ç' || plateau[i + 1, j] == '#'))
                            {
                                plateau[i + 1, j] = plateau[i, j];
                                plateau[i, j] = '#';
                            }
                        }
                    }

                    AffichageConsole();

                }






                return true;


            }

        }


    }







}

