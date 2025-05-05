using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource sound;
    
    void Start () {
        sound = GetComponent<AudioSource>();
   
    }

    void Playy (){ 

        
            sound.Play();
         
    }
    void OnTriggerEnter (Collider coll){

        
          Playy();
        
    }
    void OnTriggerExit (Collider coll){
 
          sound.Pause();
        
    }

}