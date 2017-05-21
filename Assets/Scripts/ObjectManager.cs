using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

    public Player player;

	void Start () {
	
	}
	
	void Update () {
	
	}
    public void StaticObjectManage() {
        //switch(name)
        //    case:
        // ToDo(SHBoo) 스위치 정리
    }


    public void MoveByDoor(int doorNum, Vector2 endPos) {
        player.transform.position = endPos;
    }
    
}
