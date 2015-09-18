using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_fichier
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fin = false;
            string commande;
            string[] listecommande;

            Path utilisateur = new Path();
            Dossier home = new Dossier("c:");
            utilisateur.start(home);
            
            while (fin == false)
            {
                
                commande = Console.ReadLine();
                listecommande = commande.Split(' ');
                commande = listecommande[0];

                switch (commande)
                {
                    #region attribut CD
                    case "cd":
                            if (2 == listecommande.Length)
                            {
                                if (utilisateur.current.canExecute(utilisateur.current.autorisation))
                                {
                                    utilisateur.cd(listecommande[1]);
                                }
                                else
                                {
                                Console.WriteLine("Vous n'avez pas les droit pour vous déplacer dans ce fichier");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Votre commande cd n'est pas bien écrite EX:\"cd [nom du répertoire]\"");
                            }
                            break;
                    #endregion

                    #region attribut mkdir
                    case "mkdir":
                          if (2 == listecommande.Length)
                          {
                              if(utilisateur.current.canWrite(utilisateur.current.autorisation))
                              {
                                  Dossier ledossier = new Dossier (listecommande[2],"dossier",utilisateur.current);
                                  utilisateur.adddossier(ledossier, utilisateur.current);
                              }
                              else
                              {
                                  Console.WriteLine("Vous n'avez pas les droit pour écrire dans ce fichier");
                              }
                          }
                          break;
                    #endregion

                    #region attribut getPath
                    case "getPath":
                            if (1 != listecommande.Length)
                            {
                                Console.WriteLine("Votre commande path n'est pas bien écrite EX:\"path\"");
                            }
                            else
                            {
                                Console.WriteLine(utilisateur.getPath());
                            }
                            break;
                    #endregion
                    
                    #region attribut ls
                        case "ls":
                         if (1 == listecommande.Length)
                         {
                             Console.WriteLine(utilisateur.current.ls(utilisateur.current));
                         }
                         else
                         {
                             Console.WriteLine("Votre commande ls n'est pas bien écrite EX:\"ls\"");
                         }
                         break;
                        #endregion
                    
                    #region attribut search
                    case "search":
                    if (2 == listecommande.Length)
                        {
                            Console.WriteLine(utilisateur.search(listecommande[2],utilisateur.current));
                        }   
                        break;
                    #endregion

                    #region attribut getRoot
                    case "getRoot":
                        utilisateur.getRoot();
                         break;
                    #endregion

                    #region attribut nano
                    case "nano":
                         if (1 != listecommande.Length)
                         {
                             if (utilisateur.current.canWrite(utilisateur.current.autorisation))
                             {
                                 string chaine;
                                 Console.Clear();
                                 chaine = Console.ReadLine();
                                 Fichier lefichier = new Fichier(listecommande[1], "fichier", utilisateur.current, chaine);
                                 utilisateur.current.addfichier(lefichier);
                                 Console.Clear();
                             }
                             else
                             {
                                 Console.WriteLine("Vous n'avez pas les droit pour modifier ce fichier");
                             }
                         }
                         break;
                    #endregion

                    #region attribut createNewFile
                    case "create":
                        if (2 == listecommande.Length)
                        {
                             if (utilisateur.current.canWrite(utilisateur.current.autorisation))
                             {
                                 string letype = "";
                                 while (letype != "d" || letype != "f")
                                 {
                                     Console.WriteLine("\n fichier => f"
                                                     + "\n ou"
                                                     + "\n dossier => d");
                                     letype = Console.ReadLine();
                                 }

                                 if (letype == "f")
                                 {
                                     string chaine;
                                     Console.Clear();
                                     chaine = Console.ReadLine();
                                     Fichier lefichier = new Fichier(listecommande[2], "fichier", utilisateur.current, chaine);
                                     utilisateur.current.addfichier(lefichier);
                                     Console.Clear();
                                 }
                                 else if (letype == "d")
                                 {
                                     Dossier ledossier = new Dossier(listecommande[2], "dossier", utilisateur.current);
                                     utilisateur.current.adddossier(ledossier);
                                 }
                                 else
                                 {
                                     Console.WriteLine("Votre commande create n'est pas bien écrite EX:\"create [nom du fichier]\"");
                                 }
                             }
                             else
                             {
                                 Console.WriteLine("Vous n'avez pas les droit pour modifier ce fichier");
                             }
                         }
                         break;
                    #endregion

                    #region attribut delete
                    case "delete":
                         if (2 == listecommande.Length)
                         {
                             if (utilisateur.current.canWrite(utilisateur.current.autorisation))
                             {
                                 string lefile = listecommande[1];
                                 utilisateur.delete(lefile);
                             }
                             else
                             {
                                 Console.WriteLine("Vous n'avez pas les droit pour modifier ce fichier");
                             }
                         }
                         else
                         {
                             Console.WriteLine("Votre commande delete n'est pas bien écrite EX:\"delete [nom du fichier]\"");
                         }

                         break;
                    #endregion

                    #region attribut renameTo
                    case "renameTo":
                         if (3 == listecommande.Length)
                         {
                             utilisateur.current.renameTo(listecommande[2]);
                         }
                         else
                         {
                             Console.WriteLine("Votre commande rename n'est pas bien écrite EX:\"rename [fichier a modifier] [nouveau nom]\"");
                         }
                         break;
                    #endregion

                    #region attribut chmod
                    case "chmod":
                        if (2 == listecommande.Length)
                        {
                            utilisateur.current.chmod(Int32.Parse(listecommande[1]));
                        }
                         break;
                    #endregion

                    #region attribut isFile
                    case "file":
                         if (utilisateur.current.type == "fichier")
                         {
                             Console.WriteLine("vous êtes bien dans un fichier");
                         }
                         else
                         {
                             Console.WriteLine("vous n'êtes pas dans un fichier");
                         }
                         break;
                    #endregion

                    #region attribut isDirectory
                    case "directory":
                         if (utilisateur.current.type == "dossier")
                         {
                             Console.WriteLine("le dossier courant est un directory");
                         }
                         else
                         {
                             Console.WriteLine("le dossier courant n'est pas un directory");
                         }
                         break;
                    #endregion

                    #region attribut getName
                    case "name":
                         if (1 == listecommande.Length)
                         {
                             Console.WriteLine(utilisateur.current.nom);
                         }
                         break;
                    #endregion

                    #region attribut getParent
                    case "parent":
                         if (1 == listecommande.Length)
                         {
                             utilisateur.cd();
                         }
                         else
                         {
                             Console.WriteLine("Votre commande .. n'est pas bien écrite EX:\"..\"");
                         }

                         break;
                    #endregion

                    #region attribut lirefichier
                    case "show":
                         if (1 != listecommande.Length)
                         {
                             utilisateur.ficheraffichage(listecommande[1]);
                         }
                         else
                         {
                             Console.WriteLine("Votre commande show n'est pas bien écrite EX:\"show [nom de fichier]\"");
                         }
                         break;
                    #endregion

                    #region attribut canWrite
                    case "write":
                         if (1 != listecommande.Length)
                         {
                             if (utilisateur.canWrite() == true)
                             {
                                 Console.WriteLine("vous pouvez modifier le fichier");
                             }
                         }
                         else
                         {
                             Console.WriteLine("Votre commande write n'est pas bien écrite EX:\"write\"");
                         }
                         break;
                    #endregion

                    #region attribut canRead
                    case "read":
                         if (1 != listecommande.Length)
                         {
                             if (utilisateur.canRead() == true)
                             {
                                 Console.WriteLine("vous pouvez lire le fichier");
                             }
                         }
                         else
                         {
                             Console.WriteLine("Votre commande read n'est pas bien écrite EX:\"read\"");
                         }
                         break;
                    #endregion

                    #region attribut canExecute
                    case "execute":
                         if (1 != listecommande.Length)
                         {
                             if (utilisateur.canExecute() == true)
                             {
                                 Console.WriteLine("vous pouvez éxécuter le fichier");
                             }
                         }
                         else
                         {
                             Console.WriteLine("Votre commande execute n'est pas bien écrite EX:\"execute\"");
                         }
                         break;
                    #endregion

                    #region attribut shutdown
                    case "shutdown":
                         fin = true;
                         Console.WriteLine("appuyer pour éteindre");
                         Console.ReadLine();
                         break;
                    #endregion

                    #region attribut default
                    default:
                        Console.WriteLine("La commande : " + commande + " est érroné");
                        break;
                    #endregion

                    #region attribut vide
                    case "":
                    break;
                    #endregion
                }
            }
        }
    }
}
