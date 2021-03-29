public class GameManager {

    private static GameManager _instance;
    public PlayerController player1 { get; set; }
    public PlayerController player2 { get; set; }

    public enum PlayerTurn {
        PLAYER1, PLAYER2
    }
    public PlayerTurn currentTurn {
        get; private set;
    }
    // Use this for initialization
    void Start() {
        currentTurn = PlayerTurn.PLAYER1;
    }

    // Update is called once per frame
    void Update() {

    }
    public static GameManager GetInstance() {
        if (_instance == null) {
            _instance = new GameManager();
        }

        return _instance;
    }
}