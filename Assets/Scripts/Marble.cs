using UnityEngine;

[System.Serializable]
public class Marble
{
    public string color;
    public Sprite sprite;  // optional: if you want a visual reference

    public Marble(string color, Sprite sprite = null)
    {
        this.color = color;
        this.sprite = sprite;
    }
}
