using AlarmClockApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alarmclock_01.Models
{
    internal class ClockModel
    {
        public TimeSpan CurrentTime => DateTime.Now.TimeOfDay;

        public bool IsAlsrmOn
        {
            get => Setings.IsAlarmOn;
            set => Setings.IsAlarmOn = value;
        }

        public bool IsSoundOn
        {
            get => Setings.IsSoundOn;
            set => Setings.IsSoundOn = value;
        }

        public bool IsTimeToAwake()
        {
            if (!IsAlsrmOn)
            {
                return false;
            }

            var now = DateTime.Now.TimeOfDay;
            if (now.Hours == Setings.AlarmTime.Hours
                && now.Minutes == Setings.AlarmTime.Minutes)
            {
                return true;
            }

            return false;
        }

        public SettingsModel Setings { get; set; } = new SettingsModel();
    }
}

