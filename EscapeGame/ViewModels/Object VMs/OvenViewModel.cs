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
        private string _ovenMode;

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
            if (!POvenMode.Equals(null) &&
                !(PBakingTime.Equals(null) || PBakingTime.ToString("hh:mm:ss").Equals("00:00:00")))
                PIsBakingEnabled = true;
            else PIsBakingEnabled = false;
        }

        #endregion

        #region Properties

        public bool POvenOn
        {
            get { return _ovenOn; }
            set
            {
                _ovenOn = value;
                NotifyOnPropertyChanged("POvenOn");
            }
        }

        public bool PIsBaking
        {
            get { return _isBaking; }
            set
            {
                _isBaking = value;
                NotifyOnPropertyChanged("PIsBaking");
            }
        }

        public bool PIsBakingEnabled
        {
            get { return _isBakingEnabled; }
            set
            {
                _isBakingEnabled = value;
                NotifyOnPropertyChanged("PIsBakingEnabled");
            }
        }

        public bool PIsIndeterminate
        {
            get { return _isIndeterminate; }
            set
            {
                _isIndeterminate = value;
                NotifyOnPropertyChanged("PIsIndeterminate");
            }
        }

        public int PBakingProgress
        {
            get { return _bakingProgress; }
            set
            {
                _bakingProgress = value;
                NotifyOnPropertyChanged("PBakingProgress");
            }
        }

        public DateTime PBakingTime
        {
            get { return _bakingTime; }
            set
            {
                _bakingTime = value;
                NotifyOnPropertyChanged("PBakingTime");
            }
        }

        public string POvenMode
        {
            get { return _ovenMode; }
            set
            {
                _ovenMode = value;
                NotifyOnPropertyChanged("POvenMode");
            }
        }

        #endregion

        #region Commands

        public ICommand CmdBake
        {
            get { return new RelayCommand(o => BakeFries()); }
        }

        public ICommand CmdSettingsModified
        {
            get { return new RelayCommand(o => OvenSettingsModified()); }
        }

        #endregion
    }
}
