using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class UiInvenSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI textMeshProUGUI;

    private SaveItemData itemData;

    public void SetEmpty()
    {
        icon.sprite = null;
        textMeshProUGUI.text = string.Empty;
    }

    public void SetItem(SaveItemData data)
    {
        this.itemData = data;

        icon.sprite = data.itemId.SpriteIcon;
        textMeshProUGUI.text = data.itemId.StringName;
    }
}
