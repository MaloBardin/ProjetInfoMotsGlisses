﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfoMotsCroises
{
    internal class Dictionnaire
    {



        public void Begin()
        {
            List<string> Dico = new List<string>();//
            string[] lines = File.ReadAllLines("Mots_Français.txt");//           
            Console.WriteLine(toString());//
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                Dico.AddRange(words);
            }
            Tri_XX(Dico);
        }


        //méthode toString : 
        public static string toString()
        {
            string s = "Dans ce dictionnaire de langue française, il y a ";
            string[] lines = File.ReadAllLines("Mots_Français.txt");
            int[] tab = new int[16];
            foreach (string line in lines)
            {

                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    int a = word.Length;

                    tab[a] += 1;
                }
            }
            s += tab[1] + " mots avec 1 lettre, ";
            for (int i = 2; i < 16; i++)
            {
                s += tab[i] + " mots avec " + i + " lettres, ";
            }
            s += " et aucun mot avec plus de lettres.";

            return s;
        }
        //méthodes pour l'algorithme de tri : 
        static void Tri_XX(List<string> liste)
        {
            if (liste.Count <= 1)
                return;

            int milieu = liste.Count / 2;
            List<string> gauche = liste.GetRange(0, milieu);
            List<string> droite = liste.GetRange(milieu, liste.Count - milieu);

            Tri_XX(gauche);
            Tri_XX(droite);

            Fusionner(liste, gauche, droite);
        }
        static void Fusionner(List<string> liste, List<string> gauche, List<string> droite)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < gauche.Count && j < droite.Count)
            {
                // Utilisation de CompareTo pour comparer les chaînes, basé sur l'ordre des lettres dans l'alphabet
                if (gauche[i].CompareTo(droite[j]) < 0)
                    liste[k++] = gauche[i++];
                else
                    liste[k++] = droite[j++];
            }
            while (i < gauche.Count)
            {
                liste[k++] = gauche[i++];
            }
            while (j < droite.Count)
            {
                liste[k++] = droite[j++];
            }

        }
        //méthode de vérification du mot
        static bool verification(string mot, List<string> Dico)
        {
            bool rep = false;
            foreach (string word in Dico)
            {
                //Console.WriteLine(word);
                if (word == mot)
                {
                    rep = true;
                    break;
                }
            }
            return rep;
        }
    }
}
