using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float velocidade = 5.0f;

    GameManager gm;

    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
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
        if (gameObject.tag == "Player1" && gm.currentTurn == GameManager.PlayerTurn.PLAYER1) {
            Move();
        }
        else if (gameObject.tag == "Player2" && gm.currentTurn == GameManager.PlayerTurn.PLAYER2) {
            Move();
        }
    }
}
