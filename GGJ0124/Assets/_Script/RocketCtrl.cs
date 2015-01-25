using UnityEngine;
using System.Collections;

public class RocketCtrl : MonoBehaviour {

	private float mGunShotTime;
	private float mHeight = 10.0f;

	private GameObject explode;

	private void Start(){
		this.transform.Translate(Vector3.up * mHeight);
		mGunShotTime = 2.0f;
		
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
