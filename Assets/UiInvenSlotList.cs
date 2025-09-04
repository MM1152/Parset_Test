using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class UiInvenSlotList : MonoBehaviour
{
    public int SlotIndex { get; set; }

    public UiInvenSlot prefab;
    public ScrollRect scrollRect;

    private List<UiInvenSlot> slotList = new List<UiInvenSlot>();
    public ItemData ItemData { get; private set; }

    public int maxCount = 30;
    private int itemCount = 0;

    private List<SaveItemData> testItemList = new List<SaveItemData>();
    private void Start()
    {
        for (int i = 0; i < maxCount; ++i)
        {
            var newSlot = Instantiate(prefab, scrollRect.content);
            newSlot.SetEmpty();
            slotList.Add(newSlot);
            slotList[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddRandomItem();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RemoveItem(0);
        }
    }

    private void UpdateSlots(List<SaveItemData> itemList)
    {
        if (itemList.Count > slotList.Count)
        {
            for (int i = slotList.Count; i < itemList.Count; ++i)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.SetEmpty();
                slotList.Add(newSlot);
                slotList[i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < slotList.Count; i++)
        {
            if (i < itemList.Count)
            {
                slotList[i].SetItem(itemList[i]);
                slotList[i].gameObject.SetActive(true);
            }
            else
            {
                slotList[i].SetEmpty();
                slotList[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddRandomItem()
    {
        var itemInstance = new SaveItemData();
        itemInstance.itemId =  DataTableManger.ItemTable.GetRandom();
        testItemList.Add(itemInstance);
        UpdateSlots(testItemList);
    }

    public void RemoveItem(int slotIndex)
    {
        testItemList.RemoveAt(slotIndex);
        UpdateSlots(testItemList);
    }
}
