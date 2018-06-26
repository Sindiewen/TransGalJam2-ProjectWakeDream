using UnityEngine;

public class homeTreeMorningHappinessEvents : MonoBehaviour
{
	
	// Variables
	[HeaderAttribute("DayStart Block")]
	public int dayStartWeatherRain;
	public int dayStartWeatherSunny;
	public int dayStartWeatherCloudy;

	[HeaderAttribute("School Day - Clothing Decision Block")]
	public int clothingDecisionSchoolDress;
	public int clothingDecisionSchoolNotDress;

	[HeaderAttribute("Break Day - Clothing Decision Block")]
	public int clothingDecisionBreakDressDadHome;
	public int clothingDecisionBreakDressAlone;
	public int clothingDecisionBreakNoDressDadHome;
	public int clothingDecisionBreakNoDressAlone;

    private Hapiness_Calculator happyCalc;

    private void Start()
    {
        happyCalc = gameObject.GetComponent<Hapiness_Calculator>();
    }

    // Home Tree - Morning events

    // DayStart Block
    public void dayStart_WeatherRain()
	{
        happyCalc.calculateHappinessValueOnMood(dayStartWeatherRain);
	}

    public void dayStart_WeatherSunny()
	{
        happyCalc.calculateHappinessValueOnMood(dayStartWeatherSunny);
	}

    public void dayStart_WeatherCloudy()
	{
        happyCalc.calculateHappinessValueOnMood(dayStartWeatherCloudy);
	}


    // School Day - Clothing Decision
    public void clothingDecisionSchool_Dress()
	{
        happyCalc.calculateHappinessValueOnMood(clothingDecisionSchoolDress);
	}

    public void clothingDecisionSchool_NotDress()
	{
        happyCalc.calculateHappinessValueOnMood(clothingDecisionSchoolNotDress);
	}


    // Break Day - Clothing Decision
    public void clothingDecisionBreak_DressDadHome()
	{
        happyCalc.calculateHappinessValueOnMood(clothingDecisionBreakDressDadHome);
	}

    public void clothingDecisionBreak_DressAlone()
	{
        happyCalc.calculateHappinessValueOnMood(clothingDecisionBreakDressAlone);
	}

    public void clothingDecisionBreak_NoDressDadHome()
	{
        happyCalc.calculateHappinessValueOnMood(clothingDecisionBreakNoDressDadHome);
	}

    public void clothingDecisionBreak_NoDressAlone()
	{
        happyCalc.calculateHappinessValueOnMood(clothingDecisionBreakNoDressAlone);
	}

}
