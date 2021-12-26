/* Stabilize the camera when car moving, follow the stable target above the car */
using UnityEngine;

public class CameraStabilizator : MonoBehaviour {

    public GameObject Car;
    private float CarX;
    private float CarY;
    private float CarZ;

    void Update() {
        CarX = Car.transform.eulerAngles.x;
        CarY = Car.transform.eulerAngles.y;
        CarZ = Car.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX - CarX, CarY, CarZ - CarZ);
    }
}