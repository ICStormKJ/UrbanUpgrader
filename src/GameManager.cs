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
	public String districtLoaded;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.budget = 100; // $100,000,000 by default
		this.taxRate = 10; // 10% tax rate by default
		this.level = 1; // Level 1

		Node globalVars = GetTree().Root.GetNode<Node>("GlobalVars");
		globalVars.Set("reputationPercent", this.approval);
		globalVars.Set("money", this.budget);
		
		this.eventTimer = GetNode<Timer>("EventTimer");
		this.levelTimer = GetNode<Timer>("LevelTimer");

		Button harlemButton = GetNode<Button>("Map/Districts/Harlem");
		harlemButton.Pressed += EnterHarlem;
		Button midtownButton = GetNode<Button>("Map/Districts/Midtown");
		midtownButton.Pressed += EnterMidtown;

		StartLevel();
		StartEvent();
	}

	public void StartLevel() {
		this.levelTimer.Start(180);
		this.levelTimer.Timeout += EndLevel;
	}

	public void EndLevel() {
		this.levelTimer.Stop();

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
		RandomNumberGenerator random = new RandomNumberGenerator();
		int randomNum = random.RandiRange(0, 3);
		switch (randomNum) {
			case 0:
				Control education = (Control) ResourceLoader.Load<PackedScene>("res://events/control_Education.tscn").Instantiate();
				AddChild(education);
				break;
			case 1:
				Control flood = (Control) ResourceLoader.Load<PackedScene>("res://events/control_FloodWall.tscn").Instantiate();
				AddChild(flood);
				break;
			case 2:
				Control rich = (Control) ResourceLoader.Load<PackedScene>("res://events/control_RichGuy.tscn").Instantiate();
				AddChild(rich);
				break;		
			case 3:
				Control tax = (Control) ResourceLoader.Load<PackedScene>("res://events/control_Tax.tscn").Instantiate();
				AddChild(tax);
				break;	
		}
		StartEvent();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		int totalPopulation = 1;
		int totalRevenue = 0;
		int totalApproval = 0;

		/**
		foreach (District district in this.districts.Values) {
			totalPopulation += district.population;
			totalRevenue += (int) (district.salary * district.population);
			totalApproval += district.approval * district.population;
		}
		*/

		this.approval = totalApproval / totalPopulation;
		this.budget += totalRevenue * taxRate;
	}

	public void SendEvent() {}

	public void EnterHarlem() {
		District district = (District) ResourceLoader.Load<PackedScene>("res://scenes/districts/Harlem.tscn").Instantiate();
		AddChild(district); 
		districtLoaded = "Harlem";
		Button returnButton = GetNode<Button>("Harlem/District/Button");
		returnButton.Pressed += LeaveDistrict;
		ToggleMap();
	}

	public void EnterMidtown() {
		District district = (District) ResourceLoader.Load<PackedScene>("res://scenes/districts/Midtown.tscn").Instantiate();
		AddChild(district); 
		districtLoaded = "Midtown";
		Button returnButton = GetNode<Button>("Midtown/District/Button");
		returnButton.Pressed += LeaveDistrict;
		ToggleMap();
	}

	public void LeaveDistrict() {
		ToggleMap();
		RemoveChild(GetNode<District>(districtLoaded));
	}

	public void ToggleMap() {
		Control map = GetNode<Control>("Map");
		map.Visible =!map.Visible;
	}
}
