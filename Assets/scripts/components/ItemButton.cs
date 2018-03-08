using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {
    private LogoController logoController;
    private OrderController orderController;
    private RestController restController;
    public Image image;
    public Text text;
    public Button button;
    public string id;
    private string name;

	// Use this for initialization
	void Start () {
        logoController = GameObject.FindObjectOfType<LogoController>();
        orderController = GameObject.FindObjectOfType<OrderController>();
        restController = GameObject.FindObjectOfType<RestController>();
        button.onClick.AddListener(delegate{onClick(id);});
    }

    public void Setup(List<Item> availableItems)
    {
        foreach (Item itm in availableItems)
        {
            if (itm.id.Equals(id))
            {
                this.name = itm.name;
                this.text.text = itm.name;
            }
        }
    }

    public void Setup()
    {
        Debug.Log("The detected id is: " + id);
        Item item = restController.GetItemWithId(id);
        Debug.Log("This item is named: " + item.name);
        if (item != null)
        {
            this.name = item.name;
            this.text.text = item.name;
        }
    }

	public void SetUp(string id, string name, Sprite logo)
    {
        this.id = id;
        this.name = name;
        this.image.sprite = logo;
        this.text.text = name;
    }

    void onClick(string id)
    {
        Debug.Log("Clicked item button with id: " + id);
        orderController.addItemToCurrentOrder(id);
    }
}
