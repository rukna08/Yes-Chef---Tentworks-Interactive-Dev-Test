using System.Collections;
using TMPro;
using UnityEngine;

public class OrderInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public string ingredient_1;
    public string ingredient_2;
    public string ingredient_3;

    bool is_ingredient_1_satisfied;
    bool is_ingredient_2_satisfied;
    bool is_ingredient_3_satisfied;

    public GameObject vegetable_1;
    public GameObject vegetable_2;
    public GameObject vegetable_3;

    public GameObject cooked_meat_1;
    public GameObject cooked_meat_2;
    public GameObject cooked_meat_3;

    public GameObject cheese_1;
    public GameObject cheese_2;
    public GameObject cheese_3;

    public TMP_Text random_order_text;

    public Hand player_hand;

    public TMP_Text elapsed_seconds_text;
    float elapsed_time;

    bool is_order_satisfied;

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
    }

    void Start() {
        elapsed_time = 0f;

        ingredient_1 = "";
        ingredient_2 = "";
        ingredient_3 = "";

        is_ingredient_1_satisfied = false;
        is_ingredient_2_satisfied = false;
        is_ingredient_3_satisfied = false;

        is_inside_interaction_zone = false;

        is_order_satisfied = false;

        generate_order();
    }


    void Update() {

        elapsed_time += Time.deltaTime;
        int seconds = Mathf.FloorToInt(elapsed_time);
        elapsed_seconds_text.text = seconds.ToString() + "s";


        if (is_inside_interaction_zone) {
            random_order_text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)) {

                // Cut Vegetable Placement
                if (!is_ingredient_1_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_1 == "Vegetable" && player_hand.held_ingredient.tag == "CutVegetable") {
                            player_hand.release_ingredient();
                            vegetable_1.SetActive(true);

                            is_ingredient_1_satisfied = true;

                            
                        }
                    }
                }

                if (!is_ingredient_2_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_2 == "Vegetable" && player_hand.held_ingredient.tag == "CutVegetable") {
                            player_hand.release_ingredient();
                            vegetable_2.SetActive(true);

                            is_ingredient_2_satisfied = true;

                            
                        }
                    }
                }

                if (!is_ingredient_3_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_3 == "Vegetable" && player_hand.held_ingredient.tag == "CutVegetable") {
                            player_hand.release_ingredient();
                            vegetable_3.SetActive(true);

                            is_ingredient_3_satisfied = true;

                            
                        }
                    }
                }

                // Cheese Placement
                if (!is_ingredient_1_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_1 == "Cheese" && player_hand.held_ingredient.tag == "Cheese") {
                            player_hand.release_ingredient();
                            cheese_1.SetActive(true);

                            is_ingredient_1_satisfied = true;

                            
                        }
                    }
                }

                if (!is_ingredient_2_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_2 == "Cheese" && player_hand.held_ingredient.tag == "Cheese") {
                            player_hand.release_ingredient();
                            cheese_2.SetActive(true);

                            is_ingredient_2_satisfied = true;

                            
                        }
                    }
                }

                if (!is_ingredient_3_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_3 == "Cheese" && player_hand.held_ingredient.tag == "Cheese") {
                            player_hand.release_ingredient();
                            cheese_3.SetActive(true);

                            is_ingredient_3_satisfied = true;

                            
                        }
                    }
                }


                // Cooked Meat Placement
                if (!is_ingredient_1_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_1 == "Meat" && player_hand.held_ingredient.tag == "CookedMeat") {
                            player_hand.release_ingredient();
                            cooked_meat_1.SetActive(true);

                            is_ingredient_1_satisfied = true;

                            
                        }
                    }
                }

                if (!is_ingredient_2_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_2 == "Meat" && player_hand.held_ingredient.tag == "CookedMeat") {
                            player_hand.release_ingredient();
                            cooked_meat_2.SetActive(true);

                            is_ingredient_2_satisfied = true;

                            
                        }
                    }
                }

                if (!is_ingredient_3_satisfied) {
                    if (player_hand.held_ingredient != null) {
                        if (ingredient_3 == "Meat" && player_hand.held_ingredient.tag == "CookedMeat") {
                            player_hand.release_ingredient();
                            cooked_meat_3.SetActive(true);

                            is_ingredient_3_satisfied = true;

                            
                        }
                    }
                }
            }
            
        } else {
            random_order_text.gameObject.SetActive(false);
        }

        // elapsed time on top of the order window.
        random_order_text.text = ingredient_1 + "|" + ingredient_2 + "|" + ingredient_3;


        process_order_satisfaction();


        if(is_order_satisfied) {

            is_order_satisfied = false;

            // update score

            StartCoroutine(process_completed_order());
        }
    }

    IEnumerator process_completed_order() {

        // update score here later

        is_ingredient_1_satisfied = false;
        is_ingredient_2_satisfied = false;
        is_ingredient_3_satisfied = false;

        vegetable_1.SetActive(false);
        vegetable_2.SetActive(false);
        vegetable_3.SetActive(false);

        cheese_1.SetActive(false);
        cheese_2.SetActive(false);
        cheese_3.SetActive(false);

        cooked_meat_1.SetActive(false);
        cooked_meat_2.SetActive(false);
        cooked_meat_3.SetActive(false);

        ingredient_1 = "";
        ingredient_2 = "";
        ingredient_3 = "";

        yield return new WaitForSeconds(5f);


        generate_order();

        Debug.Log("New order arrived!");
        
    }

    void process_order_satisfaction() {
        // check for order satisfaction.
        if(is_ingredient_1_satisfied && is_ingredient_2_satisfied && (ingredient_3 == "" || is_ingredient_3_satisfied)) {
            is_order_satisfied = true;
        }
    }

    void generate_order() {

        // 2 or 3, last value 4 as it is max exclusive
        // and min inclusive.
        int ingredient_amount = Random.Range(2, 4);


        if (ingredient_amount == 2) {
            int dice_roll = Random.Range(0, 3);
            switch (dice_roll)
            {
                case 0: ingredient_1 = "Vegetable"; break;
                case 1: ingredient_1 = "Meat";      break;
                case 2: ingredient_1 = "Cheese";    break;
            }
            dice_roll = Random.Range(0, 3);
            switch (dice_roll)
            {
                case 0: ingredient_2 = "Vegetable"; break;
                case 1: ingredient_2 = "Meat";      break;
                case 2: ingredient_2 = "Cheese";    break;
            }
        }
        else if(ingredient_amount == 3) {
            int dice_roll = Random.Range(0, 3);
            switch (dice_roll) {
                case 0: ingredient_1 = "Vegetable"; break;
                case 1: ingredient_1 = "Meat";      break;
                case 2: ingredient_1 = "Cheese";    break;
            }
            dice_roll = Random.Range(0, 3);
            switch (dice_roll) {
                case 0: ingredient_2 = "Vegetable"; break;
                case 1: ingredient_2 = "Meat";      break;
                case 2: ingredient_2 = "Cheese";    break;
            }
            dice_roll = Random.Range(0, 3);
            switch (dice_roll) {
                case 0: ingredient_3 = "Vegetable"; break;
                case 1: ingredient_3 = "Meat";      break;
                case 2: ingredient_3 = "Cheese";    break;
            }
        }

        if (ingredient_amount == 2)
        {
            Debug.Log("Order: " + ingredient_1 + ", " + ingredient_2);
        }
        else {
            Debug.Log("Order: " + ingredient_1 + ", " + ingredient_2 + ", " + ingredient_3);
        }
    }
}