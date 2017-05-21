using UnityEngine;

public class UtilHelper {
    public static T AddScript<T>(Transform transform) where T : UnityEngine.Component {
        GameObject obj = new GameObject(typeof(T).ToString(), typeof(T));
        obj.transform.parent = transform;
        return obj.GetComponent<T>();
    }
}
