using UnityEngine;
using System.Collections;

public class GridCtrl : MonoBehaviour {

	private enum GRUID_STATES{
		NONE,
		NORMAL,
		NOT_PASS,
		DEAD_ZONE
	}

	private GRUID_STATES currentState;
	private GRUID_STATES nextState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		switch (currentState) {
			case GRUID_STATES.NORMAL:
				break;
			case GRUID_STATES.DEAD_ZONE:
				break;
			case GRUID_STATES.NOT_PASS:
				break;
		}


		if (nextState != GRUID_STATES.NONE) {
			switch(nextState){
			case GRUID_STATES.NORMAL:
				break;
			case GRUID_STATES.DEAD_ZONE:
				break;
			case GRUID_STATES.NOT_PASS:
				break;
			}
		}


		switch (currentState) {
			case GRUID_STATES.NORMAL:
				break;
			case GRUID_STATES.DEAD_ZONE:
				break;
			case GRUID_STATES.NOT_PASS:
				break;
		}


	}

}
