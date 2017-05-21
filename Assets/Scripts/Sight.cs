using UnityEngine;
using System.Collections;

// Hosung Cha

public class Sight : MonoBehaviour {

    public float sight;
    public bool sightGizmos = true;

    private Light _light = null;

    private GameObject ghost = null;
    private SpriteRenderer ghostSpriteRenderer = null;

	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
        sight = Vector3.Distance(transform.parent.localPosition, _light.transform.localPosition) * Mathf.Tan(Mathf.Deg2Rad * (_light.spotAngle / 2));

        // ghost = GameObject.Find("Ghost");
        // ghostSpriteRenderer = ghost.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.z = 0;

        // 귀신이 시야 내에 들어오면 귀신을 볼 수 있다.
        //if (Vector3.Distance(pos, ghost.transform.position) < sight) {
        //    ghostSpriteRenderer.enabled = true;
        //}
        //else {
        //    ghostSpriteRenderer.enabled = false;
        //}
	}

    void OnDrawGizmosSelected() {
        if (!sightGizmos)
            return;

        _light = GetComponent<Light>();
        if (_light) {
            sight = Vector3.Distance(transform.parent.localPosition, _light.transform.localPosition) * Mathf.Tan(Mathf.Deg2Rad * (_light.spotAngle / 2));
        }
            
        Vector3 pos = transform.position;
        pos.z = 0;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + new Vector3(Mathf.Cos(Mathf.Deg2Rad * 135) * sight, Mathf.Sin(Mathf.Deg2Rad * 135) * sight, 0));
    }
}
