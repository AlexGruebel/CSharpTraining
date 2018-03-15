namespace PacktLibrary{
    using System;
    public struct DisplacmentVector{
        int X;
        int Y;

        public DisplacmentVector(int X, int Y){
            this.X = X;
            this.Y = Y;
        }

        public static DisplacmentVector AddDisplacmentVectors(DisplacmentVector v1, DisplacmentVector v2){
            return new DisplacmentVector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static DisplacmentVector operator +(DisplacmentVector v1, DisplacmentVector v2) => AddDisplacmentVectors(v1, v2);
    }
}