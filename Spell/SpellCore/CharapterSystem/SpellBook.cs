using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.CharapterSystem
{
    class SpellBook
    {
        private List<Guid> spellBook;//Храним как GUID на заклинания в общем списке.
        internal SpellBook()
        {
            spellBook = new List<Guid>();
        }
        /// <summary>
        /// Ищем заклинание в книге по названию и возвращаем его
        /// </summary>
        /// <param name="spellname"></param>
        /// <returns></returns>
        internal BaseSpell FindSpell(string spellname)
        {
            throw new NotImplementedException();
        }
       /// <summary>
       /// Загрузка книги
       /// </summary>
       /// <param name="Class"></param>
       /// <returns></returns>
        internal bool LoadBook(BaseCharapter Class)
        {
            return true;//загрузка удачна
        }
        /// <summary>
        /// Сохряняем книгу
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        internal bool SaveBook(BaseCharapter Class)
        {
            return true;//сохранение удачно
        }

        private void AddSpell(BaseSpell spell)
        {
            throw new NotImplementedException();
        }
    }
}
