using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource bolsonaroMusic;
    public AudioSource lulaMusic;
    GameManager gm;

    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
        gm.audioMgr = this;
    }

    public void SetBolsonoaroMusic() {
        lulaMusic.Pause();
        bolsonaroMusic.Play();
    }
    public void SetLulaMusic() {
        lulaMusic.Play();
        bolsonaroMusic.Pause();
    }
    public void PauseAllMusic() {
        lulaMusic.Pause();
        bolsonaroMusic.Pause();
    }
    // Update is called once per frame
    void Update() {

    }
}
