using UnityEngine;
using System.Collections;

public class RocketExplodeCtrl : MonoBehaviour {

	private float aTime;
	private float aDeleteTime = 1.0f;

	// Update is called once per frame
	void Update () {
		aTime += Time.deltaTime;
		if (aTime > aDeleteTime)
			Object.Destroy(this.gameObject);
	}
}
