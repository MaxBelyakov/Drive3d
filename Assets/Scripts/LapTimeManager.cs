/* Calculating Lap Time and Best Time in format 00:00.0 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LapTimeManager : MonoBehaviour {

    private float m_seconds;
    private int seconds = 0;
    private int minutes = 0;
    private int sum = 0;

    private float best_m_seconds;
    private int best_seconds = 0;
    private int best_minutes = 0;
    private int best_sum = 0;
    
    public TMP_Text TimeText;
    public TMP_Text BestTime;
    public TMP_Text Laps;

    private string s_0;
    private string m_0;

    private int laps_current = 1;
    private int laps_all = 3;

    private string best_time_car;

    void Update() {

        if (CheckPointsList.player_finish) {

            CheckBestTime("Player");

            // Restart Lap Time
            minutes = 0;
            seconds = 0;
            m_seconds = 0;

            // Next Lap
            laps_current++;

            // At the end of the game show statistics screen
            if (laps_current > laps_all)
                SceneManager.LoadScene("Statistics");
            
            // Update Lap text
            Laps.text = laps_current + "/" + laps_all;

            CheckPointsList.player_finish = false;
        }

        /*if (CheckPointsList.black_car_finish) {
            CheckBestTime("Black car");
        }
        if (CheckPointsList.blue_car_finish) {
            CheckBestTime("Blue car");
        }*/

        // Calculating Lap Time
        m_seconds += Time.deltaTime * 10;

        if (m_seconds >= 10) {
            m_seconds = 0;
            seconds++;
        }

        if (seconds < 10)
            s_0 = "0";
        else
            s_0 = "";

        if (seconds >= 60) {
            seconds = 0;
            minutes++;
        }

        if (minutes < 10)
            m_0 = "0";
        else
            m_0 = "";
        
        TimeText.text = m_0 + minutes + ":" + s_0 + seconds + "." + Mathf.Floor(m_seconds);
    }

    void CheckBestTime(string car_name) {
        // Compare Lap Time with the best time
        sum = minutes * 60 * 10 + seconds * 10 + (int) m_seconds;
        best_sum = best_minutes * 60 * 10 + best_seconds * 10 + (int) best_m_seconds;

        if (best_sum == 0 || sum < best_sum) {
            best_minutes = minutes;
            best_seconds = seconds;
            best_m_seconds = m_seconds;

            // Update Best time text
            BestTime.text = TimeText.text;

            // Save best time car name
            best_time_car = car_name;
        }
    }
}