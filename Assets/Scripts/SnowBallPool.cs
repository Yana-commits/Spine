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

    void Start()
    {
        PoolSnowBall();
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
