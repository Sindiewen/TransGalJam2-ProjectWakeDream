using UnityEngine;

public class SleepTreeHappinessEvents : MonoBehaviour
{
    // Variables
    [HeaderAttribute("Dream Events")]
    public int depressedNightmare;
    public int depressedNoDream;

    public int neutralDream;

    public int happyGoodDream;
    public int happyBadDream;

    private Hapiness_Calculator happyCalc;

    private void Start()
    {
        happyCalc = gameObject.GetComponent<Hapiness_Calculator>();
    }

    // Dream Events
    public void depressed_Nightmare()
    {
        happyCalc.calculateHappinessValueOnMood(depressedNightmare);
    }

    public void depressed_NoDream()
    {
        happyCalc.calculateHappinessValueOnMood(depressedNoDream);
    }

    public void neutral_Dream()
    {
        happyCalc.calculateHappinessValueOnMood(neutralDream);
    }

    public void happy_GoodDream()
    {
        happyCalc.calculateHappinessValueOnMood(happyGoodDream);
    }

    public void happy_BadDream()
    {
        happyCalc.calculateHappinessValueOnMood(happyBadDream);
    }
}
