using UnityEngine.Serialization;

[System.Serializable]
public class ItemInstance
{
    [FormerlySerializedAs("itemType")] public GunData gunType;

    public ItemInstance(GunData gunData)
    {
        gunType = gunData;
    }
}
