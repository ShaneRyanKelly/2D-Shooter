using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboScript : MonoBehaviour
{
    public int enemyTimer;
    public EnemyScript enemy;
    private int enemyCountdown;
    // Start is called before the first frame update
    void Start()
    {
        enemyCountdown = enemyTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCountdown--;
        if (enemyCountdown < 0)
        {
            Vector3 enemyPosition = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
            Instantiate(enemy, enemyPosition, new Quaternion(0,0,0,0));
            enemyCountdown = enemyTimer;
        }
    }
}
