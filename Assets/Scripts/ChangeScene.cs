using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // This will change the scene when a button is clicked
    // Ex. Clicking How To Play will go into a tutorial of how to play the game
    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo);
    }
}
