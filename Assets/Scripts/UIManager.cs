using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]

    public TextMeshProUGUI marbleAddedFloatText;
    public TextMeshProUGUI totalMarblesText;
    public Button drawMarbleButton;

    public Button addRedButton;
    public Button addGreenButton;
    public Button addBlueButton;
    public Button addYellowButton;
    public Button addPurpleButton;

    public TextMeshProUGUI redPercentageText;
    public TextMeshProUGUI greenPercentageText;
    public TextMeshProUGUI bluePercentageText;
    public TextMeshProUGUI yellowPercentageText;
    public TextMeshProUGUI purplePercentageText;

    public Image drawResultImage;

    public void StartUpUI()
    {
        drawResultImage.enabled = false;
    }



    public void DrewAMarbleUI(Marble marble)
    {
        marbleAddedFloatText.text = $"Drew a {marble.color} marble!";
        if (!drawResultImage.enabled) drawResultImage.enabled = true;
        drawResultImage.sprite = marble.sprite;
    }

    public void AddedAMarbleUI(string color) 
    {
        marbleAddedFloatText.text = $"Added a {color} marble!";
    }

    public void BagEmptyUI()
    {
        marbleAddedFloatText.text = $"Oops.  The bag is empty.";
    }

    public void SetDrawnMarbleSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            drawResultImage.sprite = null;
        }
        else
        {
            drawResultImage.sprite = sprite;
            //drawResultImage.color = Color.white; // ensure it's visible
        }
    }

    public void UpdateColorPercentages(
       float redPercent,
       float greenPercent,
       float bluePercent,
       float yellowPercent,
       float purplePercent,
       string totalMarbles)

    {
        redPercentageText.text = $"{redPercent:F2}%";
        greenPercentageText.text = $"{greenPercent:F2}%";
        bluePercentageText.text = $"{bluePercent:F2}%";
        yellowPercentageText.text = $"{yellowPercent:F2}%";
        purplePercentageText.text = $"{purplePercent:F2}%";
        totalMarblesText.text = $"Marbles in the bag: {totalMarbles}";
    }
}

