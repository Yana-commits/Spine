using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;
using UnityEngine.UI;
using Zenject;

public class PlayerController : Creature
{
  
    [SerializeField]
    private Transform attackPoint;

    private float shootPower=0 ;
    public float ShootPower
    {
        get { return shootPower; }

        set { shootPower = value; }
    }

    private Vector3 direction;

    public Vector3 directionRight;

    public Vector3 directionLeft;

    private Joystick joystick;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private int speed;

    public float timeShoot = 2f;

    private Slider mySlider;

    public float moovement;

    [SerializeField]
    private BoxCollider2D bc;

    public float bowKoef = 0.01f;
   

    public void Initializie( Joystick joystick,Transform snowBallParent, Slider slider)
    {
        this.joystick = joystick;
        this.snowBallParent = snowBallParent;
        //this.currentId = currentId;
        this.mySlider = slider;
    }

    void Start()
    {
   
        currentState = "Idle4";

        SetCharacterState(currentState);

        StartCoroutine(PlayShoot());
    }

    void FixedUpdate()
    {
        Move();

        timeShoot = timeShoot - 1 * Time.fixedDeltaTime;

    }

    private IEnumerator PlayShoot()
    {
        while (true)
        {

            while (shootPower <= 10)
            {
                mySlider.value = shootPower;

                shootPower = shootPower + 2 * Time.fixedDeltaTime;

                yield return null;
            }
            shootPower = 0;
        }
    }
    public void Move()
    {
        moovement = joystick.Horizontal;

        rigidbody.velocity = new Vector2(moovement * speed, rigidbody.velocity.y);

        if (moovement != 0)
        {
            if (!currentState.Equals("throw_ball"))
            {
                SetCharacterState("run");
            }

            if (moovement > 0)
            {
                transform.localScale = new Vector2(1f, 1f);

                direction = directionRight;
            }
            else
            {
                transform.localScale = new Vector2(-1f, 1f);

                direction = directionLeft;
            }
        }
        else
        {
            if (!currentState.Equals("throw_ball"))
            {
                SetCharacterState("Idle4");
            }
        }
    }

    public void Shoot()
    {
        if (timeShoot <= 0)
        {
            Shooter(1, ShootPower, attackPoint, direction);

            timeShoot = 2f;
        }
       
    }
    private void Destroyed()
    {
       skeletonAnimation.AnimationState.SetAnimation(0, loose, false).TrackEnd = float.PositiveInfinity;
    }
    private void GetHit()
    {
        skeletonAnimation.state.SetAnimation(0, gets_hit, false);
        skeletonAnimation.AnimationState.AddAnimation(0, Idle, true, 0);
    }

    public void BowControl()
    {
      
        StartCoroutine(PlayBow());
    }

    private IEnumerator PlayBow()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, bow, false);

        bc.offset = new Vector2(bc.offset.x, bc.offset.y - bc.size.y * (1 - bowKoef) / 2);

        bc.size = new Vector2(bc.size.x, bowKoef * bc.size.y);

        yield return new WaitForSeconds(2);

        SetCharacterState("Idle4");

        bc.offset = new Vector2(bc.offset.x, bc.offset.y + (bc.size.y / bowKoef - bc.size.y) / 2);

        bc.size = new Vector2(bc.size.x, bc.size.y / bowKoef);
    }
}

