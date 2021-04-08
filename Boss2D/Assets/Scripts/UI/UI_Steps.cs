using UnityEngine;
using UnityEngine.UI;

public class UI_Steps : MonoBehaviour {

    Text textComp;
    public GameObject playerObj;

    void Start() {
        textComp = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        PlayerController player = playerObj.GetComponent<PlayerController>();
        textComp.text = $"Steps: {player.stepCounter}";

    }
}
