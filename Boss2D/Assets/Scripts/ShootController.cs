using UnityEngine;

public class ShootController : MonoBehaviour {

    GameManager gm;

    private Vector3 shootDir;

    public void Setup(Vector3 shootDir) {
        this.shootDir = shootDir;
    }

    void Start() {
        gm = GameManager.GetInstance();
        transform.position += new Vector3(1.1f , 0, 0);
    }

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
        float moveSpeed = 10f;
        transform.position += this.shootDir * moveSpeed * Time.deltaTime;
    }
}