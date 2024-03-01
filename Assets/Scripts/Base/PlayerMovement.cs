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
        moveSpeed = (float)PlayerDataManager.Instance.GetSpeedValue();
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
            LookDirection();
            //transform.LookAt(transform.forward);
        }
        else
        {
            Vector3 enemyDirection = new Vector3(vision.nearestEnemy.transform.position.x,
                                                    transform.position.y,
                                                    vision.nearestEnemy.transform.position.z);

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


        LookDirection();
         

    }

    void LookDirection()
    {
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }


}
