using alarmclock_01.Forms;
using alarmclock_01.Models;
using AlarmClockApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarmclock_01
{
    public partial class ClockForm1 : Form
    {
        private ClockModel _model = new ClockModel();

        private string _initialText;

        private AboutForm1 _aboutForm1;

        public ClockForm1()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.Model = _model.Setings;

            if (settingsForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            DisplayAlarmMode();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            DisplayLabel.Text = _model.CurrentTime.ToString(@"hh\:mm\:ss");

            if (_model.IsTimeToAwake())
            {
                if (_aboutForm1 == null || _aboutForm1.IsDisposed)
                {
                    _aboutForm1 = new AboutForm1 { Model = _model.Setings };
                }

                _aboutForm1.Show();

                if (_model.IsSoundOn)
                {
                    SystemSounds.Question.Play();
                }
            }
        }

        private void AboutButton_Click(object sender, EventArgs e) 
        {
            new AboutForm1().ShowDialog();
        }

        private void ClockForm_Load(object sender, EventArgs e)
        {
            _initialText = Text;
            _model.Setings.AlarmOff = () => DisplayAlarmMode();
        }

        private void DisplayAlarmMode()
        {
            if (_model.IsAlsrmOn)
            {
                Text = _initialText + "{ожидание}";
            }
            else
            {
                Text = _initialText;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _model.IsAlsrmOn = false;
            DisplayAlarmMode();
        }

        private void DisplayLabel_Click(object sender, EventArgs e)
        {

        }

        private void DisplayLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
