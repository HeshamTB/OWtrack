using System;
using System.Drawing;
using System.Windows.Forms;

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
            label4.Text = Program.Version;
            Text = "OWTrack " + Program.Version;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkStatus(); 
        }

        private void checkStatus()
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);                
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
