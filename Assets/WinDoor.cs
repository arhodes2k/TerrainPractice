using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WinDoor : MonoBehaviour
{
  GameObject key;

    Animation anim;

    public UnityEvent DreamTeleport;

    // Start is called before the first frame update
    void Start()
    {

      key = GameObject.FindGameObjectWithTag("key");

        
        anim = GetComponent<Animation>();

        
    }

    void Update(){
      key.GetComponent<Key>().KeyRetrieved.AddListener(Open);
    }

    void Open () { 

       anim.Play("WinningDoor");

    }

    void OnTriggerEnter(Collider coll){ 
      if(coll.tag == "Player"){ 
        DreamTeleport.Invoke();
      }
    }
    // Update is called once pe
}
