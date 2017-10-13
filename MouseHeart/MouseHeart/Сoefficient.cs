using System;
namespace MouseHeart
{
    internal class Сoefficient
    {
        public Guid id;
        public string Name;
        public float Value;
        public static float operator -(Сoefficient a, Сoefficient b)
        {
            return a.Value - b.Value;
        }
    }
}