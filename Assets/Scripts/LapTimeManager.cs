/* Calculating Lap Time and Best Time in format 00:00.0 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class LapTimeManager : MonoBehaviour {

    private float m_seconds_player;
    private int seconds_player = 0;
    private int minutes_player = 0;
    private float m_seconds_black;
    private int seconds_black = 0;
    private int minutes_black = 0;
    private float m_seconds_blue;
    private int seconds_blue = 0;
    private int minutes_blue = 0;

    private float best_m_seconds;
    private int best_seconds = 0;
    private int best_minutes = 0;
    private int best_sum = 0;
    
    public TMP_Text TimeText;
    public TMP_Text BestTime;
    public TMP_Text Laps;

    public GameObject BlackCar;
    public GameObject BlueCar;

    public static int laps_current_player = 1;  // Current player lap value. Connected with Rating script 
    public static int laps_current_black = 1;   // Current black car lap value. Connected with Rating script
    public static int laps_current_blue = 1;    // Current blue car lap value. Connected with Rating script
    private int laps_all = 3;                   // Laps in the race

    public static string best_time_car;         // Best lap time car name. Connected with Statistics
    public static string best_time_text;        // Best lap time. Connected with Statistics

    void Update() {

        if (CheckPointsList.player_finish) {

            CheckBestTime("Player", m_seconds_player, seconds_player, minutes_player);

            // Restart Lap Time
            minutes_player = 0;
            seconds_player = 0;
            m_seconds_player = 0;

            // Next Lap
            laps_current_player++;

            // At the end of the game show statistics screen
            if (laps_current_player > laps_all) {
                Rating.player_add_bonus = true;
                SceneManager.LoadScene("Statistics");
            }
            
            // Update Lap text
            Laps.text = laps_current_player + "/" + laps_all;

            CheckPointsList.player_finish = false;
        }

        if (CheckPointsList.black_car_finish) {

            CheckBestTime("Black car", m_seconds_black, seconds_black, minutes_black);

            // Restart Lap Time
            minutes_black = 0;
            seconds_black = 0;
            m_seconds_black = 0;

            // Next Lap
            laps_current_black++;

            // Car finished all laps
            if (laps_current_black > laps_all) {
                BlackCar.GetComponent<CarAIControl>().m_Driving = false;
                Rating.black_add_bonus = true;
            }

            CheckPointsList.black_car_finish = false;
        }
            
        if (CheckPointsList.blue_car_finish) {

            CheckBestTime("Blue car", m_seconds_blue, seconds_blue, minutes_blue);

            // Restart Lap Time
            minutes_blue = 0;
            seconds_blue = 0;
            m_seconds_blue = 0;

            // Next Lap
            laps_current_blue++;

            // Car finished all laps
            if (laps_current_blue > laps_all) {
                BlueCar.GetComponent<CarAIControl>().m_Driving = false;
                Rating.blue_add_bonus = true;
            }

            CheckPointsList.blue_car_finish = false;
        }
            
        // Calculating Lap Time
        m_seconds_player += Time.deltaTime * 10;
        m_seconds_black += Time.deltaTime * 10;
        m_seconds_blue += Time.deltaTime * 10;

        // Calculating seconds
        if (m_seconds_player >= 10) {
            m_seconds_player = 0;
            seconds_player++;
        }
        if (m_seconds_black >= 10) {
            m_seconds_black = 0;
            seconds_black++;
        }
        if (m_seconds_blue >= 10) {
            m_seconds_blue = 0;
            seconds_blue++;
        }

        // Calculating minutes
        if (seconds_player >= 60) {
            seconds_player = 0;
            minutes_player++;
        }
        if (seconds_black >= 60) {
            seconds_black = 0;
            minutes_black++;
        }
        if (seconds_blue >= 60) {
            seconds_blue = 0;
            minutes_blue++;
        }

        // Correct seconds and minutes text
        string s_0 = "";
        string m_0 = "";
        if (seconds_player < 10)
            s_0 = "0";
        if (minutes_player < 10)
            m_0 = "0";
        
        // Show player lap time text
        TimeText.text = m_0 + minutes_player + ":" + s_0 + seconds_player + "." + Mathf.Floor(m_seconds_player);

    }

    void CheckBestTime(string car_name, float m_seconds, int seconds, int minutes) {
        // Compare Lap Time with the best time
        var sum = minutes * 60 * 10 + seconds * 10 + (int) m_seconds;
        best_sum = best_minutes * 60 * 10 + best_seconds * 10 + (int) best_m_seconds;

        if (best_sum == 0 || sum < best_sum) {
            best_minutes = minutes;
            best_seconds = seconds;
            best_m_seconds = m_seconds;

            string best_s_0 = "";
            string best_m_0 = "";

            // Correct seconds and minutes text
            if (best_seconds < 10)
                best_s_0 = "0";
            if (best_minutes < 10)
                best_m_0 = "0";

            // Update Best time text
            BestTime.text = best_m_0 + minutes + ":" + best_s_0 + seconds + "." + Mathf.Floor(m_seconds);

            // Save best time and car name
            best_time_car = car_name;
            best_time_text = BestTime.text;
        }
    }
}