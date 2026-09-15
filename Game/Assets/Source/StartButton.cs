using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    
    public void start_new_game() {
        SceneManager.LoadScene("Main");    
    }

}
