using UnityEngine;
using System;
public class SaveItemData
{
    public Guid instanceId;
    public DateTime creationTime;
    public ItemData itemId;

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;
    }
}