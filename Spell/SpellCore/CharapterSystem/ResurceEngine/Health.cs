using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCore.CharapterSystem.ResurceEngine.ResurscePipeBlocks;


namespace SpellCore.CharapterSystem.ResurceEngine
{
    public class Health : BaseResurce
    {
        public Health(object owner) : base(owner)
        {//Порядок добавления важен. Ресурс начинает обрабатываться конца доходя до собственно говоря здоровья.
            PipeBlocks.Add("Health",new BaseHealth((BaseCharapter)owner));
            PipeBlocks.Add("Shield",new BaseShield((BaseCharapter)owner));
        }   
        //После создания скидываем всё в начальное состояние
        public void Reset()
        {
            foreach (var block in PipeBlocks)
            {
                block.Value.Reset();
            }
        }
        public void ChangeBlock(string nameBlock, IResurcePipeBlock block)
        {
            PipeBlocks[nameBlock] = block;
        }
        public float CalcEHP()
        {
            float OUT = 0;
            foreach (var item in PipeBlocks)
            {
                IResurcePipeBlock block = item.Value;
                if (block.ActiveBlock)
                {
                    OUT += block.Value;
                }
            }
            return OUT;
        }
    }
}
