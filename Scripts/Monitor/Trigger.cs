using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Monitor
{
    public partial class Trigger : Sprite2D
    {
        Area2D area;
        bool canUp;
        bool canDown;
        public bool usingMonitor;

        [Signal] public delegate void UpMonitorEventHandler();
        [Signal] public delegate void DownMonitorEventHandler();

        public override void _Ready()
        {
            usingMonitor = false;
            canUp = true;
            canDown = false;
            area = GetNode<Area2D>("../Trigger/Area2D");
            if (area == null) return;
            area.MouseEntered += MonitorChange;
            area.MouseExited += MonitorReset;
        }

        void MonitorChange()
        {
            if (usingMonitor)
            {
                EmitSignal(Trigger.SignalName.DownMonitor);
                usingMonitor = false;
                GD.Print("Changed monitor to false");
            } 
            else
            {
                EmitSignal(Trigger.SignalName.UpMonitor);
                usingMonitor = true;
                GD.Print("Changed monitor to true");
            }
        }

        void MonitorReset()
        {
            if (usingMonitor)
            {
                canDown = true;
                canUp = false;
            } else
            {
                canDown = false;
                canUp = true; 
            }
        }
    }
}
