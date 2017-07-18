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
            //создали ресурс
            b.Card.AddResurce("Health");
            //создали 2 блока в нем ХП (1000 из виталити) и щит на 10 едениц
            b.Card.Resurces["Health"].AddBlock("BaseHealth");
            b.Card.Resurces["Health"].AddBlock("BaseShield",10f);
           
            //атака на 100 едениц
            AttackModule a = new AttackModule("Health");
            a.Type = AttackModuleType.Damage;
            a.Value = 100;
            b.Card.IncomingAttackModule(a);

            Assert.AreEqual(910f, b.Card.Resurces["Health"]["BaseHealth"].CurrentValue);

            //добавляем щит на 110 поинтов
            b.Card.Resurces["Health"].AddBlock("BaseShield", 110f);
            a = new AttackModule("Health");
            a.Type = AttackModuleType.Damage;
            a.Value = 100;
            b.Card.IncomingAttackModule(a);

            Assert.AreEqual(910f, b.Card.Resurces["Health"]["BaseHealth"].CurrentValue);
            Assert.AreEqual(10f, b.Card.Resurces["Health"]["BaseShield"].CurrentValue);

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
