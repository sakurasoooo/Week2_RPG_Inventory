using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{

    private float timer = 0.0f;
    private bool timerStopped = false;

    private Vector3 birthPos;

    private WaitForSeconds waitTime;

    public float speed = 5.0f;
    private void Awake()
    {
        birthPos = transform.position;
        waitTime = new WaitForSeconds(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStopped)
        {
            timer += speed * Time.deltaTime;
        }

        Move();
    }

    private void Move()
    {
        float x = birthPos.x + Mathf.PingPong(timer * 0.1f, 2) - 4.0f;;
        float y = birthPos.y + Mathf.PingPong(timer * 0.5f, 20) - 10.0f;
        float z = birthPos.z;
        transform.position = new Vector3(x, y, z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Don't call when timer stopped
        if(!timerStopped)
        {
            StartCoroutine(Wait());
        }
        timerStopped = true;

    }

    private IEnumerator Wait()
    {
        yield return waitTime;
        timerStopped = false;
    }
}
