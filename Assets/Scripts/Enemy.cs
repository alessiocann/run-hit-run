using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private float velocita = 300;
    public Personaggio pg;
    bool isCambioDirezione = false;
    public LayerMask filtroNemico;
    Rigidbody2D enemy;
    SpriteRenderer enemyFlip;


    RaycastHit2D hit;



    private void Start() {
        enemy = GetComponent<Rigidbody2D>();
        enemyFlip = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        int moltiplicatoreDirezione = Convert.ToInt32(isCambioDirezione)-1; 
        float direzione=Mathf.Sign(moltiplicatoreDirezione);
        float movimentoX = velocita * Time.deltaTime * direzione;

        float movimentoY = enemy.velocity.y;
        enemy.velocity = new Vector2(movimentoX, movimentoY); 

        hit = Physics2D.Linecast(transform.position, transform.position + Vector3.right * direzione, filtroNemico);
        
        
        if(hit){
            if(hit.transform.CompareTag("Player")){  
                if(enemy.name=="Enemy_B")pg.TakeDamage(0.25f);
                if(enemy.name=="Enemy_M")pg.TakeDamage(1);
                if(enemy.name=="Enemy_H")pg.TakeDamage(2.5f);
                isCambioDirezione=!isCambioDirezione;
                
                if(isCambioDirezione) 
                    enemyFlip.flipX = true;

                else
                    enemyFlip.flipX=false;
                
                if(pg.currentHealth <= 0) hit.transform.GetComponent<Personaggio>().destory();
            }
            else{
                isCambioDirezione=!isCambioDirezione;
                
                if(isCambioDirezione) 
                    enemyFlip.flipX = true;

                else
                    enemyFlip.flipX=false;


            }
        }

        
        hit = Physics2D.Linecast(transform.position, transform.position - Vector3.right * direzione, filtroNemico);
        if(hit){
            if(hit.transform.CompareTag("Player")){ 
                if(enemy.name=="Enemy_B")pg.TakeDamage(0.25f);
                if(enemy.name=="Enemy_M")pg.TakeDamage(1);
                if(enemy.name=="Enemy_H")pg.TakeDamage(2.5f);
                if(pg.currentHealth <= 0) hit.transform.GetComponent<Personaggio>().destory(); //Se da dietro lo tocca il player dev'essere distrutto.
                
            }
        }



    }

    public void destory(){
        gameObject.SetActive(false);
    }
}
