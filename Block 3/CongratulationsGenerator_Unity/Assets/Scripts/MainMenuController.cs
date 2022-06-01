using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadHolidayScene(int i)
    {
        if (i >= 0 && i < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(i);
        }
        else
        {
            Debug.LogError("ID scene does not exist. Please, correct ID numeration");
        }
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
