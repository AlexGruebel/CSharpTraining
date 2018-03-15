namespace Exercies02 {
    public class Square : Shape
    {
        
        protected override void recalculateArea()
        {
            base.area = Height * Width;
        }

    
    }
}