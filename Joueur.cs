using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Joueur

    {
        public List<string> mots = new List<string>();
        public int score = 0;
        public string nom; 
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
    }
}