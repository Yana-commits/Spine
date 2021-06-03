using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;
using UnityEngine.UI;
using System;
using Zenject;

public class Creature : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;

    public AnimationReferenceAsset Idle, run, throw_ball, gets_hit, loose, bow;

    public string currentState;

    public string previousState;

    public string currentAnimation;

    public SkeletonAnimation spineboy;

    protected Transform snowBallParent;

    [Inject]
    private GameController game;

    public int Id;

    //public Action BallCount;

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        if (animation.name.Equals(currentAnimation))
        {
            return;
        }
        Spine.TrackEntry animationEntry = skeletonAnimation.state.SetAnimation(0, animation, loop);
        animationEntry.timeScale = timescale;
        animationEntry.Complete += AnimationEntry_Complete;
        currentAnimation = animation.name;
    }

    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry)
    {
        if (currentState.Equals("throw_ball"))
        {
            SetCharacterState(previousState);
        }

        //skeletonAnimation.initialSkinName = "sd";
    }

    public void SetCharacterState(string state)
    {
        switch (state)
        {
            case "run":

                SetAnimation(run, true, 1f);
                break;
            case "throw_ball":

                SetAnimation(throw_ball, false, 1f);
                break;
            case "Idle4":

                SetAnimation(Idle, true, 1f);
                break;
            default:
                SetAnimation(Idle, true, 1f);
                break;
        }

        currentState = state;
    }



    public void Shooter(float gravity, float shootPower, Transform attackPoint, Vector3 direction)
    {
        if (!currentState.Equals("throw_ball"))
        {
            previousState = currentState;
        }
        SetCharacterState("throw_ball");

        GameObject newBall = snowBallParent.GetChild(game.currentId).gameObject;

        newBall.SetActive(true);
        newBall.transform.position = attackPoint.position;

        newBall.GetComponent<Rigidbody2D>().gravityScale = gravity;
        newBall.GetComponent<Rigidbody2D>().AddForce(direction.normalized * shootPower, ForceMode2D.Impulse);


        Damager ballBehaviour = newBall.GetComponent<Damager>();

        ballBehaviour.Owner = gameObject;

        game.SnowBallsCounter();
        //BallCount?.Invoke();
        //currentId++;
        //if (currentId > snowBallParent.childCount - 1)
        //{
        //    currentId = 0;
        //}
    }

}