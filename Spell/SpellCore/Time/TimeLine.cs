using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCore.Time
{
    class TimeLine
    {
        public static readonly TimeLine Instance = new TimeLine();
        public Action StartTik { get; set; }
        public Action EndTik   { get; set; }

        private int _currentTime = 0;
        private List<TimeItem> Line;
        /// <summary>
        /// Предоставляет текущее время
        /// </summary>
        public int CurrentTime
        {
            get { return _currentTime; }
        } 
        private TimeLine()
        {
            Line = new List<TimeItem>();
            _currentTime = 0;
        }
        public void Tik()
        {
            StartTik();
            ///теперь таймлайн
            if (Line.Count == 0) return;//если список пуст то и делать тут нечего.Быстро вошли быстро вышли
            //вызываем все реакции в текущем тике.
            while (Line[0].TimeStamp == _currentTime) 
            {
                 Line[0].Reaction(Line[0].Arg);
                 Line.RemoveAt(0);
            }
            EndTik();
        }
        /// <summary>
        /// Добавляем в временую линию будущее событие
        /// </summary>
        /// <param name="item">в объекте указывается через сколько должно состояться событие</param>
        public void AddTimeItem(TimeItem item)
        {
            if (item.TimeStamp == 0)
            {
                ImmediatelyExecute(item);
                return;
            }
            item.TimeStamp = CurrentTime + item.TimeStamp;
            int index = Line.FindLastIndex(x => x.TimeStamp <= item.TimeStamp);
            if (index == -1 || index == Line.Count - 1) Line.Add(item);
            else
                Line.Insert(index+1, item);
        }
        /// <summary>
        /// Вставляет Item Для обработки в текущем тике
        /// </summary>
        /// <param name="item"></param>
        public void ImmediatelyExecute(TimeItem item)
        {
            if (Line.Count > 0)
            {
                int index = Line.FindLastIndex(x => x.TimeStamp == CurrentTime);
                if (index != -1)
                    Line.Insert(index+1, item);
                else
                    Line.Insert(0, item);
            }
            else
                    Line.Add(item);
        }
    }
}
