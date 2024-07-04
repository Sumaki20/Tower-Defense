using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public bool isWaveEnd = false;
    public GameObject[] enemiesWavePrefab;
    public int[] enemiesWaveCount;
    public float[] enemiesWaveDelay;
    public float[] waveDelay;

    public int currentWaveIndex = 0;

    private float timer = 0f;
    private int currentEnemiesCount = 0;

    public Transform[] wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWaveIndex == enemiesWavePrefab.Length)
        {
            isWaveEnd = true;
            return;
        }
        if(timer <= 0)
        {
            GameObject enemyObj = Instantiate(enemiesWavePrefab[currentWaveIndex], wayPoints[0].position, transform.rotation);
            BaseEnemy be = enemyObj.GetComponent<BaseEnemy>();
            
            if (be != null)
            {
                be.SetupEnemy(wayPoints);
            }
            else
            {
                Destroy(enemyObj);
            }
            currentEnemiesCount++;
            timer = enemiesWaveDelay[currentWaveIndex];

            if (currentEnemiesCount == enemiesWaveCount[currentWaveIndex])
            {
                currentEnemiesCount = 0;
                currentWaveIndex++;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
