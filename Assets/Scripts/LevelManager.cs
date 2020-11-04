using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{ 

    public void LaadScene(int sceneIndex)
    {
        //Laadt de scene via een index. De index van een scene kan je vinden bij Build Settings in Unity.
        SceneManager.LoadScene(sceneIndex);
    }

    public void LaadVolgendeScene()
    {
        //Pakt de huidige scene en kijkt wat de index van die scene is. Daarna laadt hij de scene door +1 te doen bij de huidige index.
        int huidigeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(huidigeSceneIndex + 1);
    }

    public void SpelAfsluiten()
    {
        Application.Quit();
    }
}
