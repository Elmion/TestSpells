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
        XmlDocument doc;
        public List<Experiment> CurrentExperements;
        public List<XmlElement> Reports;
        public Lab(int NumLab,XmlDocument mainDoc)
        {
            this.NumLab = NumLab;
            rnd = new Random((int)DateTime.Now.Ticks + NumLab * 476);
            doc = mainDoc;
        }
        public void DoExperiments(object experements)
        {

            CurrentExperements = experements as List<Experiment>;
      
            foreach (var experement in CurrentExperements)
            {
                experement.SetRandom(rnd);
                experement.Calc();
            }
           // GenerateReport();
        }
        public void GenerateReport()
        {
            Reports = new List<XmlElement>();
            foreach (var experement in CurrentExperements)
            {
                lock(doc)
                {
                    Reports.Add(experement.GetReport(doc));
                }
            }
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
