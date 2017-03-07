using SpellCore.CharapterSystem;
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
        public Action OnPreTurn;
        public Action OnBeginTurn;
        public Action OnAttackFase;
        public Action OnDefendFase;
        public Action OnReactionAttack;
        public Action OnEndTrun;
        public Action OnLateEndTurn;
        public Action OnApplyEffect;

        public static readonly Board Instance = new Board();

        private  List<BaseSpell> EffectInTurn;

        public Board()
        {
            EffectInTurn = new List<BaseSpell>();
        }
        public void AddEffectOnBoard(BaseSpell spell)
        {
            AddedSpell = spell;
            OnBoardAddEffect();
            AddedSpell = null;
        }
        private void CollectActiveEffectCharapter()
        {

        }
        public bool RegistryCharapterSpellBook()
        {
            return false;
        }
        #region TurnStructure
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
        public void LateEndTurn()
        {

        }
        public void ApplyEffect()
        {

        } 
        #endregion


    }
}
