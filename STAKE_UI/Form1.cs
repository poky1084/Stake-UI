using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hilo_v2;
using Keno;
using Limbo;
using Bomber_GUI;

namespace STAKE_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadGameTabs();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        private void LoadGameTabs()
        {
            // HILO
            var hiloControl = new Hilo_v2.Form1();
            hiloControl.AutoScaleMode = AutoScaleMode.None;  // <-- fix scaling
            tabPage1.Tag = hiloControl.Size;
            hiloControl.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(hiloControl);

            // KENO
            var kenoControl = new Keno.Form1();
            kenoControl.BackColor = SystemColors.Control;   // <-- ensures correct color inheritance
            tabPage2.Tag = kenoControl.Size;
            kenoControl.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(kenoControl);

            var LimboControl = new Limbo.Form1();
            LimboControl.BackColor = SystemColors.Control;   // <-- ensures correct color inheritance
            tabPage3.Tag = LimboControl.Size;
            LimboControl.Dock = DockStyle.Fill;
            tabPage3.Controls.Add(LimboControl);

            var minesControl = new Bomber_GUI.Form1();
            minesControl.BackColor = SystemColors.Control;   // <-- ensures correct color inheritance
            tabPage4.Tag = minesControl.Size;
            minesControl.Dock = DockStyle.Top;
            tabPage4.Controls.Add(minesControl);

            minesControl.SizeChanged2 += (s, e) =>
            {
                this.BeginInvoke(new Action(() =>
                {
                    tabPage4.Tag = minesControl.PreferredSize;
                }));
            };
        }
    }
}
