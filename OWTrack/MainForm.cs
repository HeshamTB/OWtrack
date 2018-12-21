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
using System.IO;

namespace OWTrack
{
    public partial class MainForm : Form
    {
        Tracker tr;
        private const string IS_RUNNING = "Running";
        private const string NOT_RUNNING = " Not running";
        private bool SRonce = false;
        private string Version = Program.Version.ToString();

        public MainForm()
        {
            InitializeComponent();
            tr = new Tracker();
            loadSave();
            checkStatus();
            update();
            label4.Text = Version;
            Text = "OWTrack " + Version;
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
                    if (tr.settings.TrackOW)
                    {
                        status.Text = NOT_RUNNING;
                        status.ForeColor = Color.Black;
                    }
                    else status.Text = "";
                }
            }
            catch (Exception e)
            {
                status.Text = e.Message;
                status.ForeColor = Color.Red;
            }
        }

        //Move to saveManeger.cs ?
        //Refactor!!
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
                    tr = saveManeger.GetSavedTracker();               
                    if (tr.startSR > 0) SRonce = true;                    
                    if (tr.settings.GamePath == "" || tr.settings.GamePath == null)
                    {
                        if (!tr.LoacteOW())
                        {
                            tr.settings.GamePath = askForGamePath();
                        }      
                    }    
                }                
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }                
            }
            else if (!tr.LoacteOW())
            {
                tr.settings.GamePath = askForGamePath();
            }
            ExeTrackCheckBx.Checked = tr.settings.TrackOW;
            SRCheckBx.Checked = tr.settings.TrackSR;
            update();
        }

        private string askForGamePath()
        {
            openFileDialog1.Title = "Select Overwatch.exe";
            openFileDialog1.DefaultExt = "exe";
            openFileDialog1.Filter = "exe Files (*.exe)|*.exe|All files (*.*)|*.*";           
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Saved Overwatch.exe location.\nPress Clear to rest");
                return openFileDialog1.FileName;
            }
            else return null;                      
        }        

        private void SRSystem(bool state)
        {
            srBut.Enabled = state;
            srTextBox.Enabled = state;
            tr.settings.TrackSR = state;
        }

        private void OWTrackFunc(bool state) => tr.settings.TrackOW = state;

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

        private void AddMatch()
        {
            Match match = new Match
            {
                oldSR = tr.startSR,
                newSR = tr.newSR,
                ChangeInSR = tr.srDiff(),
                dateTime = DateTime.Now
            };
            tr.AddMatch(match);
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
            AddMatch();
            update();
        }

        private void SRCheckBx_CheckedChanged(object sender, EventArgs e)
        {
            SRSystem(SRCheckBx.Checked);
            update();
        }

        private void ExeTrackCheckBx_CheckedChanged(object sender, EventArgs e)
        {
            OWTrackFunc(ExeTrackCheckBx.Checked);
            update();
        }

        private void ChngOWPathBtn_Click(object sender, EventArgs e)
        {
            tr.settings.GamePath = askForGamePath();
            update();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Icon = null;
            notifyIcon1.Dispose();           
        }
        #endregion        
    }
}
