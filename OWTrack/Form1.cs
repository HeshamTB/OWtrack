using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OWTrack
{
    public partial class Form1 : Form
    {
        Tracker tr = new Tracker();
        private const string IS_RUNNING = "Running";
        private const string NOT_RUNNING = " Not running";


        public Form1()
        {
            InitializeComponent();
            checkStatus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkStatus(); 
        }

        private void checkStatus()
        {
            Time.Text = DateTime.Now.ToString("h:mm tt");
           if (tr.owRunning())
           {                                
                status.Text = IS_RUNNING;
                status.ForeColor = Color.FromArgb(128, 255, 128);
           }
           else
           {
                status.Text = NOT_RUNNING;
                status.ForeColor = Color.Red;
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tr.addWin();
            update();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tr.addLoss();
            update();
        }
        private void update()
        {
            Wins.Text = tr.GetWins().ToString();
            Losses.Text = tr.GetLosses().ToString();
        }        
    }
}
