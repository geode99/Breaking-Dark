using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{
    public string sceneToLoad;
    public void loadGivenScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
