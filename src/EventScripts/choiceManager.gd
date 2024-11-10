extends ColorRect

# onreadies for the result screen and background screen, to disable/enable and update
@onready var PopUp = $ResultPopUp
@export_multiline var problemDescription: String
#Set problem text
@onready var Problem_text = $ProblemBubble/ProblemText
#References used to change texts on the result pop up
@onready var Yes_Data = $YesOption/YesButton
@onready var No_Data = $NoOption/NoButton

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	Problem_text.text = problemDescription
	PopUp.visible = false

#Update information on the pop up with Yes_Data and make it visible
func _on_yes_button_pressed() -> void:
	#toggling and setting up pop up data
	PopUp.visible = true
	No_Data.disabled = true
	Yes_Data.disabled = true
	PopUp.get_child(0).text = Yes_Data.outcomeDescription
	PopUp.get_child(2).text = str(Yes_Data.repValue)
	PopUp.get_child(4).text = str(Yes_Data.moneyValue)
	#update global vars
	GlobalVars.reputation += Yes_Data.repValue
	GlobalVars.money += Yes_Data.moneyValue

#Update information on the pop up with No_Data and make it visible
func _on_no_button_pressed() -> void:
	#toggling and setting up pop up data
	PopUp.visible = true
	No_Data.disabled = true
	Yes_Data.disabled = true
	PopUp.get_child(0).text = No_Data.outcomeDescription
	PopUp.get_child(2).text = str(No_Data.repValue)
	PopUp.get_child(4).text = str(No_Data.moneyValue)
	#update gloal vars
	GlobalVars.reputation += Yes_Data.repValue
	GlobalVars.money += Yes_Data.moneyValue
	

#"Ends" everything by setting parent background to false
func _on_OK_button_pressed() -> void:
	PopUp.visible = false
	self.visible = false
	
