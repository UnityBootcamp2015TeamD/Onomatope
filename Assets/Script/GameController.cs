using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : SingletonMonoBehaviour<GameController>
{
    private int popupCounter = 0;

    public GameObject gotonPopup;
    public GameObject wiinPopup;
    public GameObject kuruPopup;
    public GameObject biyonPopup;
    public GameObject patiPopup;

    public GameObject girlfriend;

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

        // clear check
        if (girlfriend.GetComponent<RotationGimmick>().Executed)
        {
            patiPopup.SetActive(true);
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
                biyonPopup.GetComponent<Transform>().position = position;
                biyonPopup.SetActive(true);
                break;

        }
        popupCounter = 1;
    }

    public void OnOnomatopeClicked(string onomatope)
    {
        var nearest = FindNearestGimmick(5);
        if (nearest == null) return;

        Gimmick gimmick = null;

        // ここでクリックされた擬音語とギミックを対応づけている
        switch (onomatope)
        {
            case "ゴトッ":
                gimmick = nearest.GetComponent<FallflatGimmick>();
                break;
            case "ビヨーン":
                gimmick = nearest.GetComponent<StretchGimmick>();
                break;
            case "クルッ":
                gimmick = nearest.GetComponent<RotationGimmick>();
                break;
            case "ウィーン":
                gimmick = nearest.GetComponent<ElevatorGimmick>();
                break;
        }

        if (gimmick == null) return;
        gimmick.Execute();
        DisableOnomatopeButton(onomatope);
    }
}
