using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IANeurones {
    class RUnit {

        public int [] entrees { get; set; }
        public double [] matrice { get; set; }
        public double pas { get; set; }

        public RUnit (int[] ent, double[] poids,double pas) {

            this.entrees = ent;
            this.matrice = poids;
            this.pas = pas;
        }

        public void changerPoids(double sortieAtt, double sortie) {

            for(int i =0 ; i<matrice.Length ; i++)
                this.matrice[i] += this.pas*(sortieAtt - sortie)*entrees[i];
        }

        public double calcul() {

            double res = 0.0;
            for(int i = 0 ; i < entrees.Length ; i++) {
                res += entrees [i] * matrice [i];
            }
            return res;
        }

        public int exit(double sortie) {

            if (sortie >= 0.0)
                return 1;
            else
                return 0;
        }


    }
}
