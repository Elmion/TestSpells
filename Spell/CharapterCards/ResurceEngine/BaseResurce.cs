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
        internal CharapterCard card;
        internal List<KeyValuePair<string, IResurcePipeBlock>> PipeBlocks { get; private set; }
        public BaseResurce(CharapterCard card)
        {
            this.card = card;
            PipeBlocks = new List<KeyValuePair<string, IResurcePipeBlock>>();
        }
        public IResurcePipeBlock this[string nameBlock]
        {
            get
                {
                  int index = PipeBlocks.FindIndex(x => x.Key == nameBlock);
                  if (index != -1) return PipeBlocks[index].Value;
                  return null;
                }
        }
        public AttackModule TakeAttackModule(AttackModule InputAttackModule)
        {
            //проходим через все блоки
            for (int i = 0; i < PipeBlocks.Count; i++)
            {
                InputAttackModule = PipeBlocks[i].Value.TakeExtarnalEffect(InputAttackModule);
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
            return InputAttackModule;
        }
        public void Upgarde()
        {

        }
        public IResurcePipeBlock AddBlock(string nameBlock,params object[] arg)
        {
            IResurcePipeBlock OUT = PipeBlockFabric.Create(nameBlock,card, arg);
            if ( PipeBlocks.FindIndex(x => x.Key == nameBlock) != -1)
            {
                ChangeBlock(nameBlock, OUT);
            }
            else
            {
                int index = PipeBlocks.FindLastIndex(x => x.Value.nameBlock == nameBlock);//ТУТ НУЖНО ЕЩЁ ПОДУМАТЬ КАК ИСКАТЬ ИНДЕКС В КОТОРЫЙ НУЖНО ВСТАВИТЬ НОВЫЙ БЛОК
                if (index != -1 && index != PipeBlocks.Count - 1)
                {
                        PipeBlocks.Insert(index + 1, new KeyValuePair<string, IResurcePipeBlock>(nameBlock, OUT));
                }
                else
                {
                        PipeBlocks.Add( new KeyValuePair<string, IResurcePipeBlock>(nameBlock, OUT));
                }
            }
            PipeBlocks.Sort((x, y) =>  x.Value.SortIndex.CompareTo(y.Value.SortIndex));
            PipeBlocks.Reverse();
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
