using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour {

	[SerializeField] private Transform m_gridTrans;

    public GameObject m_itemSlotPrefab;


    private bool m_firstOpenInventory = false;
    public InventoryItemSlot[] m_inventorySlots; 


    public void InitailzeInventory()
    {
        m_inventorySlots = new InventoryItemSlot[CUserDataTable.Inst.m_userInventory.m_MaxItemSlot];
        for(int i=0;i<m_inventorySlots.Length;i++)
        {
            m_inventorySlots[i] = Instantiate(m_itemSlotPrefab).GetComponent<InventoryItemSlot>();
            m_inventorySlots[i].InitalizeSlot(i, OnClickSlot);
            m_inventorySlots[i].transform.SetParent(m_gridTrans);
            m_inventorySlots[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void UpdateSlot()
    {
        for (int i = 0; i < m_inventorySlots.Length; i++)
        {
            if(i < CUserDataTable.Inst.m_userInventory.m_CurrentItemCount)
            {
                m_inventorySlots[i].SetItemName(CUserDataTable.Inst.m_userInventory.GetItem(m_inventorySlots[i].m_SlotIndex).m_ItemName);
                continue;
            }
            m_inventorySlots[i].SetItemName("없음");
        }
    }

    public void OnClickSlot(int _slotIndex)
    {
        CUserDataTable.Inst.m_userInventory.UseItem(_slotIndex);
    }

    public void OpenInventory()
    {
        if (!m_firstOpenInventory)
        {
            m_firstOpenInventory = true;
            InitailzeInventory();
        }
            
        UpdateSlot();
        this.gameObject.SetActive(true);
    }
    public void CloseInventory()
    {
        this.gameObject.SetActive(false);
    }
    
}
