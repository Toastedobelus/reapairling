using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    CharacterController characterController;

    public ControlScheme controls;
    public float hustle = 2.0f;
    public float jump = 4.0f;
    public float gravity = 20.0f;

    private float pickupRange = 3;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        this.controls = new WASDControlScheme();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = this.getVelocity();
            moveDirection *= this.hustle;

            if (this.controls.checkJump())
            {
                moveDirection.y = this.jump;
            }
        }
        
        moveDirection.y -= (gravity * Time.deltaTime);

        characterController.Move(moveDirection * Time.deltaTime);

        if (this.controls.checkInteraction())
        {
            this.getCollisions();
            Debug.Log("Interaction key pressed");
        }
    }

    Vector3 getVelocity()
    {
        Vector3 velocity = Vector3.zero;
        if (this.controls.checkUp())
        {
            velocity.z = -this.hustle;
        }
        else if (this.controls.checkDown())
        {
            velocity.z = this.hustle;
        }
        if (this.controls.checkLeft())
        {
            velocity.x = this.hustle;
        }
        else if (this.controls.checkRight())
        {
            velocity.x = -this.hustle;
        }

        return velocity;
    }

    void getCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRange);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Debug.Log(hitColliders[i].tag);
        }
    }
}
