using System;

namespace Shapes{
    public class Kreis : Figur{

        private double radius;

        public Kreis(double radius) : this()
        {
            this.radius = radius;
        }

        public Kreis(){
            base.FigurName = "Kreis";
        }

        public override double GetUmfang() => 2 * Math.PI * this.radius;

        public override double GetFlaeche() => Math.Pow(radius, 2) * Math.PI;
    }
}