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

	public Vector2 originPos;
	public int ID;

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


	public int Cross(int gridId, int currentDirection){

		if (0 <= gridId && gridId < Const.COL && currentDirection == Const.UP) {
			return gridId;
		}

		if (gridId % Const.COL == 0 && currentDirection == Const.LEFT) {
			return gridId;
		}


		if (Const.ROW * Const.COL - Const.COL <= gridId && gridId < Const.ROW * Const.COL) {
			return gridId;
		}

		if (gridId % Const.COL == Const.COL - 1 && currentDirection == Const.RIGHT) {
			return gridId;
		}


		do {
			if (currentDirection == Const.DOWN) {
				return gridId + Const.COL;
			}
			if (currentDirection == Const.UP) {
				return gridId - Const.COL;
			}
			if (currentDirection == Const.LEFT) {
				return gridId - 1;
			}
			if (currentDirection == Const.RIGHT) {
				return gridId + 1;
			}
		} while(false);

		return gridId;
	}

}
