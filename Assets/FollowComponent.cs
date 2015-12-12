using UnityEngine;
using System.Collections;

public class FollowComponent : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
    }

    void Update()
    {
        GetComponent<Transform>().position = target.position + offset;
    }
}
