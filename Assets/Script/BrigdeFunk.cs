using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrigdeFunk : MonoBehaviour {

	public float volume = 0.5f;
	public bool flag = false;
	public bool nearFlag = false;
    public bool crear = false;
	public float stopTime =0f;
	private float nowTime = 0;

	public float dis_vol =10f;

	public GameObject player;
    public GameObject she;

    public GameObject g;

    // Use this for initialization
    void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (flag && nearFlag)
        {
            GameObject.Find("GameController").GetComponent<GameController>().RaisePopup(3, GetComponent<Transform>().position);

            this.gameObject.transform.Rotate(0,volume,0);
			var button = GameObject.Find("OnomatopeButton_Kuru").GetComponent<Button>();

            nowTime += Time.deltaTime;
            if (nowTime >= stopTime)
            {

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
        she = GameObject.FindGameObjectWithTag("Finish"); 
		float dis = Vector3.Distance (player.transform.position, this.gameObject.transform.position);
        float dis2 = Vector3.Distance(she.transform.position, player.transform.position);

        if (dis < dis_vol) {
			nearFlag =true;

        }
        else {
			nearFlag = false;
		}

        if (dis2 < 10 && flag)
        {
            crear = true;
            g.SetActive(true);

        }else { crear = false; }

    }

}
