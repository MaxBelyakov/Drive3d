/* CheckPoint Triggers. Connected with CheckPointList script */

using UnityEngine;

public class Checkpoints : MonoBehaviour {

    /* !!! Each checkpoint has that script, be careful when declare variables there */

    void OnTriggerEnter(Collider collision) {

        if (collision.tag == "Player") {
            // Ignore not the target
            if (this.name == CheckPointsList.s_checkPoints[CheckPointsList.n].name) {

                // Disable checkpoint marker
                CheckPointsList.s_checkPoints[CheckPointsList.n].GetComponentInChildren<CheckPointMarkerController>().enabled = false;

                // Select next target
                if (CheckPointsList.n != CheckPointsList.s_checkPoints.Count - 1)
                    CheckPointsList.n++;
                else {
                    CheckPointsList.n = 0;
                    CheckPointsList.player_finish_lap = true;
                }

                // Enable new checkpoint marker
                CheckPointsList.s_checkPoints[CheckPointsList.n].GetComponentInChildren<CheckPointMarkerController>().enabled = true;
            }
        }

        if (collision.tag == "Black Car") {
            // Ignore not the target
            if (this.name == CheckPointsList.s_checkPoints[CheckPointsList.m].name) {
                // Select next target
                if (CheckPointsList.m != CheckPointsList.s_checkPoints.Count - 1)
                    CheckPointsList.m++;
                else {
                    CheckPointsList.m = 0;
                    CheckPointsList.black_car_finish_lap = true;
                }
                // Show new target to Red car
                CheckPointsList.black_car_target.transform.position = CheckPointsList.s_checkPoints[CheckPointsList.m].transform.position + new Vector3(0, 0, 5f);
            }
        }

        if (collision.tag == "Blue Car") {
            // Ignore not the target
            if (this.name == CheckPointsList.s_checkPoints[CheckPointsList.k].name) {
                // Select next target
                if (CheckPointsList.k != CheckPointsList.s_checkPoints.Count - 1)
                    CheckPointsList.k++;
                else {
                    CheckPointsList.k = 0;
                    CheckPointsList.blue_car_finish_lap = true;
                }
                // Show new target to Blue car
                CheckPointsList.blue_car_target.transform.position = CheckPointsList.s_checkPoints[CheckPointsList.k].transform.position - new Vector3(0, 0, 5f);
            }
        }
    }
}