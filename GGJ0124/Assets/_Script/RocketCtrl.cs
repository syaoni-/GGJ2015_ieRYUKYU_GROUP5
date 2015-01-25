using UnityEngine;
using System.Collections;

public class RocketCtrl : MonoBehaviour {

	private float mGunShotTime;
	private float mTime;
	private float mHeight = 10.0f;

	private GameObject explode;

	public void launch(float iTime){

		this.transform.Translate(Vector3.up * mHeight);

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

			this.transform.Translate(-Vector3.up * mGunShotTime / mHeight);
			yield return null;
		}
		Instantiate(Resources.Load("Prefab/RocketExplode"), this.transform.position, Quaternion.identity);
		Object.Destroy(this.gameObject);
	}
}
