using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

public partial class GameManager : Node2D
{
	// The approval rating of the player. If the approval rating is too low, the player will not be re-elected (progress to the next level)
	public int approval;

	// The budget of the player (in millions of USD). Decisions and events will require the player to spend their budget, forcing them to choose wisely.
	public int budget;

	// The current level of the game, which represents the current term of the player.
	public int level;

	// The current tax rate of the game.
	public int taxRate;

	public Godot.Timer eventTimer;

	public Godot.Timer levelTimer;

	// District currently loaded.
	public District districts;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		EnterDistrict();

		/**
		this.budget = 100; // $100,000,000 by default
		this.taxRate = 10; // 10% tax rate by default
		this.level = 1; // Level 1
		
		this.eventTimer = GetNode<Timer>("EventTimer");
		this.levelTimer = GetNode<Timer>("LevelTimer");

		StartLevel();
		*/
	}

	public void StartLevel() {
		this.eventTimer.Start(180);
		this.eventTimer.Timeout += EndLevel;
		StartEvent();
	}

	public void EndLevel() {
		this.eventTimer.Stop();

		if (approval < 30.0) {
			return;
		}

		level++;

		StartLevel();
	}

	public void StartEvent() {
		this.eventTimer.Start(10);
		this.eventTimer.Timeout += EndEvent;
	}

	public void EndEvent() {
		StartEvent();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		/**
		int totalPopulation = 0;
		int totalRevenue = 0;
		int totalApproval = 0;

		foreach (District district in this.districts.Values) {
			totalPopulation += district.population;
			totalRevenue += (int) (district.salary * district.population);
			totalApproval += district.approval * district.population;
		}

		this.approval = totalApproval / totalPopulation;
		this.budget += totalRevenue * taxRate;
		*/
	}

	public void SendEvent() {}

	public void EnterDistrict() {
		/**
		District district = (District) ResourceLoader.Load<PackedScene>("res://scenes/districts/Harlem.tscn").Instantiate();
		AddChild(district);
		ToggleMap();
		*/
		GetTree().ChangeSceneToFile("res://scenes/districts/Midtown.tscn"); // Changing the scene to the Game scene.
	}

	public void ToggleMap() {
		Control map = GetNode<Control>("Map");
		map.Visible =!map.Visible;
	}
}
