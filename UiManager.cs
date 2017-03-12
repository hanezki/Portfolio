using UnityEngine;
using System.Collections;

public class UiManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	//Tämä mahdollistaa laitteen omalla back napilla peruuttamisen.
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			switch(Application.loadedLevel) {
			case 0:
				Application.Quit();
				break;
			case 1: 
				Application.LoadLevel(0);
				break;
			case 2: 
				Application.LoadLevel(1);
				GameInfo.Running = false;
				GameInfo.timer = 0f;
				GameInfo.Moves = 0;
				GameInfo.Turned = 0;
				break;
			case 3: 
				Application.LoadLevel(0);
				break;
			case 4: 
				Application.LoadLevel(1);
				break;
			}
			
		}
	}
}
