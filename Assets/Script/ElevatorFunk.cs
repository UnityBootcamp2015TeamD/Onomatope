using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ElevatorFunk : MonoBehaviour {

	public bool  flag	 = false;
	public float speed 	 = 0.2f;
	public float stopTime =0f;
	private float nowTime = 0;
	public bool  nearFlag= false; 

	public float dis_vol =10f;

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (flag && nearFlag) {

            GameObject.Find("GameController").GetComponent<GameController>().RaisePopup(2, GetComponent<Transform>().position);

            this.gameObject.transform.Translate(0,speed,0);

			nowTime += Time.deltaTime;
			
			if(nowTime >= stopTime){
				var button = GameObject.Find("OnomatopeButton_Ween").GetComponent<Button>();
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
		Debug.Log (dis);
		if (dis < dis_vol) {
			nearFlag = true;
        }
        else {
			nearFlag = false;
		}
		
	}

}
