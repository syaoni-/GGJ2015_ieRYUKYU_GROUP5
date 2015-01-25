using UnityEngine;
using System.Collections;

public class MissileLaunchar : MonoBehaviour {
    private float interval = 2.0f;
    private float NextMissileCreateTime = 0.0f;
	private int XGrid;
	private int YGrid;
	private int GridNumber;
    private float xGrid;
    private float yGrid;
    private float xGridRangs = 1.9f;
    private float yGridRangs = 1.9f;
    private float yGridConstStart = 1.4f;
    private float AllTime = 0.0f;
    private float MissileSpeed = 0.1f;

	public AudioClip TargetClip;
	AudioSource TargetSource;

	public AudioClip TargetClip_T;
	AudioSource TargetSource_T;
	public AudioClip TargetClip_R;
	AudioSource TargetSource_R;

	public AudioClip PlayBGMClip_Game;
	public AudioClip PlayBGMClip_Title;
	public AudioClip PlayBGMClip_Result;
	AudioSource PlayBGMSource_Game;
	AudioSource PlayBGMSource_Title;
	AudioSource PlayBGMSource_Result;

	private int flag = 0;

	// Use this for initialization
    void Start () {
		//target
		TargetSource = gameObject.GetComponent<AudioSource>();
		TargetSource.clip = TargetClip;

		//TITLE BGM
		TargetSource_T = gameObject.GetComponent<AudioSource>();
		TargetSource_T.clip = TargetClip_T;
		//RESULT BGM
		TargetSource_R = gameObject.GetComponent<AudioSource>();
		TargetSource_R.clip = TargetClip_R;

		//BGM
		PlayBGMSource_Game = gameObject.GetComponent<AudioSource>();
		PlayBGMSource_Game.clip = PlayBGMClip_Game;

		//title bgm start
		TargetSource_T.PlayOneShot(TargetClip_T);
	}
	
	// Update is called once per frame
	void Update() {

		if (flag == 0)
		{
			// GAME START
			if (Input.GetMouseButtonDown( 0 ) )
			{
				StartView();
				PlayBGMSource_Game.Play();
			}

			return;
		}


		XGrid = Random.Range (-3, 4);
		YGrid = Random.Range (-4, 0);
		GridNumber = XGrid - (YGrid + 1)* 8 + 3;
		xGrid = (float)XGrid * xGridRangs;
        yGrid = (float)YGrid * yGridRangs;
        NextMissileCreateTime += Time.deltaTime;
        AllTime += Time.deltaTime;
		Debug.Log (GridNumber);
        if (NextMissileCreateTime > interval) {
			//Target apper
            //Debug.Log(transform.position.x + (float)xGrid);
            GameObject MissileType = Instantiate (Resources.Load("Prefab/MissilePrefab"), new Vector3(transform.position.x + xGrid, transform.position.y + yGrid - yGridConstStart, transform.position.z) ,Quaternion.identity) as GameObject;
			TargetSource.PlayOneShot(TargetClip);
			MissileType.GetComponent<MissileAction>().launch(MissileSpeed);
            //Instantiate (Resources.Load("Prefab/CursorPrefab"), new Vector3(transform.position.x + xGrid, transform.position.y + yGrid - yGridConstStart, transform.position.z) ,Quaternion.AngleAxis(-180,-Vector3.forward));
            NextMissileCreateTime = 0;
			//GameOver();
        }

        if (AllTime > 10.0f) {
            MissileSpeed += 0.1f;
            interval -= 0.1f;
            AllTime = 0;
        }
	}

	private void StartView() {
		//Debug.Log (GameObject.Find ("start"));
		Destroy(GameObject.Find("start"));
		flag++;
	}

	public void GameOver() {
		// stop bgm
		PlayBGMSource_Game.Stop ();
		//result bgm start
		TargetSource_R.PlayOneShot(TargetClip_R);

		GameObject end = GameObject.Find ("result");
		var pos = end.transform.position;
		pos.y -= 10;
		end.transform.position = pos;
		Time.timeScale = 0;
	}

}
