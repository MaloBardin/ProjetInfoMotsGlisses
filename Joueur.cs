using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Joueur
    {
        public List<string> mots;
        public int score;
        public string nom; 

        public Joueur(string nom)
        {
            this.nom = nom;
            this.score = 0;
            this.mots = new List<string>();
        }
        public void Add_Mot(string mot)
        {
            if (mots.Contains(mot) == false)
            {
                mots.Add(mot);
            }

        }
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
        public void Add_Score(int val)
        {
            score += val;

        }
        public int calculscore(string mot)
        {
            int[] tabponderation = new int[26];
            char[] tabLettre = new char[26];
            int score = 0;
            string filename = "Lettre";
            try
            {
                //on lit le fichier pour accéder aux mots
                string[] lines = File.ReadAllLines(filename + ".txt");



                //LECTURE FICHIER LETTRE PONDERATION
                int posLigne = 0;
                
                foreach (string line in lines)
                {

                    string[] TabTemp = line.Split(',');
                    tabLettre[posLigne] = char.Parse(TabTemp[0]);
                    tabponderation[posLigne] = int.Parse(TabTemp[2]);
                    posLigne++;
                }
                for (int i = 0; i < mot.Length; i++)
                {
                    score += tabponderation[mot[i]-97];
                }
                return score;
            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine("Le fichier de lettre n'existe pas " + f.Message);
                Console.WriteLine("Toutes les lettres seront considérées comme égales à 1");
                score = mot.Length;
                return score;
            }
        }
    }
}