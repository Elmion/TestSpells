using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore
{
    class Board
    {
        public Action OnBoardAddEffect;
        public static readonly Board Instance = new Board();
        public Board()
        {

        }
        public void AddEffectOnBoard()
        {
            OnBoardAddEffect();

        }
        public void PreTurn()
        {

        }
        public void BeginTurn()
        {

        }
        public void AttackFase()
        {

        }
        public void DefendFase()
        {

        }
        public void ReactionAttack()
        {

        }
        public void EndTrun()
        {
            
        }
        public void LateEndPurn()
        {

        }

        public void ApplyEffect()
        {

        }
        private void CollectActiveEffectCharapter()
        {

        }
        public bool RegistryCharapterSpellBook()
        {
            return false;
        }

    }
}
