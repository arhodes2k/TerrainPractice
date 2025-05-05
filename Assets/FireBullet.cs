using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;
    void Start(){ 
        StartCoroutine(KillBullet(gameObject, lifeTime));
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log("hit" + other.name);

        Destroy(gameObject);
    }

     private IEnumerator KillBullet(GameObject bullet, float delay){
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
