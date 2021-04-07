using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ENDGAME : MonoBehaviour
{
    public Text message;

    GameManager gm;
    void OnEnable() {
        gm = GameManager.GetInstance();

        if (gm.gameState != GameManager.GameState.ENDGAME) return;

        if (gm.player1.Vida <= 0) {
            message.text = $"Player 2 Venceu !!!";
        }
        else if (gm.player2.Vida <= 0) {
            message.text = $"Player 1 Venceu !!!";
        }
    }

    public void Menu() {
        gm.changeState(GameManager.GameState.MENU);
    }

    public void Voltar() {
        gm.changeState(GameManager.GameState.GAME);
    }
}
