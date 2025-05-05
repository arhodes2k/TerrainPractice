using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class JoeController : MonoBehaviour
{
    //Thank you Claude for the aim speed help!

    Animator anim;
    //Scene 1 Dialog Tings
    [SerializeField] string[] dNodes;
    [SerializeField] TMP_Text shownDialogue;
    [SerializeField] float readCount = 2f;
    float readTime;
    [SerializeField] int currentEntry;
    bool bTalking = false;

    [SerializeField] GameObject key;
    

    // Shooting Tings
    public bool bAim = false;
    [SerializeField] bool canShoot = true;

    [SerializeField] float shootCooldown = 2f;

    [SerializeField] GameObject aimCam;
    [SerializeField] GameObject pfBullet;
    [SerializeField] Transform BulletSpawn;


    [SerializeField] float bulletSpeed = 30f;

    public bool killed; 
    public bool wakeUp;
    //public UnityEvent KilledMe;

    void Start()
    {
        currentEntry = 0;
        readTime = readCount;
        NewText();
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        aimCam.SetActive(bAim);
        if (bTalking)
        {
            // Correctly decrement the timer using deltaTime
            readTime -= Time.deltaTime;

            // Hide text when timer expires
            if (readTime <= 0)
            {
                shownDialogue.enabled = false;
                bTalking = false;
            }
        }

        if (key != null){ 
            NewText();
        }

        if (Input.GetButton("Fire3"))
        {
            bAim = true;
        }
        else
        {
            bAim = false;
        }

        if (bAim)
        {
            //pc.MoveSpeed = 1f;

            if (Input.GetKeyDown(KeyCode.L) && canShoot)
            {
                Shoot();
                canShoot = false;

            }
        }

        if (anim != null)
        {
            anim.SetBool("aim", bAim);
        }
        else
        {
            // If anim is null, try to get the component
            anim = GetComponent<Animator>();
        }


    }

    void Shoot()
    {
        GameObject bullet = Instantiate(pfBullet);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), BulletSpawn.parent.GetComponent<Collider>());
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        bullet.transform.position = BulletSpawn.position;
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(BulletSpawn.rotation.x, transform.eulerAngles.y, BulletSpawn.rotation.z);
        //forcemode.impulse means that you won't be adding continuous force to the rb, just once. 
        bullet.GetComponent<Rigidbody>().AddForce(BulletSpawn.up * bulletSpeed, ForceMode.Impulse);
        canShoot = false;
        StartCoroutine(CoolDown());

    }

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "trigger")
        {
            currentEntry++;
            NewText();
        }

        if (coll.tag == "hands")
        {
            Debug.Log("You got hit by " + coll.tag);
            StartCoroutine(Died());
            killed = true; 

            
        }

        if (coll.tag == "transition"){ 
            wakeUp = true;
        }
    }

    private IEnumerator Died(){ 
        
        yield return new WaitForSeconds(3); 
        SceneManager.LoadScene("InHouseScene");
       // KilledMe.Invoke();
        
        Debug.Log("killed me");
    }


    public void NewText()
    {

        if (currentEntry >= 0 && currentEntry < dNodes.Length)
        {

            shownDialogue.text = dNodes[currentEntry];
            shownDialogue.enabled = true;
            readTime = readCount;
            bTalking = true;
        }
        else if (currentEntry >= dNodes.Length)
        {
            shownDialogue.text = "";
            shownDialogue.enabled = false;
            bTalking = false;
        }
    }
}