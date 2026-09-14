using TMPro;
using UnityEngine;

public class StoveInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public TMP_Text cook_meet_text;

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
    }

    void Update() {
        if(is_inside_interaction_zone) {
            cook_meet_text.gameObject.SetActive(true);
        } else {
            cook_meet_text.gameObject.SetActive(false);        
        }
    }
}
