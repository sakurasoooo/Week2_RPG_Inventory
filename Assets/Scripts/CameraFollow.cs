using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float BoundX = 1.0f;
    public float BoundY = 1.0f;
    private Vector2 velocity = Vector2.zero;
    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector2.SmoothDamp(transform.position, target.position, ref velocity, 0.5f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
        }

        if (Mathf.Abs(transform.position.x) > BoundX)
        {
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * BoundX, transform.position.y, -10.0f);
        }

        if (Mathf.Abs(transform.position.y) > BoundY)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y) * BoundY, -10.0f);
        }
    }
}
