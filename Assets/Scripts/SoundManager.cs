using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

   public AudioSource source;
   static AudioSource staticSource;

   private void Start(){
      staticSource = source;
   }


   public static void playSound(string clipName){
      AudioClip clipDaRiprodurre = Resources.Load<AudioClip>("Clip/" + clipName); 
      staticSource.PlayOneShot(clipDaRiprodurre); 

   }
}
