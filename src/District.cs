using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public partial class District {
	[Export]
    public int approval;

    [Export]
    public int population;

    [Export]
    public double salary;

    [Export]
    public Boolean floodWalls;

    public Button button;

    public District(int approval, int population, double salary, Boolean floodWalls, Button button) {
        this.approval = approval;
        this.population = population;
        this.salary = salary;
        this.floodWalls = floodWalls;
        this.button = button;
    }
}
