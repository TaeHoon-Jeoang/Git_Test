using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ui_Title_GameStart : MonoBehaviour
{
    private Button btn_start;

    void Awake()
    {
        btn_start = GetComponent<Button>();
    }

    public void SetEvent(UnityAction action)
    {
        btn_start.onClick.AddListener(action);
    }
    
}
