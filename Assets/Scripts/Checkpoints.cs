/* CheckPoint Triggers. Connected with CheckPointList script */

using UnityEngine;

public class Checkpoints : MonoBehaviour {

    public static bool finish = false;

    void OnTriggerEnter() {

        // Finish signal
        if (this.name == CheckPointsList.cp0.name) {
            finish = true;
        }

        if (CheckPointsList.n != CheckPointsList.CheckPoints.Count - 1) {
            Debug.Log("Checkpoint " + this.name);
            // Deactivate current checkpoint and activate next one
            if (this.name == CheckPointsList.CheckPoints[CheckPointsList.n].name) {
                CheckPointsList.CheckPoints[CheckPointsList.n].SetActive(false);
                CheckPointsList.n++;
                CheckPointsList.CheckPoints[CheckPointsList.n].SetActive(true);
            }
        } else {
            // Last trigger reload checkpoint list
            CheckPointsList.FillCheckPointsList();
            Debug.Log("Checkpoint " + this.name);
        }
    }
}