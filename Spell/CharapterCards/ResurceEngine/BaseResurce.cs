using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharapterCards
{
    /// <summary>
    /// Базовывый ресурс ... во PipeBlocks набираем необходимые модули для обработки 
    /// </summary>
    public class BaseResurce
    {
        internal List<KeyValuePair<string, IResurcePipeBlock>> PipeBlocks { get; private set; }
        public BaseResurce(CharapterCard card)
        {
            PipeBlocks = new List<KeyValuePair<string, IResurcePipeBlock>>();
        }
        public void TakeExtarnalEffect(AttackModule InputAttackModule)
        {
            switch(InputAttackModule.ProccesingType)
            {
                case ModuleEffectTypes.Damage:
                case ModuleEffectTypes.Restore:
                    // Проходим пайп в обратном порядке подкюченных модулей
                    for (int i = PipeBlocks.Count-1; i <= 0; i--)
                    {
                        InputAttackModule = PipeBlocks[i].Value.TakeExtarnalEffect(InputAttackModule);
                    }
                    break;
                case ModuleEffectTypes.WithoutDamage:
                    break;
                case ModuleEffectTypes.AfterBufferShild:
                    break;
            }
            //После проверям блоки на изжившие себя и удаляем 
            for (int i = 0; i< PipeBlocks.Count; i++)
            {
                if (PipeBlocks[i].Value.MarkToRemove)
                {
                    PipeBlocks.RemoveAt(i);
                    i--;
                }
            }
        }
        public void Upgarde()
        {

        }
        public IResurcePipeBlock AddBlock(string nameBlock,params object[] arg)
        {
            IResurcePipeBlock OUT = PipeBlockFabric.Create(nameBlock, arg);
            if ( PipeBlocks.FindIndex(x => x.Key == nameBlock) != -1)
            {
                ChangeBlock(nameBlock, OUT);
            }
            else
            {
                int index = PipeBlocks.FindLastIndex(x => x.Value.Tags.Contains(OUT.Tags[0]));//ТУТ НУЖНО ЕЩЁ ПОДУМАТЬ КАК ИСКАТЬ ИНДЕКС В КОТОРЫЙ НУЖНО ВСТАВИТЬ НОВЫЙ БЛОК
                if (index != -1 && index != PipeBlocks.Count - 1)
                {
                        PipeBlocks.Insert(index + 1, new KeyValuePair<string, IResurcePipeBlock>(nameBlock, OUT));
                }
                else
                {
                        PipeBlocks.Add( new KeyValuePair<string, IResurcePipeBlock>(nameBlock, OUT));
                }
            }
            return OUT;
        }
        public void RemoveBlock(IResurcePipeBlock removedBlock)
        {

        }
        //public float CalcEHP()
        //{
        //    float OUT = 0;
        //    foreach (var item in PipeBlocks)
        //    {
        //        IResurcePipeBlock block = item.Value;
        //        if (block.ActiveBlock)
        //        {
        //            OUT += block.Value;
        //        }
        //    }
        //    return OUT;
        //}
        //public void CalcEShild()
        //{

        //}
        public void ChangeBlock(string nameBlock, IResurcePipeBlock block)
        {
            PipeBlocks[PipeBlocks.FindIndex( x=> x.Key == nameBlock)] = new KeyValuePair<string, IResurcePipeBlock>(nameBlock, block);
        }

    }
}
