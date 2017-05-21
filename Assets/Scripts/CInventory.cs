using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CItem
{
    private string m_itemName;
    public string m_ItemName { get { return m_itemName; } }
    //private string m_itemSpritePath;

    public CItem(string _name)
    {
        m_itemName = _name;
    }

    public virtual bool UseItem()
    {
        Debug.Log("아이템 사용 :" + m_itemName);
        return true;
    }
}

public class CInventory 
{
    private int m_maxItemSlot = 5;
    
    private List<CItem> m_itemList = new List<CItem>();


    public int m_MaxItemSlot { get { return m_maxItemSlot; } }
    public int m_CurrentItemCount { get { return m_itemList.Count; } }


    public CInventory(int _maxSlot)
    {
        m_maxItemSlot = _maxSlot;
    }

    public void AddItem(CItem _item)
    {
        if(m_maxItemSlot <= m_itemList.Count)
        {
            //
            return;
        }

        m_itemList.Add(_item);
    }
    public void DeleteItem(int _index)
    {
        if (m_itemList.Count <= _index)
            return;
        m_itemList.RemoveAt(_index);
    }
    public void DeleteItem(string _itemName)
    {
        for(int i=0;i<m_itemList.Count;i++)
        {
            if (m_itemList[i].m_ItemName == _itemName)
            {
                m_itemList.RemoveAt(i);
                break;
            }
        }
    }

    public CItem GetItem(int _index)
    {
        if (m_itemList.Count <= _index)
            return null;
        return m_itemList[_index];
    }
    public CItem GetItem(string _itemName)
    {
        for (int i = 0; i < m_itemList.Count; i++)
        {
            if (m_itemList[i].m_ItemName == _itemName)
                return m_itemList[i];
        }
        return null;
    }

    public void UseItem(int _index)
    {
        if (m_itemList.Count <= _index)
            return;
        if(m_itemList[_index] != null)
            m_itemList[_index].UseItem();
    }
}
