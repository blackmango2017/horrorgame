using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScene : Scene {

    protected override void Register() {
        channelList.Add(Channel.C1, SceneList.FLOOR2);
    }

    public override void Enter() {
        StartCoroutine(IELoadAsync(SceneList.TITLE.ToString()));
        StartCoroutine(NextScene(3.0f));
    }

    public override void Exit() {
        
    }

    private IEnumerator NextScene(float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneController.instance.ChangeScene(Channel.C1);
    }
}
