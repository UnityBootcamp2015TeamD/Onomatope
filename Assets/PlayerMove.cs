using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		this.gameObject.transform.Translate (x * speed, 0, z * speed);

	}
}
