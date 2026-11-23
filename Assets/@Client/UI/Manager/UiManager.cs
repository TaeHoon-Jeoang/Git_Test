using UnityEngine;

public class UiManager : MonoBehaviour
{
    private UI_Score uiScore =null;
    private UI_GameClear uiGameClear= null;
    private UI_GameOver uiGameOver=null;    
    void Awake()
    {
        uiScore = this.GetComponentInChildren<UI_Score>();
        uiGameClear = this.GetComponentInChildren<UI_GameClear>();
        uiGameOver = this.GetComponentInChildren<UI_GameOver>();        
    }

    public void Init()
    {
        uiGameClear.gameObject.SetActive(false);
        uiGameOver.gameObject.SetActive(false);
    }
    public void UpdateScoreUI(int score)
    {
        uiScore.UpdateScore(score);
    }
    public void ShowGameOverUi()
    {
        uiGameOver.gameObject.SetActive(true);
    }
    public void ShowGameClearUi()
    {
        uiGameClear.gameObject.SetActive(true);
    }
}
