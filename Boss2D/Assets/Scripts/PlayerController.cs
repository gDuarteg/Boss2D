using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float velocidade = 5.0f;

    public GameObject tiro;

    public int Vida { get; set; }

    GameManager gm;

    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
        if (gameObject.tag == "Player1") {
            gm.player1 = this;
        }
        else if (gameObject.tag == "Player2") {
            gm.player2 = this;
        }
        Vida = 5;
    }

    void Die() {
        Destroy(gameObject);
    }

    public void OnHit() {
        Debug.Log(Vida);
        Vida--;

        if (Vida <= 0) {
            Die();
        }
    }

    void Shoot() {
        Instantiate(tiro , transform.position , Quaternion.identity);
    }

    void Move() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX , 0 , 0) * Time.deltaTime * velocidade;
        // Only allow user to go up (jump)
        if (inputY > 0) {
            transform.position += new Vector3(0 , 1 , 0) * Time.deltaTime * velocidade;
        }
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }

        if (gameObject.tag == "Player1" && gm.currentTurn == GameManager.PlayerTurn.PLAYER1) {
            Move();
        }
        else if (gameObject.tag == "Player2" && gm.currentTurn == GameManager.PlayerTurn.PLAYER2) {
            Move();
        }
    }
}
