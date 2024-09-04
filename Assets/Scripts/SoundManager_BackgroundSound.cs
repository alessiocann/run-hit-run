using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager_BackgroundSound : MonoBehaviour
{
    [SerializeField] Image audioOnIcon;
    [SerializeField] Image audioOffIcon;
    private bool muted=false;

    void Start() {
        if(!PlayerPrefs.HasKey("muted")){
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else Load();
        
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon(){
        if(muted==false){
            audioOnIcon.enabled=true;
            audioOffIcon.enabled=false;
        }
        else{
            audioOnIcon.enabled=false;
            audioOffIcon.enabled=true;
        }

    }

    public void OnButtonPress(){
        if(muted==false){
            muted = true;
            AudioListener.pause = true;
        }
        else{
            muted=false;
            AudioListener.pause=false;
        }

        Save();
        UpdateButtonIcon();

    }

    private void Load(){
        muted=PlayerPrefs.GetInt("muted") == 1;

    }

    private void Save(){
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}
