using UnityEngine;

public class Hand : MonoBehaviour {


    public GameObject held_ingredient;

    void Start() {
        held_ingredient = null;
    }

    public void hold_ingredient(GameObject ingredient) {
        held_ingredient = ingredient;

        
        ingredient = Instantiate(ingredient, transform.position, Quaternion.identity, transform);

        ingredient.transform.localScale = new Vector3(2f, 0.5f, 2f);
    }

    public void release_ingredient() {
        held_ingredient = null;
    }

}
