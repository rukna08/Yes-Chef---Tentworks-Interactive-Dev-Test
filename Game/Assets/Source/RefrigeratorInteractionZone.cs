using TMPro;
using UnityEngine;

public class RefrigeratorInteractionZone : MonoBehaviour {
    
    public TMP_Text interact_open_text;
    public TMP_Text interact_close_text;
    public GameObject ingredient_options;

    
    bool is_refrigerator_open;

    
    bool is_inside_interaction_zone;
    public Hand player_hand;

    
    public GameObject[] ingredients;

    void Start() {
        is_refrigerator_open = false;
        is_inside_interaction_zone = false;

        update_ui();
    }

    void Update() {
        if (!is_inside_interaction_zone) return;

        process_input();
    }

    void process_input() {
        if (Input.GetKeyDown(KeyCode.E)) {
            is_refrigerator_open = !is_refrigerator_open;
            update_ui();
        }

        if (is_refrigerator_open) {
            process_ingredient_selection();
        }
    }

    void process_ingredient_selection() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            select_ingredient(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            select_ingredient(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            select_ingredient(2);
        }
    }

    void select_ingredient(int index) {
        if (index >= ingredients.Length) return;

        player_hand.hold_ingredient(ingredients[index]);
    }

    void update_ui() {
        if (!is_inside_interaction_zone) {
            interact_open_text.gameObject.SetActive(false);
            interact_close_text.gameObject.SetActive(false);
            ingredient_options.SetActive(false);

            return;
        }

        if (is_refrigerator_open) {
            interact_open_text.gameObject.SetActive(false);
            interact_close_text.gameObject.SetActive(true);
            ingredient_options.SetActive(true);
        } else {
            interact_open_text.gameObject.SetActive(true);
            interact_close_text.gameObject.SetActive(false);
            ingredient_options.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;

        update_ui();
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
        is_refrigerator_open = false;

        update_ui();
    }
}