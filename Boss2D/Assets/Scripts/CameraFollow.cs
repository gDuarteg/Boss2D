using UnityEngine;

public class CameraFollow : MonoBehaviour {
    // Start is called before the first frame update
    public Transform target1;
    public Transform target2;

    GameManager gm;

    private void Start() {
        gm = GameManager.GetInstance();
    }

    private void LateUpdate() {
        Transform bulletObject = GameObject.FindWithTag("Bullet")?.transform;
        if ( bulletObject ) {
            transform.position = new Vector3(bulletObject.position.x, bulletObject.position.y, transform.position.z);
        } else if ( gm.currentTurn == GameManager.PlayerTurn.PLAYER1 ) {
            transform.position = new Vector3(target1.position.x, target1.position.y, transform.position.z);
        } else if ( gm.currentTurn == GameManager.PlayerTurn.PLAYER2 ) {
            transform.position = new Vector3(target2.position.x, target2.position.y, transform.position.z);
        }
    }


}
