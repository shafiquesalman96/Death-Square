using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject loseMenue;
    [SerializeField] private GameObject winMenue;


    public static UiManager Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public void TriggerLoseMenu() => loseMenue.SetActive(true);
    public void TriggerWinMenu() => winMenue.SetActive(true);



  

}
