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
   
    private GameManager() {
        currentTurn = PlayerTurn.PLAYER1;
    }

    public static GameManager GetInstance() {
        if (_instance == null) {
            _instance = new GameManager();
        }

        return _instance;
    }

    public void changeTurn() {
        if (currentTurn == PlayerTurn.PLAYER1) {
            currentTurn = PlayerTurn.PLAYER2;

            player2.gameObject.GetComponent<PlayerController>().enabled = true;
            player1.gameObject.GetComponent<PlayerController>().enabled = false;
        }
        else {
            currentTurn = PlayerTurn.PLAYER1;
            player1.gameObject.GetComponent<PlayerController>().enabled = true;
            player2.gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }
}