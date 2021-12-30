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

    public static GameObject enemy_target;

    public static bool player_finish = false;
    public static bool enemy_finish = false;

    public static int n = 0;
    public static int m = 0;

    void Start() {
        CheckPoints = new List<GameObject>();
        CheckPoints.Add(cp1);
        CheckPoints.Add(cp2);
        CheckPoints.Add(cp0);

        enemy_target = GameObject.Find("enemy_target");
        enemy_target.transform.position = CheckPoints[0].transform.position;
    }
}