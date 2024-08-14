using UnityEngine;


[System.Serializable]
public class Card
{
    public string name;
    public int value;
    public Sprite sprite;

    public Card(string name, int value, Sprite sprite)
    {
       this. name = name;
       this. value = value;
       this. sprite = sprite;
    }
}
