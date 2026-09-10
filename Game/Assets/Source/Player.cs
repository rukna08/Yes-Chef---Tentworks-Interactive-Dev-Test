using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;

    void Start() {

        speed = 10f;

    }

    void Update() {

        move();

    }

    void move() {

        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input   = Input.GetAxis("Vertical");

        Vector3 translation = new Vector3(horizontal_input, 0f, vertical_input);

        // Multiplied Time.deltaTime for framerate independence.
        transform.Translate(translation * speed * Time.deltaTime);
    }
}