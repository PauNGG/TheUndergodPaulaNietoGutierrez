using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerTetris : MonoBehaviour
{
    public int linecounter;
    public static GameManagerTetris sharedInstance;
    public AudioClip destroy;
    public AudioSource sound;
    public GameObject Human;
    public GameObject pieceSpawner;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    private void Update()
    {
        if (linecounter >= 5)
        {
            Debug.Log("Fin");
            StartCoroutine(EndOfTetrisCo());
        }
    }

    public IEnumerator EndOfTetrisCo()
    {
        PlayerController.sharedInstance.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        Destroy(pieceSpawner);

        CameraController.sharedInstance.target = PlayerController.sharedInstance.gameObject.transform;
        yield return new WaitForSeconds(0.5f);

    }
}
