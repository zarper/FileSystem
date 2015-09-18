using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_fichier
{
    abstract class Files
    {
        public string nom;
        public string type;
        public int autorisation;

        public Files(string nom, string type)
        {
            this.nom = nom;
            this.type = "file";
            this.autorisation = 4;
        }
        public Files(string nom)
        {
            this.nom = nom;
            this.type = "dossier";
        }

        public void renameTo(string nom)
        {
            this.nom = nom;
        }

        public bool canWrite(int droit)
        {
            if (droit == 2 || droit == 3 || droit == 6 || droit == 7)
            {
                return true;
            }
            return false;
        }

        public bool canExecute(int droit)
        {
            if (droit == 1 || droit == 3 || droit == 5 || droit == 7)
            {
                return true;
            }
            return false;
        }

        public bool canRead(int droit)
        {
            if (droit == 4 ||droit == 5 || droit == 6 || droit == 7)
            {
                return true;
            }
            return false;
        }

    }
}
