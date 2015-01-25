using UnityEngine;
using System.Collections;

public class CursorCtrl : MonoBehaviour {

	private float mGunShotTime;
	private float mTime;
	private float mHeight = 10.0f;

	public void launch(float iTime){

		mGunShotTime = iTime;
		StartCoroutine("forwardRocket");
	}
	
	private IEnumerator forwardRocket(){
		float iTime = 0.0f;
		
		while (true) {
			iTime += Time.deltaTime;
			if (iTime > mGunShotTime) {
				break;
			}
			
			yield return null;
		}
		Instantiate(Resources.Load("Prefab/RocketExplode"), this.transform.position, Quaternion.identity);
		Object.Destroy(this.gameObject);
	}


}
