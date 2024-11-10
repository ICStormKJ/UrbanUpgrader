using Godot;

public partial class District : Node2D
{
	[Export]
	public MayorMayhem.DistrictResource stats;

	public override void _Ready()
	{
		Control panel = ResourceLoader.Load<PackedScene>("res://gui/DistrictPanel.tscn").Instantiate<Control>();
		AddChild(panel);
	}
}
