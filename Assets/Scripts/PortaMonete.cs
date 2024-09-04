using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Libreria esterna per il text mash
using UnityEngine.SceneManagement;

public class PortaMonete : MonoBehaviour
{
    int monete = 0;
    string scene_name;

    public TextMeshProUGUI contaMoneteText;

    
    

    private void OnTriggerEnter2D(Collider2D collision) { 
        if(collision.name.Contains("Coin")){  
            monete++;
            collision.gameObject.SetActive(false);

            
            print("Moneta toccata\n");
            print("Ho " + monete + " monete");
            SoundManager.playSound("Coin_Sound");
            AggiornaConteggioMonete();
            scene_name=SceneManager.GetActiveScene().name;

            if(monete==10 && scene_name=="Level1"){
                SceneManager.LoadScene(11);
            }
            else if(monete==15 && scene_name=="Level2"){
                SceneManager.LoadScene(12);
            }
            else if(monete==20 && scene_name=="Level3"){
                SceneManager.LoadScene(3);
            }


        }

        void AggiornaConteggioMonete(){
            contaMoneteText.SetText("Monete: " + monete);
        }
    
    }
}

