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
}
