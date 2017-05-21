using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryItemSlot : MonoBehaviour {

    private int m_slotIndex = -1;
    public int m_SlotIndex { get { return m_slotIndex; } }

    [SerializeField]
    private Text m_itemNameText;

    public System.Action<int> m_clickEvent;

    public void InitalizeSlot(int _slotIndex , System.Action<int> _clickEvent)
    {
        m_slotIndex = _slotIndex;
        m_clickEvent = _clickEvent;
    }

    public void ClickSlot()
    {
        if(m_clickEvent != null)
            m_clickEvent(m_slotIndex);
    }


    public void SetItemName(string _itemName)
    {
        m_itemNameText.text = _itemName;
    }
}
