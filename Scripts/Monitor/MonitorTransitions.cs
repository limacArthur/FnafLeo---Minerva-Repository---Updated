using System;
using Godot;

namespace FNAFLEOv2.Scripts.Monitor
{
    public partial class MonitorTransitions : AnimatedSprite2D
    {
        Trigger trigger;
        MonitorStatic noise;


        [Signal] public delegate void CallCamerasEventHandler();
        [Signal] public delegate void CreateNoiseEventHandler();

        public override void _Ready()
        {
            trigger = GetNode<Trigger>("../Trigger");
            noise = GetNode<MonitorStatic>("../Static");
            Visible = false;
            noise.NoiseFinished += OnNoiseFinished;
            trigger.UpMonitor += OnAnimation;
            trigger.DownMonitor += OnAnimation;
            this.AnimationFinished += OnAnimationFinished;
        }

        private void OnAnimation()
        {
            if (!trigger.usingMonitor)
            {
                Visible = true;
                Play("Up");
            }
            else
            {
                EmitSignal(SignalName.CreateNoise);
            }
        }

        private void OnAnimationFinished()
        {
            if (Animation == "Up")
            {
                EmitSignal(SignalName.CreateNoise);
                EmitSignal(SignalName.CallCameras);
            }
        }

        private void OnNoiseFinished()
        {
            if (!trigger.usingMonitor)
            {
                Play("Down");
            }
        }
    }
}
