using CommandHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace EscapeGame.ViewModels
{
    public class OvenViewModel : ObjectViewModel
    {
        private bool _ovenOn, _isBaking, _isIndeterminate, _isBakingEnabled;
        private int _bakingProgress;
        private DateTime _bakingTime;
        private string _ovenMode, _temperature;

        #region Main

        public OvenViewModel() { }

        private void BakeFries()
        {
            PIsBaking = true;
            PIsIndeterminate = true;
            Timer timer = new Timer { Interval = 5000, AutoReset = false };
            timer.Elapsed += (o, e) =>
            {
                PIsIndeterminate = false;
                TriggerOnComponentFinished(new string[] { $"Eine Backzeit von {PBakingTime:T}?",
                "Das wär ja noch schöner, wenn wir das hier 1:1 abbilden würden.",
                "Ich bin hier immernoch der Spielmaster! Das virtuelle Backen dauert...",
                "...acht Sekunden! Habe ich soeben spontan entschlossen." });
                timer.Stop();
            };
            timer.Enabled = true;
        }

        private void OvenSettingsModified()
        {
            PIsBakingEnabled = !(POvenMode is null || PBakingTime.ToString("hh:mm:ss").Equals("12:00:00"));
        }

        #endregion

        #region Properties

        public bool POvenOn
        {
            get => _ovenOn;
            set
            {
                _ovenOn = value;
                NotifyOnPropertyChanged("POvenOn");
            }
        }

        public bool PIsBaking
        {
            get => _isBaking;
            set
            {
                _isBaking = value;
                NotifyOnPropertyChanged("PIsBaking");
            }
        }

        public bool PIsBakingEnabled
        {
            get => _isBakingEnabled;
            set
            {
                _isBakingEnabled = value;
                NotifyOnPropertyChanged("PIsBakingEnabled");
            }
        }

        public bool PIsIndeterminate
        {
            get => _isIndeterminate;
            set
            {
                _isIndeterminate = value;
                NotifyOnPropertyChanged("PIsIndeterminate");
            }
        }

        public int PBakingProgress
        {
            get => _bakingProgress;
            set
            {
                _bakingProgress = value;
                NotifyOnPropertyChanged("PBakingProgress");
            }
        }

        public string PTemperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                NotifyOnPropertyChanged("PTemperature");
            }
        }

        public DateTime PBakingTime
        {
            get => _bakingTime;
            set
            {
                _bakingTime = value;
                NotifyOnPropertyChanged("PBakingTime");
            }
        }

        public string POvenMode
        {
            get => _ovenMode;
            set
            {
                _ovenMode = value;
                NotifyOnPropertyChanged("POvenMode");
            }
        }

        #endregion

        #region Commands

        public ICommand CmdBake => new RelayCommand(o => BakeFries());

        public ICommand CmdSettingsModified => new RelayCommand(o => OvenSettingsModified());

        #endregion
    }
}
