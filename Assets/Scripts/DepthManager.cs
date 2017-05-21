using UnityEngine;

public class DepthManager : MonoBehaviour {

    Transform player;
    SpriteRenderer playerSpriteRenderer;
    Bounds playerBound;

    Transform[] objects;
    SpriteRenderer[] objectSpriteRenderers;
    Bounds[] bounds;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSpriteRenderer= player.GetComponent<SpriteRenderer>();
        playerBound = playerSpriteRenderer.sprite.bounds;

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Object");
        objects = new Transform[temp.Length];
        for (int i = 0; i < temp.Length; ++i) {
            objects[i] = temp[i].transform;
        }

        objectSpriteRenderers = new SpriteRenderer[objects.Length];
        bounds = new Bounds[objects.Length];
        for (int i = 0; i < objects.Length; ++i) {
            objectSpriteRenderers[i] = objects[i].GetComponent<SpriteRenderer>();
            bounds[i] = objectSpriteRenderers[i].bounds;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < bounds.Length; ++i) {
            if (playerBound.Intersects(bounds[i])) {
                if (player.position.y < objects[i].position.y) {
                    objectSpriteRenderers[i].sortingOrder = playerSpriteRenderer.sortingOrder - 1;
                }
                else if (player.position.y > objects[i].position.y) {
                    objectSpriteRenderers[i].sortingOrder = playerSpriteRenderer.sortingOrder + 1;
                }
                else {
                    if (player.position.x < objects[i].position.x) {
                        objectSpriteRenderers[i].sortingOrder = playerSpriteRenderer.sortingOrder - 1;
                    }
                    else if (player.position.x > objects[i].position.x) {
                        objectSpriteRenderers[i].sortingOrder = playerSpriteRenderer.sortingOrder + 1;
                    }
                }
            }
        }
    }
}
