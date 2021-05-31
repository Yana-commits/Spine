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

    void Start()
    {
        hud.OnShoot += player.Shoot;
        hud.OnBow += player.BowControl;
    }

    
    void Update()
    {
        
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
