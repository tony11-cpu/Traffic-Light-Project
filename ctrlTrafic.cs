using MyTraficLightProj.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyTraficLightProj.ctrlTrafic;

namespace MyTraficLightProj
{
    public partial class ctrlTrafic : UserControl
    {
        public ctrlTrafic() => InitializeComponent();

        private CancellationTokenSource _CancelleProccess = new CancellationTokenSource();
        private enLightState _CurrentTraficStatus = enLightState.Red;
        public event EventHandler<clsClassArgs.StatusChangedEventArgs> OnRedLight = null;
        public event EventHandler<clsClassArgs.StatusChangedEventArgs> OnOrangeLight = null;
        public event EventHandler<clsClassArgs.StatusChangedEventArgs> OnGreenLight = null;

        private void _LightChange_EventInvoke(string newState, byte duration) => OnRedLight?.Invoke(null, new clsClassArgs.StatusChangedEventArgs(newState, duration));

        private void _RedLight_Invokation()
        {
            pbTraficLight.Image = Resources.Red;
            lblTime.ForeColor = Color.Red;
            lblTime.Text = RedDuration.ToString();

            _LightChange_EventInvoke("RED",RedDuration);
        }

        private void _OrangeLight_Invokation()
        {
            pbTraficLight.Image = Resources.Orange;
            lblTime.ForeColor = Color.Orange;
            lblTime.Text = OrangeDuration.ToString();

            _LightChange_EventInvoke("ORANGE", OrangeDuration);
        }

        private void _GreenLight_Invokation()
        {
            pbTraficLight.Image = Resources.Green;
            lblTime.ForeColor = Color.Green;
            lblTime.Text = GreenDuration.ToString();

            _LightChange_EventInvoke("GREEN", GreenDuration);
        }

        public byte RedDuration { get; set; } = 10;
        public byte GreenDuration { get; set; } = 15;
        public byte OrangeDuration { get; set; } = 5;

        public enum enLightState : byte
        {
            Red = 1,
            Orange = 2,
            Green = 3
        }

        public enLightState CurrentTraficStatus
        {
            get => _CurrentTraficStatus;

            set
            {
                _CurrentTraficStatus = value;

                switch (value)
                {
                    case enLightState.Red:
                        _RedLight_Invokation();
                        break;
                    case enLightState.Orange:
                        _OrangeLight_Invokation();
                        break;
                    case enLightState.Green:
                        _GreenLight_Invokation();
                        break;
                }
            }
        }

        private async Task _EveryInterval(int Duration)
        {
            for(int i = Duration; i >= 0; i--)
            {
                lblTime.Text = i.ToString();
                await Task.Delay(1000);
            }
        }

        private async Task _RunLighy()
        {
            switch (CurrentTraficStatus)
            {
                case enLightState.Red:
                    await _EveryInterval(RedDuration);
                    CurrentTraficStatus = enLightState.Green;
                    break;
                case enLightState.Green:
                    await _EveryInterval(GreenDuration);
                    CurrentTraficStatus = enLightState.Orange;
                    break;
                case enLightState.Orange:
                    await _EveryInterval(OrangeDuration);
                    CurrentTraficStatus = enLightState.Red;
                    break;
            }
        }

        public virtual async Task Start()
        {
            while (!_CancelleProccess.IsCancellationRequested) 
               await _RunLighy();
        }

        public void Stop() => _CancelleProccess.Cancel();
    }
}
