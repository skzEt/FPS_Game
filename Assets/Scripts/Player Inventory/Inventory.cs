using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    private int maxItems = 5;
    public List<ItemInstance> items = new();

    public bool addItem(ItemInstance item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items.Add(item);
                return true;
            }
        }

        if (items.Count < maxItems)
        {
            items.Add(item);
            return true;
        }
        return false;
    }

    public void removeItem(ItemInstance item)
    {
        items.Remove(item);
    }
}
