using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Key : MonoBehaviour
{
    public UnityEvent KeyRetrieved;
    [SerializeField] AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            KeyRetrieved.Invoke();
            Kill();
        }
    }

    private void Kill()
    {
        sound.Play();

        Destroy(gameObject);
    }
}
