/* CheckPoint Triggers. Connected with CheckPointList script */

using UnityEngine;

public class Checkpoints : MonoBehaviour {

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

        if (collision.tag == "enemy") {
            // Ignore not the target
            if (this.name == CheckPointsList.CheckPoints[CheckPointsList.m].name) {
                // Select next target
                if (CheckPointsList.m != CheckPointsList.CheckPoints.Count - 1)
                    CheckPointsList.m++;
                else {
                    CheckPointsList.m = 0;
                    CheckPointsList.enemy_finish = true;
                }
                // Show new target to enemy
                CheckPointsList.enemy_target.transform.position = CheckPointsList.CheckPoints[CheckPointsList.m].transform.position;    
            }
        }
    }
}