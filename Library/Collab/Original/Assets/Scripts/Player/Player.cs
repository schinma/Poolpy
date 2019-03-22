using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int totalLives;

    private int remainingLives;
    private InventoryManager inventoryManager;
    private PlayerHeartDisplay playerHeartDisplay;

    void Start()
    {
        remainingLives = totalLives;
		inventoryManager = GetComponent<InventoryManager>();
        playerHeartDisplay = GetComponent<PlayerHeartDisplay>();
	}

	void OnTriggerEnter2D(Collider2D hit)
    {
		if(hit.CompareTag("PickUp")){
            PickUp item = hit.GetComponent<PickUp>();
            inventoryManager.Add(item);
            Destroy(hit.gameObject);
        } else if (hit.CompareTag("Heart"))
        {
            if (totalLives > remainingLives)
            {
                remainingLives++;
                playerHeartDisplay.OnChangeHeart(totalLives, remainingLives);
            }
            Destroy(hit.gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            if (remainingLives != 0)
            {
                remainingLives--;
                playerHeartDisplay.OnChangeHeart(totalLives, remainingLives);
            }
			if (remainingLives == 0)
			{
				SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
			}
        }
    }
}
