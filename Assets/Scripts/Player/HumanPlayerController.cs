using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanPlayerController : MonoBehaviour
{
    public float movementSpeed = 5;
    public string axis = "Horizontal";

    public Transform firePointRight;
    public Transform firePointLeft;

    public GameObject can;
    private Rigidbody2D theRB;
    private SpriteRenderer theSR;

    public bool isLeft;
    public bool canInteract = false;

    public float fireRate = 1f;
    public float canFireTimer = 0f;


    public float knockBackLength, knockBackForce; //Valor que tendrá el contador de KnockBack, y la fuerza de KnockBack
    private float knockBackCounter; //Contador de KnockBack

    public int itemCount;


//SINGLETON//
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
        if (itemCount == 2)
        {
            PlayerController.sharedInstance.roarAndBreakUnlocked = true;
            //SceneManager.LoadScene("Overworld");
        }






        //ATAQUE
        if (Input.GetKeyDown(KeyCode.E) && Time.time > canFireTimer)
        {
            canFireTimer = Time.time + fireRate;
            ThrowCan();
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

    private void ThrowCan()
    {
        if (isLeft)
        {
            Instantiate(can, firePointLeft.position, Quaternion.identity);
        }
        else
        {
            Instantiate(can, firePointRight.position, Quaternion.identity);

        }
    }

    public void KnockBack()
    {
        //Inicializar el contador de KnockBack
        knockBackCounter = knockBackLength;
        //Paralizamos en X al jugador y hacemos que salte en Y
        theRB.velocity = new Vector2(0f, knockBackForce);

        //Activamos el trigger del animator
        //anim.SetTrigger("hurt");
    }
}

