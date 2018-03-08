using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    private List<Item> mainItems;
    private List<Item> subItems;
    private RestController restController;

	// Use this for initialization
	void Start () {
        restController = GameObject.FindObjectOfType<RestController>();
        ClearItemLists();
	}
	
	private void ClearItemLists()
    {
        mainItems = new List<Item>();
        subItems = new List<Item>();
    }

    public void RebuildItemLists()
    {
        foreach (Item item in restController.AvailableItems())
        {
            if (item.isFavorite) mainItems.Add(item);
            else subItems.Add(item);
        }
    }

    public double getPriceOfItem(string id)
    {
        Debug.Log("Getting price of item with id " + id + ".");
        foreach (Item item in restController.AvailableItems())
        {
            if (item.id.Equals(id))
            {
                return item.price;
            }
        }
        return 0;
    }
}

