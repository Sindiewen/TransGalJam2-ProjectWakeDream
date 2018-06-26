using UnityEngine;

public class SchoolTreeHappinessEvents : MonoBehaviour
{
	
	// Variables
	[HeaderAttribute("Bus Activity Block")]
    public int listenToUpbeatMusic;
    public int listenToMeloncholicMusic;
    public int playGameOnDS;
    public int watchAnimeBus;
    public int daydreamBus;

    [HeaderAttribute("BusEvents")]
    public int busEventLoudppl;
    public int busEventHittingSeat;
    public int busEventSittingWithFriend;

    [HeaderAttribute("Before/After Lunch Event Block")]
    public int schoolEventFight;
    public int schoolEventHarassment;
    public int schoolEventFirealarm;
    public int schoolEventFriendEncounter;
	

    [HeaderAttribute("LunchActivity Block")]
    public int playGameOnComputer;
    public int playCardGameswithFriends;
    public int playOnDS;
    public int watchAnime;
    public int daydream;

    private Hapiness_Calculator happyCalc;

    private void Start()
    {
        happyCalc = gameObject.GetComponent<Hapiness_Calculator>();
    }

    // Home Tree - Morning events

    // Bus Activity Block
    public void BusActivity_listenToUpbeatMusic()
    {
        happyCalc.calculateHappinessValueOnMood(listenToUpbeatMusic);
    }

    public void BusActivity_listenToMeloncholicMusic()
    {
        happyCalc.calculateHappinessValueOnMood(listenToUpbeatMusic);
    }

    public void BusActivity_playGameOnDS()
    {
        happyCalc.calculateHappinessValueOnMood(playGameOnDS);
    }

    public void BusActivity_watchAnimeBus()
    {
        happyCalc.calculateHappinessValueOnMood(watchAnimeBus);
    }

    public void BusActivity_daydreamBus()
    {
        happyCalc.calculateHappinessValueOnMood(daydreamBus);
    }


    // Bus Events
    public void busEvent_LoudPpl()
    {
        happyCalc.calculateHappinessValueOnMood(busEventLoudppl);
    }

    public void busEvent_HittingSeat()
    {
        happyCalc.calculateHappinessValueOnMood(busEventHittingSeat);
    }

    public void busEvent_SittingWithFriend()
    {
        happyCalc.calculateHappinessValueOnMood(busEventSittingWithFriend);
    }


    // Before/After Lunch Events
    public void schoolEvent_FightFunc()
    {
        happyCalc.calculateHappinessValueOnMood(schoolEventFight);
    }

    public void schoolEvent_HarassmentFunc()
    {
        happyCalc.calculateHappinessValueOnMood(schoolEventHarassment);
    }

    public void schoolEvent_FireAlarmFunc()
    {
        happyCalc.calculateHappinessValueOnMood(schoolEventFirealarm);
    }

    public void schoolEvent_FriendEncounterFunc()
    {
        happyCalc.calculateHappinessValueOnMood(schoolEventFriendEncounter);
    }


    // Lunch Activity
    public void lunchActivity_playGameOnComputer()
    {
        happyCalc.calculateHappinessValueOnMood(playGameOnComputer);
    }

    public void lunchActivity_playCardGamesWithFriends()
    {
        happyCalc.calculateHappinessValueOnMood(playCardGameswithFriends);
    }

    public void lunchActivity_playOnDS()
    {
        happyCalc.calculateHappinessValueOnMood(playOnDS);
    }

    public void lunchActivity_watchAnime()
    {
        happyCalc.calculateHappinessValueOnMood(watchAnime);
    }

    public void lunchActivity_daydream()
    {
        happyCalc.calculateHappinessValueOnMood(daydream);
    }


}
