using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StretchGimmick : MonoBehaviour {

	public bool flag = false;
	public bool nearFlag = false;

	public float speed=0.2f;
	public float stopTime=5f;
	private float nowTime = 0;

	public float dis_vol =10f;

	public GameObject player;

	private Vector3 mySize;
	// Use this for initialization
	void Start () {
		mySize = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (flag && nearFlag)
        {
            GameObject.Find("GameController").GetComponent<GameController>().RaisePopup(4, GetComponent<Transform>().position);

            this.gameObject.transform.localScale = new Vector3(0,0,speed) + mySize;
			mySize = this.gameObject.transform.localScale;

			nowTime += Time.deltaTime;

			if(nowTime >= stopTime){

				var button = GameObject.Find("OnomatopeButton_byon").GetComponent<Button>();
				button.interactable = false;
				flag = false;
			}
		}
		nearPlayer ();
		
	}
	
	public void OnClick(){
		flag = true;
    }

    public void nearPlayer(){

		player = GameObject.FindGameObjectWithTag ("Player");
		float dis = Vector3.Distance (player.transform.position, this.gameObject.transform.position);

		if (dis < dis_vol) {
			nearFlag = true;
        }
        else {
			nearFlag = false;
		}
	}
}

