using System.Collections;
using UnityEngine;
using TMPro;

public class CountDownManager : MonoBehaviour {

    public TMP_Text CountDownText;
    public AudioSource CountDownSound;
    public AudioSource CountDownGoSound;
    public GameObject LapTimeManager;
    public GameObject Car;

    void Start() {
        Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(CountDownWaiter());
    }

    IEnumerator CountDownWaiter() {
        yield return new WaitForSeconds(0.5f);
        CountDownText.text = "3";
        CountDownSound.Play();
        yield return new WaitForSeconds(1f);
        CountDownText.text = "2";
        CountDownSound.Play();
        CountDownText.GetComponent<Animator>().Play("Countdown", -1, 0f);
        yield return new WaitForSeconds(1f);
        CountDownText.text = "1";
        CountDownSound.Play();
        CountDownText.GetComponent<Animator>().Play("Countdown", -1, 0f);
        yield return new WaitForSeconds(1f);
        CountDownGoSound.Play();
        LapTimeManager.SetActive(true);
        Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}