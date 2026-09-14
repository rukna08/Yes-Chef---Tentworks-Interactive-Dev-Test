using TMPro;
using UnityEngine;

public class RefrigeratorInteractionZone : MonoBehaviour {

    public TMP_Text interact_open_text;
    public TMP_Text interact_close_text;
    public GameObject ingredient_options;

    public bool is_refrigerator_open;

    public bool is_inside_interaction_zone;

    public Hand player_hand;

    public GameObject[] ingredients;

    void Start() {
        is_refrigerator_open = false;

        is_inside_interaction_zone = false;
    }
    
    private void OnTriggerEnter(Collider other) {
        interact_open_text.gameObject.SetActive(true);

        is_inside_interaction_zone = true;
    }

    private void OnTriggerExit(Collider other) {
        interact_open_text.gameObject.SetActive(false);
        interact_close_text.gameObject.SetActive(false);

        ingredient_options.SetActive(false);

        is_refrigerator_open = false;
        
        is_inside_interaction_zone = false;
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

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                player_hand.hold_ingredient(ingredients[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                player_hand.hold_ingredient(ingredients[1]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                player_hand.hold_ingredient(ingredients[2]);
            }
        } else {
            ingredient_options.SetActive(false);
        }
    }

    void Update() {
        if (is_inside_interaction_zone) {
            process_input();
            process_ingredient_options();
        }
    }
}