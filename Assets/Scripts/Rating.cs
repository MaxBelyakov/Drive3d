using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;

// Collect car rating statistics
public class CarRating {
    public string Name { get; set; }        // Car name
    public float Rating { get; set; }       // Car rating
    public string race_time { get; set; }   // Car race time
}

// Calculate rating
public class Rating : MonoBehaviour {

    public GameObject player_car;
    public GameObject black_car;
    public GameObject blue_car;

    public TMP_Text text_1st;
    public TMP_Text text_2nd;
    public TMP_Text text_3rd;
    
    public static bool player_add_bonus;    // Add bonus to player. Connected with LapTimeManager
    public static bool black_add_bonus;     // Add bonus to black car. Connected with LapTimeManager
    public static bool blue_add_bonus;      // Add bonus to blue car. Connected with LapTimeManager
    private float player_bonus = 0;
    private float black_bonus = 0;
    private float blue_bonus = 0;
    private float end_race_bonus = 100f;    // Start bonus number

    public static string place_1;  // For statistics use
    public static string place_2;  // For statistics use
    public static string place_3;  // For statistics use
    
    void Update() {

        // Bonus system. At the end of race car takes a bonus and minus it. Next finished car take bonus smaller.
        // It needs to save mathematics logic of rating and pass the situation when 1st finished car become 2nd if the distance
        // to target of the 2nd car is smaller.
        if (player_add_bonus) {
            player_bonus = end_race_bonus;
            end_race_bonus -= 10f;
            player_add_bonus = false;
        } 
        if (black_add_bonus) {
            black_bonus = end_race_bonus;
            end_race_bonus -= 10f;
            black_add_bonus = false;
        } 
        if (blue_add_bonus) {
            blue_bonus = end_race_bonus;
            end_race_bonus -= 10f;
            blue_add_bonus = false;
        }

        // Calculate distance between car and target for each car
        float player_target_distance = Vector3.Distance(player_car.transform.position, CheckPointsList.CheckPoints[CheckPointsList.n].transform.position);
        float black_target_distance = Vector3.Distance(black_car.transform.position, CheckPointsList.CheckPoints[CheckPointsList.m].transform.position);
        float blue_target_distance = Vector3.Distance(blue_car.transform.position, CheckPointsList.CheckPoints[CheckPointsList.k].transform.position);

        // Calculate rating points
        // First point is amount of finished laps (1p for each)
        // Second point is amount of finished checkpoints in current lap (0.1p for each)
        // Third point is distance to current target. The biggest number is near the target (0.000001p for each distance point)
        float player_rating = LapTimeManager.laps_current_player + CheckPointsList.n / 10f + (10000f - player_target_distance) / 1000000f;
        float black_rating = LapTimeManager.laps_current_black + CheckPointsList.m / 10f + (10000f - black_target_distance) / 1000000f;
        float blue_rating = LapTimeManager.laps_current_blue + CheckPointsList.k / 10f + (10000f - blue_target_distance) / 1000000f;

        // Add bonus to car rating
        player_rating += player_bonus;
        black_rating += black_bonus;
        blue_rating += blue_bonus;

        // Fill the CarRating class by cars, rating values and race time
        List<CarRating> rating = new List<CarRating>() {
            new CarRating() { Name = "Player", Rating = player_rating, race_time = LapTimeManager.player_race_time_text },
            new CarRating() { Name = "Black car", Rating = black_rating, race_time = LapTimeManager.black_race_time_text },
            new CarRating() { Name = "Blue car", Rating = blue_rating, race_time = LapTimeManager.blue_race_time_text }        
        };

        // Sort rating by amount of points. 1st car has the biggest amount of points
        List<CarRating> rating_sorted = rating.OrderBy(x => x.Rating).ToList();

        // Save car names and race time by number of place for Statistics
        place_1 = rating_sorted[2].Name + " (" + rating_sorted[2].race_time + ")";
        place_2 = rating_sorted[1].Name + " (" + rating_sorted[1].race_time + ")";
        place_3 = rating_sorted[0].Name + " (" + rating_sorted[0].race_time + ")";

        // Show rating in race
        text_1st.text = rating_sorted[2].Name;
        text_2nd.text = rating_sorted[1].Name;
        text_3rd.text = rating_sorted[0].Name;
    }
}