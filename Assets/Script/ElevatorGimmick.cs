using UnityEngine;
using UnityEngine.UI;

public class ElevatorGimmick : MonoBehaviour, Gimmick
{
    private bool flag = false;
    private Vector3 currentPosition;

    public float speed = 0.2f;
    public float elevateHeight = 5f;

    private void Start()
    {
        currentPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (flag)
        {
            currentPosition.y += speed * Time.deltaTime;
            gameObject.transform.position = currentPosition;

            if (currentPosition.y >= elevateHeight)
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
