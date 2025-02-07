using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;
using System.Collections.Generic;

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

    [Header("Peek Panel References")]
    public GameObject peekPanel;
    public RectTransform peekPanelMarblesParent;    // The "Content" object with the Layout Group
    public GameObject marbleCellPrefab;    // Prefab for displaying a single marble

    private bool isPeekPanelOpen = false;

    public void StartUpUI()
    {
        drawResultImage.enabled = false;
        marbleAddedFloatText.enabled = false;
        peekPanel.SetActive(false);
    }

    public void DrewAMarbleUI(Marble marble)
    {
        
        if (!drawResultImage.enabled) drawResultImage.enabled = true;
        if (!marbleAddedFloatText.enabled) marbleAddedFloatText.enabled = true;
        drawResultImage.sprite = marble.sprite;
        marbleAddedFloatText.text = $"Drew a {marble.color} marble!";
    }

    public void AddedAMarbleUI(string color) 
    {
        marbleAddedFloatText.text = $"Added a {color} marble!";
    }

    public void BagEmptyUI()
    {
        if (!marbleAddedFloatText.enabled) marbleAddedFloatText.enabled = true;
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

    public void TogglePeekPanel(List<Marble> marbles)
    {
        isPeekPanelOpen = !isPeekPanelOpen;
        peekPanel.SetActive(isPeekPanelOpen);

        // If we just opened it, populate it with marbles
        if (isPeekPanelOpen)
        {
            RebuildMarblesList(marbles);
        }
    }

    public void UpdatePeekPanelIfOpen(List<Marble> marbles)
    {
        if (isPeekPanelOpen)
        {
            RebuildMarblesList(marbles);
        }
    }

    // Destroys existing marble cells and rebuilds them from the provided list
    private void RebuildMarblesList(List<Marble> marbles)
    {
        // 1. Clear existing children
        foreach (Transform child in peekPanelMarblesParent)
        {
            Destroy(child.gameObject);
        }

        // 2. Instantiate a new cell for each marble in the bag
        foreach (Marble marble in marbles)
        {
            GameObject cell = Instantiate(marbleCellPrefab, peekPanelMarblesParent);
            // If your marbleCellPrefab has an Image component, set its sprite:
            Image cellImage = cell.GetComponent<Image>();
            if (cellImage != null)
            {
                cellImage.sprite = marble.sprite;
                // Optionally color it or do something else
            }

            // If there's a child Text, you can set the text to the color name
            TextMeshPro textComponent = cell.GetComponentInChildren<TextMeshPro>();
            if (textComponent != null)
            {
                textComponent.text = marble.color.ToString();
            }
        }
    }
}


