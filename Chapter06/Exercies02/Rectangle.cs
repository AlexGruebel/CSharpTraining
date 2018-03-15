namespace Exercies02{
    public class Rectangle : Shape{
        protected override void recalculateArea(){
            base.area = Height * Width;
        }
    }
}
