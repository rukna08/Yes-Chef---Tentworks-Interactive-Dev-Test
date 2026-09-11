using TMPro;
using UnityEngine;

public class RefrigeratorInteractionZone : MonoBehaviour {

    public TMP_Text interact_open_text;
    public TMP_Text interact_close_text;
    public GameObject ingredient_options;

    public bool is_refrigerator_open;

    void Start() {
        is_refrigerator_open = false;
    }
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Player Entered");

        interact_open_text.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Player Exited!");

        interact_open_text.gameObject.SetActive(false);
        interact_close_text.gameObject.SetActive(false);

        is_refrigerator_open = false;
    }
    void process_fridge_state() {
        if (is_refrigerator_open) {
            interact_open_text.gameObject.SetActive(false);
            interact_close_text.gameObject.SetActive(true);
        }
        else {
            interact_open_text.gameObject.SetActive(true);
            interact_close_text.gameObject.SetActive(false);
        }
    }

    void process_input() {
        if (Input.GetKeyDown(KeyCode.E)) {
            is_refrigerator_open = !is_refrigerator_open;
            process_fridge_state();
        }
    }

    void process_ingredient_options() {
        if (is_refrigerator_open) {
            ingredient_options.SetActive(true);
        }
        else {
            ingredient_options.SetActive(false);
        }
    }


    void Update() {
        process_input();
        process_ingredient_options();
    }
}