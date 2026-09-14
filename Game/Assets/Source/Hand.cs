using UnityEngine;

public class Hand : MonoBehaviour {


    public GameObject held_ingredient;

    void Start() {
        held_ingredient = null;
    }

    public void hold_ingredient(GameObject ingredient) {

        if (ingredient != null) {
            Destroy(held_ingredient);
        }

        held_ingredient = ingredient;

        held_ingredient = Instantiate(ingredient, transform.position, Quaternion.identity, transform);

        held_ingredient.transform.localScale = new Vector3(2f, 0.5f, 2f);
    }

    public void release_ingredient() {
        Destroy(held_ingredient);
        held_ingredient = null;
    }

}
