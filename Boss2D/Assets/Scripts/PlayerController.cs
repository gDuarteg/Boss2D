using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float velocidade = 5.0f;

    [SerializeField] private GameObject tiro;

    public Vector3 lastStepPosition;

    public int stepCounter = 0;

    public int Vida {
        get; set;
    }

    Vector3 mousePos;
    Vector3 bulletInitPos;
    GameManager gm;
    Animator animator;

    public LayerMask mapa;

    private float oneStepSize = 0.5f;
    private bool isJumping;
    private bool isGrounded;

    void Start() {
        gm = GameManager.GetInstance();
        lastStepPosition = transform.position;
        animator = GetComponent<Animator>();
        if (gameObject.tag == "Player1") {
            gm.player1 = this;
        }
        else if (gameObject.tag == "Player2") {
            gm.player2 = this;
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
        Vida = 5;
    }

    void Die() {
        Destroy(gameObject);
    }

    public void OnHit() {
        Vida--;

        if (Vida <= 0 && gm.gameState == GameManager.GameState.GAME) {
            gm.changeState(GameManager.GameState.ENDGAME);
            //Die();
        }
    }

    void Shoot() {
        mousePos = new Vector3(Input.mousePosition.x , Input.mousePosition.y , 0);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x < transform.position.x) {
            bulletInitPos = transform.position + new Vector3(-1.01f , 0 , 0);
        }
        else {
            bulletInitPos = transform.position + new Vector3(1.01f , 0 , 0);
        }

        GameObject bulletTransform = Instantiate(tiro , bulletInitPos , Quaternion.identity);
        ShootController bulletTeste = bulletTransform.GetComponent<ShootController>();
        bulletTeste.Setup(mousePos - transform.position);
    }

    void Move() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX , 0 , 0) * Time.deltaTime * velocidade;

        // If pressing <- or -> arrows, update running animation and step counter
        if (inputX != 0) {
            animator.SetFloat("Velocity" , 1.0f);
            UpdateStepCounter();
        }
        else {
            animator.SetFloat("Velocity" , 0);
        }

        // If running to the left and character is looking to the right flip
        if (inputX < 0 && transform.localRotation.eulerAngles.x != 180) {
            transform.localRotation = Quaternion.Euler(0 , 180 , 0);
        }
        // If running to the right and character is looking to the left flip
        else if (inputX > 0 && transform.localRotation.eulerAngles.y != -180) {
            transform.localRotation = Quaternion.Euler(0 , 0 , 0);
        }

        if (inputY > 0) {
            Jump();
        }
    }

    void Jump() {
        transform.position += new Vector3(0 , 1.2f , 0) * Time.deltaTime * velocidade;

        animator.SetBool("isJumping" , true);
    }

    bool IsMyTurn() {
        if (gameObject.tag == "Player1" && gm.currentTurn == GameManager.PlayerTurn.PLAYER1) {
            return true;
        }
        if (gameObject.tag == "Player2" && gm.currentTurn == GameManager.PlayerTurn.PLAYER2) {
            return true;
        }
        return false;
    }

    void UpdateIsGrounded() {
        RaycastHit2D ground = Physics2D.Raycast(transform.position , Vector2.down , 0.4f , mapa);
        if (ground.collider != null) {
            isGrounded = true;
        }
        else {
            isGrounded = false;
            animator.SetBool("isJumping" , false);
        }
    }

    void UpdateStepCounter() {
        if (transform.position.x >= lastStepPosition.x + oneStepSize || transform.position.x <= lastStepPosition.x - oneStepSize) {
            stepCounter += 1;
            lastStepPosition = transform.position;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gm.changeState(GameManager.GameState.PAUSE);
        }

        if (stepCounter > 30) {
            gm.changeTurn();
        }

        UpdateIsGrounded();

        if (!IsMyTurn() || gm.gameState != GameManager.GameState.GAME)
            return;

        Move();

        // Shoot
        if (Input.GetButtonDown("Fire1") && !GameObject.FindWithTag("Bullet")) {
            Shoot();
        }


    }
}