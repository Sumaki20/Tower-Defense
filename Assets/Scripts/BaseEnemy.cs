using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Transform[] wayPoints;
    private int currentWaypointIndex = 0;
    // Start is called before the first frame update
    public void SetupEnemy(Transform[] waypointInput)
    {
        wayPoints = waypointInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaypointIndex + 1 == wayPoints.Length)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 moveDirection = wayPoints[currentWaypointIndex + 1].position - transform.position;

        if(moveDirection.magnitude <= moveSpeed * Time.deltaTime)
        {
            currentWaypointIndex++;
            transform.position = wayPoints[currentWaypointIndex].position;
        }
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime,Space.World);
        
    }
}
