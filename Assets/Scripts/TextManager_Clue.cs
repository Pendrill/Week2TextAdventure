using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager_Clue : MonoBehaviour {
	//Here is a list of the rooms that the player should be able to explore as they are investigating the house:
	/*
	 * Outside the Mansion
	 * The Garden
	 * The Entrance Hall
	 * The Dining Room
	 * The Kitchen
	 * The StairCase
	 * The Master BedRoom
	 * The BathRoom
	 * The Living Room 
	 * The Guest Room
	 * The Library
	 * 
	 * The player should have the option to leave the crime scene. This equates to them giving up
	 */

	// We are going to need a series of counters to mangae the different things that can happen in a room, based on how many times 
	// the player has entered the room.

	int outsideCounter=0, gardenCounter=0, entranceCounter=0, diningCounter=0, kitchenCounter=0, livingCounter=0,
	guestCounter=0, libraryCounter=0, stairCounter=0, bedroomCounter=0, bathroomCounter=0, leaveCounter=0;

	//The player should start just Outside the Mansion.
	string currentRoom = "The perimeter just outside the Mansion";
	//We create the gates the player will have to open
	bool GameOver=false;
	bool hasKeyToTheBedroom = false;
	//bool hasEnteredTheMansion = false;
	bool wasGivenPermissionToGarden = false;
	bool hasAllTheEvidence = false;
	//bool hasStudentID = false;
	bool hasVial=false, window=false, pharmacist=false, letter=false, cup= false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		string textBuffer = "You are currently in: " + currentRoom;

		//you are outside the residence for the first time.
		if (currentRoom == "The perimeter just outside the Mansion" && outsideCounter == 0) {
			textBuffer += "\n\nI was called in early this morning after the news of Mrs. Ronan’s death broke." +
			" The swirling red and blue lights of the police vehicles surround me. I are not alone here. There are many other officers, however" +
			" none of them feel the need to investigate the Residence. They seem content with just staling the media and ignoring their questions. " +
			"Unfortunately, this crime is not going to solve itself. ";

			textBuffer += "\n\npress [S] to enter the Residence";
			textBuffer += "\npress [A] to go inspect the Garden";
			textBuffer += "\nPress [W] to leave the crime scene. Someone else can take care of it, right...?";

			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "Leave";
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "The Entrance Hall";
				outsideCounter++;
				leaveCounter++;
			} else if (Input.GetKeyDown (KeyCode.A)) {
				currentRoom = "The Garden";
			}
			//You have returned to outisde the residence after having leaving it at least once.
		} else if (currentRoom == "The perimeter just outside the Mansion" && outsideCounter > 0) {
			//Does the player have all the evidence or are their still things they have not found.
			if (!hasAllTheEvidence) {
				textBuffer += "\n\nNot much seems to have changed here. More police officers have arrived. They really don’t want anyone getting inside that residence." +
				" It seems some of the media people have started to trickle out. They must realize we know as much as them at this point. Anyways, I should get back to" +
				" the investigation; it’s still unclear what has happened here.";
				textBuffer += "\n\npress [S] to enter the Residence";
				textBuffer += "\npress [A] to go inspect the Garden";
				textBuffer += "\nPress [W] to leave the crime scene. Someone else can take care of it, right...?";

				if (Input.GetKeyDown (KeyCode.W)) {
					currentRoom = "Leave";
				} else if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "The Entrance Hall";
				} else if (Input.GetKeyDown (KeyCode.A)) {
					currentRoom = "The Garden";
				}
			} else if (hasAllTheEvidence) {
				textBuffer += "\n\nI think I have found all the evidence in the house. Now might be the time to go see the Commissioner and possibly make an arrest.";
				textBuffer += "\n\nPress [S] to confront the Commissioner.";
				if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "Commissioner";
				}
			}

		} else if (currentRoom == "The Garden" && gardenCounter == 0) {
			textBuffer += "\n\nThere is a gate leading to the garden. However it seems unlock.";
			if (!wasGivenPermissionToGarden) {
				textBuffer += "\nI was not given permission to enter the Garden. I am not even sure it is relevant to this case. Maybe I should double check that it is ok for me to be here.";
				textBuffer += "\n\npress [D] to return to the perimeter outside the residence";
				if (Input.GetKeyDown (KeyCode.D)) {
					currentRoom = "The perimeter just outside the Mansion";
				}
				//add the options to return to the previous rooms, so that the player can retrieve their student ID
			} else if (wasGivenPermissionToGarden) {
				textBuffer += "\nI open the gate and step into the garden. There is not much to see here. It seems most of the plants have wilted away. Just as I am about to leace the garden" +
				"a momentary flash of light blinds me. I notice a tiny vial of glass laying on the floor. I put on my gloves and pick it up. A very distinct smell emits from the vial." +
				"I place the vial with the rest of the evidence.";
				hasVial = true;
				textBuffer += "\n\npress [D] to return to the perimeter outside the residence";
				if (Input.GetKeyDown (KeyCode.D)) {
					currentRoom = "The perimeter just outside the Mansion";
					gardenCounter++;
				}
				//Don't forget the option to now go up and down the elevator to access some new rooms
				//I am assuming you do this the same way as when we accessed the previous rooms
			}
			//Debug.Log("Test");
			//insert Elevators code here
		} else if (currentRoom == "The Garden" && gardenCounter > 0) {
			textBuffer += "\n\nThere is nothing more to see here.";
			textBuffer += "\n\npress [D] to return to the perimeter outside the residence";
			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "The perimeter just outside the Mansion";
			}
		} else if (currentRoom == "Leave" && leaveCounter == 0) {
			textBuffer += "\n\nWhat am I doing? I should not leave now. I just got here. I should at least check the crime scene and see if i can figure anything out.";
			textBuffer += "\n\nPress [S] to go back to the perimeter outside the residence";
			if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "The perimeter just outside the Mansion";
			}

			//insert Outside code here
		} else if (currentRoom == "Leave" && leaveCounter > 0) {
			textBuffer += "\n\nShould I really leave the crime scene? If I do then it is up to someone else to solve this crime, and they might not manage. Am I sure I want to do this?";
			textBuffer += "\n\nPress [S] to go back to the perimeter outside the residence";
			textBuffer += "\n\nPress [W] to abandon the case.";
			if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "The perimeter just outside the Mansion";
			} else if (Input.GetKeyDown (KeyCode.W)) {
				GameOver = true;
				currentRoom = "GAME OVER";
			} 
		} else if (currentRoom == "The Entrance Hall" && entranceCounter == 0) {
			textBuffer += "\n\nAs soon as I walk into the main lobby I see the commissionner leaning against one of the many ornate tables. As his eyes meet mine he begins to walk towards me." +
			"He removes his right hand from his pocket and as he passes me, he lays it on my shoulder.\n 'This might a tough one' he says 'Most of the witnesses are in the kitchen, we wanted to " +
			"move them away from the body. I'm going to go outside, let me know if you can make sense of this murder. \nI wasn't sure if the commissioner was truly stumped and couldn't deal with this case" +
			"or if he was simply tired of this job and needed a smoke. In any case, it seemed clear that this was a murder";
			textBuffer += "\n\npress [A] to enter the Dining Room";
			textBuffer += "\npress [S] to enter the Living Room";
			textBuffer += "\nPress [D] to go up the Stairs";
			textBuffer += "\nPress [W] to go back Outside";

			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "The StairCase";
				entranceCounter++;
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "The Living Room";
				entranceCounter++;
			} else if (Input.GetKeyDown (KeyCode.A)) {
				currentRoom = "The Dining Room";
				entranceCounter++;
			} else if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "The perimeter just outside the Mansion";
				entranceCounter++;
			}

		} else if (currentRoom == "The Entrance Hall" && entranceCounter > 0) {
			if (!hasAllTheEvidence) {
				textBuffer += "\n\nNothing has changed here. Maybe I should move on to an other room. There must be more evidence to find!";
				textBuffer += "\n\npress [A] to enter the Dining Room";
				textBuffer += "\npress [S] to enter the Living Room";
				textBuffer += "\nPress [D] to go up the Stairs";
				textBuffer += "\nPress [W] to go back Outside";

				if (Input.GetKeyDown (KeyCode.D)) {
					currentRoom = "The StairCase";
					entranceCounter++;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "The Living Room";
					entranceCounter++;
				} else if (Input.GetKeyDown (KeyCode.A)) {
					currentRoom = "The Dining Room";
					entranceCounter++;
				} else if (Input.GetKeyDown (KeyCode.W)) {
					currentRoom = "The perimeter just outside the Mansion";
					entranceCounter++;
				}

			} else if (hasAllTheEvidence) {
				textBuffer += "\n\nI believe I have found all the evidence; there is nothing more to see here. I should go talk to the commissioner." +
				"He should be waiting for me outside.";
				textBuffer += "\n\npress [A] to enter the Dining Room";
				textBuffer += "\npress [S] to enter the Living Room";
				textBuffer += "\nPress [D] to go up the Stairs";
				textBuffer += "\nPress [W] to go back Outside";

				if (Input.GetKeyDown (KeyCode.D)) {
					currentRoom = "The StairCase";
					entranceCounter++;
				} else if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "The Living Room";
					entranceCounter++;
				} else if (Input.GetKeyDown (KeyCode.A)) {
					currentRoom = "The Dining Room";
					entranceCounter++;
				} else if (Input.GetKeyDown (KeyCode.W)) {
					currentRoom = "The perimeter just outside the Mansion";
					entranceCounter++;
				}
			}

		} else if (currentRoom == "The Dining Room" && diningCounter == 0) {
			textBuffer += "\n\nI stepped in to the Dining Room to find three of the five witnesses. They all seemed distraught. Who wouldn't be after seeing a dead body." +
			"One of them was crying so strongly they could probably be heared from any room in the house. They sat by the table next to the open window. This was probably not much consalation" +
			" but at least they had a nice view on the garden. It was clear this was probably not the time to bother these people.";
			
			textBuffer += "\n\npress [D] to enter to return to the Main Hall";
			textBuffer += "\npress [S] to enter the Kitchen";
			window = true;
			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "The Entrance Hall";
				diningCounter++;
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "The Kitchen";
				diningCounter++;
			} 
		} else if (currentRoom == "The Dining Room" && diningCounter > 0) {
			textBuffer += "\n\nThe witnesses were all still there. Still not ready to talk. Hopefully the commissioner had a chance to talk to them before I got here.";

			textBuffer += "\n\npress [D] to enter to return to the Main Hall";
			textBuffer += "\npress [S] to enter the Kitchen";
			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "The Entrance Hall";
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "The Kitchen";
			} 


		} else if (currentRoom == "The Kitchen" && kitchenCounter == 0) {
			textBuffer += "\n\nAs I walk into the kitchen I find another one of the witnesses. \n'Are you one of the police officers on the case?' They ask. I reply that I am and show them my badge." +
			"They looks at it dismissively and then says 'My name is Sam, I am the owner of this Residence. Is there anything you would like to know?' I asked her about the other witnesses. 'Oh, well" +
			" we are all friends. Henry is a pharmacist, Valentine is an actor, Marie is a lawyer, and Laura is currently unnemployed but she used to serve in the military'. I jot all the information down" +
			"on my notebook. Before leaving her i ask her if it ok for me to search every place within the residence. She nodded yes reluctantly.";
			pharmacist = true;
			wasGivenPermissionToGarden = true;
			textBuffer += "\n\nPress [W] to go back to the Dining Room";
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "The Dining Room";
				kitchenCounter++;
			}

		} else if (currentRoom == "The Kitchen" && kitchenCounter > 0) {
			textBuffer += "\n\nSam was still in the Kitchen. She was sipping on some water. When she noticed me she seemed perplexed. 'Is there anything you need she asks'? I relpy that " +
			"there is not and excuse myself for bothering her.";
			textBuffer += "\n\nPress [W] to go back to the Dining Room";
			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "The Dining Room";
			}

		} else if (currentRoom == "The StairCase") {
			textBuffer += "\n\nI decided to go up the stairs";
			if (!hasKeyToTheBedroom) {
				textBuffer += "\nOnce I reach the top I go to open the door. However it won't budge. It must be locked. There has to be a key around here somewhere.";
				textBuffer += "\n\npress [A] to return to the Entrance Hall";
				if (Input.GetKeyDown (KeyCode.A)) {
					currentRoom = "The Entrance Hall";

				}
			} else if (hasKeyToTheBedroom) {
				textBuffer += "\nOnce I reach the top I go to open the door. I use the key I found in the library to unlock. The door opens.";
				textBuffer += "\n\nPress [A] to return to the Entrance Hall";
				textBuffer += "\nPress [S] to go into the Master Bedroom";
				if (Input.GetKeyDown (KeyCode.A)) {
					currentRoom = "The Entrance Hall";
				} else if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "The Master BedRoom";
				}
			}

		}





		if (GameOver) {
			textBuffer = "GAME OVER. The case will remain unsolved";
		}
		if (hasVial&&window&&pharmacist&&letter&&cup){
			hasAllTheEvidence=true;
		}
		//
		GetComponent<Text> ().text = textBuffer;
	}
}
