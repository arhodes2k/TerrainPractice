using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
 Animator anim;
    GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.ResetTrigger("Fade");
       
    }

    // Update is called once per frame
    void Update()
    {
         door = GameObject.FindGameObjectWithTag("door");

        //eventThrower.GetComponent<TheThrowerGO>().InvokedEventToListenFor.AddListener(MethodToRun);
        door.GetComponent<Door>().DreamTeleport.AddListener(Fade); //this is the in-house method that's being called.
        
    }
    public void Fade(){
        anim.SetTrigger("Fade");
    }
}
