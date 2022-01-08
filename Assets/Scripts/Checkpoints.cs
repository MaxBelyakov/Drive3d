/* CheckPoint Triggers. Connected with CheckPointList script */

using UnityEngine;

public class Checkpoints : MonoBehaviour {

    /* !!! Each checkpoint has that script, be careful when declare variables there */

    void OnTriggerEnter(Collider collision) {

        if (collision.tag == "Player") {
            // Ignore not the target
            if (this.name == CheckPointsList.CheckPoints[CheckPointsList.n].name) {
                // Select next target
                if (CheckPointsList.n != CheckPointsList.CheckPoints.Count - 1)
                    CheckPointsList.n++;
                else {
                    CheckPointsList.n = 0;
                    CheckPointsList.player_finish = true;
                }      
            }
        }

        if (collision.tag == "Black Car") {
            // Ignore not the target
            if (this.name == CheckPointsList.CheckPoints[CheckPointsList.m].name) {
                // Select next target
                if (CheckPointsList.m != CheckPointsList.CheckPoints.Count - 1)
                    CheckPointsList.m++;
                else {
                    CheckPointsList.m = 0;
                    CheckPointsList.black_car_finish = true;
                }
                // Show new target to Red car
                CheckPointsList.black_car_target.transform.position = CheckPointsList.CheckPoints[CheckPointsList.m].transform.position;    
            }
        }

        if (collision.tag == "Blue Car") {
            // Ignore not the target
            if (this.name == CheckPointsList.CheckPoints[CheckPointsList.k].name) {
                // Select next target
                if (CheckPointsList.k != CheckPointsList.CheckPoints.Count - 1)
                    CheckPointsList.k++;
                else {
                    CheckPointsList.k = 0;
                    CheckPointsList.blue_car_finish = true;
                }
                // Show new target to Blue car
                CheckPointsList.blue_car_target.transform.position = CheckPointsList.CheckPoints[CheckPointsList.k].transform.position;
            }
        }
    }
}