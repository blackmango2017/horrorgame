using UnityEngine;
using System.Collections;

// Hosung Cha.

public class Ghost : MonoBehaviour {

    public Transform player;

    private SpriteRenderer spriteRenderer = null;
    private float stoppingDistance = 0.7f;
    private float speed = 1.5f;

    public float appearTime = 60.0f;        // 게임이 시작한 후에 귀신이 등장하는 시간. (appearTime 초 후에 등장함.)
    private bool isWake = false;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;     // 귀신은 캐릭터와 일정거리가 되어야 보이므로 스프라이트를 끈다.

        StartCoroutine(WakeUp(appearTime));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isWake) {
            return;
        }

        // 플레이어에게 간다.
        if (Vector3.Distance(player.position, transform.position) > stoppingDistance)
            transform.Translate((player.position - transform.position) * Time.deltaTime * speed);
	}

    private IEnumerator WakeUp(float seconds) {
        yield return new WaitForSeconds(seconds);
        isWake = true;
    }
}
