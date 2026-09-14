using System.Collections;
using TMPro;
using UnityEngine;

public class TableInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public TMP_Text chop_vegetable_text;

    public Hand player_hand;

    public GameObject vegetable;
    public GameObject cut_vegetable;

    void Start() {
        is_inside_interaction_zone = false;
    }

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
    }

    IEnumerator chop_vegetable() {
        Debug.Log("Chopping Vegetable");

        player_hand.release_ingredient();
        vegetable.SetActive(true);

        // Wait 2 secs for chopping.

        yield return new WaitForSeconds(2f);

        // cut vegetable object sec active true

        vegetable.SetActive(false);
        cut_vegetable.SetActive(true);
    }

    void Update() {

        if (is_inside_interaction_zone) {
            chop_vegetable_text.gameObject.SetActive(true);


            if (Input.GetKeyDown(KeyCode.E)) {
                if (player_hand.held_ingredient != null && player_hand.held_ingredient.tag == "Vegetable") {
                    StartCoroutine(chop_vegetable());
                }
            }
            
        } else {
            chop_vegetable_text.gameObject.SetActive(false);
        }
    }
}