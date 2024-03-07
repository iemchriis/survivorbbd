using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour, ISlowed, IStunned
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
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }
    }

    public void ApplySlowEffect(int debuffAmount, float debuffDuration)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator ApplySlowEffectAsync(int debuffAmount, float debuffDuration)
    {
        throw new System.NotImplementedException();
    }

    public void ApplyStun(float stunDuration)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator ApplyStunAsync(float stunDuration)
    {
        throw new System.NotImplementedException();
    }
}
