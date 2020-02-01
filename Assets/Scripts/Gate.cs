using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 50;

    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public GameObject gateRallyPoint;
    //public Texture2D progressBarEmpty;
    //public Texture2D progressBarFull;

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
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
