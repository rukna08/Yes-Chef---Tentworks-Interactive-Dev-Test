using UnityEngine;

public class RefrigeratorInteractionZone : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Player Entered");
    }

}
