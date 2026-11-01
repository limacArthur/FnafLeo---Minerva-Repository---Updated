using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Monitor
{
    public partial class Cameras : AnimatedSprite2D
    {

        MonitorTransitions monitorTransitions;
        Trigger trigger;
        public override void _Ready()
        {
            Visible = false;
            monitorTransitions = GetNode<MonitorTransitions>("../Transition");
            trigger = GetNode<Trigger>("../Trigger");
            monitorTransitions.CallCameras += OnCallCameras;
            trigger.DownMonitor += () => Visible = false;

        }

        void OnCallCameras()
        {
            GetTree().CreateTimer(0.36f).Timeout += () => Visible = true;
        }


    }
}
