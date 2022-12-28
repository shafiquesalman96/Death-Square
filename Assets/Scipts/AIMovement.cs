using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : CharacterMovement
{

private Robot robot;

private float currentStoppingTime;
private float currentTime;

private bool shouldCounting = true;



private void OnEnable()
{
    if(robot == null)
    {
        robot = FindObjectOfType<Robot>();

        robot.OnStartCounting += OnStartCounting;
        robot.OnStopCounting += OnStopCounting;

        currentStoppingTime = Random.Range(-5,5);

    }

}



// Update is called once per frame
    private void Update()
    {
// start of the game, Time is 0 and in first move add the time in current time         
        if (shouldCounting)
        {
            currentTime += Time.deltaTime;

        }
        if(currentTime >= currentStoppingTime)
        {
            verticalDirection = 0;
            shouldCounting = false;
        }



     animator.SetFloat("Speed", rb.velocity.magnitude);   

    }

     
    
// after first move speed will be 1
    private void OnStartCounting()
    {
            verticalDirection = 1;
            currentTime = 0;
            shouldCounting = false;
            currentStoppingTime = Random.Range(-12,6);
    }

     private void OnStopCounting()
    {
         

    }
}
