using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Para obtener la posici�n del objetivo de la c�mara
    public Transform target;

    //Referencias a las posiciones de los fondos
    public Transform farBackground, middleBackground1, middleBackground2;
    //Variables para posici�n m�nima y m�xima en vertical de la c�mara
    public float minHeight, maxHeight;

    //Variable donde guardar la �ltima posici�n en X que tuvo el jugador
    //private float lastXPos;
    //Referencia a la �ltima posici�n del jugador en X e Y
    private Vector2 lastPos;



    public static CameraController sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        //Al empezar el juego la �ltima posici�n del jugador ser� la actual
        lastPos = transform.position;
    }

    // LateUpdate is called once per frame, y los LateUpdate se hacen despu�s de todos los Update.
    //Con lo cu�l evitamos problemas de tirones de la c�mara
    void LateUpdate()
    {
        //La c�mara sigue al jugador sin variar su posici�n Z
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y + 0.5f, minHeight, maxHeight), transform.position.z);


        //Variable que me permite conocer cuanto hay que moverse en X
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position = farBackground.position + new Vector3(amountToMove.x, 0f, 0f);
        //farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        //middleBackground.position += new Vector3(amountToMoveX * .5f, 0f, 0f);
        middleBackground1.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .2f;
        middleBackground2.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .3f;

        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }
}
