using System.Collections;
using TMPro;
using UnityEngine;

public class StoveInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public TMP_Text cook_meat_text;

    public Hand player_hand;

    public GameObject meat_1;
    public GameObject meat_2;

    public GameObject cooked_meat_1;
    public GameObject cooked_meat_2;

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
                
                    if(player_hand.held_ingredient != null && !meat_1.activeSelf && !cooked_meat_1.activeSelf) {
                        StartCoroutine(cook_meat_1());
                    } else if(player_hand.held_ingredient != null && !meat_2.activeSelf && !cooked_meat_2.activeSelf) {
                        StartCoroutine(cook_meat_2());
                    }
                
                }

                if (player_hand.held_ingredient == null && cooked_meat_1.activeSelf && !meat_1.activeSelf) {
                    Debug.Log("Picked cooked meat 1");
                } else if (player_hand.held_ingredient == null && cooked_meat_2.activeSelf && !meat_2.activeSelf) {
                    Debug.Log("Picked cooked meat 2");
                }

            }


        } else {
            cook_meat_text.gameObject.SetActive(false);        
        }
    }

    IEnumerator cook_meat_1() {
        meat_1.SetActive(true);
        player_hand.release_ingredient();

        // Cook for 6 seconds.
        yield return new WaitForSeconds(6f);

        // deactivate meat_1 and activate cooked_meat_1
        meat_1.SetActive(false);
        cooked_meat_1.SetActive(true);
    }

    IEnumerator cook_meat_2() {
        meat_2.SetActive(true);
        player_hand.release_ingredient();

        // Cook for 6 seconds.
        yield return new WaitForSeconds(6f);

        // deactivate meat_1 and activate cooked_meat_1
        meat_2.SetActive(false);
        cooked_meat_2.SetActive(true);
    }
}
