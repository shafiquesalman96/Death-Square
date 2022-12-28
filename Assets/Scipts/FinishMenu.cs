using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class FinishMenu : MonoBehaviour
{
    public void GotoScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
}
