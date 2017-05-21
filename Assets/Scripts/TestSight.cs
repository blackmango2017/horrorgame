using UnityEngine;
using System.Collections;

public class TestSight : MonoBehaviour {

    public int width = 512;
    public int height = 512;

    public float radius = 64.0f;
    public float factor = 5.0f;

    private GameObject player;

    private Texture2D effectTex;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        effectTex = new Texture2D(width, height);

        int pivotX = width / 2;
        int pivotY = height / 2;

        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
                effectTex.SetPixel(x, y, Color.black);
        }

        int min = (int)(height / 2 - radius);
        int max = (int)(height / 2 + radius);

        for (int y = min; y < max; ++y)
        {
            for (int x = min; x < max; ++x)
            {
                float pos = Mathf.Pow(x - pivotX, 2) + Mathf.Pow(y - pivotY, 2);

                if (pos < radius * radius)
                {
                    Color color = Color.yellow;
                    color.a = Mathf.Lerp(0.0f, 1.0f, pos / (radius * radius * factor));
                    effectTex.SetPixel(x, y, color);
                }
            }
        }

        effectTex.Apply();

        GetComponent<SpriteRenderer>().sprite = Sprite.Create(effectTex, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
    }
}
