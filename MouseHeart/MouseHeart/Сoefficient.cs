using System;
using System.Collections.Generic;
namespace MouseHeart
{
    internal class Coefficient
    {
        public static Dictionary<string, Coefficient> ListCoefficients = new Dictionary<string, Coefficient>();

        public string Name;
        public float  Value;
        public Coefficient()
        {
            Name = string.Empty;
            Value = 0;
        }
        public static bool Add(string Name)
        {
            if(!ListCoefficients.ContainsKey(Name))
            {
                ListCoefficients.Add( Name, new Coefficient() { Name = Name, Value = 0 });
                return true;
            }
            return false;
        }
    }
}