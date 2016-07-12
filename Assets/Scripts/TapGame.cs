using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TapGame : MonoBehaviour {

	public Text tapText;
	private int currentPoints=0;
	// Use this for initialization
	void Start () {
		tapText.text = "Current Score: " + currentPoints;
	}
	
	// Update is called once per frame
	void Update () {
		//Give player 1 point if they press Space
		if (Input.GetKeyDown (KeyCode.Space)) {
			currentPoints++;

			

		} else if (Input.GetKeyDown (KeyCode.X)) {
			currentPoints += 1000;
		}
		tapText.text = "Current Score: " + currentPoints;
	}
}
