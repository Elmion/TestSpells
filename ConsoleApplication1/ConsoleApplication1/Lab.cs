using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Lab
    {
        int NumLab;
        Random rnd;
        List<int> Prices;
        List<int> CurrentCard;
        public Lab(int NumLab)
        {
            this.NumLab = NumLab;
            rnd = new Random((int)DateTime.Now.Ticks + NumLab * 476);
            Prices = new List<int>();
        }
        public void DoExperiment(object card)
        {
            CurrentCard = card as List<int>;
            Prices.Clear();
            int i = 0;
            while (i < 3)
            {

                ItemEquipment item = new ItemEquipment(rnd);
                while (item.CurrentRefine <= 29)
                {
                    item.Refine(CurrentCard[item.CurrentRefine]);
                }
                Prices.Add(item.GetBuildPrice(CurrentCard));
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

            elemCard.InnerXml = ConvertPerfocarta(CurrentCard);
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
            return (int)(OUT / numbers.Count);
        }
    }
}
