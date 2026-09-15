using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public int main_score;

    public TMP_Text score_ui;

    void Start() {
        main_score = 0;
    }

    void Update() {
        score_ui.text = "SCORE: " + main_score.ToString();
    }

}
