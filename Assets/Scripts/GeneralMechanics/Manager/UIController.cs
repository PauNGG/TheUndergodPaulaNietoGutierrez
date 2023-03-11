using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder trabajar con elementos de la UI
using TMPro;

public class UIController : MonoBehaviour
{
    public Image HealthBar;
    public Sprite FullBar, HalfBar, LowBar, EmptyBar;
    public TextMeshProUGUI betrootCountText;
    public Image betrootCountImage;


    //Referencia al FadeScreen
    public Image fadeScreen;
    //Variable para la velocidad de transición al FadeScreen
    public float fadeSpeed;
    //Variables para conocer cuando hacemos fundido a negro o vuelta a transparente
    private bool shouldFadeToBlack, shouldFadeFromBlack;


    public static UIController sharedInstance;
    
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar el contador de gemas
        UpdateBetrootCount();
        FadeFromBlack();
    }

    private void Update()
    {
        //Si hay que hacer fundido a negro
        if (shouldFadeToBlack)
        {
            //Cambiar la transparencia del color a opaco
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            //Mathf.MoveTowards (Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
            //Si el color ya es totalmente opaco
            if (fadeScreen.color.a == 1f)
            {
                //Paramos de hacer fundido a negro
                shouldFadeToBlack = false;
            }
        }
        //Si hay que hacer fundido a transparente
        if (shouldFadeFromBlack)
        {
            //Cambiar la transparencia del color a transparente
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            //Mathf.MoveTowards (Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
            //Si el color ya es totalmente transparente
            if (fadeScreen.color.a == 0f)
            {
                //Paramos de hacer fundido a transparente
                shouldFadeFromBlack = false;
            }
        }
    }

    //Método para actualizar la vida en la UI
    public void UpdateHealthDisplay()
    {
        //Dependiendo del valor de la vida actual del jugador
        switch (PlayerHealthController.sharedInstance.currentHealth)
        {
            //En el caso en el que la vida actual valga 3
            case 3:
                HealthBar.sprite = FullBar;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 2
            case 2:
                HealthBar.sprite = HalfBar;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 1
            case 1:
                HealthBar.sprite = LowBar;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 0
            case 0:
                HealthBar.sprite = EmptyBar;
                //Cerramos el caso
                break;
            //En el caso por defecto, el jugador estará muerto
            default:
                HealthBar.sprite = EmptyBar;
                //Cerramos el caso
                break;
        }
    }

    //Método para actualizar el contador de gemas
    public void UpdateBetrootCount()
    {
        //Actualizar el número de gemas recogidas                                  /////////////NOMBRE DE LA VARIABLE
        betrootCountText.text = LevelManager.sharedInstance.betrootCollected.ToString();//Cast -> convertimos el número entero en texto para que pueda ser representado en la UI
    }

    public void FadeToBlack()
    {
        //Activamos la booleana de fundido a negro
        shouldFadeToBlack = true;
        //Desactivamos la booleana de fundido a transparente
        shouldFadeFromBlack = false;
    }

    //Método para hacer fundido a transparente
    public void FadeFromBlack()
    {
        //Activamos la booleana de fundido a transparente
        shouldFadeFromBlack = true;
        //Desactivamos la booleana de fundido a negro
        shouldFadeToBlack = false;
    }
}
