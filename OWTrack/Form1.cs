using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

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
            loadSave();
            checkStatus();
            label4.Text = Program.Version;
            Text = "OWTrack " + Program.Version;           
        }
                
        private void checkStatus()
        {
            try
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + "/data.json", JsonConvert.SerializeObject(tr));
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

        private void loadSave()
        {
            if (saveExist())
            {
                tr.wins = savedTracker().wins;
                tr.losses = savedTracker().losses;
                update();
            }
            else MessageBox.Show("no save");
        }

        private bool saveExist()
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "/data.json")) { return true; }
                else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }            
        }

        private Tracker savedTracker()
        {
            try
            {
                return JsonConvert.DeserializeObject<Tracker>(File.ReadAllText(Directory.GetCurrentDirectory() + "/data.json"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;                
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            checkStatus();
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

        private void reduceWinBut_Click(object sender, EventArgs e)
        {
            tr.reduceWin();
            update();
        }

        private void reduceLossBut_Click(object sender, EventArgs e)
        {
            tr.rediceLoss();
            update();
        }

        private void update()
        {
            Wins.Text = tr.GetWins().ToString();
            Losses.Text = tr.GetLosses().ToString();
        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            tr.reset();
            update();
        }
    }
}
