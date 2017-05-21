using UnityEngine;
using System.Collections;

public class CUserDataTable
{
    private static CUserDataTable inst;
    public static CUserDataTable Inst
    {
        get
        {
            if(inst == null)
            {
                inst = new CUserDataTable();
            }
            return inst;
        }
    }




    public CInventory m_userInventory = new CInventory(5);
}
