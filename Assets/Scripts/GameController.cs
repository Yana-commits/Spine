using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private GameplayState gamePlayState = GameplayState.Stop;

    void Start()
    {
        
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
   
}
