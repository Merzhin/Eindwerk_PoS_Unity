using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class Order
{
    public Dictionary<string, int> orderedItems;

    public Order()
    {
        RenewOrder();
    }

    private void RenewOrder()
    {
        orderedItems = new Dictionary<string, int>();
    }

    public void AddItem(string id)
    {
        bool newItem = true;
        foreach (string itemId in orderedItems.Keys)
        {
            if (itemId.Equals(id))
            {
                newItem = false;
                orderedItems[id] += 1;
                break;
            }
        }
        if (newItem)
        {
            orderedItems.Add(id, 1);
        }
    }

    public void RemoveOneOfItem(string id)
    {
        foreach (KeyValuePair<string, int> itemListing in orderedItems)
        {
            if (itemListing.Key.Equals(id))
            {
                if (itemListing.Value == 1)
                {
                    orderedItems.Remove(id);
                } else
                {
                    orderedItems[id] -= 1;
                }
                break;
            }
        }
    }
}

