using TMPro;
using UnityEngine;

public class StoveInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public TMP_Text cook_meat_text;

    public Hand player_hand;

    public GameObject meat_1;
    public GameObject meat_2;

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
    }

    void Update() {
        if(is_inside_interaction_zone) {
            cook_meat_text.gameObject.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E)) {
                    
                if (player_hand.held_ingredient != null && player_hand.held_ingredient.tag == "Meat") {
                
                    if(player_hand.held_ingredient != null && !meat_1.activeSelf) {
                        meat_1.SetActive(true);
                        player_hand.release_ingredient();
                    }

                    if(player_hand.held_ingredient != null && !meat_2.activeSelf) {
                        meat_2.SetActive(true);  
                        player_hand.release_ingredient();
                    }
                
                }

            }


        } else {
            cook_meat_text.gameObject.SetActive(false);        
        }
    }
}
