using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    /// <summary>
    /// La classe joueur possède tous les attributs et les méthodes utiles pour 
    /// </summary>
    public class Joueur
    {
        //On déclare les attributs
        public List<string> mots;
        public int score;
        public string nom;

        /// <summary>
        /// Voici le constructeur d'un joueur, défini par son nom, son score et la liste constituée par les mùots qu'il a déjà trouvé 
        /// </summary>
        /// <param name="nom">nom du joueur</param>
        public Joueur()
        {
            
            this.score = 0;
            this.mots = new List<string>();
        }

        /// <summary>
        /// La méthode ajoute le mot dans la liste des mots déjà trouvés par le joueur au cours de la partie
        /// </summary>
        /// <param name="mot">mot entré par le joeur</param>
        public void Add_Mot(string mot)
        {
            if (mots.Contains(mot) == false)
            {
                mots.Add(mot);
            }

        }
        /// <summary>
        /// Vérifie que le mot en paramètre ne fait pas partie de la liste des mots déjà trouvés par le joueur au cours de la partie
        /// </summary>
        /// <param name="mot">mot</param>
        /// <returns>un booléen</returns>
        public bool Contient(string mot)
        {

            for (int i = 0; i < mots.Count; i++)
            {
                if (mots[i] == mot)
                {
                    return true;
                    break;
                }
            }
            return false;
        }
        /// <summary>
        /// retourne une chaîne de caractères qui décrit un joueur.
        /// </summary>
        /// <returns>une chaine de caractère qui décrit ses mots et son score</returns>
        public string toString()
        {
            string description = "nom du joueur : " + nom + "\nmotstrouvés : ";
            for (int i = 0; i < mots.Count; i++)
            {
                description += mots[i] + "\n";
            }
            description += "score : " + score + "\n";
            return description;
        }
        /// <summary>
        /// Ajoute une valeur au score du joueur
        /// </summary>
        /// <param name="val"> entre la valeur à ajouter, qui va dépendre de la méthode calculscore quand ça va être utilisé dasn le main </param>
        public void Add_Score(int val)
        {
            score += val;

        }
        /// <summary>
        /// Calcule le score d'un mot entré par un joueur 
        /// Réutilisation du même principe que pour le code de la méthode RandomGen()
        /// </summary>
        /// <param name="mot">mot entré</param>
        /// <returns>score associé au mot</returns>
        public int CalculScore(string mot)
        {
            int[] tabponderation = new int[26];
            int score = 0;
            string filename = "Lettre";
            try
            {
                //on lit le fichier pour accéder aux mots
                string[] lines = File.ReadAllLines(filename + ".txt");



                //LECTURE FICHIER LETTRE PONDERATION
                int posLigne = 0;

                foreach (string line in lines) // on split pour lire la valeur de chaque lettre sur le fichier
                {

                    string[] TabTemp = line.Split(',');
                    tabponderation[posLigne] = int.Parse(TabTemp[2]);
                    posLigne++;
                }
                for (int i = 0; i < mot.Length; i++)
                {
                    score += tabponderation[mot[i] - 97]; 
                }
                
                Add_Score((score*mot.Length)/3); // formule pour le calcul du score
                return ((score * mot.Length)/ 3);
            }
            catch (FileNotFoundException f) // si le fichier n'existe pas
            {
                Console.WriteLine("Le fichier de lettre n'existe pas " + f.Message);
                Console.WriteLine("Toutes les lettres seront considérées comme égales à 1");
                score = mot.Length;
                Add_Score(score);
                return score;
            }
        }
    }
}