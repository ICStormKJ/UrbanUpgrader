extends Node

#variables that keeps track of how many areas had flood walls
var areasWithProtection: int

#savedMessage is a special message when you protected all areas
@export_multiline var message: String
@export_multiline var savedMessage: String

##multiply this with amount of damaged areas to get reputation loss
@export var reputationMultiplier: int
var reputation: int

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	if areasWithProtection != 5:
		message += str(5-areasWithProtection) + "areas were affected."
		reputation = -1 * (5-areasWithProtection) * reputationMultiplier
	else:
		message += savedMessage
		reputation = 30
	self.get_child(0).text = message
	#update the reputation based on how many areas took damage
	self.get_child(2).text = str(reputation)