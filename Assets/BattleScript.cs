using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScript : MonoBehaviour
{
    public int attackStrength;
    public Enemy currentEnemy;
    public int playerHealth;

    public void Attack()
    {
        currentEnemy.takeDamage(attackStrength);
        Debug.Log("Dealt " + attackStrength + " damage!");
        playerHealth -= currentEnemy.attackStrength;
        Debug.Log("Took " + currentEnemy.attackStrength + " damage!");
    }
    public void Escape()
    {
        int escapeNum = Random.RandomRange(0, 10);
        
        if (escapeNum > 6)
        {
            Debug.Log("Escaped");
            SceneManager.LoadScene("Game");
        }
        Debug.Log("Could Not Escape!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
