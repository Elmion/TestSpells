using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem.Features;

namespace SpellCore.CharapterSystem
{
    class BaseHealth : IPipeBlockFeature
    {
        public float Amount { get; set; }
        public string Name { get; set; }

        public BaseHealth(object o)
        {

        }
        public void AddOrigin(object origin, int powerOrigin)
        {
            throw new NotImplementedException();
        }

        public void Recalculation()
        {
            throw new NotImplementedException();
        }

        public void RemoveOrigin(object origin)
        {
            throw new NotImplementedException();
        }
    }

    class InventoryHealth : IPipeBlockFeature
    {
        public float Amount { get; set; }
        public string Name { get; set; }

        public InventoryHealth(object o)
        {

        }
        public void AddOrigin(object origin, int powerOrigin)
        {
            throw new NotImplementedException();
        }

        public void Recalculation()
        {
            throw new NotImplementedException();
        }

        public void RemoveOrigin(object origin)
        {
            throw new NotImplementedException();
        }
    }

    class SpellHealth : IPipeBlockFeature
    {
        public float Amount { get; set; }
        public string Name { get; set; }

        public SpellHealth(object o)
        {

        }
        public void AddOrigin(object origin, int powerOrigin)
        {
            throw new NotImplementedException();
        }

        public void Recalculation()
        {
            throw new NotImplementedException();
        }

        public void RemoveOrigin(object origin)
        {
            throw new NotImplementedException();
        }
    }

}
