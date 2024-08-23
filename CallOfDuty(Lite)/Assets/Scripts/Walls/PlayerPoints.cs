using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    public int currentPoints = 0;
    public TMP_Text pointsText;

    void Start()
    {
        UpdatePointsText();
    }

    public void AddPoints(int amount)
    {
        currentPoints += amount;
        Debug.Log("Points added: " + amount);
        UpdatePointsText();
    }

    public void SpendPoints(int amount)
    {
        if (currentPoints >= amount)
        {
            currentPoints -= amount;
            Debug.Log("Points spent: " + amount);
            UpdatePointsText();
        }
        else
        {
            Debug.Log("Not enough points to spend.");
        }
    }

    void UpdatePointsText()
    {
        pointsText.text = "Your Points: " + currentPoints.ToString();
    }
}
