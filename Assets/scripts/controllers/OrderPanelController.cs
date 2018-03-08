using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPanelController : MonoBehaviour {
    public Transform contentPanel;
    public GameObject itemListingPrefab;
    private RestController rest;
    private OrderController orderController;
    private List<GameObject> ItemListings;

    // Use this for initialization
    void Start()
    {
        ItemListings = new List<GameObject>();
        rest = GameObject.FindObjectOfType<RestController>();
        orderController = GameObject.FindObjectOfType<OrderController>();
    }

    public void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        foreach (GameObject obj in ItemListings)
        {
            GameObject.Destroy(obj);
        }
    }

    private void AddButtons()
    {
        foreach (KeyValuePair<string, int> item in orderController.currentOrder.orderedItems)
        {
            GameObject newListing = GameObject.Instantiate(itemListingPrefab);
            newListing.transform.SetParent(contentPanel);
            newListing.GetComponent<OrderedItemListing>().Setup(item.Key, item.Value);
            ItemListings.Add(newListing);
        }
    }
}
