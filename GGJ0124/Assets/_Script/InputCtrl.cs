using UnityEngine;
using System.Collections;

public class InputCtrl : MonoBehaviour {

	public UnitMgr aUnitMng;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			Debug.Log("UpArrow");
			this.aUnitMng.SayUnits(Const.UP);
		}
		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			Debug.Log("DownArrow");
			this.aUnitMng.SayUnits(Const.DOWN);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			Debug.Log("LeftArrow");
			this.aUnitMng.SayUnits(Const.LEFT);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			Debug.Log("RightArrow");
			this.aUnitMng.SayUnits(Const.RIGHT);
		}
	}
}
