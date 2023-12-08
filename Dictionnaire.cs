namespace ProjetInfoMotsCroises
{
    internal class Dictionnaire
    {
        List<string> dico;

        /// <summary>
        /// Voici le constructeur, qui construit un disctionnaire et le retourne directement trié en utilisant la méthode de tri fusion
        /// </summary>
        public Dictionnaire()
        {
            
            this.dico = new List<string>();


            string[] lines = File.ReadAllLines("Mots_Français.txt");
            //Console.WriteLine(toString());//
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                dico.AddRange(words);
            }
            
            Tri_Fusion(dico);

        }
        public List<string> Dico
        {
            get { return this.dico; }
            set { this.dico = value; }
        }



        /// <summary>
        /// la fonction lit tous les mots du dictionnaire et les compte
        /// </summary>
        /// <returns>elle retourne une chaine de caractère qui décrit le dictionnaire
        /// elle retourne donc la langue du dictionnaire et le nombre de mot par lettre</returns>        
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
        /// <summary>
        /// On fait un tri fusion en récursif qui a une complexité en temps de nlog(n)
        /// Il est basé sur le principe du diviser pour régner
        /// </summary>
        /// <param name="liste"> Le paramètre est une liste de strings correspondants aux mots du dictionnaire </param>
        public void Tri_Fusion(List<string> liste)
        {
            //Si la taille de la liste est supérieure à 1, on continue, sinon, on retourne la liste triée
            //C'est la condition d'arrèt de l'algorithle récursif
            if (liste.Count <= 1)
                return;
            int milieu = liste.Count / 2;
            //On prend la partie gauche du code et on en fait une nouvelle liste
            List<string> gauche = liste.GetRange(0, milieu);
            //On prend la partie droite du code et on en fait une nouvelle liste
            List<string> droite = liste.GetRange(milieu, liste.Count - milieu);

            //On applique alors la recursion, et il s'agit ici de Faire le Tri_Fusion à gauche et à droite de la liste
            Tri_Fusion(gauche);
            Tri_Fusion(droite);

            //On fusionne ici toutes les parties de la liste à l'aide de la fonction Fusionner
            //Ca nous retourne donc le tableau entier trié
            Fusionner(liste, gauche, droite);
        }
        /// <summary>
        /// Cet algorithme a pour but de fusionner plusieurs listes
        /// </summary>
        /// <param name="liste">C'est la liste que l'on veut trier </param>
        /// <param name="gauche">c'est la liste que l'on veut mettre à gauche en fusionnant</param>
        /// <param name="droite">c'est la liste que l'on veut mettre à droite en fusionnant</param>
        public void Fusionner(List<string> liste, List<string> gauche, List<string> droite)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            //Tant que au moins une des listes n'a pas été totalement parcourue pour être fusionnée
            while (i < gauche.Count && j < droite.Count)
            {
                // On utilise CompareTo pour comparer les chaînes, basé sur l'ordre des lettres dans l'alphabet
                if (gauche[i].CompareTo(droite[j]) < 0)
                    liste[k++] = gauche[i++];
                else
                    liste[k++] = droite[j++];
            }
            // On ajoute les éléments restants de la liste gauche si c'est la liste droite qui a été entièrement parcourue
            while (i < gauche.Count)
            {
                liste[k++] = gauche[i++];
            }
            // On ajoute les éléments restants de la liste droite si c'est la liste gauche qui a été entièrement parcourue
            while (j < droite.Count)
            {
                liste[k++] = droite[j++];
            }

        }
        //méthode de vérification du mot
        /// <summary>
        /// Vérification via recherche récursive d'un mot dans le dictionnaire à l'aide de la méthode de recherche dichotomique.
        /// </summary>
        /// <param name="mot"> c'est le mot que l'on veut analyser</param>
        /// <param name="debut">position du premier terme du dictionnaire, en l'occurence 0</param>
        /// <param name="fin">position du dernier terme du dictionnaire, 130557 comme on a 130557 mots dans le dictionnaire</param>
        /// <returns></returns>
        public bool RechercheDichoRecursif(string mot, int debut=0, int fin =130557)
        {
            //On met le mot en majuscule, comme les mots dasn le dictionnaire sont en majuscule
            mot=mot.ToUpper();
            int moitie = (debut + fin) / 2;
            //On met des conditions de vérification pour garantir le bon fonctionnement du programme
            if (dico == null || debut > fin)
            {
                return false;
            }
            else
            {
                // Si le mot actuel est le mot à rechercher, la recherche réussit.
                if (mot == dico[moitie])
                {
                    return true;
                }
                else
                {
                    // Si le mot à rechercher est inférieur (dans l'alphabet) au mot actuel,
                    // on fait la recherche récursive à gauche.
                    if (mot.CompareTo(dico[moitie]) < 0)
                    {
                        return RechercheDichoRecursif(mot, debut, moitie - 1);
                    }
                    // Si le mot à rechercher est supérieur (dans l'alphabet) au mot actuel,
                    // on fait la recherche récursive à droite.
                    if (mot.CompareTo(dico[moitie]) > 0)
                    {
                        return RechercheDichoRecursif(mot, moitie + 1, fin);
                    }
                    //Si le mot est retrouvé au bout d'un moment, l'algorithme est terminé, 
                    //sinon, on retourne faux
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
//Pour le temps, utiliser le threading pour avoir le temps en parallèle, on a le droit