using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public float frequenza = 1;
    public float potenza = 5;
    public GameObject freccia;
    public Vector2 direzione;
    public Transform origine; 
    bool isActive = true; 
    void Start()
    {
        StartCoroutine(CicloSparo());
    }

    
    IEnumerator CicloSparo(){  
        while(isActive){ 
            yield return new WaitForSeconds(frequenza);
            GameObject nuovaFreccia = Instantiate(freccia, origine.position, Quaternion.identity); 
            nuovaFreccia.GetComponent<Freccia>().Spara(direzione, potenza);
        }
    }
    
}
