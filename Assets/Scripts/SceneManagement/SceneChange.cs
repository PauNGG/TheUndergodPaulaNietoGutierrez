using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        StartCoroutine(LoadLevelCo());
    }

    //La corrutina para cargar un nivel
    public IEnumerator LoadLevelCo()
    {
        //Hacemos fundido a negro
        //UIController.sharedInstance.FadeToBlack();
        ////Reproducimos el sonido de cargar un nivel
        //AudioManager.sharedInstance.PlaySFX(1);
        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(1f);
        //Cargamos el nivel al que queremos ir
        SceneManager.LoadScene(SceneToLoad);
    }
}
