﻿using UnityEngine;
using System.Collections;

public class UnitCtrl : MonoBehaviour {

	[SerializeField]
	private int aFirstGridNum = 10;

	public int aWaitDirection;
	[SerializeField]
	private float mWaitDirectionInterval = 0.5f;
	private float mMinWaitInterval = 0.5f;
	private float mMaxWaitInterval = 1.0f;

	public string mUnitState;
	
	public int mTargetGridNum;
	public int mCurrentGridNum;
	
	[SerializeField]
	private float mTimeCounter;

	[SerializeField]
	private float mMeetTime = 3.0f;
	[SerializeField]
	private int mDirection;

	[SerializeField]
	private float mMoveSpeed;

	private PanickPeapleAction mPanickPeapleAction;

	public GameObject meetImg;

	// Use this for initialization
	void Start () {
		this.mTimeCounter = 0f;
		this.InitUnit(aFirstGridNum);

		this.meetImg.gameObject.SetActive (false);

		mPanickPeapleAction = this.GetComponent<PanickPeapleAction> ();

		aWaitDirection = Random.Range(Const.UP, Const.LEFT);
	}
	
	// Update is called once per frame
	void Update () {

		if (this.mUnitState == Const.USER_WAIT) {
			if (this.mTimeCounter < this.mWaitDirectionInterval) {
				mTimeCounter += Time.deltaTime;
			} else {
				aWaitDirection = Random.Range(Const.UP, Const.LEFT);
				mWaitDirectionInterval = Random.Range(Const.MEET_FAST, Const.MEET_LATE);
			}
		}

		if (this.mUnitState == Const.USER_MEET) {
			if (this.mTimeCounter < this.mMeetTime) {
				this.mTimeCounter += Time.deltaTime;
			}else{
				this.mTimeCounter = 0f;
				this.ActMove();
			}
		}
	}

	private void InitUnit(int iInitGrid){
		this.mUnitState = Const.USER_WAIT;
		this.mCurrentGridNum = iInitGrid;
		this.mTimeCounter = 0f;
	}

	#region ChangeState
	public void ActWait(){
		this.mUnitState = Const.USER_WAIT;
		this.mTimeCounter = 0f;
		this.mPanickPeapleAction.IndexAngle = 5;

		this.meetImg.gameObject.SetActive (false);
	}

	public void ActMeet(float iMeetingTime, int iDirection, int iTargetGridNum){
		this.mUnitState = Const.USER_MEET;
		this.mTimeCounter = 0f;

		this.mMeetTime = iMeetingTime;
		this.mDirection = iDirection;
		this.mTargetGridNum = iTargetGridNum;

		this.meetImg.gameObject.SetActive (true);
	}

	public void ActMove(){
		this.mUnitState = Const.USER_MOVE;
		this.mTimeCounter = 0f;

		this.mPanickPeapleAction.IndexAngle = mDirection;

		this.mCurrentGridNum = this.mTargetGridNum;
		this.GetComponent<UnitMove>().move(mDirection);
		Debug.Log ("move start");

		this.meetImg.gameObject.SetActive (false);
	}
	#endregion
	
//	public void ActUnit(float iMeetTime, int iDirection){
//		Debug.Log (iDirection);
//		if (this.mUnitState == Const.USER_WAIT) {
//			this.mMeetTime	= iMeetTime;
//			this.mDirection = iDirection;
//			this.ActMeet();
//		}
//	}

	#region KillUnit
	public void Destroy(){
		//DestroyAnimation
		StartCoroutine ("DestroyAnim");
		Debug.Log("destroy destroy");
	}
	private IEnumerator DestroyAnim(){
		Destroy (this.gameObject);
		yield return new WaitForSeconds(0.1f);
	}
	#endregion
}