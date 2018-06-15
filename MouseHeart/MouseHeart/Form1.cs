using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeopotamGroup.Ecs;
namespace MouseHeart
{

    public partial class Form1 : Form
    {
        public static EcsWorld world;
        public static EcsSystems systems;
        Timer t = new Timer();
        public static bool EatClick = false;
        public Form1()
        {
            InitializeComponent();
            t.Tick += T_Tick;
            world = new EcsWorld();
            systems = new EcsSystems(world)
                            .Add(new LungsProcessing())
                            .Add(new EatProcessing())
                            .Add(new DigestiondProcessing())
                            .Add(new HeartProcessing())
                            .Add(new BrainProcessing())
                            .Add(new MuscleProcessing())
                            .Add(new BonesProcessing())
                            .Add(new ConsoleOutputProcessing());

            systems.Initialize();

            int i = world.CreateEntity();
            var f = world.AddComponent<Mouse>(i);
            f.blood = new Blood();
            f.blood.V3 = 5.0f;
            f.stomach = new Stomach();
            f.blood.energy = new Energy();
            f.blood.o2 = new O2();
            f.heart = new Heart();
            f.heart.V3 = 0.02f;
            f.heart.Frequence = 2f;
            f.stomach.StomachCells = new List<Food>();
            f.lungs = new Lungs();
            f.lungs.Concentration = new O2();
            f.lungs.Concentration.Ammont = 0.1f;
            f.lungs.V3 = 3;
            f.lungs.Frequence = 6;

            i = world.CreateEntity();


            t.Start();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            systems.Run();
        }
        private void bEat_Click(object sender, EventArgs e)
        {
           EatClick = true;
        }
    }
    public class Mouse
    {
        public Stomach stomach;
        public Blood blood;
        public Heart heart;
        public Lungs lungs;
        
    }
    public class Stomach
    {
       public List<Food> StomachCells;
    }
    public class Lungs
    {
        public O2 Concentration;
        public float V3;
        public float Frequence;
    }
    public class Heart
    {
        public float V3;
        public float Frequence;
    }
    public class Food
    {
        public Energy energy;
        public float TimeDigestion;
    }
    public class Blood
    {
        public float V3;
        public Energy energy;
        public O2 o2;
    }
    public class Energy
    {
        public float Amount;
    }
    public class O2
    {
        public float Ammont;
    }

    [EcsInject]
    public class LungsProcessing :  IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;

        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                if(m.blood.o2.Ammont <= 0)
                {
                    m.lungs.Frequence = Math.Abs(m.blood.o2.Ammont) / (m.lungs.V3 * m.lungs.Concentration.Ammont);
                    m.blood.o2.Ammont += (float)Math.Ceiling(m.lungs.Frequence) * m.lungs.V3 * m.lungs.Concentration.Ammont;
                }
            }
        }
        public void Destroy() { }
    }
    [EcsInject]
    public class DigestiondProcessing : IEcsInitSystem, IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;

        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                m.blood.energy.Amount += GetEnergy(m.stomach);
            }
        }
        public void Initialize()
        {
        }
        public void Destroy() {}

        float GetEnergy(Stomach stomach)
        {
            float energyOut = 0;
            for (int i = 0; i < stomach.StomachCells.Count; i++)
            {
                if (stomach.StomachCells[i].energy.Amount > 0)
                {
                    stomach.StomachCells[i].energy.Amount--;
                    energyOut ++;
                }
            }
            return energyOut;
        }
    }
    [EcsInject]
    public class HeartProcessing : IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;

        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                m.blood.o2.Ammont += m.blood.o2.Ammont / (m.blood.V3/ (m.heart.V3*m.heart.Frequence));
                m.blood.energy.Amount -= 1f;
            }
        }
        public void Destroy() { }
    }
    [EcsInject]
    public class BrainProcessing : IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;

        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                m.blood.o2.Ammont -= 0.2f;// m.blood.o2.Ammont / (m.blood.V3 / (m.heart.V3 * m.heart.Frequence));
                m.blood.energy.Amount -= 1f;
            }
        }
        public void Destroy() { }
    }
    [EcsInject]
    public class MuscleProcessing : IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;
        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                m.blood.o2.Ammont -= 1f;// m.blood.o2.Ammont / (m.blood.V3 / (m.heart.V3 * m.heart.Frequence));
                m.blood.energy.Amount -= 1f;
            }
        }
        public void Destroy() { }
    }
    [EcsInject]
    public class BonesProcessing : IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;

        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                m.blood.o2.Ammont -= 1f;// m.blood.o2.Ammont / (m.blood.V3 / (m.heart.V3 * m.heart.Frequence));
                m.blood.energy.Amount -= 1f;
            }
        }
        public void Destroy() { }
    }
    [EcsInject]
    public class ConsoleOutputProcessing : IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;

        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                Console.Clear();
                Console.WriteLine("e  " + m.blood.energy.Amount);
                Console.WriteLine("o2 " + m.blood.o2.Ammont);
                string s = "";
                for (int j = 0; j < m.stomach.StomachCells.Count; j++)
                {
                    s += m.stomach.StomachCells[j].energy.Amount + " ";
                }
                Console.WriteLine("St " + s);
            }
        }
        public void Destroy() { }
    }
    [EcsInject]
    public class EatProcessing : IEcsRunSystem
    {
        EcsWorld world = null;
        EcsFilter<Mouse> mouse = null;

        public void Run()
        {
            for (int i = 0; i < mouse.EntitiesCount; i++)
            {
                var m = mouse.Components1[i];
                if (m.stomach.StomachCells.Count < 5 && Form1.EatClick)
                {
                    m.stomach.StomachCells.Insert(0, new Food() { energy = new Energy() });
                    m.stomach.StomachCells[0].energy.Amount = 200;
                    Form1.EatClick = false;
                }
                for (int j = 0; j < m.stomach.StomachCells.Count; j++)
                {
                    if (m.stomach.StomachCells[j].energy.Amount <= 0)
                    {
                        m.stomach.StomachCells.Remove(m.stomach.StomachCells[j]);
                    }
                }
            }
        }
        public void Destroy() { }


    }
}
