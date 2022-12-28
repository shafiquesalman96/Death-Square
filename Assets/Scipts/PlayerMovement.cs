using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{


    void Update()
    {
        verticalDirection = Input.GetAxis("Vertical");
        //var sprintspeed = Input.GetAxis("Sprint");


        verticalDirection = Mathf.Clamp(verticalDirection, 0, 1);
        animator.SetFloat("Speed", verticalDirection );
    }

    public override void Die()
    {
        base.Die();
       // Debug.Log("name death menu");

       UiManager.Instance.TriggerLoseMenu();
    }

     public override void Win()
    {
        base.Win();

        //Debug.Log("Trigger win menu");
        UiManager.Instance.TriggerWinMenu();


    }


}
