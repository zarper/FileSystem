using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_fichier
{
    class Path
    {
        public Files current;
        public string etat;
        public string[] arbo = { };

        public string getPath()
        {
            string chaine = "";

            for (int i = 0; i < arbo.Length; i++)
            {
                chaine = chaine + arbo[i]+ "\\";
            }

                return chaine;
        }

        public string showcurrent()
        {
            return current.nom;
        }

        public void start(Dossier first)
        {
            this.current = first;
            this.etat = "fichier";
            int taille = arbo.Length;
            Array.Resize(ref arbo, taille + 1);
            this.arbo[taille] = ""+first.nom+"";
        }

        public void cd (string next)
        {
            if (current.directory(next) == true)
            {
                this.current = current.nomdossier(next);

                    int taille = arbo.Length;
                    Array.Resize(ref arbo, taille + 1);
                    arbo[taille] = next;
            }
            if (current.directorydfiles(next) == true)
            {
                this.current = current.nomdossier(next);

                int taille = arbo.Length;
                Array.Resize(ref arbo, taille + 1);
                arbo[taille] = next;
            }
        }

        public void ficheraffichage(string nom)
        {
            if (current.directorydfiles(nom) == true)
            {

                Console.WriteLine("\n" + current.textfichier(nom));
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void delete (string nomfichier)
        {
            if (current.directory(nomfichier) == true)
            {
                for (int i = 0; i < current.dossiers.Count; i++)               // parcours de la list et supprime si c'est un dossier
                {
                    if (current.dossiers[i].nom == nomfichier)
                    {
                        current.dossiers.RemoveAt(i);
                        Console.WriteLine("dossier supprimer");
                    }
                }
            }
            else if (current.directorydfiles(nomfichier) == true)
            {
                for (int i = 0; i < current.fichiers.Count; i++)               // parcours de la list et supprime si c'est un fichier
                {
                    if (current.fichiers[i].nom == nomfichier)
                    {
                        current.fichiers.RemoveAt(i);
                        Console.WriteLine("fichier supprimer");
                    }
                }
            }
        }

        public void cd ()
        {
            //this.current = current.parent;

            for (int i = 0;i<arbo.Length;i++)
            {
                if (i == arbo.Length - 1)
                {   
                    arbo[i] = null;
                    int taille = arbo.Length;
                    Array.Resize(ref arbo, taille - 1);
                }
            }
            //arbo = arbo + "\\"+ ;
        }

        public void getRoot()
        {
            if (this.current.nom == "c:")
            {
                Console.WriteLine("le fichier est le fichier racine c:");
            }
            else
            {
                 Console.WriteLine(this.current.parent.nom);
            }
        }

        public void chmod(int perm)
        {
            current.autorisation = perm;
        }

        public string search(string lenom)
        {
            string chaine = "";
            if (current.fichiers.Count != 0)
            {
                for (int i = 0; i <= parent.fichiers.Count - 1; i++)
                {
                    if (fichiers[i].nom == lenom)
                    {
                        chaine = (user.path() + fichiers[i].nom);
                    }
                }
            }
            if (current.dossiers.Count != 0)
            {
                for (int i = 0; i <= parent.dossiers.Count - 1; i++)
                {
                    chaine = (chaine + " d:" + parent.dossiers[i].nom);
                }

            }
            return chaine;
        }
    }
}

