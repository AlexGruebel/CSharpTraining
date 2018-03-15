namespace Exercies02 {
    public class Circle : Shape{
        
        protected override void recalculateArea()
        {
            base.area = base.height * base.height * 2.56;
        }
    }
}