using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ENDGAME : MonoBehaviour
{
    public Text message;
    //public Sprite vencedor1;
    //public Sprite vencedor2;

    GameManager gm;

    void OnEnable() {
        gm = GameManager.GetInstance();
        Image actual_Image = GetComponent<Image>();

        if (gm.gameState != GameManager.GameState.ENDGAME) return;

        if (gm.player1.Vida <= 0) {
            //actual_Image.sprite = vencedor2;
            message.text = $"Player2 Venceu !!!";
        }
        else if (gm.player2.Vida <= 0) {
            message.text = $"Player1 Venceu !!!";
            //actual_Image.sprite = vencedor1;
        }
    }

    public void Menu() {
        gm.changeState(GameManager.GameState.MENU);
    }

    public void Voltar() {
        gm.changeState(GameManager.GameState.GAME);
    }
}
