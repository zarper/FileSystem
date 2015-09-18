using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_fichier
{
    class Fichier : Files
    {
        public Dossier parent;
        public string text;
        

        public Fichier( string nom, string type,Dossier parent, string text) 
            : base(nom, type)
        {
            this.parent = parent;
            this.text = text;
            this.autorisation = 7;
        }
        //!!!!!!!!!!

        public int test()
        {
            return autorisation;
        }

        public void chmod(int right)
        {
            this.autorisation = right;
        }

    }
}
