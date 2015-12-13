using UnityEngine;
using UnityEngine.UI;

public class ElevatorGimmick : MonoBehaviour, Gimmick
{
    public bool flag = false;
    public float speed = 0.2f;
    public float stopTime = 0f;
    private float nowTime = 0;

    void Update()
    {
        if (flag)
        {
            this.gameObject.transform.Translate(0, speed, 0);

            nowTime += Time.deltaTime;

            if (nowTime >= stopTime)
            {
                flag = false;
            }
        }
    }

    public void Execute()
    {
        flag = true;
        var position = GetComponent<Transform>().position + new Vector3(0, 2, 0);
        GameController.Instance.RaisePopup(2, position);
    }
}
