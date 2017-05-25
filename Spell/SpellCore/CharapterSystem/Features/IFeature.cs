
namespace SpellCore.CharapterSystem
{
    public class Feature
    {
        public float Value { get; private set; }
        public void Change(float ammont)
        {
            Value += ammont;
        }
        public void Set(float ammont)
        {
            Value = ammont;
        }

    }
}
