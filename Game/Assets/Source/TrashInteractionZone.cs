using TMPro;
using UnityEngine;

public class TrashInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public TMP_Text dump_text;

    public Hand player_hand;

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
    }

    void Update() {

        if (is_inside_interaction_zone) {
            dump_text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) player_hand.release_ingredient();
        } else {
            dump_text.gameObject.SetActive(false);
        }

    }

}
