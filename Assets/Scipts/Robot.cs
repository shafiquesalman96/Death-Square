using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


enum RobotStates { Counnting, Inspecting };

public class Robot : MonoBehaviour
{
    [SerializeField] private float startInspectionTime = 10f;

    // array for random music
    public AudioClip[] countingSounds;
    private AudioSource jingleSource;
    [SerializeField] private AudioSource shootingSound;


    private float currentInspectionTime;

    private RobotStates currentState = RobotStates.Counnting;

    public delegate void OnStartCountingDelegate();
    public OnStartCountingDelegate OnStartCounting ;

    public delegate void OnStopCountingDelegate();
    public OnStopCountingDelegate OnStopCounting ;

    

    private Animator animator;
    private List<CharacterMovement> characters = new List<CharacterMovement>();


    // Start is called before the first frame update
    void Start()
    {
        characters = FindObjectsOfType<CharacterMovement>().ToList();
        animator = GetComponentInChildren<Animator>();

        currentInspectionTime = startInspectionTime;
        jingleSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(characters == null)
        return;

        if(characters.Count <= 0)
        return; 
        
        StateMachine();
    }

    private void StateMachine()
    {
        switch (currentState)
        {
            case RobotStates.Counnting:
                Count();
                break;
            case RobotStates.Inspecting:
                Inspect();
                break;

            default:
                break;

        }
    }

    private void Count()
    {
        if (!jingleSource.isPlaying)
        {
            animator.SetTrigger("Look");
            currentState = RobotStates.Inspecting;
            OnStopCounting?.Invoke();
        }


    }
    private void Inspect()
    {
        if (currentInspectionTime > 0)
        {
            currentInspectionTime -= Time.deltaTime;

            var charsToRemove = new List<CharacterMovement>();

            foreach (var character in characters)
            {

                if (character.IsMoving() && character.afterWin == false)
                {
                    charsToRemove.Add(character);
                 }
    
            }

                foreach (var character in charsToRemove)
            {

                shootingSound.Play();
                characters.Remove(character);
               // Destroy(character.gameObject);
               character.Die();

            }

           
        }
        else
        {
            currentInspectionTime = startInspectionTime;
            animator.SetTrigger("Look"); 
           // jingleSource.pitch = Random.Range(1,3);


            jingleSource.clip = countingSounds[Random.Range(0,countingSounds.Length)];
            jingleSource.Play();
            currentState = RobotStates.Counnting;
            OnStartCounting?.Invoke();

        }



    }

}
