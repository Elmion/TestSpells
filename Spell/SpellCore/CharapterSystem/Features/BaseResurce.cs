using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
    class BaseResurce
    {
        List<IResurcePipeBlock> PipeBlocks;
        public object owner;

        public BaseResurce(object owner)
        {
            PipeBlocks = new List<IResurcePipeBlock>();
            this.owner = owner;
        }
        public IResurcePipeBlock this[Type PipeBlock]
        {
            get
            {
                return PipeBlocks.FirstOrDefault(x => x.GetType() == PipeBlock);
            }
        }
        public void AddNewBlock(IResurcePipeBlock block)
        {
            PipeBlocks.Add(block);
        }
        public bool RemoveBlock (IResurcePipeBlock block)
        {
            return PipeBlocks.Remove(block);
        }
        public void Update()
        {
            for (int i = 0; i < PipeBlocks.Count; i++)
            {
                PipeBlocks[i].Update();
            }
        }
    }
    class Health : BaseResurce
    {
        public Health(object owner) :base(owner)
        {
            AddNewBlock(new BaseHealth((BaseCharapter)owner));
        }
    }
 }
