using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    //Nombre de la escena a cargar
    public string sceneToLoad;

    //El nombre del área de la escena a la que vamos a ir
    public string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Método para conocer cuando el jugador entra en el área de cambio de nivel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Cargamos la escena a la que queremos ir
            SceneManager.LoadScene(sceneToLoad);

            //El jugador recoge el área a la que quiere ir de la salida que está pisando
            PlayerController.sharedInstance.areaTransitionName = areaTransitionName;
        }
    }
}