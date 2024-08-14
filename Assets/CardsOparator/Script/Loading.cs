using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    float value = 0;
    [SerializeField] Slider slider;
    IEnumerator Start()
    {
        while(value < 1)
        {
            int speed = Random.Range(10, 20);
            value += speed * Time.deltaTime;
            slider.value = value;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  
}
