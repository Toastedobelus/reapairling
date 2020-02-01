using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;

    public Camera camera;

    public ControlScheme controls;
    public float hustle = 4;
    public float jump = 4;
    public float gravity = 9.8f;
    public float rotateSpeed = 90;

    public int id;
    public int repairAmount = 1;
    public int maxHealth = 25;
    public int currentHealth = 25;

    private float pickupRange = 3;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Create(ControlScheme controlScheme, Rect viewportRect)
    {
        this.controls = controlScheme;
        this.camera.rect = viewportRect;
    }

    public void Update()
    {
        float horizontal = getHorizontal();
        float vertical = getVertical();

        this.rotation = new Vector3(0, horizontal * rotateSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, vertical * Time.deltaTime);
        move = this.transform.TransformDirection(move);

        if (characterController.isGrounded && this.controls.checkJump())
        {
            move.y += this.jump;
        }

        move.y -= (gravity * Time.deltaTime);

        characterController.Move(move * hustle);
        this.transform.Rotate(this.rotation);

        if (this.controls.checkInteraction())
        {
            this.getCollisions();
            Debug.Log("Interaction key pressed");
        }
    }

    float getVertical()
    {
        if (this.controls.checkUp())
        {
            return this.hustle;
        }
        else if (this.controls.checkDown())
        {
            return -this.hustle;
        }
        return 0.0f;
    }

    float getHorizontal()
    {
        if (this.controls.checkLeft())
        {
            return -this.hustle;
        }
        else if (this.controls.checkRight())
        {
            return this.hustle;
        }
        return 0.0f;
    }

    void getCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRange);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Gate")
            {
                Gate gate = hitColliders[i].GetComponent<Gate>();
                gate.Repair(this.repairAmount);
            }
            if (hitColliders[i].tag == "Soul")
            {
                Soul soul = hitColliders[i].GetComponent<Soul>();
                soul.TakeDamage(2);
            }
        }
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
