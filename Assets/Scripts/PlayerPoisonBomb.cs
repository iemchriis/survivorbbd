using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoisonBomb : MonoBehaviour
{

    public bool canFire;
    public int numberOfTrajectory;
    private float fireTime;
    public float rateOfFire;
    public GameObject Poison;

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
            GameObject bomb = Instantiate(Poison, transform.position, Quaternion.identity);
            bomb.transform.parent = LevelGenerator.Instance.GetLevelParent();
            yield return new WaitForSeconds(0.5f);

        }
    }
}
