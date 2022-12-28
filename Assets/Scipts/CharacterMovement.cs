using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    protected Rigidbody rb;

    public bool afterWin;

    [SerializeField] protected float movementSpeed = 100f;
    protected float sprintspeed = 0;

    protected float verticalDirection = 1;
    
    protected Animator animator;

// after death animation player will not move
    private bool canMove = true;

// Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    
    // Update is called once per frame  
    void FixedUpdate()
    {
        if(canMove == true)
        {
        rb.velocity = Vector3.forward * verticalDirection  * movementSpeed *Time.fixedDeltaTime;
        }
        else
        {
        rb.velocity = Vector3.zero;

        }
     
    }


     public bool IsMoving() 
    {
        return rb.velocity.magnitude > 0.1f;
 
    }

    public virtual void Die()
    {
       // animator.SetTrigger("Death");
        //for death animation and stop moving
        Debug.Log(name + "has died!");
        animator.SetTrigger("Death");
        canMove = false;
    }

      public virtual void Win()
    {
       // win and open prize money menu 
       // make inuvlnerable = after win
        afterWin = true;

        Debug.Log(name + "has won!");

    }
}




