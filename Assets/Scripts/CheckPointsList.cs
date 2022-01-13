//
/* Control CheckPoints behavior. Creates new List and fill it by checkpoint objects */
//

using System.Collections.Generic;
using UnityEngine;

public class CheckPointsList : MonoBehaviour {

    public static List<GameObject> s_checkPoints;
    public List<GameObject> checkPointsInspector;

    public static GameObject black_car_target;
    public static GameObject blue_car_target;

    public static bool player_finish_lap = false;
    public static bool black_car_finish_lap = false;
    public static bool blue_car_finish_lap = false;

    public static int n = 0;    // Player checkpoint counter
    public static int m = 0;    // Black car checkpoint counter
    public static int k = 0;    // Blue car checkpoint counter

    void Start() {
        // Get checkpoints list from unity inspector
        s_checkPoints = checkPointsInspector;

        // Enable 1st checkpoint marker
        s_checkPoints[n].GetComponentInChildren<CheckPointMarkerController>().enabled = true;

        // Set Black car target 1st checkpoint
        black_car_target = GameObject.Find("black_car_target");
        black_car_target.transform.position = s_checkPoints[0].transform.position + new Vector3(0, 0, 5f);

        // Set Blue car target 1st checkpoint
        blue_car_target = GameObject.Find("blue_car_target");
        blue_car_target.transform.position = s_checkPoints[0].transform.position - new Vector3(0, 0, 5f);
    }
}