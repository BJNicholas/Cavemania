using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public GameObject target;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (target.transform.position.y < transform.position.y)
        {
            transform.position = new Vector3(0, target.transform.position.y, -10);
        }
    }
}
