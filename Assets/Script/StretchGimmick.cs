using UnityEngine;

public class StretchGimmick : MonoBehaviour, Gimmick
{
    private Vector3 stretchDirection = new Vector3(0, 0, 1);
    private Vector3 originalSize;
    private bool flag = false;

    public float speed = 0.2f;
    public float stretchSize = 5f;

    public Vector3 CurrentSize { get; private set; }

    private void Start()
    {
        CurrentSize = gameObject.transform.localScale;
        originalSize = CurrentSize;
    }

    private void Update()
    {
        if (flag)
        {
            CurrentSize += stretchDirection * speed;
            gameObject.transform.localScale = CurrentSize;

            if (CurrentSize.z - originalSize.z >= stretchSize)
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

