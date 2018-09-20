using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;


namespace OWTrack
{
    public partial class MainForm : Form
    {
        Tracker tr = new Tracker();
        private const string IS_RUNNING = "Running";
        private const string NOT_RUNNING = " Not running";
        private string savesPath = Directory.GetCurrentDirectory() + "/saves/data.json";
        private bool SRonce = false;

        public MainForm()
        {
            InitializeComponent();
            loadSave();
            checkStatus();
            update();
            label4.Text = Program.Version.ToString();
            Text = "OWTrack " + Program.Version.ToString();           
        }
                
        private void checkStatus()
        {                                   
            try
            {
                Time.Text = DateTime.Now.ToString("h:mm tt");
                status.Text = NOT_RUNNING;
                status.ForeColor = Color.Red;
                if (tr.owRunning())
                {
                    status.Text = IS_RUNNING;
                    status.ForeColor = Color.FromArgb(0, 192, 0);
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);                
            }
        }

        private void loadSave()
        {
            Directory.CreateDirectory("saves");
            if (saveManeger.saveExist())
            {
                try
                {                   
                    using (StreamReader st = new StreamReader(savesPath))
                    {
                        string line = st.ReadLine();
                        if (line.Contains("Overwatch.exe"))
                        {
                            tr = saveManeger.GetSavedTracker();
                            st.Close();                            
                        }
                        else
                        {
                            if (!tr.LoacteOW())
                            {
                                tr.gamePath = getGamePath();
                            }
                            st.Close();
                        }

                    }
                }                
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }                
                update();
            }
            else if (!tr.LoacteOW())
            {
                tr.gamePath = getGamePath();
            }
        }       
        
        private string getGamePath()
        {
            openFileDialog1.Title = "Select Overwatch.exe";
            openFileDialog1.DefaultExt = "exe";
            openFileDialog1.Filter = "exe Files (*.exe)|*.exe|All files (*.*)|*.*";           
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                //tr.gamePath = openFileDialog1.FileName;
                MessageBox.Show("Saved Overwatch.exe location.\nPress Clear to rest\n" + openFileDialog1.FileName );
                return openFileDialog1.FileName;
            }
            else 
            {
                update();
                return null;
            }            
        }

        private Tracker savedTracker()
        {
            try
            {
                return JsonConvert.DeserializeObject<Tracker>(File.ReadAllText(savesPath));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;                
            }
        }

        private void update()
        {
            Wins.Text = tr.GetWins().ToString();
            Losses.Text = tr.GetLosses().ToString();
            if (tr.newSR == 0)
            {
                if (tr.srDiff() < 1) { srLabel.Text = tr.startSR.ToString() + " - 0"; }
                else srLabel.Text = tr.startSR.ToString() + " - " + tr.srDiff();
            }
            else srLabel.Text = tr.startSR.ToString() + " - " + tr.srDiff();
            srTextBox.Text = null;
            File.WriteAllText(Directory.GetCurrentDirectory() + "/saves/data.json", JsonConvert.SerializeObject(tr));
        }

        #region Events
        private void timer1_Tick(object sender, EventArgs e) => checkStatus();

        private void WinBtn_Click(object sender, EventArgs e)
        {
            tr.addWin();
            update();
        }

        private void LossBtn_Click(object sender, EventArgs e)
        {
            tr.addLoss();
            update();
        }

        private void reduceWinBut_Click(object sender, EventArgs e)
        {
            if (tr.wins > 0)
            {
                tr.reduceWin();
                update();
            }
        }

        private void reduceLossBut_Click(object sender, EventArgs e)
        {
            if (tr.losses > 0)
            {
                tr.rediceLoss();
                update();
            }
        }        

        private void clearBut_Click(object sender, EventArgs e)
        {
            tr.reset();
            update();
        }       

        private void srBut_Click(object sender, EventArgs e)
        {
            int sr = 0;
            try
            {
                sr = Convert.ToInt32(srTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a Number!");
                return;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (!SRonce)
                {
                    tr.startSR = sr;
                    SRonce = true;
                }
                else tr.newSR = sr;
            }
            update();
        }
        #endregion
    }
}
