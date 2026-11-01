using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace FNAFLEOv2.Scripts.Monitor
{
    public partial class mpGlobal : Node2D
    {
        [Export] public int camID;
        [Export] public string camName;
    }
}
