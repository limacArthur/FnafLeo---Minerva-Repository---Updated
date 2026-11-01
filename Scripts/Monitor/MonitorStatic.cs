using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using Godot.NativeInterop;

namespace FNAFLEOv2.Scripts.Monitor
{
    public partial class MonitorStatic : Sprite2D
    {
        AudioStreamPlayer audio;
        [Signal] public delegate void NoiseFinishedEventHandler();
        MonitorTransitions monitorTransitions;
        Tween tween;

        public override void _Ready()
        {
            audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
            monitorTransitions = GetNode<MonitorTransitions>("../Transition");
            monitorTransitions.CreateNoise += OnCreateNoise;
        }

        void OnCreateNoise()
        {
            audio.Play();
            Visible = true;
            tween?.Kill();
            tween = CreateTween();
            tween.TweenProperty(this, "frame", 23f, 0.36f).From(0f);
            GetTree().CreateTimer(0.36f).Timeout += () =>
            {
                Visible = false;
                EmitSignal(SignalName.NoiseFinished);
                audio.Stop();
            };
        }
    }
}
