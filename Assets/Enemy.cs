﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int attackStrength;

    public void takeDamage(int attack)
    {
        Health -= attack;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
