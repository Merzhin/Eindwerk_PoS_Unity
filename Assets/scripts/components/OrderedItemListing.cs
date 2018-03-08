using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderedItemListing : MonoBehaviour {
    private string id;
    public Text nameText;
    public Text amountText;
    public Button removeOneButton;
    private RestController restController;
    private OrderController orderController;

	// Use this for initialization
	void Start () {
        restController = GameObject.FindObjectOfType<RestController>();
        orderController = GameObject.FindObjectOfType<OrderController>();
        removeOneButton.onClick.AddListener(delegate { onClick(id); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setup(string id, int amount)
    {
        restController = GameObject.FindObjectOfType<RestController>();
        this.id = id;
        foreach (Item item in restController.AvailableItems())
        {
            if (item.id.Equals(id))
            {
                nameText.text = item.name;
                amountText.text = amount.ToString();
                break;
            }
        }
    }

    void onClick(string id)
    {
        Debug.Log("removing button with id: " + id);
        orderController.RemoveOneOfItem(id);
    }
}
