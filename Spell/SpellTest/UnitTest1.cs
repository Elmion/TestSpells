using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormulasStorage;
using CharapterCards;
namespace SpellTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBaseCharapter()
        {
            SpellCore.CharapterSystem.BaseCharapter b = new SpellCore.CharapterSystem.BaseCharapter(typeof(int));
            FormulasPort.Initialize(b);
            b.Card.Features.Add("Vitality",new CharapterCards.Feature(10));
            b.Card.Health.AddBlock("BaseHealth");
            b.Card.Health.AddBlock("BaseShield",10f);
            b.Card.Health.AddBlock("BaseHealth");
            AttackModule a = new AttackModule();
            a.ProccesingType = ModuleEffectTypes.Damage;
            a.DamageValue = 100;
            b.Card.Health.TakeExtarnalEffect(a);
            b.Card.Health.AddBlock("BaseShield", 110f);
            a = new AttackModule();
            a.ProccesingType = ModuleEffectTypes.Damage;
            a.DamageValue = 100;
            b.Card.Health.TakeExtarnalEffect(a);
            b.Card.Health.AddBlock("BaseShield", 110f);
        }
        [TestMethod]
        public void AttackHP100()
        {
            //BaseCharapter b = SpellCore.Core.CreateCharapter("Mage");
            //AttackModule a = new AttackModule();
            //a.DamageValue = 300;
            //a.ProccesingType = AttackTypes.Standart;
            //b.Card.CharapterHealth.TakeExternalEffect(a);
            //Assert.AreEqual(700, b.Card.CharapterHealth.CalcEHP());
            //a = new AttackModule();
            //a.DamageValue = 200;
            //a.ProccesingType = AttackTypes.Restore;
            //b.Card.CharapterHealth.TakeExternalEffect(a);
            //Assert.AreEqual(900, b.Card.CharapterHealth.CalcEHP());
        }
    }
}
