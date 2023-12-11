using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    /// <summary>
    /// La classe plateau contient le plateau et toutes les méthodes utile pour son bon fonctionnement et le bon déroulé du jeu
    /// </summary>
    internal class Plateau
    {
        int tailleX; // possible d'utiliser plateau.GetLength(0)
        int tailleY; // possible d'utiliser plateau.GetLength(1)
        char[,] plateau; // le fameux plateau de jeu

        /// <summary>
        /// Constructeur qui appelle directement ToRead pour lire/générer notre plateau
        /// </summary>
        /// <param name="filename"></param>
        public Plateau(string filename)
        {

            ToRead(filename); // le constructeur appelle directement ToRead avec en parametre le nom du fichier
            
        }

        /// <summary>
        /// Permet de résumer le plateau en un string
        /// </summary>
        /// <returns>string décrivant la matrice</returns>
        public string ToString()
        {

            string chaine = "";// chaine vide prete a etre remplie
            for (int i = 0; i < tailleX; i++)
            {
                for (int j=0;j < tailleY; j++) //on parcours le plateau
                {
                    chaine += plateau[i, j] + " "; // et on ajoute a chaque fois la lettre correspondante et l'espace
                }
                chaine += "\n"; // un retour a la ligne a chaque saut de ligne du plateau
            }
            return chaine;


            //sinon, si la chaine souhaitée est uniquement un string long séparé par des ; et des | a chaque fin de ligne voici le potentiel code : 

            /*
            for (int i = 0; i < tailleX; i++)
            {
                for (int j = 0; j < tailleY; j++) //on parcours le plateau
                {
                    chaine += plateau[i, j] + ";"; // et on ajoute a chaque fois la lettre correspondante et l'espace
                }
                chaine += "|"; // un retour a la ligne a chaque saut de ligne du plateau
            }
            return chaine;
            */
        }

        /// <summary>
        /// L'affichage console permet un affichage rapide du plateau à l'écran. Il peut-être appelé à n'importe quel instant dans le code 
        /// et ne nécéssite pas de paramètres.
        /// </summary>
        public void AffichageConsole()
        {


            //AFFICHAGE
            Console.SetCursorPosition(0, 10);
            for (int u = 0; u < tailleY; u++)
            {
                
                Console.Write("- - "); // Pour la beauté du plateau
            }
            Console.WriteLine();



            
            for (int i = 0; i < tailleX; i++) // affichage des caractère
            {


                for (int j = 0; j < tailleY; j++)
                {

                    
                   
                    if (i == tailleX - 1) // on regarde si on est sur la dernière ligne
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // couleur rouge pour signaler la dernière ligne, celle d'on on peux faire partir les mots
                    }
                    if (plateau[i, j] == '#')
                    {
                        Console.Write(" ");
                        // ON AFFICHE RIEN CAR CARACTERE NUL
                    }
                    else
                    {
                        Console.Write(plateau[i, j]); // on affiche le vértiable caractère
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" | "); // petite séparation entre les lettres 
                }
                Console.WriteLine("");
                if (i < tailleX - 1)
                {
                    for (int u = 0; u < tailleY; u++)
                    {
                        Console.Write("- + "); // uniquement pour les lignes entre deux lignes de lettre
                    }
                    Console.WriteLine();
                }



            }

            //Console.SetCursorPosition(65, 10+tailleY+1);
            for (int u = 0; u < tailleY; u++)
            {
                Console.Write("- - "); // ligne de fin pour fermer la matrice
            }
            Console.WriteLine();

            

        }


        /// <summary>
        /// La fonction RandomGen s'occupe de générer aléatoirement une matrice du plateau si jamais il n'existe pas de fichier correspondant.
        /// Pour cela, elle prends en compte le fichier Lettre.txt qui indique les lettres qui vont-être présente sur la matrice et leur probabilité
        /// d'apparation (fichier entièrement modulable). Si le fichier n'existe pas, les lettres sont générées aléatoirement sans pondération.
        /// </summary>
        public void RandomGen()
        {


            tailleX = 8;
            tailleY = 8; //TAILLE PAR DEFAUT 
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


            }

            catch (FileNotFoundException f)
            {
                Console.WriteLine("Le fichier de lettre n'existe pas " + f.Message);
                Console.WriteLine("Nous allons ainsi génerer complètement aléatoirement les lettres");

                

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

        /// <summary>
        /// Fonction qui lit un fichier et aloue et la matrice plateau si celui-ci existe. Si le fichier n'existe pas / une erreur est produite, il s'occupe de créer aléatoirement
        /// le plateau en suivant les pondérations à l'aide de la fonction RandomGen et du fichier lettre txt
        /// </summary>
        /// <param name="filename">Le nom du fichier est en parametre</param>
        public void ToRead(string filename)
        {
            try
            {
                //SETUP TAILLE X TAILLE Y
                string[] lines = File.ReadAllLines(filename + ".csv"); // par défaut le type de fichier est un .csv
                //string cheminFichier = filename + ".csv";
                tailleX = lines.Length;// trouver la tailleX pour notre matrice
                foreach (string line in lines)
                {
                    string[] TabTemp = line.Split(';'); // on split chaque caractère 
                    tailleY = TabTemp.Length; // trouver la tailleY pour notre matrice
                }

                plateau = new char[tailleX, tailleY]; // création du nouveau plateau !


                int x = 0; //position x tab
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(';');

                    for (int i = 0; i < TabTemp.Length; i++)// 
                    {
                        plateau[x, i] = TabTemp[i][0]; //on remplit notre plateau

                    }

                    x++;
                }

                
                //plateau 100% remplit



            }

            catch (FileNotFoundException f) // on catch le fait que le fichier n'existe pas
            {
                Console.SetCursorPosition(10, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("/!| Erreur /!|");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Le fichier n'existe pas " + f.Message);
                Console.SetCursorPosition(55, 1);
                Console.WriteLine("Nous allons procéder à la génération aléatoire pondérée du plateau");
                RandomGen(); // nous procédons à la génération finale du tableau


            }
            finally { Console.WriteLine(""); }; // possible de mettre un msg de debug ici 
        }



        /// <summary>
        /// Cette fonction qui peut paraitre inutile est enfait très important, elle permet d'éviter de repasser sur une lettre déja existante !
        /// Par exemple si nous avions : 
        ///     n 
        ///     a m         Notre code sans cette fonction trouverait le mot maman en utilisant deux fois le a, avec l'appel de celle-ci c'est désormais impossible !
        ///     m
        /// </summary>
        /// <param name="WordTab">Le tableau de coordonnée de mot</param>
        /// <param name="posXVisée">La position X visée</param>
        /// <param name="posYVisée">La position Y visée</param>
        /// <returns>un bool, true si jamais il y a un conflit de position (on s'apprete à réutiliser une lettre déja utilisée précédemmet) et false dans le cas contraire</returns>
        public bool BackGroundCheck(int[,] WordTab, int posXVisée, int posYVisée)
        {
            for (int i=0;i<WordTab.GetLength(0);i++) // on parcours l'ensemble des lettres du mot
            {
                if (WordTab[i, 0] == posXVisée && WordTab[i, 1] == posYVisée) // on regarde donc si la case du tableau en i correspond aux coordonées X et Y de la lettre allant être utilisée
                {
                    return true;
                }
                
            }
            return false;
        }

        /// <summary>
        /// Cette fonction permet, a partir d'un mot en entrée, de vérifier récursivement si il existe dans notre matrice plateau
        /// </summary>
        /// <param name="word">le mot recherché</param>
        /// <param name="indiceX">la positionX dans le plateau</param>
        /// <param name="indiceY">la positionY dans le plateau</param>
        /// <param name="indiceMot">la position dans mot</param>
        /// <param name="wordPos">le tableau des positions des lettres trouvées</param>
        /// <returns>un tableau contenant l'entièreté des coordonées du mot</returns>
        /// 
        public int[,] SearchWordTab(string word, int indiceX = -5, int indiceY = -5, int indiceMot = 0, int[,] wordPos = null)//init a 10 pour montrer que c'est le start
        {
            //init tableau
            if (indiceX == -5 && indiceY == -5)
            {
                wordPos = new int[word.Length, 2]; // a l'init on créé un tableau du nombre de colonne du mot et de 2 lignes car il y aura que deux coordonées / lettre (x et y)
                for (int i = 0; i < word.Length; i++)// init a -10, des indices impossible pour éviter d'avoir des problèmes futurs lors du background check( si on avait pas initialisé, on aurait eu 0,0 partout et donc probleme sur la lettre 0 0 (trouvée avec beaucoup de back testing ))
                {
                    wordPos[i, 0] = -10;
                    wordPos[i, 0] = -10;
                }
            }

            //condition d'arret : quand notre indice qui parcours le mot arrive a la taille du tableau de coordonée (chaque lettre possède son couple de coordonées)
            if (indiceMot == word.Length)
            {
                return wordPos;
            }
            else
            {   //condition de depart si nous sommes à la première initialisation
                if (indiceX == -5 && indiceY == -5)
                {
                    //balade premiere ligne
                    for (int i = 0; i < plateau.GetLength(1); i++)
                    {
                        if (word[indiceMot] == plateau[plateau.GetLength(0) - 1, i])
                        {
                            wordPos[indiceMot, 0] = plateau.GetLength(0)-1; //notre pos en X est forcément celle du bas car on commence le mot sur la ligne du bas
                            wordPos[indiceMot, 1] = i; // pos en Y = i

                            if (SearchWordTab(word, plateau.GetLength(0) - 1, i, indiceMot + 1, wordPos) != null) // on valide le choix de la lettre
                            {
                                return wordPos; 
                            }
                        }

                    }

                    //ADD UNE CONDITION POUR NE PAS AVOIR A RETOURNBER EN ARRIERE
                }
                else
                {
                    //CAS A GAUCHE
                    if (indiceY - 1 >= 0 && word[indiceMot] == plateau[indiceX, indiceY - 1] && BackGroundCheck(wordPos,indiceX,indiceY-1)==false)//la derniere condition évite de retourner sur une lettre déja utilisée
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
                    if (indiceY + 1 <= plateau.GetLength(1)-1 && indiceX - 1 >= 0 && word[indiceMot] == plateau[indiceX - 1, indiceY + 1])
                    {
                        wordPos[indiceMot, 0] = indiceX - 1;
                        wordPos[indiceMot, 1] = indiceY + 1;
                        if (SearchWordTab(word, indiceX - 1, indiceY + 1, indiceMot + 1, wordPos) != null)
                        {
                            return wordPos;
                        }

                    }
                    //CAS A DROITE
                    if (indiceY + 1 <= plateau.GetLength(1)-1 && word[indiceMot] == plateau[indiceX, indiceY + 1] && BackGroundCheck(wordPos, indiceX, indiceY + 1) == false)//la derniere condition évite de retourner sur une lettre déja utilisée
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





            return null; // si jamais ça ne marche pas on renvoie null !


        }


        /// <summary>
        /// IsTabEmpty permet de regarder l'ensemble de la matrice et de vérifier si celle-ci est vide
        /// </summary>
        /// <returns>true si la matrice de jeu est vide false sinon</returns>
        public bool IsTabEmpty()
        {
            for (int i = 0; i < plateau.GetLength(0); i++) //on parcours l'ensemble de la matrice 
            {
                for (int j=0; j< plateau.GetLength(1); j++)
                {
                    if (plateau[i, j] != '#' && plateau[i,j]!=' ')
                    {
                        return false; //ON TROUVE UN CARACTERE QUI PERMET DE CONTINUER LA PARTIE
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// La fonction permet de regarder si le mot est dans la matrice. Pour cela elle appelle la fonction SearchWordTab qui lui donne un tableau de coordonées
        /// Et si jamais ce dernier n'est pas nul, s'occupe de faire descendre les lettres avec une forme de gravité
        /// </summary>
        /// <param name="mot">Le parametre est un string qui correspond au mot rentré par le joueur</param>
        /// <returns>La fonction renvoie un true or false pour savoir si le mot a bel et bien été accepté et la matrice du plateau est modifiée instantanément</returns>
        public bool Recherche_Mot(string mot)
        {
            int[,] MatriceCoords = SearchWordTab(mot); // on viens récupérer la matrice coordonées qui possède l'enwemble des coordonées X et Y de chaque caractere du mot

            if (MatriceCoords == null)
            {

                return false; // si la matrice est nulle, aucun mot n'a été trouvé donc on ne fait rien et on renvoie false
            }
            else //UN MOT VALIDE EST TROUVé
            {
                
                //MODIF PLATEAU
                for (int i = 0; i < MatriceCoords.GetLength(0); i++) // on se balade dans la matrice pour chaque lettre
                {

                    plateau[MatriceCoords[i, 0], MatriceCoords[i, 1]] = 'ç'; //et pour chaque coordonée d'une lettre ud mot, on la remplace par ç, un caractère temporaire traité plus tard 


                }

                // ANCIENNE FONCTION QUI ETAIT NON OPTIMISEE
                /*
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
                }
                */


                //MODIF GRAVITE MATRICE
                //on commence par regarder dans chaque colonne
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    //ici, c'est un indice qui permet de mettre tout en haut le # si on en trouve un
                    int TopPos = 0;

                    for (int i = 0; i < plateau.GetLength(0); i++) // pour se balader dans une ligne
                    {
                        if (plateau[i, j] == '#' || plateau[i, j] == 'ç') // on détecte soit un trou (#) soit une lettre qui vient d'etre remplacée 'ç'
                        {
                            for (int k = i; k > TopPos; k--) // on permet de faire descendre les lettres au dessus du # ou ç
                            {
                                plateau[k, j] = plateau[k - 1, j]; // en copiant celui du haut et en répétant l'opération jusqu'en haut
                            }

                            plateau[TopPos, j] = '#';
                            TopPos++;
                        }
                    }
                }





                return true; // on renvoie true une fois les modifs faites


            }

        }
        

        //FONCTION NON UTILISéE MAIS UTILE POUR MIEUX COMPRENDRE NOTRE RECURSIVITEE
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


    }







}

