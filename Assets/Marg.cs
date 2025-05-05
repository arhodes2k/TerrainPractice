using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marg : MonoBehaviour
{

    [SerializeField] GameObject EvilJoe;
    [SerializeField] GameObject dialogtrigger;

    Animator anim;
    public bool saved;
    Vector3 unsavedPos = new Vector3(-2.8f, 1.65f, 9.37f);
    Vector3 savedPos = new Vector3(-2.8f, 0f, 9.37f);
    [SerializeField] float lerpSpeed = 1.65f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EvilJoe != null)
        {
            saved = false;
            transform.position = new Vector3(transform.position.x, 1.65f, transform.position.z);
        }
        else
        {
            saved = true;
        }

        if (saved)
        {
            // Use Time.deltaTime to properly interpolate over time
            transform.position = Vector3.Lerp(transform.position, savedPos, lerpSpeed * Time.deltaTime);
        }

        anim.SetBool("Saved", saved);
    }

    void OnTriggerEnter(Collider coll)
    {

        if (coll.CompareTag("Player"))
        {
            dialogtrigger.SetActive(true); 
             StartCoroutine(StopTalking());

        }
    }
    private IEnumerator StopTalking(){ 

        yield return new WaitForSeconds(5); 
        dialogtrigger.SetActive(false); 
    }

}
