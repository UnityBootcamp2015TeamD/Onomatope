using UnityEngine;

public class RotationGimmick : MonoBehaviour, Gimmick
{
    private bool flag = false;

    public Vector3 axis = new Vector3(0, 1, 0);
    public float rotation = 90f;
    public float speed = 0.5f;

    public bool Executed { get; private set; }
    public float CurrentAngle { get; private set; }

    private void Start()
    {
        CurrentAngle = 0;
    }

    private void Update()
    {
        if (flag)
        {
            CurrentAngle += speed;
            gameObject.transform.rotation = Quaternion.Euler(axis * CurrentAngle);
            if (CurrentAngle >= rotation)
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
