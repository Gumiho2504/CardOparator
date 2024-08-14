using UnityEngine;
using UnityEngine.UI;
public class InforGame : MonoBehaviour
{
    public GameObject column;
    public Sprite[] cards;


    private void Start()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            GameObject c = Instantiate(column, transform.localPosition, Quaternion.identity) ;
            c.SetActive(true);
            c.transform.SetParent(GameObject.FindGameObjectWithTag("Parent").transform, false);
            c.transform.GetChild(0).GetComponent<Image>().sprite = cards[i];
            c.transform.GetChild(2).GetComponent<Text>().text = (i+1).ToString();
        }
    }

}
