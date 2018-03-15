namespace Exercies02 {

    public abstract class Shape{

        protected double area;

        protected double width;

        protected double height;

        public virtual double Height{
            get{
                return height;
            } 
            set{
                this.height = value;
                recalculateArea();
            }
        }

        public virtual double Width{get; set;}

        public  double Area{get{
            return this.area;
        } }

        protected abstract void recalculateArea();
    }
}