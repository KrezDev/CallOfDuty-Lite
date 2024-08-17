using UnityEditor;
using UnityEngine;

public class WallItem : MonoBehaviour
{
    public string itemName = "WeaponName";
    public int itemCost = 1000;
    public GameObject itemPrefab;

    private PlayerPoints playerPoints;
    private bool isPlayerInRange = false;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPoints = player.GetComponent<PlayerPoints>();
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TryBuyItem();
        }
    }

    void TryBuyItem()
    {
        if (playerPoints != null && playerPoints.currentPoints >= itemCost)
        {
            playerPoints.SpendPoints(itemCost);
            itemPrefab.SetActive(true);
            Debug.Log(itemName + " purchased!");
        }
        else
        {
            Debug.Log("Not enough points to buy " + itemName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered the purchase zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player left the purchase zone.");
        }
    }
}
