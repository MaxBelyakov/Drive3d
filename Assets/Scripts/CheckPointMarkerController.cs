using System.Collections;
using UnityEngine;

public class CheckPointMarkerController : MonoBehaviour {

    private bool waiter = false;    // Wait until corountine works

    void Update() {
        if (!waiter) {
            
            // Show marker
            this.GetComponent<MeshRenderer>().enabled = true;

            StartCoroutine(Waiter());
        }
    }

    IEnumerator Waiter() {
        waiter = true;
        yield return new WaitForSeconds(1);

        // Hide marker
        this.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(1);
        waiter = false;
    }
}
