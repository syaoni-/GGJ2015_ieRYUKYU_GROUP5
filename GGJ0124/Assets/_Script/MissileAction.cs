using UnityEngine;
using System.Collections;

public class MissileAction : MonoBehaviour {
	private GameObject MissileObj;
	public AudioClip ShootClip;
	AudioSource ShootSource;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MissileObj = this.transform.FindChild("Missile").gameObject;
		ShootSource = gameObject.GetComponent<AudioSource>();
		ShootSource.clip = ShootClip;
	}

    public void launch(float speed){
        StartCoroutine("MissileMovement",speed);
    }

    private IEnumerator MissileMovement(float speed){
        yield return new WaitForSeconds(2);
        while(true){
            MissileObj.transform.Translate(transform.up * - speed);

            if (MissileObj.transform.localPosition.y < 1.0f) {
				ShootSource.PlayOneShot(ShootClip);
                break;
            }
            
            yield return null;
        }
        GameObject ExplosionObj = Instantiate (Resources.Load ("Prefab/Explosion"), this.gameObject.transform.position, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        Destroy(ExplosionObj.gameObject);
        yield return null;
    }
}
