﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Repair(int repairAmount)
    {
        this.currentHealth += repairAmount;
    }

    public bool isRepaired()
    {
        return currentHealth >= maxHealth;
    }

    public float healthPercentage()
    {
        return (float)currentHealth / (float)maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

    }
}
