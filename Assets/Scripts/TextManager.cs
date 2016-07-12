using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	string currentRoom = "Lobby";
	bool hasStudentID = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "You are currently in: " + currentRoom;

		if (currentRoom == "Lobby") {
			textBuffer += "\nYou see the security guard.";

			textBuffer += "\npress [W] to go to the elevators.";
			textBuffer += "\npress [S] to go outside.";

			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "Elevators";
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "Outside";
			}
			//insert Lobby code here
		} else if (currentRoom == "Elevators") {
			textBuffer += "\nYou are waiting.";
			if (!hasStudentID) {
				textBuffer += "\nYou cannot access the elevator without swipping your student ID, which is currently not in your possession...";
				textBuffer += "\npress [S] to return to the lobby";
				if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "Lobby";
				}
				//add the options to return to the previous rooms, so that the player can retrieve their student ID
			} else if (hasStudentID) {
				textBuffer += "\nYou swipe your student ID, the guard smiles, and you now enter the elevator.";
				//Don't forget the option to now go up and down the elevator to access some new rooms
				//I am assuming you do this the same way as when we accessed the previous rooms
			}
			//Debug.Log("Test");
			//insert Elevators code here
		} else if (currentRoom == "Outside") {
			textBuffer += "\n IT IS REALLY HOT, WHAT IS WRONG WITH YOU?";
			textBuffer += "\npress [S] to go back inside, like right now!";
			textBuffer += "\n(oh and you found your student ID on the floor)";
			hasStudentID = true;

			if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "Lobby";
			}

			//insert Outside code here
		}
		GetComponent<Text> ().text = textBuffer;
	}
}
