using Godot;
using System;
using System.ComponentModel;

public partial class GameManager : Node2D
{
	[Export]
	// The approval rating of the player. If the approval rating is too low, the player will not be re-elected (progress to the next level)
	public float approval;

	[Export]
	// The budget of the player (in millions of USD). Decisions and events will require the player to spend their budget, forcing them to choose wisely.
	public float budget;
	[Export]
	// The current level of the game, which represents the current term of the player.
	public int level;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Default stats;
		this.approval = 50.0f;
		this.budget = 100.0f;
		this.level = 1;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void Hello() {
		
	}
}
