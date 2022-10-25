using CommandHelper;
using EscapeGame.Enums;
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
        private bool _ovenOn, _isBaking, _isIndeterminate, _isBakingEnabled, _firstTimeBaking = true;
        private int _temperature = 0; //_bakingProgress,
        private float _bakingProgress = (float)BakingProgress.Raw;
        private DateTime _bakingTime;
        private string _ovenMode;

        #region Main

        public OvenViewModel() { }

        private void BakeFries()
        {
            PIsBaking = true;
            int interval = _firstTimeBaking ? 1000 : 5000;
            PIsIndeterminate = true;
            Timer timer = new Timer { Interval = interval, AutoReset = false };
            timer.Elapsed += (o, e) =>
            {
                PIsIndeterminate = false;
                if (_firstTimeBaking)
                {
                    TriggerOnComponentFinished(new string[] { PBakingTime.Minute.ToString() } );
                    _firstTimeBaking = false;
                }
                else { PBakingProgress = (float)BakingProgress.Ready; }
                timer.Stop();
            };
            timer.Enabled = true;
        }

        private void OvenSettingsModified()
        {
            PIsBakingEnabled = !(POvenOn == false || POvenMode is null || PBakingTime.ToString("hh:mm:ss").Equals("12:00:00"));
        }

        public override void InvokeOnEnter(ActionID actionID)
        {
            switch(actionID)
            {
                case ActionID.Bake:
                    if(CmdBake.CanExecute(null)) CmdBake.Execute(null);
                    break;
                default:
                    break;
            }
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

        //public int PBakingProgress
        //{
        //    get => _bakingProgress;
        //    set
        //    {
        //        _bakingProgress = value;
        //        NotifyOnPropertyChanged("PBakingProgress");
        //    }
        //}

        public float PBakingProgress
        {
            get => _bakingProgress / 10;
            set
            {
                _bakingProgress = value;
                NotifyOnPropertyChanged("PBakingProgress");
            }
        }

        public int PTemperature
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
