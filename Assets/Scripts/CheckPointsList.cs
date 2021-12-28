//
/* Control CheckPoints behavior. Creates new List and fill it by checkpoint objects */
//

using System.Collections.Generic;
using UnityEngine;

public class CheckPointsList : MonoBehaviour {

    private static GameObject cp0;
    private static GameObject cp1;
    private static GameObject cp2;
    public static int n;
    public static List<GameObject> CheckPoints;

    void Start() {
        cp0 = GameObject.Find("cp0");
        cp1 = GameObject.Find("cp1");
        cp2 = GameObject.Find("cp2");
        FillCheckPointsList();
    }

    /* Fill the List by Checkpoints objects and deactivate it, instead finish line */
    public static void FillCheckPointsList() {
        n = 0;
        CheckPoints = new List<GameObject>();
        CheckPoints.Add(cp0);
        CheckPoints.Add(cp1);
        CheckPoints.Add(cp2);

        for (int i = 0; i < CheckPoints.Count; i++) {
            CheckPoints[i].SetActive(false);
        }
        CheckPoints[0].SetActive(true);
    }
}