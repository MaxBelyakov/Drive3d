/* 3-2-1 counter. Disabled controls and lap time while counting */

using System.Collections;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Vehicles.Car;

public class CountDownManager : MonoBehaviour {

    public TMP_Text CountDownText;
    public AudioSource CountDownSound;
    public AudioSource CountDownGoSound;
    public GameObject LapTimeManager;
    public GameObject Car;
    public GameObject BlackCar;
    public GameObject BlueCar;

    void Start() {
        LapTimeManager.SetActive(false);
        Car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        BlackCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        BlueCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
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
        BlackCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        BlueCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        yield return new WaitForSeconds(1f);
        // Send countdown trigger to enemy controller
        CarAIControl.countdown = false;
    }
}