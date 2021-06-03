using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SnowBallPool : MonoBehaviour
{
    [Inject]
    private GameObject snowball;

    public Transform snowBallParent;
    public int poolCount = 10;
    public int currentId = 0;

    readonly SignalBus _signalBus;
    [Inject]
    public SnowBallPool(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    void Start()
    {
        PoolSnowBall();
        _signalBus.Fire<JustSignal>();
    }

    private void PoolSnowBall()
    {
        snowBallParent = transform;

        for (int i = 0; i < poolCount; i++)
        {
            var instance = Instantiate(snowball, transform.position, transform.rotation, snowBallParent);
            instance.SetActive(false);
        }
    }

    public void SnowBallsCounter()
    {
        currentId++;

        if (currentId > snowBallParent.childCount - 1)
        {
            currentId = 0;
        }
    }

   
}
