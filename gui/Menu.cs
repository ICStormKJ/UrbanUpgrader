using Godot;
using System;

public partial class Menu : Control
{
	public Button playButton;
	public Button settingsButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		playButton = GetNode<Button>("Panel/VBoxContainer/PlayButton");
		playButton.Pressed += PlayPressed; // Connecting the button press event to the PlayPressed method.

		settingsButton = GetNode<Button>("Panel/VBoxContainer/SettingsButton");
		settingsButton.Pressed += SettingsPressed; // Connecting the button press event to the SettingsPressed method.
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	// When play button is pressed.
	public void PlayPressed() {
		GetTree().ChangeSceneToFile("res://scenes/map.tscn"); // Changing the scene to the Game scene.
	}

	public void SettingsPressed() {
		// Implement settings logic here.
	}
}
