using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAFLEOv2.Scripts.Control
{
	public partial class LightBehavior : Sprite2D
	{
		[Export] public string SwitchName;

		public bool isOn = false;

		[Export] public bool isRight;

		Switch lightSwitch;

		Tween tween;

		AudioStreamPlayer audio;

		public override void _Ready()
		{
			lightSwitch = GetNode<Switch>("../" + SwitchName);
			audio = GetNode<AudioStreamPlayer>("../LightAudio");
			lightSwitch.ChangeRightLightState += OnChangeRightLightState;
			lightSwitch.ChangeLeftLightState += OnChangeLeftLightState;
		}

		void OnChangeLeftLightState()
		{
			if (!isRight) isOn = !isOn;
            GD.Print("Light state changed: " + isOn);
            if (!isRight) audio.Play();
            UpdateAnimation();
        }

		void OnChangeRightLightState()
		{
			if (isRight) isOn = !isOn;
			GD.Print("Light state changed: " + isOn);
            if (isRight) audio.Play();
            UpdateAnimation();
        }

		void UpdateAnimation()
		{
			tween?.Kill();
            Frame = 0;

            if (isOn)
			{
                tween = CreateTween();
                tween.SetLoops();
                tween.TweenProperty(this, "frame", 5, 0.1f).From(0);
            }
			else
			{
				Frame = 5;
			}
		}
	}
}
