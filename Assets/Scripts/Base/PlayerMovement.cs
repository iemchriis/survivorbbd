using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerVision vision;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;

    public float moveSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        LookAtEnemy();
    }

    private void FixedUpdate()
    {
        if(!GetComponent<PlayerHealth>().IsDead())
            MovePlayer();
    }

    void LookAtEnemy()
    {
        if (vision.nearestEnemy == null)
        {
            transform.LookAt(transform.forward);
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

        if(rb.velocity.z != 0 || rb.velocity.x != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }


}
