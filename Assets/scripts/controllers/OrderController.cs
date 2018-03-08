using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour {
    [HideInInspector]
    public Order currentOrder;
    private RestController restController;
    private ItemController itemController;
    private OrderPanelController orderPanelController;
    public Text totalPriceNumberText;
    private double totalPrice;

	// Use this for initialization
	void Start () {
        restController = GameObject.FindObjectOfType<RestController>();
        itemController = GameObject.FindObjectOfType<ItemController>();
        orderPanelController = GameObject.FindObjectOfType<OrderPanelController>();
        NewOrder();
	}
	
	private void NewOrder()
    {
        currentOrder = new Order();
        totalPrice = 0;
        UpdateTotalPriceText();
        orderPanelController.RefreshDisplay();
    }

    public void addItemToCurrentOrder(string id)
    {
        Debug.Log("Adding item with id " + id + " to the current order.");
        currentOrder.AddItem(id);
        totalPrice += itemController.getPriceOfItem(id);
        UpdateTotalPriceText();
        orderPanelController.RefreshDisplay();
    }

    public void CloseOrder()
    {
        Debug.Log("Closing order");
        restController.UploadOrder(currentOrder);
        NewOrder();
    }

    private void UpdateTotalPriceText()
    {
        totalPriceNumberText.text = "€ "+totalPrice.ToString();
    }

    public int getAmountOfUniqueItemsInOrder()
    {
        return currentOrder.orderedItems.Count;
    }

    public void RemoveOneOfItem(string id)
    {
        currentOrder.RemoveOneOfItem(id);
        totalPrice -= itemController.getPriceOfItem(id);
        UpdateTotalPriceText();
        orderPanelController.RefreshDisplay();
    }
}
