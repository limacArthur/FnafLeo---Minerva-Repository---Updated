using Godot;
using System;

public partial class EventBus : Node
{
    [Signal] public delegate void BlackoutCalledEventHandler();

    [Signal] public delegate void NewGameStartedEventHandler();

    [Signal] public delegate void ContinueGameEventHandler();

    [Signal] public delegate void TransitionOnEventHandler();

    [Signal] public delegate void TransitionOffEventHandler();

    [Signal] public delegate void SelectNightEventHandler();

    [Signal] public delegate void SettingsScreenEventHandler();

    [Signal] public delegate void ExtrasScreenEventHandler();

    public static EventBus Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }
}