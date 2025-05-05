using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour
{
    [SerializeField] Transform ObjToLookAt; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(ObjToLookAt);

        Vector3 lookVector = new Vector3(ObjToLookAt.position.x, ObjToLookAt.position.y, ObjToLookAt.position.z);

        transform.LookAt(lookVector);
    }
}
