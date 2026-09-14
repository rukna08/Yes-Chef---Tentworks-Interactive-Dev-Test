using UnityEngine;

public class OrderInteractionZone : MonoBehaviour {

    bool is_inside_interaction_zone;

    public string ingredient_1;
    public string ingredient_2;
    public string ingredient_3;

    void OnTriggerEnter(Collider other) {
        is_inside_interaction_zone = true;
    }

    void OnTriggerExit(Collider other) {
        is_inside_interaction_zone = false;
    }

    void Start() {
        is_inside_interaction_zone = false;

        generate_order();
    }


    void Update() {



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