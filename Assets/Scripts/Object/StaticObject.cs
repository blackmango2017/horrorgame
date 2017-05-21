using UnityEngine;
using System.Collections;

public class StaticObject : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start () {
        _spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (transform.position.y < collision.transform.position.y) {
            ++_spriteRenderer.sortingOrder;
        } else {
            --_spriteRenderer.sortingOrder;
        }
    }
}
