using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SceneList {
    NONE,
    LOGO,
    TITLE,
    FLOOR1,
    FLOOR2,
    FLOOR3,
    END,
}

public enum Channel {
    C1,
    C2,
}

public class SceneController : Singleton<SceneController> {

    private Dictionary<SceneList, Scene> _sceneList = new Dictionary<SceneList, Scene>();

    private SceneList _currentScene = SceneList.NONE;
    
    public SceneList currentScene {
        get {
            return _currentScene;
        }
    }

	// Use this for initialization
	void Start () {
        Add<LogoScene>(SceneList.LOGO);
        Add<TitleScene>(SceneList.TITLE);
        Add<Floor1Scene>(SceneList.FLOOR1);
        Add<Floor2Scene>(SceneList.FLOOR2);
        Add<Floor3Scene>(SceneList.FLOOR3);

        ActiveScene(SceneList.LOGO);
	}

    // 씬 검색
    #region Search function
    public Scene GetScene(SceneList scene) {
        if (!_sceneList.ContainsKey(scene)) {
            return null;
        }

        return _sceneList[scene];
    }
    #endregion

    // 씬 추가
    #region Add function
    public void Add<T>(SceneList scene) where T : UnityEngine.Component {
        if (_sceneList.ContainsKey(scene)) {
            return;
        }

        Scene script = UtilHelper.AddScript<T>(transform) as Scene;
        script.Init();
        _sceneList.Add(scene, script);
    }
    #endregion

    // 씬 삭제
    #region Remove functions
    public void Remove(SceneList scene) {
        if (_sceneList.ContainsKey(scene)) {
            _sceneList.Remove(scene);
        }
    }

    public void Destroy(SceneList scene) {
        if (!_sceneList.ContainsKey(scene)) {
            return;
        }

        if (_sceneList[scene].gameObject != null) {
            DestroyImmediate(_sceneList[scene].gameObject);
        }
        Remove(scene);
    }

    public void Clear() {
        _sceneList.Clear();
    }
    #endregion

    public void ChangeScene(Channel channel) {
        SceneList prevScene = _currentScene;
        _currentScene = _sceneList[_currentScene].GetScene(channel);

        if (!_sceneList.ContainsKey(_currentScene)) {
            return;
        }

        _sceneList[prevScene].Exit();
        ActiveScene(_currentScene);
    }

    private void ActiveScene(SceneList scene) {
        if (!_sceneList.ContainsKey(scene)) {
            return;
        }

        foreach (KeyValuePair<SceneList, Scene> kVal in _sceneList) {
            if (kVal.Key == scene) {
                kVal.Value.gameObject.SetActive(true);
            } else {
                kVal.Value.gameObject.SetActive(false);
            }
        }

        _currentScene = scene;
        _sceneList[_currentScene].Enter();
    }
}
