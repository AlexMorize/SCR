using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadQuitAndPause : MonoBehaviour
{
    bool isPaused = false;
    public void loadLevel()
    {
        SceneManager.LoadScene("GlobalScene");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        } else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void Unpause()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
