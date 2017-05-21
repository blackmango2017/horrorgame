using UnityEngine;
using System.Collections;

public class LogoScene : Scene {

    protected override void Register() {
        channelList.Add(Channel.C1, SceneList.TITLE);
    }

    public override void Enter() {
        StartCoroutine(IELoadAsync(SceneList.LOGO.ToString()));
        StartCoroutine(NextScene(1.0f));
    }

    public override void Exit() {
        
    }

    private IEnumerator NextScene(float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneController.instance.ChangeScene(Channel.C1);
    }
}
