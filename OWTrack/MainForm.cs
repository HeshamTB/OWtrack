/*Copyright(c) 2018 Hesham Systems LLC.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

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
            Time.Text = DateTime.Now.ToString("h:mm tt");
            try
            {
                if (tr.owRunning())
                {
                    status.Text = IS_RUNNING;
                    status.ForeColor = Color.FromArgb(0, 192, 0);
                }
                else
                {
                    status.Text = NOT_RUNNING;
                    status.ForeColor = Color.Black;
                }
            }
            catch (Exception e)
            {
                status.Text = e.Message;
                status.ForeColor = Color.Red;
            }
        }

        private void loadSave()
        {
            try
            {
                Directory.CreateDirectory("saves");
            }
            catch (Exception e)
            {
                MessageBox.Show("Can not create save directory.\n" + e.Message);
            }
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
                MessageBox.Show("Saved Overwatch.exe location.\nPress Clear to rest");
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
            saveManeger.SaveJSON(tr);
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
