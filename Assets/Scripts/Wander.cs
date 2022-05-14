using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{

    // private float timer = 0.0f;
    private bool canMove = true;

    private Vector3 birthPos;

    private WaitForSeconds waitTime;

    private bool nextMove = true;

    public float speed = 2.5f;
    public float rotateSpeed = 20.0f;

    public float upperBorder;
    public float leftBorder;

    private enum Actions
    {
        Foward,
        Rotate
    }
    private void Awake()
    {
        birthPos = transform.position;
        waitTime = new WaitForSeconds(2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > leftBorder)
        {
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * leftBorder, transform.position.y, 0);
        }

        if (Mathf.Abs(transform.position.y) > upperBorder)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y) * upperBorder, 0);
        }

        if (nextMove)
        {
            nextMove = false;
            Actions action = (Actions)Random.Range(0, System.Enum.GetNames(typeof(Actions)).Length);
            switch (action)
            {
                case Actions.Foward:
                    StartCoroutine(RandomForward());
                    break;
                case Actions.Rotate:
                    StartCoroutine(RandomRotate());
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator RandomForward()
    {
        float moveDistance = Random.Range(0.25f, 3.0f);

        while (moveDistance > 0)
        {
            if (canMove)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
                moveDistance -= speed * Time.deltaTime;
                yield return null;
            }
            else
            {
                yield return waitTime;
                canMove = true;
            }
        }

        nextMove = true;
    }

    private IEnumerator RandomRotate()
    {
        float rotateAngle = Random.Range(10.0f, 90.0f);
        float direction = Mathf.Sign(Random.Range(-1.0f, 1.0f));
        while (rotateAngle > 0)
        {
            if (canMove)
            {
                transform.Rotate(Vector3.forward * rotateSpeed * direction * Time.deltaTime, Space.Self);
                rotateAngle -= rotateSpeed * Time.deltaTime;
                yield return null;
            }
            else
            {
                yield return waitTime;
                canMove = true;
            }
        }

        nextMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canMove = false;

    }

}
