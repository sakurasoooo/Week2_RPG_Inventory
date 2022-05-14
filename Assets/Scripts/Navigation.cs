using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public float speed = 2.0f;
    public float naviRadius = 6.0f;

    public bool canMove = true;
    public LayerMask naviLayer;
    private Transform lastStartPosition;
    private Transform lastDestinatePosition;
    private Transform destination = null;

    private Collider2D[] naivPoints;

    private WaitForSeconds waitTime;

    // private Vector3 direction = Vector3.zero;
    private void Awake()
    {
        lastStartPosition = transform;
        lastDestinatePosition = transform;
        waitTime = new WaitForSeconds(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            Move();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, naviRadius);
    }
    void Move()
    {
        // find new destination
        if (destination == null)
        {
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            naivPoints = Physics2D.OverlapCircleAll(position, naviRadius, naviLayer);

            float minDistance = 9999.0f;
            for (int i = 0; i < naivPoints.Length; i++)
            {
                float distance = Vector2.Distance(transform.position, naivPoints[i].transform.position);
                // get nearest navi-point
                if (minDistance > distance && distance > 0.1f && Vector2.Distance(naivPoints[i].transform.position, lastStartPosition.position) > 0.1f)
                {
                    
                    minDistance = distance;
                
                    destination = naivPoints[i].transform;
                }
            }


            lastStartPosition = lastDestinatePosition; // backup destination
            destination = destination ??= transform;

        }
        //move
        Vector3 direction = GetDirection(destination.position, transform.position);
        if (Vector2.Distance(transform.position, destination.position) >= 0.1f)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            lastDestinatePosition = destination;
            destination = null; // reset
        }

    }
    Vector3 GetDirection(Vector3 des, Vector3 pos)
    {
        Vector3 direction = destination.position - transform.position;
        Vector2 Direction2d = new Vector2(direction.x, direction.y).normalized;

        return Direction2d;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Don't call when timer stopped
        if(canMove)
        {
            StartCoroutine(Wait());
        }
        canMove = false;

    }

    private IEnumerator Wait()
    {
        yield return waitTime;
        canMove = true;
    }
}
