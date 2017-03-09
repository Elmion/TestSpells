
namespace SpellCore.CharapterSystem
{
    interface IFeature
    {

        float Value { get; set; }
        void Change(float ammont);
        void Set(float ammont);

    }
}
