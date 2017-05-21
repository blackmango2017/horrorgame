using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScene : MonoBehaviour {

    public void LoadScene(string sceneName) {
        StartCoroutine(sceneName);
    }

    private IEnumerator IELoadAsync(string sceneName) {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone) {
            yield return null;
        }

        // asyncOperation.allowSceneActivation = true;
    }
}
