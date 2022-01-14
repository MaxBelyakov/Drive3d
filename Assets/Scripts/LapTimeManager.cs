/* Calculating Lap Time, Race Time and Best Time in format 00:00.0 */

using UnityEngine;
using TMPro;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class LapTimeManager : MonoBehaviour {

    private float lap_time_player;
    private float lap_time_black;
    private float lap_time_blue;

    private float best_lap_time = 0;
    
    public TMP_Text TimeText;
    public TMP_Text BestTime;
    public TMP_Text Laps;
    public TMP_Text FinishText;
    public TMP_Text SpeedText;

    public GameObject PlayerCar;
    public GameObject BlackCar;
    public GameObject BlueCar;

    private float race_time_player = 0;
    private float race_time_black = 0;
    private float race_time_blue = 0;
    public static string player_race_time_text; // Player race time text. Connected with Rating script
    public static string black_race_time_text;  // Black car race time text. Connected with Rating script
    public static string blue_race_time_text;   // Blue car race time text. Connected with Rating script

    public static int laps_current_player = 1;  // Current player lap value. Connected with Rating script 
    public static int laps_current_black = 1;   // Current black car lap value. Connected with Rating script
    public static int laps_current_blue = 1;    // Current blue car lap value. Connected with Rating script
    private int laps_all = 3;                   // Laps in the race

    public static string best_time_car;         // Best lap time car name. Connected with Statistics
    public static string best_time_text;        // Best lap time. Connected with Statistics

    void Update() {
        SpeedText.text = Math.Round(PlayerCar.GetComponent<CarController>().CurrentSpeed * 1.609f) + " km/h";

        if (CheckPointsList.player_finish_lap) {
            // Check is the lap time the best
            CheckBestTime("Player", lap_time_player);

            // Restart Lap Time
            lap_time_player = 0;

            // Next Lap
            laps_current_player++;

            // At the end of the game show statistics screen
            if (laps_current_player > laps_all) {
                Rating.player_add_bonus = true;
                player_race_time_text = PrintText(race_time_player);
                FinishText.text = "FINISH";
                StartCoroutine("waiter");
            } else {
                // Update Lap text
                Laps.text = laps_current_player + "/" + laps_all;
            }

            CheckPointsList.player_finish_lap = false;
        }

        if (CheckPointsList.black_car_finish_lap) {
            // Check is the lap time the best
            CheckBestTime("Black car", lap_time_black);

            // Restart Lap Time
            lap_time_black = 0;

            // Next Lap
            laps_current_black++;

            // Car finished all laps
            if (laps_current_black > laps_all) {
                BlackCar.GetComponent<CarAIControl>().m_Driving = false;    // Stop the car after finish
                black_race_time_text = PrintText(race_time_black);
                Rating.black_add_bonus = true;
            }

            CheckPointsList.black_car_finish_lap = false;
        }
            
        if (CheckPointsList.blue_car_finish_lap) {
            // Check is the lap time the best
            CheckBestTime("Blue car", lap_time_blue);

            // Restart Lap Time
            lap_time_blue = 0;

            // Next Lap
            laps_current_blue++;

            // Car finished all laps
            if (laps_current_blue > laps_all) {
                BlueCar.GetComponent<CarAIControl>().m_Driving = false;     // Stop the car after finish
                blue_race_time_text = PrintText(race_time_blue);
                Rating.blue_add_bonus = true;
            }

            CheckPointsList.blue_car_finish_lap = false;
        }
            
        // Calculating Lap Time
        lap_time_player += Time.deltaTime * 10;
        lap_time_black += Time.deltaTime * 10;
        lap_time_blue += Time.deltaTime * 10;

        // Calculating Race Time
        race_time_player += Time.deltaTime * 10;
        race_time_black += Time.deltaTime * 10;
        race_time_blue += Time.deltaTime * 10;

        // Show lap time text. Check for race finish text
        if (player_race_time_text == null)
            TimeText.text = PrintText(lap_time_player);

    }

    void CheckBestTime(string car_name, float lap_time) {
        // Compare Lap Time with the best time
        if (best_lap_time == 0 || lap_time < best_lap_time) {
            // Save new best time
            best_lap_time = lap_time;

            // Update Best time text
            BestTime.text = PrintText(best_lap_time);

            // Save best time text and car name for Statistics
            best_time_car = car_name;
            best_time_text = BestTime.text;
        }
    }

    // Convert time in m.seconds to 00:00:0 format and return it as string
    string PrintText(float time) {
        var min = Math.Truncate(time/600);
        var sec = Math.Truncate((time - min * 600) / 10);
        var m_sec = (int) (time - min * 600 - sec * 10);

        // Correct seconds and minutes text
        string s_0 = "";
        string m_0 = "";
        if (sec < 10)
            s_0 = "0";
        if (min < 10)
            m_0 = "0";

        return m_0 + min.ToString() + ":" + s_0 + sec.ToString() + ":" + m_sec.ToString();
    }

    // Wait before show Statistics screen
    IEnumerator waiter() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Statistics");
    }
}