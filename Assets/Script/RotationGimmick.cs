using UnityEngine;

public class RotationGimmick : MonoBehaviour, Gimmick
{
    private bool flag = false;
    public Vector3 originalAngle;
    public Vector3 rotatedAngle;

    public Vector3 axis = new Vector3(0, 1, 0);
    public float rotation = 90f;
    public float speed = 0.1f;

    public bool Executed { get; private set; }

    private void Start()
    {
        originalAngle = gameObject.transform.rotation.eulerAngles;
        rotatedAngle = new Vector3();
    }

    private void Update()
    {
        if (flag)
        {
            rotatedAngle += speed * axis * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(originalAngle + rotatedAngle);
            Debug.Log(Vector3.Dot(rotatedAngle, axis));
            if (Vector3.Dot(rotatedAngle, axis) >= rotation)
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
