using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject cube1;
    public GameObject gotonPopup;
    public GameObject wiinPopup;
    public GameObject kuruPopup;
    public GameObject biyonPopup;
    public Transform playerTransform;

    private int popupCounter = 0;

    // Use this for initialization
    void Start()
    {
        cube1 = GameObject.Find("Cube1");
    }

    // Update is called once per frame
    void Update()
    {
        if (popupCounter > 0)
        {
            popupCounter++;
            if (popupCounter > 40)
            {
                gotonPopup.SetActive(false);
                wiinPopup.SetActive(false);
                kuruPopup.SetActive(false);
                biyonPopup.SetActive(false);
                popupCounter = 0;
            }
        }
    }

    public void RaisePopup(int code, Vector3 position)
    {
        var offset = new Vector3(0, 1, 0);
        switch (code)
        {
            case 1:
                gotonPopup.GetComponent<Transform>().position = position + offset;
                gotonPopup.SetActive(true);
                break;
            case 2:
                wiinPopup.GetComponent<Transform>().position = position + new Vector3(0, 2, 0);
                wiinPopup.SetActive(true);
                break;
            case 3:
                kuruPopup.GetComponent<Transform>().position = position + offset;
                kuruPopup.SetActive(true);
                break;
            case 4:
                biyonPopup.GetComponent<Transform>().position = position + new Vector3(0, 2, 0);
                biyonPopup.SetActive(true);
                break;

        }
        popupCounter = 1;
    }

    public void OnOnomatopeClicked(int code)
    {
        if (code == 1)
        {
            var player = GameObject.Find("Player");
            var target = GameObject.Find("Cube1");
            var distance = player.GetComponent<Rigidbody>().position - target.GetComponent<Rigidbody>().position;

            Debug.Log(distance.magnitude);
            if (distance.magnitude < 2)
            {
                var rigid = cube1.GetComponent<Rigidbody>();
                rigid.AddForceAtPosition(new Vector3(1000, 0, 0), rigid.position);

                var button = GameObject.Find("OnomatopeButton1").GetComponent<Button>();
                button.interactable = false;

                RaisePopup(1, rigid.position);
            }
        }
    }
}
