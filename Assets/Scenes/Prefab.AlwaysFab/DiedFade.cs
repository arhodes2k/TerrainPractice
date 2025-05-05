using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedFade : MonoBehaviour
{
    Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
       
       
    }

    public void OnAwake(){
        Debug.Log("fade triggered");
        anim.SetTrigger("Fade"); 

        StartCoroutine(StopFade());
    }

    private IEnumerator StopFade(){
        yield return new WaitForSeconds(3); 
        anim.ResetTrigger("Fade");
    }
}
