using UnityEngine;
using System.Collections;

public class MissileLaunchar : MonoBehaviour {
    private float interval = 2.0f;
    private float NextMissileCreateTime = 0.0f;
    private float xGrid;
    private float yGrid;
    private float xGridRangs = 1.9f;
    private float yGridRangs = 1.9f;
    private float yGridConstStart = 1.4f;
    private float AllTime = 0.0f;
    private float MissileSpeed = 0.1f;
	public AudioClip TargetClip;
	AudioSource TargetSource;
	public AudioClip PlayBGMClip;
	AudioSource PlayBGMSource;

	// Use this for initialization
    void Start () {
		TargetSource = gameObject.GetComponent<AudioSource>();
		TargetSource.clip = TargetClip;
		PlayBGMSource = gameObject.GetComponent<AudioSource>();
		PlayBGMSource.clip = PlayBGMClip;
		PlayBGMSource.Play();
	}


	// Update is called once per frame
	void Update() {
        xGrid = Random.Range(-3, 4) * xGridRangs;
        yGrid = Random.Range(-4, 0) * yGridRangs;
        NextMissileCreateTime += Time.deltaTime;
        AllTime += Time.deltaTime;

        if (NextMissileCreateTime > interval) {
            //Debug.Log(transform.position.x + (float)xGrid);
            GameObject MissileType = Instantiate (Resources.Load("Prefab/MissilePrefab"), new Vector3(transform.position.x + xGrid, transform.position.y + yGrid - yGridConstStart, transform.position.z) ,Quaternion.identity) as GameObject;
			TargetSource.PlayOneShot(TargetClip);
			MissileType.GetComponent<MissileAction>().launch(MissileSpeed);
            //Instantiate (Resources.Load("Prefab/CursorPrefab"), new Vector3(transform.position.x + xGrid, transform.position.y + yGrid - yGridConstStart, transform.position.z) ,Quaternion.AngleAxis(-180,-Vector3.forward));
            NextMissileCreateTime = 0;
        }

        if (AllTime > 10.0f) {
            MissileSpeed += 0.1f;
            interval -= 0.1f;
            AllTime = 0;
        }
	}

}
