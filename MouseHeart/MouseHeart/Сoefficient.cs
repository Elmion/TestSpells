using System;
namespace MouseHeart
{
    internal class Coefficient
    {
        public Guid id;
        public string Name;
        public float Value;
        public static float operator -(Coefficient a, Coefficient b)
        {
            return a.Value - b.Value;
        }
    }
}