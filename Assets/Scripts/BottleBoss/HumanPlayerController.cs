using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayerController : MonoBehaviour
{
    public float movementSpeed = 5;
    public string axis = "Horizontal";
    public float throwCooldown;

    public Transform firePointRight;
    public Transform firePointLeft;

    public GameObject can;
    private Rigidbody2D theRB;
    private SpriteRenderer theSR;

    public bool isLeft;




    public static HumanPlayerController sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    private void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Ponemos FixedUpdate para que la longitud de cada frame en segundos mida lo mismo, y así el movimiento sea suavizado
    void Update()
    {
        //ATAQUE
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (isLeft)
            {
                Instantiate(can, firePointLeft.position, Quaternion.identity);
            }
            else
            {
                Instantiate(can, firePointRight.position, Quaternion.identity);
            }

            can.gameObject.SetActive(false);

            StartCoroutine(CooldownCo());
        }


        //Obtenemos el valor del eje asignado
        float v = Input.GetAxis(axis);
        //Debug.Log(v);
        //Accedemos al componente del RigidBody del objeto donde está metido el script y le aplicamos una velocidad en Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * movementSpeed;//Multiplicamos por la velocidad de movimiento => 1*25 ó -1*25



        //Girar el sprite del jugador según su dirección de movimiento
        if (theRB.velocity.x < 0)
        {
            //No cambiamos la dirección del sprite
            theSR.flipX = true;
            //El jugador mira a la izquierda
            isLeft = true;
        }
        //Si el jugador por el contrario se está moviendo hacia la derecha
        else if (theRB.velocity.x > 0)
        {
            //Cambiamos la dirección del sprite
            theSR.flipX = false;
            //El jugador mira a la derecha
            isLeft = false;
        }
    }
    public IEnumerator CooldownCo()
    {
        yield return new WaitForSeconds(throwCooldown);

        can.gameObject.SetActive(true);
    }
}
