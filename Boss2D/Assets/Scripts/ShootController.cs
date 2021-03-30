using UnityEngine;

public class ShootController : MonoBehaviour {

    GameManager gm;

    // Use this for initialization
    void Start() {
        gm = GameManager.GetInstance();
        transform.position += new Vector3(1.1f , 0, 0);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!( collision.gameObject is null )) {
            if (collision.CompareTag("Player1")) {
                gm.player1.OnHit();
            }
            if (collision.CompareTag("Player2")) {
                gm.player2.OnHit();
            }
        }
    }

    private void Update() {
        transform.position += new Vector3(5f , 0 , 0) * Time.deltaTime;
    }
}