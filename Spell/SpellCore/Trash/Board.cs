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
        public static Action<object> OnCastingStart;
        public static Action<object> OnCastingEnd;
        public static Action<object> OnSpellCollision;
        public static Action<object> OnSpellApply;

        public static readonly Board Instance = new Board();

        private  List<BaseSpell> EffectInTurn;

        private Dictionary<Guid, IEffect> ApllyEffects;
        private Dictionary<Guid, SceneItem> TargetsEffects;

        public Board()
        {
            EffectInTurn = new List<BaseSpell>();
        }
        internal void CastingStart(BaseSpell spell)
        {

            OnCastingStart(spell);
        }
        private void CastingEnd(BaseSpell spell)
        {
            OnCastingEnd(spell);
        }
        private void SpellCollision(BaseSpell spell)
        {
            OnSpellCollision(spell);
        }
        private void SpellApply(BaseSpell spell)
        {
            OnSpellApply(spell);
        }
    }
}
