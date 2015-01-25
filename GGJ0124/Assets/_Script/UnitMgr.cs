using UnityEngine;
//using System;
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

//	private checkGameOver(){
//		foreach ( in aGridCenter) {
//
//		}
//	}


	/// <summary>
	/// Say Move the units.
	/// </summary>
	/// <param name="iDirection">I direction.</param>
	public void SayUnits(int iDirection){
		Transform aUnitMngTrans = this.gameObject.transform;

//		foreach(Transform child in aUnitMngTrans) {
//			child.gameObject.GetComponent<UnitCtrl>().ActUnit(1.0f,iDirection);
//		}

		//グリッド毎にループ.
		for (int aIndex = 0; aIndex < 28; aIndex++) {

			//グリッドの配列数取得.
			int gridAmount = 0;
			foreach(Transform child in aUnitMngTrans) {
				if (child.gameObject.GetComponent<UnitCtrl>().mCurrentGridNum == aIndex) {
					gridAmount += 1;
				}
			}

			//グリッドに所属するユニット数.
			int gridUnitArrayNum = 0;

			UnitCtrl[] aUnitCtrls = new UnitCtrl[gridAmount];
			foreach (Transform child in aUnitMngTrans) {
				if (child.gameObject.GetComponent<UnitCtrl>().mCurrentGridNum == aIndex) {
					aUnitCtrls[gridUnitArrayNum] = child.gameObject.GetComponent<UnitCtrl>();
					gridUnitArrayNum += 1;
				}
			}
			if (gridAmount != 0) {
				this.GridAmount(aUnitCtrls,aIndex,iDirection);
			}
		}

	}

	private void MeetUnits (UnitCtrl[] iUnitCtrls, int iDirection, float iMeetingTime, int iGridNum){
		foreach (UnitCtrl unitCtrl in iUnitCtrls) {
			unitCtrl.ActMeet(iMeetingTime,iDirection,iGridNum);
		}
	}

	private void GridAmount(UnitCtrl[] iUnitCtrls, int iGridNum, int iDirection){
		int nextGridNum = this.gameObject.GetComponent<GridCtrl> ().Cross (iGridNum, iDirection);
		if (nextGridNum == iGridNum) {
			return;
		}

		ArrayList aCountArray = new ArrayList();
		int aUpCount = 0;
		int aDownCount = 0;
		int aRightCount = 0;
		int aLeftCount = 0;

		ArrayList aRanking = new ArrayList ();

//		int aFirst;
//		int aSecond;
//		int aThird;
//		int aForth;

		for (int aIndex = 0; aIndex < aUnitNum; aIndex++) {
			if (iUnitCtrls[aIndex].mUnitState == Const.USER_WAIT) {
				if (iUnitCtrls[aIndex].aWaitDirection == Const.UP) {
					aUpCount += 1;
				} else if (iUnitCtrls[aIndex].aWaitDirection == Const.DOWN){
					aDownCount += 1;
				} else if (iUnitCtrls[aIndex].aWaitDirection == Const.RIGHT){
					aRightCount += 1;
				} else if (iUnitCtrls[aIndex].aWaitDirection == Const.LEFT){
					aLeftCount += 1;
				}
			}

		}

		//TODO Check Each Number.
		aCountArray.Add (aUpCount);
		aCountArray.Add (aDownCount);
		aCountArray.Add (aRightCount);
		aCountArray.Add (aLeftCount);
		aCountArray.Sort ();

		//
		for (int aIndex = 0; aIndex < 4; aIndex++) {
			if (aUpCount == int.Parse(aCountArray[aIndex].ToString())) {
				aRanking.Add(Const.UP);
			} else if (aDownCount == int.Parse(aCountArray[aIndex].ToString())){
				aRanking.Add(Const.DOWN);
			} else if (aRightCount == int.Parse(aCountArray[aIndex].ToString())){
				aRanking.Add(Const.RIGHT);
			} else if (aLeftCount == int.Parse(aCountArray[aIndex].ToString())){
				aRanking.Add(Const.LEFT);
			}
		}
		//TODO Decide Group Acting.
		int aDirectionRank = 0;

		for (int aIndex = 0; aIndex < 4; aIndex++) {
			if (int.Parse(aRanking[aIndex].ToString()) == iDirection) {
				aDirectionRank = aIndex;
			}
		}

		if (aDirectionRank == 0) {
			this.MeetUnits(iUnitCtrls,iDirection,Const.MEET_FAST, nextGridNum);
		} else if (aDirectionRank == 1){
			this.MeetUnits(iUnitCtrls,iDirection,Const.MEET_LATE, nextGridNum);
		} else if (aDirectionRank == 2){
			this.MeetUnits(iUnitCtrls,iDirection,Const.MEET_LATE, nextGridNum);
		} else if (aDirectionRank == 3){
			this.MeetUnits(iUnitCtrls,iDirection,Const.MEET_LATE, nextGridNum);
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
