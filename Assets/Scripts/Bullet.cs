using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    
    private float damage;

    public float moveSpeed = 10f;

    public void SetUpBullet(Transform targetInput, float damageInput)
    {
        target = targetInput;
        damage = damageInput;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 moveDirection = target.position - transform.position;
        
        if(Vector3.Distance(target.position, transform.position) < moveSpeed * Time.deltaTime) //อีกแบบ moveDirection.magnitude < moveSpeed * Time.deltaTime
        {
            
            BaseEnemy be = target.GetComponent<BaseEnemy>();
            if (be != null)
            {
                be.TakeDamage(damage);
            }
            Destroy(gameObject);
            return;
        }
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime,Space.World);
    }
}
