using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class OrderedItem
{
    public string id;
    public long amount;

    public OrderedItem(string id)
    {
        this.id = id;
        amount = 1;
    }
}

