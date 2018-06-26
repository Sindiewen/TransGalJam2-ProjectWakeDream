using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class Player_Controller : MonoBehaviour
{
    // Private class variables


    // public Class Variables
    // Fungus references
    // variable flowcharts
    public Flowchart variableFlowchart;     // Declares the flowchart variable
    //public Flowchart moodFlowchart;         // Reference to the moodFlowchart and it's blocks

    // game flowcharts
    public Flowchart homeTreeMorning;       // Reference to the hometreemorning flowchart
    public Flowchart deathTree;             // reference to the deathTree

    // Unity UI References
    public Slider happinessSlider;  // Visual representation of the player happiness

    [Header("Player Attributes")]
    // Player Values
    [Range(0, 399)] public int happiness;           // Stores the player happiness
    [Range(0, 3)]   public int curMood;             // Stores the current player mood - 0 = depressed, 1 = sad, 2 = neutral, 3 = happy
    public int weather;

    public string currentDay;       // Stores what the current day is
    public string nextDay;          // Stores what the next day will be

    public bool isOnBreak;          // Flag to check if the current day is a break day or not
    public bool dadWorkingToday;    // Flag to check is the dad is working the current day





    // Private Class Methods

    private void Start()
    {

        setInitialPlayerAttributes();
    }


    
    //////////////////////////////////////////////////////////////////
    // Updates script variables with the variableFlowchart variables if changed
    //////////////////////////////////////////////////////////////////
    private void Update ()
    {  
        // Updates Sets the happiness and it's slider slider
        happiness = variableFlowchart.GetIntegerVariable("happiness");
        happinessSlider.value = happiness;

        // Updates the player mood
        curMood = variableFlowchart.GetIntegerVariable("curMood");

        // Updates the weather
        weather = variableFlowchart.GetIntegerVariable("weather");


        // It's Impossible for your happiness level to be less than 0.
        // IF it is, TODO: "kill" player.
        if (happiness <= 50)// || Input.GetKeyDown(KeyCode.K))
        {
            happiness = 0;
            updatePlayerAttributes();
            kill();
        }

	}


    // Sets Up Initial the current values for the player
    private void setInitialPlayerAttributes()
    {
        // Sets up the current attributres for the player
        variableFlowchart.SetIntegerVariable("happiness", happiness);

        if (happiness <= 99)
        {
            curMood = 0;
        }
        else if (happiness >= 100 && happiness <= 199)
        {
            curMood = 1;
        }
        else if (happiness >= 200 && happiness <= 299)
        {
            curMood = 2;
        }
        else if (happiness >= 300 && happiness <= 399)
        {
            curMood = 3;
        }

        //moodValue = happiness % 100;

        variableFlowchart.SetIntegerVariable("curMood", curMood);
        variableFlowchart.SetIntegerVariable("weather", weather);
        variableFlowchart.SetStringVariable("currentDay", currentDay);
        variableFlowchart.SetStringVariable("nextDay", nextDay);
        variableFlowchart.SetBooleanVariable("isOnBreak", isOnBreak);
        variableFlowchart.SetBooleanVariable("dadWorkingToday", dadWorkingToday);
    }


    /// ////////////////////////////////////////////
    // Updates flowchart attributes for the player
    /// ////////////////////////////////////////////
    public void updatePlayerAttributes()
    {
        if (happiness > 399)
        {
            happiness = 399;
        }
        variableFlowchart.SetIntegerVariable("happiness", happiness);
        variableFlowchart.SetIntegerVariable("curMood", curMood);
    }





    // Public Class Methods

    // Checks to see if any values caused any change to the player.
    public void playerMoodCheck()
    {
        int prevMood = curMood; // Stores the previous player mood
        string moodStr = null;


        // Updates the current mood by the happiness value's hundredth place
        if (happiness <= 99)
        {
            curMood = 0;
        }
        else if (happiness >= 100 && happiness <= 199)
        {
            curMood = 1;
        }
        else if (happiness >= 200 && happiness <= 299)
        {
            curMood = 2;
        }
        else if (happiness >= 300 && happiness <= 399)
        {
            curMood = 3;
        }


        // If the current mood changed either by less than or greater than prevMood. Or Even stayed the same.
        if (curMood < prevMood)
        {
            happiness -= 25;
            moodStr = "You wake up, but you don't feel good right now. You feel like your mood just got shot.";
        }
        else if (curMood > prevMood)
        {
            curMood++;
            happiness += 10;
            moodStr = "As you wake up, your mood just feels overall better. You feel a slightly bit happier.";
        }
        else
        {
            moodStr = "You feel as your mood didn't change much at all, in fact you feel relativley as you felt yesterday.";
        }


        // Updates attributes
        updatePlayerAttributes();
        homeTreeMorning.SetStringVariable("calculateMoodText", moodStr);
    }

    

    private void kill()
    {
        happinessSlider.enabled = false;
        SceneManager.LoadScene("Kill");
    }



    /*
    // Mood based methods
    // Calclates what type of dream the player has
    public void calculateDream()
    {
        int randNum = Random.Range(0, 9);
        string dreamText = null;
        Debug.Log("Dream Number Generator: " + randNum);

        // plyaer is depresseed
        if (curMood == 0)
        {
            // Player has chance to get dream good or bad
            if (randNum > 6)
            {
                // give player nightmare
                dreamText = "Due to your depression, You had an unspeakable nightmare during the night, " +
                    "You tossed and turned and was overly scared about your dream. This dream will startle you and affect the " +
                    "rest of your day.";
                happiness -= 50;
            }
            else
            {
                // give player no dream - + happiness + mood
                dreamText = "You fell asleep, There was no dream. Only a deep blackness that you were lying in " +
                    "for what you thought were minuites before you woke up. You're happy that you didn't have any" +
                    "dream that emotionally hurt you.";
                happiness += 10;

            }
            
        }
        
        // else if player is not happy and the rng + cur mood made a number greater than 4
       else if (curMood != 3 && randNum + curMood > 5)
        {
            // Give the player a good dream
            dreamText = "Your neutral mood for the day gave you a good dream. Nothing overly exciting," +
                " but you woke up to something to smile about.";
            happiness += 20;
        }

        else if (curMood == 3)
        {
            if (randNum < 6)
            {
                // give player good dream
                dreamText = "Your good mood gave you such an enjoyable good dream last night. Your woke up feeling really good.";
                happiness += 25;
            }
            else
            {
                // give player bad dream - mood decrease
                dreamText = "Despite your good mood, you had a bad dream. You woke up shaking and wondering why " +
                    "you had this type of dream in the first place.";
                happiness -= 50;
            }
        }

        // Player had no dream
        else
        {
            dreamText = "You didnt have a dream last night. You fell asleep and just woke up in what you thought was an instant.";
        }

        updatePlayerAttributes();
        homeTreeMorning.SetStringVariable("dreamText", dreamText);

    }
    
    

    // If the player is currently depressed
    private void moodDepressed()
    {

    }

    */
    
}
