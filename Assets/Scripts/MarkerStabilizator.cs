/* Stabilize the Marker when car moving, follow the stable target above the car */
using UnityEngine;
using System.Collections;

public class MarkerStabilizator : MonoBehaviour {

    public GameObject car;

    private Vector3 startMarkerRotation;    // Start Marker rotation variables
    private Vector3 startMarkerPosition;    // Start Marker position variables
    private bool updateMarker;              // Patch: Marker rotation updates in 1 sec after countdown (+3 sec). Need to use updated variables

    void Start() {
        StartCoroutine(waiter());
    }

    void Update() {
        // Get Car rotatioin and position variables
        var CarY = car.transform.eulerAngles.y;
        var CarX = car.transform.position.x;
        var CarZ = car.transform.position.z;

        // Change only Y-axis Marker rotation and block change Y-axis Marker position
        if (updateMarker) {
            transform.eulerAngles = new Vector3(startMarkerRotation.x, CarY, startMarkerRotation.z);
            transform.position = new Vector3(CarX, startMarkerPosition.y, CarZ);
        }
    }

    // Wait for update Marker variables
    IEnumerator waiter() {
        yield return new WaitForSeconds(4);
        startMarkerRotation = transform.rotation.eulerAngles;
        startMarkerPosition = transform.position;
        updateMarker = true;
    }
}