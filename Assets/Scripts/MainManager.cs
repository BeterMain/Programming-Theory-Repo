using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public PedestalHealth pedestal;
    public GameObject gameOver;
    public SpawnManager spawnManager;
    public PlayerCursor playerCursor;
    public GameUIHandler gameUIHandler;

    void Update()
    {
        if (pedestal.isDead)
        {
            gameOver.SetActive(true);
            spawnManager.gameOver = true;
            playerCursor.gameOver = true;
            gameUIHandler.gameOver = true;
        }
    }

}
