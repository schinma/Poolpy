using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[Serializable]
public class SpriteType
{
    public PickUp.PickUpType type;
    public Sprite sprite;
}

public class PlayerInventoryDisplay : MonoBehaviour 
{
    private int nbSlots;

    public Text[] countSlot;
    public Image[] imageSlots;
    public SpriteType[] sprites;

    private Dictionary<PickUp.PickUpType, Sprite> spriteDictionnary = new Dictionary<PickUp.PickUpType, Sprite>();

    public void Start()
    {
        nbSlots = countSlot.Length;
        for(int i = 0; i < nbSlots; i ++)
        {
            countSlot[i].text = "";
        }
        foreach(SpriteType sp in sprites)
        {
            spriteDictionnary[sp.type] = sp.sprite;

        }   
    }

    public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> inventory)
	{
        int i = 0;
        foreach (var item in inventory)
        {
            countSlot[i].text = item.Value.ToString();
            if (item.Value > 0)
            {
                imageSlots[i].sprite = spriteDictionnary[item.Key];
            }
            i++;    
        }
	}
}
