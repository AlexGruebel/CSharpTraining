using System.Xml.Serialization;

namespace Shapes{
    
    public class Rechteck : Figur{

        private double laenge;
        private double breite;

        public Rechteck(double laenge, double breite) : this()
        {
            this.laenge = laenge;
            this.breite = breite;
        }

        public Rechteck(){
            base.FigurName = "Rechteck";
        }

        public override double GetFlaeche() => this.laenge * this.breite;

        public override double GetUmfang() => this.laenge * 2 + this.breite * 2;
    }   
}