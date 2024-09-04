using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freccia : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Spara(Vector2 direzione, float potenza){
        if(rb == null){
            Start();  
        }
        rb.AddForce(direzione * potenza, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        if(collision.transform.CompareTag("Player")){ 
            collision.transform.GetComponent<Personaggio>().destory(); 
        }
        gameObject.SetActive(false);
    }
}
