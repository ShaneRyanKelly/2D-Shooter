using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldScript : MonoBehaviour
{
    public int battleCountdown;
    private int battleTimeout;
    // Start is called before the first frame update
    void Start()
    {
        battleTimeout = battleCountdown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(battleTimeout + " s till battle.");
        battleTimeout -= 1;
        if (battleTimeout <= 0)
        {
            int battleChance = Random.Range(0, 100);
            if (battleChance > 66)
            {
                SceneManager.LoadScene("Battle");
            }
            battleTimeout = battleCountdown;
        }
        
    }
}
