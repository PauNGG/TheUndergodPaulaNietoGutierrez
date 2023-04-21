using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToScene: MonoBehaviour
{
    //El nombre del �rea de la escena donde queremos aparecer
    public string transitionName;

    // Start is called before the first frame update
    void Start()
    {
        //Si el �rea a donde debemos ir, coincide con la que tiene guardada el jugador
        if (transitionName == PlayerController.sharedInstance.areaTransitionName)
        {
            //Igualamos la posici�n del jugador a la de ese �rea
            PlayerController.sharedInstance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
