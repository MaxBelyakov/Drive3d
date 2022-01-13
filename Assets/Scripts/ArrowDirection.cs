/* Arrow show direction to current checkpoint */

using UnityEngine;

public class ArrowDirection : MonoBehaviour {

    private GameObject target;

    void Update() {
        target = CheckPointsList.s_checkPoints[CheckPointsList.n];
        transform.LookAt(target.transform);
    }
}