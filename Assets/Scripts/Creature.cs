using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Spine.Unity;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;

    public AnimationReferenceAsset Idle, run, throw_ball, gets_hit, loose, bow;

    public string currentState;

    public string previousState;

    public string currentAnimation;

    public SkeletonAnimation spineboy;




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
            case "bow":
                
                SetAnimation(bow, false, 1f);
                Debug.Log("bow");
                break;
            default:
                SetAnimation(Idle, true, 1f);
                break;
        }

        currentState = state;
    }

}
