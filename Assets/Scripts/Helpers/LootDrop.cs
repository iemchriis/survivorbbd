using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public LootType lootType;

    private Vector3 velocity = Vector3.up;
    private Rigidbody rb;
    private Vector3 startPosition;
   
    void Start()
    {
        startPosition = transform.position;
        velocity *= Random.Range(4f, 6f);
        velocity += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.position += velocity * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(Random.Range(-150f, 150f), Random.Range(150f, 250f), Random.Range(-150f, 150f)) * Time.deltaTime);

        rb.MoveRotation(rb.rotation * deltaRotation);

        if (velocity.y < -4f)
            velocity.y = -4f;
        else
            velocity -= Vector3.up * 5 * Time.deltaTime;


        if(Mathf.Abs(rb.position.y - startPosition.y) < 0.25f && velocity.y < 0f)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.velocity = velocity;
            this.enabled = false;
        }
    }


    public void GetLoot()
    {
        switch(lootType)
        {
            case LootType.GEM:
                PlayerDataManager.Instance.AddPlayerCoins();
                break;

        }

        Destroy(gameObject);
    }
}



public enum LootType
{
    GEM,
    HEALTH
}