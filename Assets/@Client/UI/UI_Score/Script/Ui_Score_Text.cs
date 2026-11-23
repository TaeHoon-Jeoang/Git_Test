using UnityEngine;
using UnityEngine.UI;
public class Ui_Score_Text : MonoBehaviour
{
    Text text =null;
    private void Awake()
    {
        text = this.GetComponent<Text>();        
    }
    void Start()
    {
        text.text = "Score : 0";
    }

    public void SetText(string msg)
    {                
        text.text = msg;
    }
}
