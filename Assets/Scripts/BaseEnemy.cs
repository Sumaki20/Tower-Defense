using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Transform[] wayPoint;
    private int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = wayPoint[currentWaypointIndex + 1].position - transform.position;

        if(moveDirection.magnitude <= moveSpeed * Time.deltaTime)
        {
            currentWaypointIndex++;
            transform.position = wayPoint[currentWaypointIndex].position;
        }
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime,Space.World);
        Debug.Log(moveDirection.magnitude);
    }
}
