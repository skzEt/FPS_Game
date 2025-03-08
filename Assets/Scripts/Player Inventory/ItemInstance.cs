[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    public int condition;
    public int ammount;

    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
    }
}