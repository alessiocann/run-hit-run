using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaggio : MonoBehaviour, Damage<float>
{
    Rigidbody2D warrior;
    private Animator anim;

    public float maxHealth = 100;
    public float currentHealth;
    private float currentHealthCheckPoint;

    private float velocita = 300;
    private float potenzaSalto = 5;
    bool isSaltoRilasciato = false;
    bool isGrounded;
    bool isGroundedDie;
    public Transform groundCheck;
    public LayerMask ground;
    public float checkRadius;
    public float radiusDie;
    RaycastHit2D pHit;
    public LayerMask filtroPlayer;
    SpriteRenderer playerFlip;

    private float timeRemaining = 10;
    private bool timerIsRunning = false;
    private Vector3 respawnPoint;



    
    void Start()
    {
        warrior = GetComponent<Rigidbody2D>();
        playerFlip = GetComponent<SpriteRenderer>();
        currentHealth=maxHealth;
        anim=GetComponent<Animator>();
        radiusDie=100;
        respawnPoint=transform.position;

    }

    
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == -1)
            playerFlip.flipX = true;
        else
            playerFlip.flipX = false;
        
        float movimentoX = Input.GetAxisRaw("Horizontal") * velocita * Time.deltaTime;
        
        float movimentoY = warrior.velocity.y; 

        warrior.velocity = new Vector2(movimentoX, movimentoY);

         if(Mathf.Abs(movimentoX) > 0 && warrior.velocity.y == 0) anim.SetBool("isRunning", true);
         else anim.SetBool("isRunning", false);


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        isGroundedDie=Physics2D.OverlapCircle(groundCheck.position, radiusDie, ground);

        if(!isGroundedDie) transform.position=respawnPoint;


        if(Input.GetAxisRaw("Jump") > 0 && isSaltoRilasciato && isGrounded){ 
            warrior.AddForce(Vector2.up * potenzaSalto, ForceMode2D.Impulse); 
            
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
            SoundManager.playSound("Jump_Sound");
            isSaltoRilasciato = false;
        }      
        else if(!isSaltoRilasciato && Input.GetAxisRaw("Jump") < 1){
            anim.SetBool("isJumping",false);
            anim.SetBool("isFalling", true);
            isSaltoRilasciato = true;
        }

        else if(Input.GetAxisRaw("Jump") == 0)
        {
            anim.SetBool("isJumping",false);
            anim.SetBool("isFalling", false);
        }

         pHit=Physics2D.Linecast(transform.position, transform.position - Vector3.up, filtroPlayer); //Gestisco la collisione verso il basso per attaccare il nemico

        if(pHit && pHit.transform.CompareTag("Enemy") && pHit.transform.GetComponent<Enemy>() != null){ 
            pHit.transform.GetComponent<Enemy>().destory();

        }

        if (timerIsRunning){
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
            }
            else{
                timeRemaining = 0;
                timerIsRunning = false;
                velocita=300;
                potenzaSalto=5;
            }
        }
}

    private void OnTriggerEnter2D(Collider2D collision) {  
        if(collision.tag == "PowerUp_V"){  
            collision.gameObject.SetActive(false); 

            timerIsRunning = true;
            timeRemaining=10;
            velocita=1000;
            }

        else if(collision.tag == "PowerUp_J"){
            collision.gameObject.SetActive(false);
            timerIsRunning = true;
            timeRemaining=10;
            potenzaSalto=10;
        }

        else if(collision.tag == "Checkpoint"){
            respawnPoint=transform.position;
            currentHealthCheckPoint=currentHealth;
        }
    }

    public void TakeDamage(float amount){
        currentHealth-=amount;
    }


    

    public void destory(){
        transform.position=respawnPoint;
        currentHealth=currentHealthCheckPoint;
    }
}
