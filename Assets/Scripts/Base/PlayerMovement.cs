using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerVision vision;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;

    public float moveSpeed;

    private void Update()
    {
        LookAtEnemy();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void LookAtEnemy()
    {
        if (vision.nearestEnemy.transform.position == null)
        {
            transform.LookAt(Vector3.forward);
        }
        else
        {
            Vector3 enemyDirection = vision.nearestEnemy.transform.position;

            transform.LookAt(enemyDirection);
        }
            

        
    }

    void MovePlayer()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
    }


}
