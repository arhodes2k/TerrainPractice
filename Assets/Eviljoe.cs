using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eviljoe : MonoBehaviour
{
    public int maxHp = 10;
    public float attackTime = 1.2f;
    Animator anim;
    [SerializeField] int hp;

    [SerializeField] float speed = 2.0f;
    [SerializeField] float minDistance = 2.0f;  // Minimum distance to keep from player

    [SerializeField] Transform joeTransform;  // Reference to the player's transform

    [SerializeField] GameObject bossTitle;
    [SerializeField] GameObject defeatedTitle;
    bool bFollowing = false;

    // Bounds for the room
    [SerializeField] Vector3 minBounds = new Vector3(-5.94f, 3.21f);
    [SerializeField] Vector3 maxBounds = new Vector3(-1.41f, 10.73f);

    GameObject door;

    [SerializeField] GameObject[] hands;

    void Start()
    {
        hp = maxHp;
        anim = GetComponent<Animator>();
        GetComponent<Animator>().enabled = true;

        // Find the door object and register the event listener
        door = GameObject.FindGameObjectWithTag("door");
        door.GetComponent<HouseDoor>().JoeHere.AddListener(StartFollowingPlayer);
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
            return;
        }

        if (bFollowing && joeTransform != null)
        {
            // Get the player's position but maintain our y position
            Vector3 targetPosition = new Vector3(joeTransform.position.x, transform.position.y, joeTransform.position.z);

            // Calculate direction and distance
            Vector3 direction = targetPosition - transform.position;
            float distance = direction.magnitude;

            // Only move if we're farther than minDistance
            if (distance > minDistance)
            {
                Vector3 moveDir = direction.normalized;
                Vector3 newPosition = transform.position + moveDir * speed * Time.deltaTime;

                // Clamp position within bounds
                newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
                newPosition.z = Mathf.Clamp(newPosition.z, minBounds.y, maxBounds.y);

                transform.position = newPosition;
            }

            // Always face the player
            if (direction.magnitude > 0.1f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
    }

    public void StartFollowingPlayer()
    {
        bFollowing = true;
        anim.SetBool("walking", true);
        bossTitle.SetActive(true);

    }

    void OnTriggerEnter(Collider coll)
    {

        Debug.Log("My health is" + hp);
        if (coll.CompareTag("bullet"))
        {
            hp -= 2;
            anim.SetTrigger("hit");
        }
        if (coll.CompareTag("Player"))
        {
            Debug.Log("In Range!");
            anim.SetTrigger("inRange");
           StartCoroutine(ActivateHandsAfterDelay(attackTime));
        }

        if (coll.CompareTag("wall"))
        {
            anim.SetBool("walking", false);
        }
    }

    IEnumerator ActivateHandsAfterDelay(float delay)
{
    yield return new WaitForSeconds(0.7f);
    hands[0].SetActive(true);
    hands[1].SetActive(true);
    bossTitle.SetActive(false);
}

    void Die()
    {
        GetComponent<Animator>().enabled = false;
        bFollowing = false;
        Destroy(gameObject, 3);
        bossTitle.SetActive(false);
        defeatedTitle.SetActive(true);
        Destroy(defeatedTitle, 3);

    }
}
