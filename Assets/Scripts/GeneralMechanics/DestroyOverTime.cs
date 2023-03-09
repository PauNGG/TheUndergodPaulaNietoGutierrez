using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    //Variable de selecci�n de tiempo para destruir el objeto
    public float lifeTime;

    // Update is called once per frame
    void Update()
    {
        //Destruir� el objeto pasado un tiempo dado
        Destroy(gameObject, lifeTime);
    }
}
