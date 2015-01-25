using UnityEngine;
using System.Collections;

public class RocketMgr : MonoBehaviour {

	private const int MAX_ROCKET = 3;
	private float intervalLaunch;
	private float mTime;

	private GameObject Rocket;
	private GameObject Cursor;

	public GridManager gridMgr;

	private enum STATE{
		NONE,
		LEADY,
		LAUNCH
	}
	private STATE currentState;
	private STATE nextState;

	// Use this for initialization
	void Start () {
		intervalLaunch = Random.Range(Const.LAUNCH_FAST, Const.LAUNCH_LATE);
		Rocket = Resources.Load("Prefab/Rocket") as GameObject;
		Cursor = Resources.Load("Prefab/Cursor") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		switch (currentState) {
		case STATE.LEADY:
			mTime += Time.deltaTime;
			if (mTime > intervalLaunch) {
				nextState = STATE.LAUNCH;
			}
			break;
		case STATE.LAUNCH:
			break;
		}

		if (nextState == STATE.NONE) {
			switch (nextState) {
			case STATE.LEADY:
				break;
			case STATE.LAUNCH:

				break;
			}
		}


		switch(currentState) {
		case STATE.LEADY:
			break;
		case STATE.LAUNCH:
			break;
		}
	}


	void RocketLaunch(int gridNum){
		GridCtrl targerGrid = this.gameObject.GetComponent<GridManager>().grids[gridNum] as GridCtrl;
		GameObject newRocket = Instantiate(Rocket, targerGrid.originPos, Quaternion.identity) as GameObject;
		GameObject newCursor = Instantiate(Cursor, targerGrid.originPos, Quaternion.identity) as GameObject;
	}
}
