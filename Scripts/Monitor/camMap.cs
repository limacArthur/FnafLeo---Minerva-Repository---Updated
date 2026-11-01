using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Monitor
{
    public partial class camMap : Node2D
    {

        MonitorStatic monitorStatic;
        Trigger trigger;
        public override void _Ready()
        {
            Visible = false;
            monitorStatic = GetNode<MonitorStatic>("/root/Office/Monitor/CanvasLayer/Static");
            trigger = GetNode<Trigger>("/root/Office/Monitor/CanvasLayer/Trigger");
            monitorStatic.NoiseFinished += OnNoiseFinished;
        }

        void OnNoiseFinished()
        {
            if (trigger.usingMonitor)
            {
                Visible = true;
            } else
            {
                Visible = false;
            }
        }
    }
}
