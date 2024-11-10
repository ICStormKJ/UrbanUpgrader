extends Button

#fields that are filled into the result pop up
@export_multiline var outcomeDescription: String
@export var repValue: int
@export var moneyValue: int

##string that could be appended if a certain thing happens via RNG
@export_multiline var outcomeAppend: String
##value that rep becomes if a certain thing happens via RNG
@export var repAlternateVal: int
##value that money becomes if a certain thing happens via RNG
@export var moneyAlternateVal: int

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	var r = RandomNumberGenerator.new()
	var number = r.randi_range(0,100)
	if number >= 50:
		repValue = repAlternateVal
		moneyValue = moneyAlternateVal
		outcomeDescription += outcomeAppend
		
