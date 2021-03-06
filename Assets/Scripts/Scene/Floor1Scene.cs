﻿using UnityEngine;
using System.Collections;

public class Floor1Scene : Scene {

    protected override void Register() {
        channelList.Add(Channel.C1, SceneList.FLOOR2);
    }

    public override void Enter() {
        StartCoroutine(IELoadAsync(SceneList.FLOOR1.ToString(), GameManager.instance.InitSetup));
    }

    public override void Exit() {
        GameManager.instance.Clear();
    }

    private void OnGUI() {
        GUI.Box(new Rect(10, 10, 100, 20), "Floor 1");
    }
}
