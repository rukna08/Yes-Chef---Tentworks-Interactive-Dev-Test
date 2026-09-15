using System.Collections;
using TMPro;
using UnityEngine;

public class TableInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public TMP_Text chop_vegetable_text;

    public Hand player_hand;

    public GameObject vegetable;
    public GameObject cut_vegetable;

    bool is_chopping_done;

    void Start() {
        is_inside_interaction_zone = false;
        is_chopping_done = false;
    }

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
    }

    IEnumerator chop_vegetable() {
        

        player_hand.release_ingredient();
        vegetable.SetActive(true);

        // Wait 2 secs for chopping.

        yield return new WaitForSeconds(2f);

        // cut vegetable object sec active true

        vegetable.SetActive(false);
        cut_vegetable.SetActive(true);

        is_chopping_done = true;
    }

    void Update() {

        if (is_inside_interaction_zone) {
            chop_vegetable_text.gameObject.SetActive(true);


            if (!is_chopping_done && Input.GetKeyDown(KeyCode.E)) {
                if (player_hand.held_ingredient != null && player_hand.held_ingredient.tag == "Vegetable") {
                    StartCoroutine(chop_vegetable());
                }
            }

            if (is_chopping_done && Input.GetKeyDown(KeyCode.E)) {
                player_hand.hold_ingredient(cut_vegetable);
                cut_vegetable.SetActive(false);
                is_chopping_done = false;
            }
            
        } else {
            chop_vegetable_text.gameObject.SetActive(false);
        }
    }
}