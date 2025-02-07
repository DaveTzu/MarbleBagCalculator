using UnityEngine;
using UnityEngine.UI;

public class MarbleBagManager : MonoBehaviour
{
    [Header("Manager References")]
    public UIManager uiManager; // drag and drop from inspector
    public Button addRedButton;
    public Button addGreenButton;
    public Button addBlueButton;
    public Button addYellowButton;
    public Button addPurpleButton;
    public Button drawMarbleButton;

    // Optionally store the color-specific sprites here 
    // so the manager knows which sprite to pass to the bag
    public Sprite redSprite;
    public Sprite greenSprite;
    public Sprite blueSprite;
    public Sprite yellowSprite;
    public Sprite purpleSprite;

    // The actual data container for marbles
    private MarbleBag marbleBag;

    private void Awake()
    {
        marbleBag = new MarbleBag();

        // Hook up UI button clicks
        addRedButton.onClick.AddListener(() => AddMarble("Red"));
        addGreenButton.onClick.AddListener(() => AddMarble("Green"));
        addBlueButton.onClick.AddListener(() => AddMarble("Blue"));
        addYellowButton.onClick.AddListener(() => AddMarble("Yellow"));
        addPurpleButton.onClick.AddListener(() => AddMarble("Purple"));

        drawMarbleButton.onClick.AddListener(DrawMarble);

        uiManager.StartUpUI();
        UpdateUI();

    }

    private void AddMarble(string color)
    {
        // Decide which sprite to use
        Sprite chosenSprite = null;
        switch (color)
        {
            case "Red": chosenSprite = redSprite; break;
            case "Green": chosenSprite = greenSprite; break;
            case "Blue": chosenSprite = blueSprite; break;
            case "Yellow": chosenSprite = yellowSprite; break;
            case "Purple": chosenSprite = purpleSprite; break;
        }

        // Create a new Marble and add it to the bag
        Marble newMarble = new Marble(color, chosenSprite);
        marbleBag.AddMarble(newMarble);

        // After adding, update the UI
        uiManager.AddedAMarbleUI(newMarble.color);
        UpdateUI();
    }

    private void DrawMarble()
    {
        Marble drawn = marbleBag.DrawRandomMarble();
        if (drawn == null)
        {
            // No marbles left
            uiManager.BagEmptyUI();
        }
        else
        {
            // Let the UI know which marble was drawn
            uiManager.DrewAMarbleUI(drawn);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        // Ask the MarbleBag for updated percentages
        float redPct = marbleBag.GetPercentage("Red");
        float greenPct = marbleBag.GetPercentage("Green");
        float bluePct = marbleBag.GetPercentage("Blue");
        float yellowPct = marbleBag.GetPercentage("Yellow");
        float purplePct = marbleBag.GetPercentage("Purple");
        string totalMarbles = marbleBag.GetTotalMarbles().ToString();

        // Use the UIManager to refresh text fields
        uiManager.UpdateColorPercentages(redPct, greenPct, bluePct, yellowPct, purplePct, totalMarbles);
    }

    public void TogglePeekPanel()
    {
        uiManager.TogglePeekPanel(marbleBag.GetAllMarbles());
    }
}
