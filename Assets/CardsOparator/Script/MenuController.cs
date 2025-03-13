using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MenuController : MonoBehaviour
{
    public static GameState gameState;
    public void GoTo(string name)
    {

        AudioController.Instance.PlaySFX("tap");
        StartCoroutine(loadSceneAnimator(name));
        switch (name)
        {
            case "easy":
                gameState = GameState.easy;
                break;
            case "hard":
                gameState = GameState.hard;
                break;
            default:
                gameState = GameState.veryhard;
                break;
        }
    }


    IEnumerator loadSceneAnimator(string name)

    {
        
        GameObject cavas = GameObject.Find("game-canvas");
        
        while (cavas.GetComponent<CanvasGroup>().alpha > 0)
        {
            
            cavas.GetComponent<CanvasGroup>().alpha -= 10 *Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(name.ToUpper());

    }

    public void Quit()
    {
        Application.Quit();
    }

public GameObject settingPanel;
    public void OnOpenSettingPanel()
    {
        AudioController.Instance.PlaySFX("tap");
        GameObject panel = settingPanel.transform.GetChild(0).gameObject;
        settingPanel.LeanMoveLocalY(0,0.3f).setFrom(Screen.height * 2f)
        .setEaseInExpo()
        .setOnComplete(() => panel.LeanScale(Vector3.one, 0.2f).setEaseOutBack());
        
    }

     public void OnCloseSettingPanel()
    {
        AudioController.Instance.PlaySFX("tap");
        GameObject panel = settingPanel.transform.GetChild(0).gameObject;
        panel.LeanScale(Vector3.zero, 0.2f).setEaseOutBack()
        .setEaseInExpo()
        .setOnComplete(() => settingPanel.LeanMoveLocalY(Screen.height * 2f,0.3f).setFrom(0f));
        
    }
}
