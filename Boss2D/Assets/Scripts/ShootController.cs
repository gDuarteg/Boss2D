using UnityEngine;

public class ShootController : MonoBehaviour {

    GameManager gm;
    Animator anim;

    public float fieldOfImpact;
    public float force;
    public LayerMask layerToHit;

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

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);
       
        foreach (Collider2D obj in objects) {
            if (obj.CompareTag("Player1")) {
                Vector2 expDir = new Vector2(-fieldOfImpact + obj.transform.position.x - transform.position.x, -fieldOfImpact + obj.transform.position.y - transform.position.y);
                //Debug.Log(expDir);
                obj.GetComponent<Rigidbody2D>().AddForce((expDir) * force);
            }
           else if (obj.CompareTag("Player2")) {
                Vector2 expDir = new Vector2(fieldOfImpact - obj.transform.position.x + transform.position.x, fieldOfImpact - obj.transform.position.y + transform.position.y);
                //Debug.Log(expDir);
                obj.GetComponent<Rigidbody2D>().AddForce((expDir) * force);
            }
        }
    }

    //private void OnDrawGizmosSelected() {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    //}

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