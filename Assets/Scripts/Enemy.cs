using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Enemy : Creature
{
    [SerializeField]
    private GameObject snowball;

    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float shootPower = 5f;

    public Vector3 direction;

    private Rigidbody2D rigidbody;

    private bool moovement = true;

    public float speed;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        SetCharacterState(currentState);

        //InvokeRepeating("RandomEvent", 1f, 3f);

        // InvokeRepeating("Shoot", 5f, 5f);

        StartCoroutine(EnemyBehave());

        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Test();
        }
    }

    public void Move()
    {
       
        Vector2 velocity = rigidbody.velocity;
        velocity.x = speed * transform.localScale.x * 1;
        rigidbody.velocity = velocity;

        if (moovement == true)
        {
            speed = 5f;

            if (!currentState.Equals("throw_ball"))
            {
                SetCharacterState("run");
            }
        }

        else
        {
            speed = 0;

            if (!currentState.Equals("throw_ball"))
            {
                SetCharacterState("Idle4");
            }
        }
    }

    void Test()
    {
  
        skeletonAnimation.skeleton.SetSkin("DogSon");
    }
    private IEnumerator EnemyBehave()
    {
        StartCoroutine(EnemyShoot());

        while (true)
        {
            RandomEvent();

            yield return new WaitForSeconds(3);
        }
    
    }

    private IEnumerator EnemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Shoot();
        }
    }
    void RandomEvent()
    {
        switch (Random.Range(0, 3))
        {
            case 1:
                moovement = true;
                Invoke("Move", 1);
                break;

            case 2:
                moovement = false;
                Invoke("Move", 1);
                break;

            default:
                Invoke("ChangeDirection", 1);
                break;
        }
    }
    private void Destroyed()
    {

    }
    private void GetHit()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, gets_hit, false);
        if (speed == 0)
        {
            skeletonAnimation.AnimationState.AddAnimation(0, Idle, true, 0);
        }
        else
        {
            skeletonAnimation.AnimationState.AddAnimation(0, run, true, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Damager ball = collider.gameObject.GetComponent<Damager>();

        if (ball == null)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (transform.localScale.x < 0)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Shoot()
    {

        if (transform.localScale != Vector3.one)
        {
            ChangeDirection();
        }

        if (!currentState.Equals("throw_ball"))
        {
            previousState = currentState;
        }
            SetCharacterState("throw_ball");

            GameObject newBall = Instantiate(snowball, attackPoint.position, attackPoint.rotation) as GameObject;

            newBall.GetComponent<Rigidbody2D>().gravityScale = 0f;

            newBall.GetComponent<Rigidbody2D>().AddForce(direction.normalized * shootPower, ForceMode2D.Impulse);

        Damager ballBehaviour = newBall.GetComponent<Damager>();

             ballBehaviour.Owner = gameObject;

        Destroy(newBall, 2f);
        
    }
   
}
