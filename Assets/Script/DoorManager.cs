using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    private GameObject player;
    private Transform[] doorTr = new Transform[10]; // Transform도 배열이 되는가~!

    void Awake() {
        for (int i = 0; i < 10; i++) { //Door Transform 배열 초기화
            doorTr[i] = null;
        }
    }

    void Start() {
        //for(int i = 0; i < 10; i++) {
        //    doorTr[i] = GameObject.Find("door").GetComponentInChildren<Transform>();
        //}
        player = GameObject.FindGameObjectWithTag("Player");
        doorTr[0] = GameObject.Find("door1").GetComponentInChildren<Transform>(); //GetComponentInChildren을 이용해 trigger의 Transform을 배열에 저장
        doorTr[1] = GameObject.Find("door2").GetComponentInChildren<Transform>();
    }

    void Update() {

    }

    public void MoveByDoor(string doorNum) {

        switch (doorNum) {
            case "door1":
                player.transform.position = new Vector2(doorTr[1].position.x, doorTr[1].position.y);
                break;
            case "door2":
                player.transform.position = new Vector2(doorTr[0].position.x, doorTr[0].position.y);
                break;
        }
    }

}