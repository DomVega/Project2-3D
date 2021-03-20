using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PausedMenuV2 : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
 

    private void Update()
    {
        if (Input.GetKeyDown("p"))

        { isPaused = !isPaused; }


        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

void ActivateMenu()
{
        Time.timeScale = 0;

    pauseMenuUI.SetActive(true);
}
public void DeactivateMenu()
{
        Time.timeScale = 1;
    pauseMenuUI.SetActive(false);
        isPaused = false;
}
    public void quitgame()
    {
        Application.Quit();
    }

}
