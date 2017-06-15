using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellCore.CharapterSystem;
using SpellCore.CharapterSystem.ResurceEngine;
namespace SpellTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBaseCharapter()
        {
            SpellCore.Core.CreateCharapter("Mage");

        }
        [TestMethod]
        public void AttackHP100()
        {
            BaseCharapter b = SpellCore.Core.CreateCharapter("Mage");
            AttackModule a = new AttackModule();
            a.DamageValue = 300;
            a.ProccesingType = AttackTypes.Standart;
            b.Card.CharapterHealth.TakeExternalEffect(a);
            Assert.AreEqual(700, b.Card.CharapterHealth.CalcEHP());
            a = new AttackModule();
            a.DamageValue = 200;
            a.ProccesingType = AttackTypes.Restore;
            b.Card.CharapterHealth.TakeExternalEffect(a);
            Assert.AreEqual(900, b.Card.CharapterHealth.CalcEHP());
        }
    }
}
