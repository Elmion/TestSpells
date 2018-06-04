using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseHeart
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        EffectManager mng = new EffectManager();
        public Form1()
        {
            InitializeComponent();
            mng.Initialize();
            t.Interval = 1;
            t.Tick += T_Tick;
           // t.Start();
            //Coefficient.Add("x");
            //Coefficient.ListCoefficients["x"].Value = 4;
            //Coefficient.Add("y");
            //Coefficient.ListCoefficients["y"].Value = 8;
            СalculationFormula f = new СalculationFormula("((2+ydf/2)/(xc+2+xc+x))");
            // Console.WriteLine(f.Calc());

            //using (FormulaEditor form = new FormulaEditor(f))
            //{
            //    form.ShowDialog();
            //}

            Varible.LoadVaribles();
            var d = Varible.ListVaribles;
            Console.WriteLine(f.Calc());

            Console.ReadLine();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            mng.Update();
            Console.Clear();
            Console.WriteLine(mng.MouseOrganStatus());
            Console.SetCursorPosition(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
