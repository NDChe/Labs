using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Lab_1_Circles
{
    public partial class Form1 : Form
    {
        Graphics GRAPHICS;
        Random random = new Random();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ThreadPriority> threadPriorities = new List<ThreadPriority>();
            foreach (ComboBox a in this.Controls.OfType<ComboBox>())
            {
                ThreadPriority threadPriority = new ThreadPriority();
                GetPriorityFromCombobox(a, threadPriority);
                threadPriorities.Add(threadPriority);
            }
            CirclesInitThreadMaker(threadPriorities);

            Thread.Sleep(100);
            Console.WriteLine("******************");
        }

        private void GetPriorityFromCombobox(ComboBox comboBox, ThreadPriority threadPriority)
        {
            switch (comboBox.SelectedItem)
            {
                case "Highest":
                    {
                        threadPriority = ThreadPriority.Highest;
                        break;
                    }
                case "AboveNormal":
                    {
                        threadPriority = ThreadPriority.AboveNormal;
                        break;
                    }
                case "Normal":
                    {
                        threadPriority = ThreadPriority.Normal;
                        break;
                    }
                case "BelowNormal":
                    {
                        threadPriority = ThreadPriority.BelowNormal;
                        break;
                    }
                case "Lowest":
                    {
                        threadPriority = ThreadPriority.Lowest;
                        break;
                    }
            }
        }

        private void CircleDrawer(object o)
        {
            int w_h = random.Next(3, 15);
            for (int i = 0; i < 10; i++)
            { 
                int x = random.Next(20, 800);
                int y = random.Next(20, 400);
                Rectangle rectangle = new Rectangle(x, y, w_h, w_h);
                GRAPHICS = this.CreateGraphics();
                GRAPHICS.DrawEllipse(new Pen(GetRandomColor(((int)o)*67), 20), rectangle);
            }
            Console.WriteLine($"Set #{(int)o} just appeared!");
        }

        public void CirclesInitThreadMaker(List<ThreadPriority> threadPriorities)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 3; i++)
            {
                object o = i+1;
                Thread thread = new Thread(() => { CircleDrawer(o); });
                thread.Priority = threadPriorities[i];
                threads.Add(thread);
            }
            ThreadStarter(threads);
        }

        public static void ThreadStarter(List<Thread> threads)
        {
            foreach (Thread thread in threads)
            {
                thread.Start();
            }
        }

        private Color GetRandomColor(int o)
        {
            return Color.FromArgb(o, 0, 0);
        }

        //public SolidBrush brushGet()
        //{
        //    SolidBrush oBrush = new SolidBrush(GetRandomColor());
        //    return oBrush;
        //}

    }
}
