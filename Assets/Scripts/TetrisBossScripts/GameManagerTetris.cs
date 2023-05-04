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
    public GameObject Human;
    public GameObject pieceSpawner;

    // Start is called before the first frame update
    void Start()
    {

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
            EndOfTetris();
        }
    }

    public void EndOfTetris()
    {
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");
        foreach (GameObject piece in pieces)
        {
            GameObject.Destroy(piece);
        }
        Destroy(pieceSpawner);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Overworld");
    }
}
