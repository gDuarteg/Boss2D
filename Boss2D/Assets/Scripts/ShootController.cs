using UnityEngine;

public class ShootController : MonoBehaviour {

    GameManager gm;

    // Use this for initialization
    void Start() {
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!( collision.gameObject is null )) {
            if (collision.CompareTag("Player1")) {
                Debug.Log(gm.player1.Vida);
                    gm.player1.OnHit();
            }
            else if (collision.CompareTag("Player2")) {
                gm.player2.Vida--;
            }
        }
    }
}