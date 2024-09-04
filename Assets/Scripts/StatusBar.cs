using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Personaggio personaggioH;
    public Image fillImage;
    private Slider slider;

    void Awake() {
        slider=GetComponent<Slider>();
    }

    void Update() {
        if(slider.value <= slider.minValue) fillImage.enabled=false;
        if(slider.value > slider.minValue && !fillImage.enabled) fillImage.enabled=true;
        
        float fillValue=personaggioH.currentHealth/personaggioH.maxHealth;

        if(fillValue<=slider.maxValue/100) fillImage.color=Color.white;
        else if(fillValue>slider.maxValue/100) fillImage.color=Color.red;

        slider.value=fillValue;

    }

}
