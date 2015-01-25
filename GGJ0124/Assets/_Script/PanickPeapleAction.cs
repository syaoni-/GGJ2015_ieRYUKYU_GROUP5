using UnityEngine;
using System.Collections;

public class PanickPeapleAction : MonoBehaviour {
    SpriteRenderer MainSpriteRenderer;
    private Sprite WhachRight;
    private Sprite WhachLeft;
    private Sprite WhachAhead;
    private Sprite WhachBack;
    private float WhachInterval = 0.0f;
    private float NextPeapleWhachTime = 0.0f;
    private int IndexAngle = 5;
    private Animator _anim;

	// Use this for initialization
	void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        WhachRight = Resources.Load<Sprite>("img/stage_04");
        WhachLeft = Resources.Load<Sprite>("img/stage_05");
        WhachAhead = Resources.Load<Sprite>("img/stage_02");
        WhachBack = Resources.Load<Sprite>("img/stage_03");
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        NextPeapleWhachTime += Time.deltaTime;
        
        if (IndexAngle == 3) {
            transform.Translate (transform.up * 1.9f * Time.deltaTime);
            _anim.Play ("Back");
        } else if (IndexAngle == 0) {
            transform.Translate (transform.up * -1.9f * Time.deltaTime);
            _anim.Play ("Ahead");
        } else if (IndexAngle == 1) {
            transform.Translate (transform.right * 1.9f * Time.deltaTime);
            _anim.Play ("Right");
        } else if (IndexAngle == 2) {
            transform.Translate (transform.right * -1.9f * Time.deltaTime);
            _anim.Play ("Left");
        } else {
            Panick ();
        }

        if (NextPeapleWhachTime > 1.0f) {
            IndexAngle = Random.Range(0, 5);
            UpdateWhach (IndexAngle);
            NextPeapleWhachTime = 0;
        }
	}

    private void UpdateWhach(int ChangeWhach){
        if (ChangeWhach == 0) {
            MainSpriteRenderer.sprite = WhachAhead;
            //_anim.Play ("Ahead");
        } else if (ChangeWhach == 1) {
            MainSpriteRenderer.sprite = WhachRight;
            //_anim.Play ("Right");
        } else if (ChangeWhach == 2) {
            MainSpriteRenderer.sprite = WhachLeft;
            //_anim.Play ("Left");
        } else if (ChangeWhach == 3) {
            MainSpriteRenderer.sprite = WhachBack;
            //_anim.Play ("Back");
        }

        //Debug.Log (ChangeWhach);
        //GetComponent<Animator>().SetInteger("IndexAngle",ChangeWhach);
    }

    private void Panick() {
        StartCoroutine("PanickMovement");
    }

    private IEnumerator PanickMovement() {
        _anim.Play("Panick");
        yield return new WaitForSeconds (2);
        yield return null;
    }
}