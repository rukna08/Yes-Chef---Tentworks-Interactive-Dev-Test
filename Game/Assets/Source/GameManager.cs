using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public int main_score;
    public int high_score;
    public TMP_Text score_ui;
    public TMP_Text time_left_ui;
    public TMP_Text high_score_ui;
    public TMP_Text new_high_score_hit_ui;
    float game_runtime;
    public GameObject game_over_screen;
    bool is_game_over;

    void Start() {
        main_score = 0;
        high_score = PlayerPrefs.GetInt("HighScore", 0);
        game_runtime = 180f;
        game_over_screen.SetActive(false);
        new_high_score_hit_ui.gameObject.SetActive(false);
        is_game_over = false;
    }

    void Update() {
        if(!is_game_over) {
            score_ui.text = "SCORE: " + main_score.ToString();
            process_game_runtime();
            process_highscore();
        }
    }

    void process_highscore() {
        if (main_score > high_score) {
            high_score = main_score;    
        }
    }

    void process_game_runtime() {
        game_runtime -= Time.deltaTime;
        time_left_ui.text = "TIME LEFT: " + ((int)game_runtime).ToString();

        if(game_runtime <= 0f) {

            if(main_score > PlayerPrefs.GetInt("HighScore", 0)) {
                PlayerPrefs.SetInt("HighScore", main_score);
                PlayerPrefs.Save();

                high_score = main_score;

                new_high_score_hit_ui.gameObject.SetActive(true);
            }

            high_score_ui.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

            game_over_screen.SetActive(true);
            is_game_over = true;
        }
    }

    public void restart_game() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exit_game() {
        Application.Quit();
    }
}