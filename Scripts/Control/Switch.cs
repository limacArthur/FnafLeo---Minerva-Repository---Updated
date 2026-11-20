using Godot;
using System;
using System.IO.Compression;
using System.Threading.Tasks;

public partial class Switch : Area2D
{
    Button button;

    [Export] string activeName;

    [Signal] public delegate void ChangeRightDoorStateEventHandler();
    [Signal] public delegate void ChangeLeftDoorStateEventHandler();
    [Signal] public delegate void ChangeRightLightStateEventHandler();
    [Signal] public delegate void ChangeLeftLightStateEventHandler();

    public override void _Ready()
    {
        button = GetNode<Button>("Button");
        button.Pressed += OnButtonPressed;
    }

    void OnButtonPressed()
    {
        switch (activeName)
        {
            case "RightDoor":
                EmitSignal(SignalName.ChangeRightDoorState);
                break;
            case "LeftDoor":
                EmitSignal(SignalName.ChangeLeftDoorState);
                break;
            case "RightLight":
                EmitSignal(SignalName.ChangeRightLightState);
                break;
            case "LeftLight":
                EmitSignal(SignalName.ChangeLeftLightState);
                break;
            
        }
        GD.Print("Switch signal emitted!");
    }
}
