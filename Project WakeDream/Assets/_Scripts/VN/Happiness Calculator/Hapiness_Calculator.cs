using UnityEngine;
public class Hapiness_Calculator : MonoBehaviour
{
    //[HideInInspector]
    public Player_Controller player;

    [HeaderAttribute("Happiness Modifiers")]
    public int depressedModifier = -25;
    public int sadModifier = 0;
    public int neutralModifier = 7;
    public int happyModifier = 14;

    // Calculates happiness
    /// <summary>
    /// Takes the current happiness of the player, and uses that to calculate the happiness gain and loss.
    /// TODO: Figure out equation
    /// </summary>
    /// <param name="happinessAmmount"></param>
    /// <returns></returns>
    public void calculateHappinessValueOnMood(int happinessAmmount)
    {
        // Variables
        int totalHappiness = 0;
        int happinessModifier = 0;
        switch (player.curMood)
        {
            // Depressed
            case 0:
                happinessModifier = -depressedModifier;
                break;

            // Sad
            case 1:
                happinessModifier = sadModifier;
                break;

            // Neutral
            case 2:
                happinessModifier = neutralModifier;
                break;
            
            // Happy
            case 3:
                happinessModifier = happyModifier;
                break;
        }

        // Calculates the total happiness
        totalHappiness = happinessAmmount + happinessModifier;

        player.happiness += totalHappiness;

        player.updatePlayerAttributes();
    }



}
