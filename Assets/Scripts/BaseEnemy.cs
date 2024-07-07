using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float maxHP;
    public Image hpBar;

    public Transform[] wayPoints;
    private int currentWaypointIndex = 0;
    private float hp;

    // Start is called before the first frame update
    public void SetupEnemy(Transform[] waypointInput)
    {
        wayPoints = waypointInput;
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaypointIndex + 1 == wayPoints.Length)
        {
            //TODO -life
            //TODO -enemy in scene count
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

    public void TakeDamage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / maxHP;

        if (hp <= 0)
        {
            //TODO +gold
            //TODO - enemy in scene count

            Destroy(gameObject);
            return;
        }
    }
}
