using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{

    public bool canFire;
    public int numberOfTrajectory;
    private float fireTime;
    public float rateOfFire;
    public Bomb Bombs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            fireTime -= Time.deltaTime;
            if (fireTime <= 0)
            {
                ThrowBomb();
                fireTime = rateOfFire;

            }
        }
    }



    void ThrowBomb()
    {
        StartCoroutine(CoThrowBomb());
    }


    IEnumerator CoThrowBomb()
    {
        for (int i = 0; i < numberOfTrajectory; i++)
        {
            Vector3 newPos = Random.onUnitSphere + transform.position;
            newPos.y += 3;
            Bomb bomb = Instantiate(Bombs, transform.position, Quaternion.identity);
            bomb.setTarget(newPos);
            yield return new WaitForSeconds(0.5f);

        }
    }
}
