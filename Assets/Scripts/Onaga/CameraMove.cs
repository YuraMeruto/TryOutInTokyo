using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private const float moveSpeed = 0.01f;
    private float moveinterval = 0.0f;
    Vector3 cameraPosition;
    void Start()
    {
        cameraPosition = transform.position;
    }

    void Update()
    {
        moveinterval += Time.deltaTime;
        //if (moveinterval > 1.0f)
        //{
            cameraPosition.x += moveSpeed;
            transform.position = cameraPosition;

            moveinterval = 0.0f;
        //}
    }
}
