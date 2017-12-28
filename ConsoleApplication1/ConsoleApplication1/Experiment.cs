using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Experiment
    {
        public List<int> card;
        public List<int> Prices;
        public Random rnd;
        public void SetRandom(Random rnd)
        {
            this.rnd = rnd;
        }
        public Experiment(List<int> card)
            {
                this.card = new List<int>(card);
                Prices = new List<int>();
            }       
        public void Calc()
            {
                int i = 0;
                while (i < 1)
                {
                    
                    ItemEquipment item = new ItemEquipment(rnd);
                    while (item.CurrentRefine <= 29)
                    {
                        item.Refine(card[item.CurrentRefine]);
                    }
                    Prices.Add(item.GetBuildPrice(card));
                    //item.GetReport(perfocarta);
                    i++;
                }
            }
        public XmlElement GetReport(XmlDocument doc)
        {
            XmlElement elemRoot = doc.CreateElement("Report");
            XmlElement elemCard = doc.CreateElement("Card");
            XmlElement elemPrice = doc.CreateElement("TotalPrice");
            elemRoot.AppendChild(elemCard);
            elemRoot.AppendChild(elemPrice);

            elemCard.InnerXml = ConvertPerfocarta(card);
            elemPrice.InnerXml = CalcAvg(Prices).ToString();
            return elemRoot;
        }
        private string ConvertPerfocarta(List<int> numbers)
        {
            string OUT = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                OUT += numbers[i].ToString();
            }
            return OUT;
        }
        private int CalcAvg(List<int> numbers)
        {
            long OUT = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                OUT += numbers[i];
            }
            return (int)( OUT / numbers.Count);
        }

    }
}
