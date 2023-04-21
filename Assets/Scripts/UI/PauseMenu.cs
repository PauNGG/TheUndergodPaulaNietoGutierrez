using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Para cambiar entre escenas

public class PauseMenu : MonoBehaviour
{
    //Variables para saber las escenas a las que queremos ir desde este men�
    public string levelSelect, mainMenu;
    //Referencia al GO del men� de pausa
    public GameObject pauseMenu;
    public GameObject healthBar;
    public GameObject controlsPanel;
    //Variable para conocer cuando el juego est� pausado o no
    public bool isPaused;

    // Update is called once per frame
    void Update()
    {
        //Si pulsamos el bot�n de Intro
        if (Input.GetKeyDown(KeyCode.O))
        {
            //Pausamos el juego
            PauseUnpause();
        }
    }

    //M�todo para pausar o continuar el juego
    public void PauseUnpause()
    {
        ////Si la variable pausa es verdadera (el juego est� pausado)
        if (isPaused)
        {
            //Entonces el juego continuar�
            isPaused = false;
            //Desactivamos el panel de pausa
            pauseMenu.SetActive(false);
            healthBar.SetActive(true);
            //Reanudamos realmente el tiempo de juego
            Time.timeScale = 1f;

        }
        //Si el juego no estaba pausado
        else
        {
            //Entonces el juego se pondr� en pausa
            isPaused = true;
            //Activamos el panel de pausa
            pauseMenu.SetActive(true);
            healthBar.SetActive(false);
            //Pausamos realmente el tiempo de juego
            Time.timeScale = 0f;
        }

    }

    //M�todo para el bot�n LevelSelect
    public void OpenControlsPanel()
    {
        //Para ir a la escena LevelSelect
        controlsPanel.SetActive(true);
        //Reanudamos realmente el tiempo de juego
        Time.timeScale = 1f;
    }

    //M�todo para el bot�n MainMenu
    public void MainMenu()
    {
        //Para ir a la escena MainMenu
        SceneManager.LoadScene(mainMenu);
        //Reanudamos realmente el tiempo de juego
        Time.timeScale = 1f;
    }
    public void CloseControlsPanel()
    {
        //Para ir a la escena LevelSelect
        controlsPanel.SetActive(true);
        //Reanudamos realmente el tiempo de juego
        Time.timeScale = 1f;
    }
}

