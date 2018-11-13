using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMonitor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterScene(string SceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);
    }

    public void ExitGame()
    {
		Application.Quit();
    }
}
