using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour {

    public TMP_Text place_1_text;
    public TMP_Text place_2_text;
    public TMP_Text place_3_text;

    public TMP_Text best_time_text;

    void Start() {

        // Rating statistics
        place_1_text.text = "1st place: " + Rating.place_1;
        place_2_text.text = "2st place: " + Rating.place_2;
        place_3_text.text = "3st place: " + Rating.place_3;

        // Best time statistics
        best_time_text.text = "Best Lap Time: " + LapTimeManager.best_time_text + " by " + LapTimeManager.best_time_car;
    }
}
