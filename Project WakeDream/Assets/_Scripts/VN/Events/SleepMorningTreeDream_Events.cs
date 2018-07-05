using UnityEngine;
using Fungus;

public class SleepMorningTreeDream_Events : MonoBehaviour
{
    public Player_Controller player;

    // Gets the reference to the sleepTreeHappiness events to allow calculating the happiness values
    public SleepTreeHappinessEvents sleepTreeHappinessEvents;

    public Flowchart sleepTree;



    // Mood based methods
    // Calclates what type of dream the player has
    public void calculateDream()
    {
        int randNum = Random.Range(0, 9);
        string dreamText = null;
        Debug.Log("Dream Number Generator: " + randNum);

        // plyaer is depresseed
        if (player.curMood == 0)
        {
            // Player has chance to get dream good or bad
            if (randNum > 6)
            {
                // give player nightmare
                dreamText = "Due to your depression, You had an unspeakable nightmare during the night, " +
                    "You tossed and turned and was overly scared about your dream. This dream will startle you and affect the " +
                    "rest of your day.";
                sleepTreeHappinessEvents.depressed_Nightmare();
            }
            else
            {
                // give player no dream - + happiness + mood
                dreamText = "You fell asleep, There was no dream. Only a deep blackness that you were lying in " +
                    "for what you thought were minuites before you woke up. You're happy that you didn't have any" +
                    "dream that emotionally hurt you.";
                sleepTreeHappinessEvents.depressed_NoDream();

            }

        }

        // else if player is not happy and the rng + cur mood made a number greater than 4
        else if (player.curMood != 3 && randNum + player.curMood > 5)
        {
            // Give the player a good dream
            dreamText = "Your neutral mood for the day gave you a good dream. Nothing overly exciting," +
                " but you woke up to something to smile about.";
            sleepTreeHappinessEvents.neutral_Dream();
        }

        else if (player.curMood == 3)
        {
            if (randNum < 6)
            {
                // give player good dream
                dreamText = "Your good mood gave you such an enjoyable good dream last night. Your woke up feeling really good.";
                sleepTreeHappinessEvents.happy_GoodDream();
            }
            else
            {
                // give player bad dream - mood decrease
                dreamText = "Despite your good mood, you had a bad dream. You woke up shaking and wondering why " +
                    "you had this type of dream in the first place.";
                sleepTreeHappinessEvents.happy_BadDream();
            }
        }

        // Player had no dream
        else
        {
            dreamText = "You didnt have a dream last night. You fell asleep and just woke up in what you thought was an instant.";
        }

        sleepTree.SetStringVariable("dreamText", dreamText);

    }
}
