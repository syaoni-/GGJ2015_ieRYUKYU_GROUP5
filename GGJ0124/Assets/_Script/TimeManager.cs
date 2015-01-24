using UnityEngine;
using System.Collections;

public class TimeManager : SingletonMonoBehaviour<TimeManager> {

	public void Awake()
	{
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}

	float TOTAL_TIME = 0.0f;
	
	// Update is called once per frame
	void Update () {
		TOTAL_TIME += Time.deltaTime;
	}
}
