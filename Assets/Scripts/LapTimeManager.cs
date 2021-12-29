/* Calculating Lap Time and Best Time in format 00:00.0 */

using UnityEngine;
using TMPro;

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

    private string s_0;
    private string m_0;

    void Update() {

        if (Checkpoints.finish) {
            // Compare Lap Time with the best time
            sum = minutes * 60 * 10 + seconds * 10 + (int) m_seconds;
            best_sum = best_minutes * 60 * 10 + best_seconds * 10 + (int) best_m_seconds;
            if (best_sum == 0 || sum < best_sum) {
                best_minutes = minutes;
                best_seconds = seconds;
                best_m_seconds = m_seconds;
                BestTime.text = TimeText.text;
            }

            // Restart Lap Time
            minutes = 0;
            seconds = 0;
            m_seconds = 0;

            Checkpoints.finish = false;
        }

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
}