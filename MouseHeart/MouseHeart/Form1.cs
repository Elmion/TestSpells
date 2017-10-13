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
            t.Start();
            СalculationFormula f = new СalculationFormula();
            FormulaTreeNode tn;
            f.TryParse("(a*c+((d*c)+g))+r-j+ (s*d)",out tn);
        }
        private void T_Tick(object sender, EventArgs e)
        {
            mng.Update();
            Console.Clear();
            Console.WriteLine(mng.MouseOrganStatus());
            Console.SetCursorPosition(0, 0);
        }
    }
}
