using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Monitor
{
    public partial class MapButton : Button
    {
        int targetCamID;
        string camName;
        AnimatedSprite2D cameras;
        MonitorTransitions monitorStatic;
        mpGlobal parent;
        


        public override void _Ready()
        {
            this.Pressed += OnPressed;
            cameras = GetNode<AnimatedSprite2D>("/root/Office/Monitor/CanvasLayer/Cameras");
            monitorStatic = GetNode<MonitorTransitions>("/root/Office/Monitor/CanvasLayer/Transition");
            parent = GetParent<mpGlobal>();
            if (parent == null) return;
            camName = parent.camName;
            this.Text = camName;
            targetCamID = parent.camID;
        }

        void OnPressed()
        {
            monitorStatic.EmitSignal(MonitorTransitions.SignalName.CreateNoise);
            cameras.Frame = targetCamID;
        }
    }
}
