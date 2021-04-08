using UnityEngine;

public class ShootController : MonoBehaviour {

    GameManager gm;
    Animator anim;

    private Vector3 shootDir;
    bool exploding;

    public void Setup(Vector3 _shootDir) {
        shootDir = new Vector3(_shootDir.x, _shootDir.y, 0);
    }

    void Start() {
        gm = GameManager.GetInstance();
        anim = gameObject.GetComponent<Animator>();
        gm.DisableBothPlayers();
        exploding = false;
    }

    private void Explode() {
        exploding = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        anim.SetTrigger("EXPLODE");
    }
    public void End() {
        gm.changeTurn();
        Destroy(gameObject);
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
        Explode();
    }

    private void Update() {
        if(gm.gameState != GameManager.GameState.GAME) return;

        if (!exploding) {
            float moveSpeed = 3f;
            transform.position += shootDir * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x >= 50 || transform.position.x <= -50 || transform.position.y <= -12) {
            Explode();
        }
    }
}