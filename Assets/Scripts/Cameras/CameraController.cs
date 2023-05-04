using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Para obtener la posición del objetivo de la cámara
    public Transform target;

    //Referencias a las posiciones de los fondos
    public Transform farBackground, middleBackground1, middleBackground2;
    //Variables para posición mínima y máxima en vertical de la cámara
    public float minHeight, maxHeight;

    //Variable donde guardar la última posición en X que tuvo el jugador
    //private float lastXPos;
    //Referencia a la última posición del jugador en X e Y
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
        //Al empezar el juego la última posición del jugador será la actual
        lastPos = transform.position;
    }

    // LateUpdate is called once per frame, y los LateUpdate se hacen después de todos los Update.
    //Con lo cuál evitamos problemas de tirones de la cámara
    void LateUpdate()
    {
        //La cámara sigue al jugador sin variar su posición Z
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
