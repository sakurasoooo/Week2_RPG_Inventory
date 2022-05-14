using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFollow : MonoBehaviour
{
    [Header("Shadow")]
    public float offset = 1.5f;

    public bool advance = false;

    public Transform PosYstandard = null;

    private float stardardY = 0.0f;

    private float y = 0.0f;

    private void Awake()
    {
        if (advance && PosYstandard != null)
        {
            stardardY = PosYstandard.position.y;
            y = transform.parent.position.y - offset;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!advance)
        {
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y - offset, transform.parent.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.parent.position.x, y + (PosYstandard.position.y - stardardY), transform.parent.position.z);
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
