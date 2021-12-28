/* CheckPoint Triggers. Connected with CheckPointList script. Deactivate current checkpoint and activate next one */

using UnityEngine;

public class Checkpoints : MonoBehaviour {
    void OnTriggerEnter() {
        if (CheckPointsList.n != CheckPointsList.CheckPoints.Count - 1) {
            Debug.Log("Checkpoint " + this.name);
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