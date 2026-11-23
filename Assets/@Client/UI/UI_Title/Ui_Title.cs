using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Ui_Title : MonoBehaviour
{
    private Ui_Title_GameStart ui_game_start;
    void Awake()
    {
        ui_game_start = GetComponentInChildren<Ui_Title_GameStart>();
    }
    void Start()
    {
        ui_game_start.SetEvent(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
