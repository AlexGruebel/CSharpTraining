using System.Xml.Serialization;


namespace Shapes{

    //[XmlRoot(Namespace = Constants.Namespace)]
    [XmlInclude(typeof(Kreis))]
    [XmlInclude(typeof(Rechteck))]
    public abstract class Figur{

        private double flache;
        private double umfang;

        public abstract double GetFlaeche();
        public abstract double GetUmfang();

        public string FigurName{get;set;}
        
        //[XmlAttribute("flaeche")]
        public double Flache{
            get{
                this.flache = GetFlaeche();
                return this.flache;
            }

            set{
                this.flache = value;
            }
        }

        //[XmlAttribute("umfang")]
        public double Umfang{
            get{
                this.umfang = GetUmfang();
                return this.umfang;
            }

            set{
                this.umfang = value;
            }
        }

    }
}