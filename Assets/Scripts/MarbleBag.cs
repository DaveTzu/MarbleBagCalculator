using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MarbleBag
{
    private List<Marble> marbles;

    public MarbleBag()
    {
        marbles = new List<Marble>();
    }

    public void AddMarble(Marble marble)
    {
        marbles.Add(marble);
    }

    public Marble DrawRandomMarble()
    {
        if (marbles.Count == 0)
            return null;

        int index = Random.Range(0, marbles.Count);
        Marble drawn = marbles[index];
        marbles.RemoveAt(index);
        return drawn;
    }

    public int GetTotalMarbles()
    {
        return marbles.Count;
    }

    public int GetCountByColor(string color)
    {
        int count = 0;
        foreach (Marble m in marbles)
        {
            if (m.color == color) count++;
        }
        return count;
    }

    public float GetPercentage(string color)
    {
        if (marbles.Count == 0) return 0f;
        float count = GetCountByColor(color);
        return (count / marbles.Count) * 100f;
    }
}

