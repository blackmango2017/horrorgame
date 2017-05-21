using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Scene : MonoBehaviour {

    protected Dictionary<Channel, SceneList> channelList = new Dictionary<Channel, SceneList>();

    public virtual void Init() { Register(); }
    protected virtual void Register() { }
    public virtual void Enter() { }
    public virtual void Exit() { }

    protected IEnumerator IELoadAsync(string sceneName, System.Action afterFunc = null) {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone) {
            yield return null;
        }

        if (afterFunc != null) {
            afterFunc();
        }
    }

    public SceneList GetScene(Channel channel) {
        if (!channelList.ContainsKey(channel)) {
            return SceneList.NONE;
        }

        return channelList[channel];
    }
}
