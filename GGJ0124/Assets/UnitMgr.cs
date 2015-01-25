using UnityEngine;
using System.Collections;

public class UnitMgr : MonoBehaviour {

	public int aUnitNum;
	public UnitCtrl[] aUnitCtrl;


	//Set Grid Info
	public Transform aGridRightTop;
	public Transform aGridLeftBottom;
	public Transform aGridCenter;
	public float mGridLength;

	// Use this for initialization
	void Start () {
		this.InitUnits (aUnitNum);
		this.mGridLength = this.CalGridLength ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Say Move the units.
	/// </summary>
	/// <param name="iDirection">I direction.</param>
	public void SayUnits(int iDirection){
		Transform aUnitMngTrans = this.gameObject.transform;

		foreach(Transform child in aUnitMngTrans) {

			child.gameObject.GetComponent<UnitCtrl>().ActUnit(1.0f,iDirection);
		}
	}

	private void GridAmount(UnitCtrl[] iUnitCtrls,int iGridNum){
		for (int aIndex = 0; aIndex < aUnitNum; aIndex++) {
			if (iUnitCtrls[aIndex].aWaitDirection == Const.UP) {

			} else if (iUnitCtrls[aIndex].aWaitDirection == Const.DOWN){
				
			} else if (iUnitCtrls[aIndex].aWaitDirection == Const.RIGHT){

			} else if (iUnitCtrls[aIndex].aWaitDirection == Const.LEFT){

			}

			//TODO Check Each Number.


			//TODO Decide Group Acting.
		}
	}



	/// <summary>
	/// Inits the units.
	/// </summary>
	/// <param name="iUnitNum">I unit number.</param>
	private void InitUnits(int iUnitNum){
		//プレハブを取得.
		GameObject prefab = (GameObject)Resources.Load ("Prefab/Unit");
		aUnitCtrl = new UnitCtrl[iUnitNum];
		for (int aIndex = 0; aIndex < iUnitNum; aIndex++) {
			//プレハブからインスタンスを生成
			GameObject aGameObject = Instantiate (prefab, CalInitPos(), Quaternion.identity) as GameObject;
			aUnitCtrl[aIndex] = aGameObject.GetComponent<UnitCtrl>();
			//親設定. 
			aGameObject.transform.parent = this.gameObject.transform;
		}
	}

	/// <summary>
	/// Cals the init position.
	/// </summary>
	/// <returns>The init position.</returns>
	private Vector2 CalInitPos(){
		float maxPosX = this.aGridRightTop.position.x;
		float minPosX = this.aGridLeftBottom.position.x;
		float maxPosY = this.aGridRightTop.position.y;
		float minPosY = this.aGridLeftBottom.position.y;
		
		float oPosX = Random.Range(minPosX,maxPosX);
		Debug.Log ("InitPosX:" + oPosX);
		float oPosY = Random.Range(minPosY,maxPosY);
		Debug.Log ("InitPosY:" + oPosY);
		return new Vector2 (oPosX, oPosY);
	}
	
	/// <summary>
	/// Cals the length of the grid.
	/// </summary>
	/// <returns>The grid length.</returns>
	public float CalGridLength(){
		float aGridLength =	this.aGridRightTop.position.x - this.aGridLeftBottom.position.x;
		return aGridLength;
	}
}
