using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_fichier
{
    class Dossier : Files
    {
        public Dossier parent;
        public List<Fichier> fichiers = new List<Fichier>();
        public List<Dossier> dossiers = new List<Dossier>();

        public Dossier(string nom,string type,Dossier parent) : base(nom, type)
        {
            this.nom = nom;
            this.type = "type";
            this.parent = parent;
            this.autorisation = 4;
        }

        public Dossier(string nom)
            : base(nom)
        {
            this.nom = nom;
            this.type = "dossier";
            this.autorisation = 7;
        }

        public void afficher()
        {
            Console.WriteLine(nom + " => " + parent.nom);
        }

        public string ls( Dossier parent)
        {
            string chaine = "";
            if (parent.fichiers.Count != 0)
            {
                for (int i = 0; i <= parent.fichiers.Count-1; i++)
                {
                    chaine = (chaine + " f:" + parent.fichiers[i].nom);
                }
            }
            if (parent.dossiers.Count != 0)
            {
                for (int i = 0; i <= parent.dossiers.Count - 1; i++)
                {
                    chaine = (chaine + " d:" + parent.dossiers[i].nom);
                }

            }
            return chaine;
        }

        public bool directory(string nom)
        {
            if (dossiers.Count != 0)
            {
                for (int i = 0; i <= dossiers.Count - 1; i++)
                {
                    if (nom == dossiers[i].nom)
                    {
                        return true;
                    }
                }

            }
            else
            {
                Console.WriteLine("il n'y a pas de sous-dossier dans ce dossier");
                return false;
            }

            return false;
        }

        public bool directorydfiles(string nom)
        {
            if (fichiers.Count != 0)
            {
                for (int i = 0; i <= fichiers.Count - 1; i++)
                {
                    if (nom == fichiers[i].nom)
                    {
                        return true;
                    }
                }

            }
            else
            {
                Console.WriteLine("il n'y a pas de fichier dans ce dossier");
                return false;
            }

            return false;
        }

        public Dossier nomdossier(string nom)
        {
            for (int i = 0; i <= dossiers.Count - 1; i++)
            {
                if (nom == dossiers[i].nom)
                {
                    return dossiers[i];
                }
            }
            return null;
        }

        public string textfichier(string nom)
        {
            for (int i = 0; i <= fichiers.Count - 1; i++)
            {
                if (nom == fichiers[i].nom)
                {
                    return fichiers[i].text;
                }
            }
            return null;
        }

        public void adddossier(Dossier lefiles)
        {
            dossiers.Add(lefiles);
        }

        public void addfichier(Fichier lefiles)
        {
            fichiers.Add(lefiles);
        }

        public void chmod(int right)
        {
            this.autorisation = right;
        }
    }
}
