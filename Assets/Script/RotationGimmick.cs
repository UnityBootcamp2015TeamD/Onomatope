using UnityEngine;

public class RotationGimmick : MonoBehaviour, Gimmick
{
    public float volume = 0.5f;
    public bool flag = false;
    public float stopTime = 0f;
    private float nowTime = 0;

    public bool Executed { get; private set; }

    void Update()
    {
        if (flag)
        {
            this.gameObject.transform.Rotate(0, volume, 0);
            nowTime += Time.deltaTime;
            if (nowTime >= stopTime)
            {
                flag = false;
                Executed = true;
            }
        }
    }

    public void Execute()
    {
        flag = true;
        var position = GetComponent<Transform>().position + new Vector3(0, 2, 0);
        GameController.Instance.RaisePopup(3, position);
    }
}
