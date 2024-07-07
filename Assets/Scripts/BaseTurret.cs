using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public GameObject[] allEnemise;
    public GameObject nearestEnemy;
    public GameObject target;

    public Transform pathToRotate;

    public float range = 10f;

    private float minDistance = float.MaxValue;
    public float timer = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Debug.Log(minDistance);
        if (timer <= 0)
        {
            allEnemise = GameObject.FindGameObjectsWithTag("Enemy");
            minDistance = float.MaxValue;
            nearestEnemy = null;
            for (int i = 0; i < allEnemise.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, allEnemise[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = allEnemise[i];
                }
            }
            if (minDistance < range)
            {
                target = nearestEnemy;
            }
            else
            {
                target = null;
            }
            timer = 0.25f;

            
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (target != null)
        {
            Vector3 lookDirection = target.transform.position - transform.position;
            lookDirection.y = 0f;
            pathToRotate.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
