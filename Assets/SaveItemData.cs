using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class SaveItemData
{
    public Guid instanceId;
    public DateTime creationTime;

    [JsonConverter(typeof(ItemDataConvertor))]
    public ItemData itemId;

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;
    }
}