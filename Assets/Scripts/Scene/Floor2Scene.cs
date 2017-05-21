using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor2Scene : Scene {

    protected override void Register() {
        channelList.Add(Channel.C1, SceneList.FLOOR3);
        channelList.Add(Channel.C2, SceneList.FLOOR1);
    }

    public override void Enter() {
        StartCoroutine(IELoadAsync(SceneList.FLOOR2.ToString(), GameManager.instance.InitSetup));
    }

    public override void Exit() {
        GameManager.instance.Clear();
    }

    private void OnGUI() {
        GUI.Box(new Rect(10, 10, 100, 20), "Floor 2");
    }
}
