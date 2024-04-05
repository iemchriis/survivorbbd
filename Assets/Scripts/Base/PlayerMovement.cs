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
    [SerializeField] private FixedJoystick rotJoystick;

    public float moveSpeed;

    public bool isMobile;

    private void Start()
    {
        animator = GetComponent<Animator>();
        moveSpeed = (float)PlayerDataManager.Instance.GetSpeedValue();
        SetControls();
    }

    private void Update()
    {      
        LookAtEnemy();
    }

    void SetControls()
    {
#if UNITY_ANDROID

        isMobile = true;
#endif


#if UNITY_EDITOR
        isMobile = false;
        joystick.gameObject.SetActive(false);
#endif
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





        if (isMobile)
        {
            rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);


        }
        else
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        }

        if (rb.velocity.z != 0 || rb.velocity.x != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


        //LookDirection();
         

    }

    void LookDirection()
    {
        if(rotJoystick.Horizontal != 0 || rotJoystick.Vertical != 0)
        {
            Vector3 lookRot = new Vector3(rotJoystick.Horizontal, 0, rotJoystick.Vertical);
           transform.rotation = Quaternion.LookRotation(lookRot);
           transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

            //transform.Rotate(rotJoystick.Vertical * 1f, 0, rotJoystick.Horizontal * 1f);
        }
    }

    public void ApplySlowEffect(int debuffAmount, float debuffDuration)
    {
        StartCoroutine(ApplySlowEffectAsync(debuffAmount,debuffDuration));
    }

    public IEnumerator ApplySlowEffectAsync(int debuffAmount, float debuffDuration)
    {
        float ms = moveSpeed;
        moveSpeed -= debuffAmount;
        yield return new WaitForSeconds(debuffDuration);
        moveSpeed = ms;

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
