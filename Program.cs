using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IANeurones {
    class Program {

        const int PAIR = 0;
        const int IMPAIR = 1;

        static int [] bit1 = new int [] { 0,0,0,0,0,0,0,0,1,1 };
        static int [] bit2 = new int [] { 0,0,0,0,1,1,1,1,0,0 };
        static int [] bit3 = new int [] { 0,0,1,1,0,0,1,1,0,0 };
        static int [] bit4 = new int [] { 0,1,0,1,0,1,0,1,0,1 };

        static int [] zero = { -1,1,1,1,1,1,1,0 };
        static int [] un = { -1,0,1,1,0,0,0,0 };
        static int [] deux = { -1,1,1,0,1,1,0,1 };
        static int [] trois = { -1,1,1,1,1,0,0,1 };
        static int [] quatre = { -1,0,1,1,0,0,1,1 };
        static int [] cinq = { -1,1,0,1,1,0,1,1 };
        static int [] six = { -1,1,0,1,1,1,1,1 };
        static int [] sept = { -1,1,1,1,0,0,1,0 };
        static int [] huit = { -1,1,1,1,1,1,1,1 };
        static int [] neuf = { -1,1,1,1,1,0,1,1 };

        static int [] nul1 = new int [] { -1,1,0,0,0,0,0,0 };
        static int [] nul2 = new int [] { -1,1,1,0,0,0,0,0 };
        static int [] nul3 = new int [] { -1,1,1,0,1,0,0,0 };
        static int [] nul4 = new int [] { -1,1,1,0,1,0,0,0 };
        static int [] nul5 = new int [] { -1,0,1,1,1,0,0,0 };
        static int [] nul6 = new int [] { -1,0,1,1,1,1,0,0 };
        static int [] nul7 = new int [] { -1,0,1,1,1,1,1,0 };
        static int [] nul8 = new int [] { -1,0,1,1,1,1,1,1 };
        static int [] nul9 = new int [] { -1,0,0,0,1,0,0,1 };
        static int [] nul10 = new int [] { -1,0,0,1,1,0,0,1 };
        static int [] nul11 = new int [] { -1,0,0,1,1,1,0,1 };
        static int [] nul12 = new int [] { -1,0,1,0,0,0,0,1 };
        static int [] nul13 = new int [] { -1,1,1,0,0,0,0,1 };
        static int [] nul14 = new int [] { -1,0,0,1,1,0,1,0 };
        static int [] nul15 = new int [] { -1,1,0,1,1,0,1,0 };
        static int [] nul16 = new int [] { -1,0,0,0,0,0,0,0 };
        static int [] nul17 = new int [] { -1,0,0,1,1,0,0,0 };
        static int [] nul18 = new int [] { -1,1,0,1,1,0,0,0 };
        static int [] nul19 = new int [] { -1,0,0,0,1,1,0,0 };
        static int [] nul20 = new int [] { -1,1,0,0,1,1,0,0 };

        static void Main (string [] args) {

            //wij(t+1) = wij(t) + f(i) - f(j)

            //f(i) = 0 si pas de signal
            //f(i) = 1 si signal.

            //SI f(i) et f(j) =1 alors wij(t+1) > wij(t)

            //Mcculloh et pits = neurone en mode automate à seuil. 

            double [] matrice = { 0,0,0,0,0,0,0,0 };

            RUnit r1 = new RUnit(null,matrice,100);
            RUnit r2 = new RUnit(null,matrice,1);
            RUnit r3 = new RUnit(null,matrice,1);
            RUnit r4 = new RUnit(null,matrice,1);

            List<int []> listTab = new List<int []> { zero,un,deux,trois,quatre,cinq,six,sept,huit,neuf };
            List<int []> listTab2 = new List<int []> { zero,un,deux,trois,quatre,cinq,six,sept,huit,neuf,nul1,nul2,nul3,nul4,nul5,nul6,nul7,nul8,nul9,nul10,nul11,nul12,nul13,nul14,nul15,nul16,nul17,nul18,nul19,nul20 };

            parite(listTab,r1);
            //valeurs(listTab,r1,r2,r3,r4);
            //validite(listTab2,r1);
            Console.Read();

        }

        private static int teach(RUnit r, int[] bit,List<int []> listTab) {

            int verif = 0;

            for (int i = 0 ; i < listTab.Count ; i++) {

                r.entrees = listTab [i];
                double sortie = r.calcul();

                if (r.exit(sortie) != bit[i]) {

                    r.changerPoids(bit[i],r.exit(sortie));
                    verif = 1;
                }

            }

            return verif;
        }

        public static void valeurs (List<int []> listTab,RUnit r1,RUnit r2,RUnit r3, RUnit r4) {

            bool verif = false;

            /*bool erreur1 = false;
            bool erreur2 = false;
            bool erreur3 = false;
            bool erreur4 = false;*/

            int erreur = 0;

            /*while (verif == false) {

                erreur += teach(r1,bit1,listTab);

                if (erreur==0)
                    verif = true;
                else
                    erreur = 0;
            }

            Console.WriteLine("is OK 111");

            verif = false;
            erreur = 0;

            while (verif == false) {

                erreur += teach(r2,bit2,listTab);

                if (erreur == 0)
                    verif = true;
                else
                    erreur = 0;
            }

            Console.WriteLine("is OK 222");

            verif = false;
            erreur = 0;

            while (verif == false) {

                erreur += teach(r3,bit3,listTab);

                if (erreur == 0)
                    verif = true;
                else
                    erreur = 0;
            }

            Console.WriteLine("is OK 333");

            verif = false;
            erreur = 0;

            while (verif == false) {

                erreur += teach(r4,bit4,listTab);

                if (erreur == 0)
                    verif = true;
                else
                    erreur = 0;
            }*/


             while (verif == false) {
                
                erreur += teach(r1,bit1,listTab);
                erreur += teach(r2,bit2,listTab);
                erreur += teach(r3,bit3,listTab);
                erreur += teach(r4,bit4,listTab);

                if (erreur == 0)
                    verif = true;
                else
                    erreur = 0;
             }

            for (int i = 0 ; i < listTab.Count ; i++) {

                Console.WriteLine(i + " = " + testChiffres(i,r1,r2,r3,r4));
            }
        }

        private static void parite (List<int []> listTab, RUnit r) {

            bool verif = false;
            bool erreur = false;

            int pair = 0;
            double sortie;

            while (verif == false) {

                for (int i = 0 ; i < listTab.Count ; i++) {

                    r.entrees = listTab [i];
                    sortie = r.calcul();

                    if (r.exit(sortie) != pair) {

                        r.changerPoids(pair,r.exit(sortie));
                        erreur = true;
                    }

                    if (pair == 0)
                        pair = 1;
                    else
                        pair = 0;
                }

                if (!erreur)
                    verif = true;
                else
                    erreur = !erreur;
            }

            for(int cpt = 0 ; cpt<listTab.Count() ; cpt++) {

                r.entrees = listTab[cpt];
                sortie = r.calcul();
                Console.WriteLine(cpt + " : " + r.exit(sortie));
                

            }
        }

        private static void validite (List <int []> listTab2, RUnit r) {

            bool verif = false;
            bool erreur = false;

            int sortieVal = 1;
            double sortie;

            while (verif == false) {

                for (int i = 0 ; i < listTab2.Count ; i++) {

                    if (i > 9)
                        sortieVal = 0;
                    else
                        sortieVal = 1;

                    r.entrees = listTab2 [i];
                    sortie = r.calcul();

                    if (r.exit(sortie) != sortieVal) {

                        r.changerPoids(sortieVal,r.exit(sortie));
                        erreur = true;
                    }

                    
                }

                if (!erreur)
                    verif = true;
                else
                    erreur = !erreur;
            }

            for (int cpt = 0 ; cpt < listTab2.Count() ; cpt++) {

                r.entrees = listTab2 [cpt];
                sortie = r.calcul();
                Console.WriteLine(cpt + " : " + r.exit(sortie));


            }

        }

        static String testChiffres (int entree,RUnit r1,RUnit r2,RUnit r3,RUnit r4) {
            String ret = "";
            double sortie1, sortie2, sortie3, sortie4;
            int [] nb = zero;
            switch (entree) {
                case 1:
                nb = un;
                break;
                case 2:
                nb = deux;
                break;
                case 3:
                nb = trois;
                break;
                case 4:
                nb = quatre;
                break;
                case 5:
                nb = cinq;
                break;
                case 6:
                nb = six;
                break;
                case 7:
                nb = sept;
                break;
                case 8:
                nb = huit;
                break;
                case 9:
                nb = neuf;
                break;
                default:
                break;
            }
            r1.entrees = nb;
            sortie1 = r1.calcul();
            r2.entrees = nb;
            sortie2 = r2.calcul();
            r3.entrees = nb;
            sortie3 = r3.calcul();
            r4.entrees = nb;
            sortie4 = r4.calcul();
            ret = entree + "  : " + r1.exit(sortie1) + "" + r2.exit(sortie2) + "" + r3.exit(sortie3) + "" + r4.exit(sortie4);
            return ret;
        }
    }
}
