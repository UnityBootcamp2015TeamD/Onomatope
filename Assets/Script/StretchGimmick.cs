using UnityEngine;

public class StretchGimmick : MonoBehaviour, Gimmick
{
    public float speed = 0.2f;
    public float stopTime = 5f;
    private float nowTime = 0;

    private Vector3 mySize;

    private bool flag = false;

    private void Start()
    {
        mySize = this.gameObject.transform.localScale;
    }

    private void Update()
    {
        if (flag)
        {
            this.gameObject.transform.localScale = new Vector3(0, 0, speed) + mySize;
            mySize = this.gameObject.transform.localScale;

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
        GameController.Instance.RaisePopup(4, position);
    }
}

