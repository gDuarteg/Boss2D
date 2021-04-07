using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MENU : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;

    private void OnEnable() {
        gm = GameManager.GetInstance();
    }

    public void Iniciar() {
        gm.changeState(GameManager.GameState.GAME);
    }
}
