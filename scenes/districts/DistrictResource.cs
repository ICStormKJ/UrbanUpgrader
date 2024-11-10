using Godot;

namespace MayorMayhem
{
	[GlobalClass]
	public partial class DistrictResource : Resource
	{
		[Export]
		public int approval;

		[Export]
		public int population;

		[Export]
		public double salary;

		[Export]
		public int floodWallLevel;

		public Button button;

		// Make sure you provide a parameterless constructor.
		// In C#, a parameterless constructor is different from a
		// constructor with all default values.
		// Without a parameterless constructor, Godot will have problems
		// creating and editing your resource via the inspector.
		public DistrictResource() : this(0, 0, 0, 0, null) {}

		public DistrictResource(int approval, int population, double salary, int floodWallLevel, Button button) {
			this.approval = approval;
			this.population = population;
			this.salary = salary;
			this.floodWallLevel = floodWallLevel;
			this.button = button;
		}
	}
}
