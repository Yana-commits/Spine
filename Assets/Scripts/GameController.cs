using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{

    private GameplayState gamePlayState = GameplayState.Stop;

    [Inject]
    private HUD hud;

    [Inject]
    private PlayerController player;

    [Inject]
    private Enemy enemy;

    [SerializeField]
    private int speed;

    [SerializeField]
    private GameObject snowball;

    public Transform snowBallParent;
    public int poolCount = 10;
    public int currentId = 0;



    void Start()
    {
        hud.OnShoot += player.Shoot;
        hud.OnBow += player.BowControl;

        PoolSnowBall();

        player.Initializie(hud.joystick,speed, snowBallParent, currentId);
        enemy.Initializie( snowBallParent, currentId);
    }

    
    void Update()
    {
        
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
    public void SetGameState(GameplayState state)
    {
        gamePlayState = state;
        switch (state)
        {
            case GameplayState.Play:
                Time.timeScale = 1;
                break;
            case GameplayState.Stop:
            case GameplayState.Pause:
                Time.timeScale = 0;
                break;
        }
    }

    private void OnDestroy()
    {
        hud.OnShoot -= player.Shoot;
        hud.OnBow -= player.BowControl;
    }
}
