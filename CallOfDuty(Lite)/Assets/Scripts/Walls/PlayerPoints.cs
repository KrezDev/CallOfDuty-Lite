using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int currentPoints = 0;

    public void AddPoints(int amount)
    {
        currentPoints += amount;
        Debug.Log("Points added: " + amount);
    }

    public void SpendPoints(int amount)
    {
        if (currentPoints >= amount)
        {
            currentPoints -= amount;
            Debug.Log("Points spent: " + amount);
        }
        else
        {
            Debug.Log("Not enough points to spend.");
        }
    }
}
