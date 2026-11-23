using UnityEngine;

public class UI_Score : MonoBehaviour
{
    //UIManager를 통해서
    //UI_Score 그 점수를 전달
    //UI_Score 는 자식에 있는 UI_Score_Text를 Score : 10 이런식으로 바꿔주면 됨

    private Ui_Score_Text text_score =null;

    void Awake()
    {
        text_score = this.GetComponentInChildren<Ui_Score_Text>();
    }
    public void UpdateScore(int score)
    {        
        text_score.SetText($"Score : {score}");
    }
}
