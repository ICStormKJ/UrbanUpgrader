using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

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

	public Dictionary<string, District> districts;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.Container districtButtons = GetNode<Godot.Container>("Districts");
		this.districts = new Dictionary<string, District>();

		districts.Add("LowerManhattan", new District(
			approval: 50,
			// 440,000 people
			population: 440,
			// $129,000 average
            salary: 0.129,
            floodWalls: true,
            button: districtButtons.GetNode<Button>("LowerManhattan")
		));

		districtButtons.GetNode<Button>("LowerManhattan");

		districts.Add("Midtown", new District(
			approval: 50,
			// 407,000 people
			population: 407,
			// $125,000 average
            salary: 0.125,
            floodWalls: false,
            button: districtButtons.GetNode<Button>("Midtown")
		));

		districts.Add("UpperManhattan", new District(
			approval: 50,
			// 434,000 people
			population: 434,
			// $147,000 average
            salary: 0.147,
            floodWalls: false,
            button: districtButtons.GetNode<Button>("UpperManhattan")
		));

		districts.Add("Harlem", new District(
            approval: 50,
			// 372,000 people
            population: 372,
			// $50,000 average
            salary: 0.050,
            floodWalls: false,
			button: districtButtons.GetNode<Button>("Harlem")
        ));

        this.budget = 100; // $100,000,000 by default
		this.taxRate = 10; // 10% tax rate by default
		this.level = 1; // Level 1
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
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
	}


}
