using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{

    private GameplayState gamePlayState = GameplayState.Stop;

    [Inject]
    private HUD hud;

    //[Inject]
    private PlayerController player;

    [Inject]
    private Enemy enemy;

    public Transform snowBallParent;
    public int poolCount = 10;
    public int currentId = 0;

    //private SnowBallPool pool;

    [Inject]
    private void Construct(PlayerController player)
    {
        this.player = player;
    }



    void Awake()
    {
        hud.OnShoot += player.Shoot;
        hud.OnBow += player.BowControl;

        StartGame();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
     
        player.Initializie(hud.joystick,  hud.mySlider);
        //enemy.Initializie(snowBallParent);
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
