using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

    private static volatile T _uniqueInstance = null;
    private static volatile GameObject _uniqueObject = null;

    public static T instance {
        get {
            if (_uniqueInstance == null) {
                lock (typeof(T)) {
                    if (_uniqueInstance == null && _uniqueObject == null) {
                        _uniqueObject = new GameObject(typeof(T).Name, typeof(T));
                        _uniqueInstance = (T)_uniqueObject.GetComponent(typeof(T));

                        DontDestroyOnLoad(_uniqueObject);
                        _uniqueInstance.Init();
                    }
                }
            }

            return _uniqueInstance;
        }
    }

    protected virtual void Init() {
        
    }
}
