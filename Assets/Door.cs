using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{

    public UnityEvent DreamTeleport;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider coll)
    {

        if (coll.tag == "Player")
        {
            anim.SetTrigger("Door Open");
            DreamTeleport.Invoke();
            Debug.Log("he walked up");
        } 

    }
}
