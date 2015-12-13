using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour
{
    public float speed = 10f;

    public GameController gameController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //this.gameObject.transform.Translate(new Vector3(x * speed, 0, z * speed));
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(x * speed, 0, z * speed));
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (other.gameObject.name == "Ground")
        {
            // gameover
            Application.LoadLevel(Application.loadedLevel);
        }

        if (other.gameObject.name == "StartCube")
        {
            Debug.Log(other.impulse.magnitude);
            if (other.impulse.magnitude > 4)
            {
                var button = GameObject.Find("OnomatopeButton1").GetComponent<Button>();
                button.interactable = false;
                gameController.RaisePopup(1, GetComponent<Transform>().position);
            }
        }
    }
}
