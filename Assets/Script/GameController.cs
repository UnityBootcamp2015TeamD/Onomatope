using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : SingletonMonoBehaviour<GameController>
{
    private int popupCounter = 0;

    public GameObject cube1;
    public GameObject gotonPopup;
    public GameObject wiinPopup;
    public GameObject kuruPopup;
    public GameObject biyonPopup;
    public Transform playerTransform;

    /// <summary>
    /// Find nearest gimmick from Player
    /// </summary>
    /// <param name="distanceMax">Upper bounds of distance</param>
    /// <returns>nearest object or null</returns>
    private GameObject FindNearestGimmick(float distanceMax)
    {
        GameObject result = null;
        var currentDistance = float.MaxValue;

        var gimmicks = GameObject.FindGameObjectsWithTag("GimmickObject");
        var player = GameObject.FindGameObjectWithTag("Player");

        var playerPosition = player.GetComponent<Transform>().position;
        foreach (var gimmick in gimmicks)
        {
            var gimmickPosition = gimmick.GetComponent<Transform>().position;
            var distance = (playerPosition - gimmickPosition).magnitude;
            if (distance < currentDistance && distance < distanceMax)
            {
                currentDistance = distance;
                result = gimmick;
            }
        }

        return result;
    }

    private void DisableOnomatopeButton(string onomatope)
    {
        var targetButton = GameObject
            .FindGameObjectsWithTag("OnomatopeButton")
            .Where(button => button.GetComponentInChildren<Text>().text == onomatope)
            .First();
        targetButton.GetComponent<Button>().interactable = false;
    }

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

    public void OnOnomatopeClicked(string onomatope)
    {
        var nearest = FindNearestGimmick(3);
        if (nearest == null) return;

        switch (onomatope)
        {
            case "ゴトッ":
                var gimmick = nearest.GetComponent<FallflatGimmick>();
                if (gimmick == null) return;
                gimmick.ExecuteFallflat();
                DisableOnomatopeButton(onomatope);
                break;
        }
    }
}
