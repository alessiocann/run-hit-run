using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void play(){
        SceneManager.LoadScene(5); 
    }

    public void option(){
        SceneManager.LoadScene(2);
    }

    public void exit(){
        Application.Quit();
    }

    public void TutorialGame(){
        SceneManager.LoadScene(4);
    }

    public void Credits(){
        SceneManager.LoadScene(3);
    }
    public void BackMenu(){
        SceneManager.LoadScene(1);
    }

    public void Liv1(){
        SceneManager.LoadScene(10);
    }
    
    public void GiocaLiv1(){
        SceneManager.LoadScene(7);
    }

    public void GiocaLiv2(){
        SceneManager.LoadScene(8);
    }

    public void GiocaLiv3(){
        SceneManager.LoadScene(9);
    }


    public static void cambiaScena(int indiceScena){
        SceneManager.LoadScene(indiceScena);
    }

}
