using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseDoor : MonoBehaviour
{

    public UnityEvent JoeHere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {

        if (coll.tag == "Player")
        {
            JoeHere.Invoke();
            Debug.Log("he walked up");
        }

    }
}
