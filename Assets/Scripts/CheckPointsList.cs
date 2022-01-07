//
/* Control CheckPoints behavior. Creates new List and fill it by checkpoint objects */
//

using System.Collections.Generic;
using UnityEngine;

public class CheckPointsList : MonoBehaviour {

    public GameObject cp0;
    public GameObject cp1;
    public GameObject cp2;
    public static List<GameObject> CheckPoints;

    public static GameObject black_car_target;
    public static GameObject blue_car_target;

    public static bool player_finish = false;
    public static bool black_car_finish = false;
    public static bool blue_car_finish = false;

    public static int n = 0;    // Player checkpoint counter
    public static int m = 0;    // Red car checkpoint counter
    public static int k = 0;    // Blue car checkpoint counter

    void Start() {
        CheckPoints = new List<GameObject>();
        CheckPoints.Add(cp1);
        CheckPoints.Add(cp2);
        CheckPoints.Add(cp0);

        black_car_target = GameObject.Find("black_car_target");
        black_car_target.transform.position = CheckPoints[0].transform.position;

        blue_car_target = GameObject.Find("blue_car_target");
        blue_car_target.transform.position = CheckPoints[0].transform.position;
    }
}