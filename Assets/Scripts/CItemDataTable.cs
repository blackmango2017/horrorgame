using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CItemDataTable 
{
    private static CItemDataTable inst;
    public static CItemDataTable Inst
    {
        get
        {
            if (inst == null)
            {
                inst = new CItemDataTable();
            }
            return inst;
        }
    }

    private Dictionary<short, CItem> m_itemDataDic = new Dictionary<short, CItem>();



    public CItemDataTable()
    {
        m_itemDataDic.Add(1000, new CItem("테스트용아이템1"));
        m_itemDataDic.Add(1001, new CItem("테스트용아이템2"));
        m_itemDataDic.Add(1002, new CItem("테스트용아이템3"));
        m_itemDataDic.Add(1003, new CItem("테스트용아이템4"));
        m_itemDataDic.Add(1004, new CItem("테스트용아이템5"));
    }


    public CItem GetData(short _id)
    {
        if(m_itemDataDic.ContainsKey(_id))
            return m_itemDataDic[_id];
        return null;
    }
    public CItem GetData(string _itemName)
    {
        foreach(var i in m_itemDataDic)
        {
            if (i.Value.m_ItemName == _itemName)
                return i.Value;
        }
        return null;
    }



}
