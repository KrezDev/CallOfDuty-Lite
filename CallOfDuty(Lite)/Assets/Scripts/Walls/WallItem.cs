using UnityEngine;

public class WallItem : MonoBehaviour
{
    public string itemName = "Box";
    public int itemCost = 1000;
    public GameObject itemPrefab;

    private PlayerPoints playerPoints;
    private bool isPlayerInRange = false;

    void Start()
    {
        if (itemPrefab != null)
        {
            itemPrefab.SetActive(false);
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPoints = player.GetComponent<PlayerPoints>();
            if (playerPoints == null)
            {
                Debug.LogError("PlayerPoints component not found on Player object.");
            }
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
        if (playerPoints != null)
        {
            if (playerPoints.currentPoints >= itemCost)
            {
                playerPoints.SpendPoints(itemCost);

                if (itemPrefab != null)
                {
                    itemPrefab.SetActive(true);
                }

                Debug.Log(itemName + " purchased and enabled!");
            }
            else
            {
                Debug.Log("Not enough points to buy " + itemName);
            }
        }
        else
        {
            Debug.LogError("PlayerPoints reference is missing.");
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
