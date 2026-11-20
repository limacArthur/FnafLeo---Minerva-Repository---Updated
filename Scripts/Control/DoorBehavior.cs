using Godot;
using Godot.NativeInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAFLEOv2.Scripts.Control
{
    public partial class DoorBehavior : Sprite2D
    {

        [Export] public bool opened = true;
        [Export] public string side;
        [Export] public float ceil;
        [Export] public float speed;

        AudioStreamPlayer audio;

        Vector2 movement; 

        Tween tween;

        float energy;

        [Export] public string switchName;

        Switch doorSwitch; 

        public override void _Ready()
        {
            audio = GetNode<AudioStreamPlayer>("../DoorAudio");
            doorSwitch = GetNode<Switch>("../" + switchName);
            doorSwitch.ChangeRightDoorState += OnChangeRightDoorState;
            doorSwitch.ChangeLeftDoorState += OnChangeLeftDoorState;
        }

        void OnChangeRightDoorState()
        {
            if (side == "right")
            {
                opened = !opened;
                audio.Play();
                ChangePosition();
            }
        }

        void OnChangeLeftDoorState()
        {
            GD.Print("Left door state changed");
            if (side == "left")
            {
                opened = !opened;
                audio.Play();
                ChangePosition();
            }
        }

        void ChangePosition()
        {
            if (tween != null && tween.IsRunning()) tween.Kill();
            tween = CreateTween();
            Vector2 targetPosition = opened ? new Vector2(Position.X, 0) + new Vector2(0f, ceil) : new Vector2(Position.X, 0);
            tween.TweenProperty(this, "position", targetPosition, speed);
        }


    }
}
