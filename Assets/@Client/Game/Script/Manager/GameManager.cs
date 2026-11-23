using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player = null;
    private EnemyManager enemyManager = null;
    private UiManager uiManager =null;

    [SerializeField] private int score = 0;

    private void Awake()
    {
        player = GetComponentInChildren<Player>();
        enemyManager = GetComponentInChildren<EnemyManager>();
        uiManager = GetComponentInChildren<UiManager>();
    }

    private void Start()
    {
        player.Init(OnGameOver);
        enemyManager.Init(player, AddScore);
        uiManager.Init();
    }
    private void OnGameOver()
    {
        uiManager.ShowGameOverUi();
        Time.timeScale=0f;
    }
    private void ClearGame()
    {
        uiManager.ShowGameClearUi();
        Time.timeScale=0f;
    }

    private void AddScore(int score)
    {
        this.score += score;
        uiManager.UpdateScoreUI(this.score);
        if (this.score >= 100)
        {
            ClearGame();
        }
    }
}
