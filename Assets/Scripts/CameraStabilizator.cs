/* Stabilize the camera when car moving, follow the stable target above the car */
using UnityEngine;

public class CameraStabilizator : MonoBehaviour {

    public GameObject Car;
    private float CarY;

    void Update() {
        CarY = Car.transform.eulerAngles.y;

        transform.eulerAngles = new Vector3(0f, CarY, 0f);
    }
}