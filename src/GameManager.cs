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

	// District currently loaded.
	public String districtLoaded;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.budget = 100; // $100,000,000 by default
		this.taxRate = 10; // 10% tax rate by default
		this.level = 1; // Level 1
		Control control = GetNode<Control>("Map");
		control.Visible = false;
		this.EnterDistrict();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		int totalPopulation = 0;
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

	public void EnterDistrict() {
		District test = ResourceLoader.Load<District>("res://scenes/districts/Harlem.tscn");
		Console.WriteLine(test.stats.approval);
		//AddChild(testNode);
	}
}
