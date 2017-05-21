using UnityEngine;
using System.Collections;

public class GetItemObject : MonoBehaviour {

    public string m_itemName;
    private bool m_isGot = false;

    public void GetItem()
    {
        if(m_isGot == false)
        {
            m_isGot = true;
            CUserDataTable.Inst.m_userInventory.AddItem(CItemDataTable.Inst.GetData(m_itemName));

            Debug.Log("아이템 획득");
        }
    }
}
