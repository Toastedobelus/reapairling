using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public ControlScheme controls;
    public float hustle = 2f;

    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        this.controls = new IJKLControlScheme();
    }

    void FixedUpdate()
    {
        this.velocity = this.getVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        this.velocity = this.getVelocity();
        Vector3 position = this.transform.position;
        position += velocity * Time.deltaTime;
        this.transform.position = position;
        if (this.controls.checkAttack())
        {
            Debug.Log("Attack key pressed");
        }
    }

    Vector3 getVelocity()
    {
        float xSpeed = 0f;
        float zSpeed = 0f;
        if (this.controls.checkUp())
        {
            zSpeed = this.hustle;
        }
        else if (this.controls.checkDown())
        {
            zSpeed = -this.hustle;
        }
        if (this.controls.checkLeft())
        {
            xSpeed = -this.hustle;
        }
        else if (this.controls.checkRight())
        {
            xSpeed = this.hustle;
        }

        return new Vector3(xSpeed, 0.0f, zSpeed);
    }
}
