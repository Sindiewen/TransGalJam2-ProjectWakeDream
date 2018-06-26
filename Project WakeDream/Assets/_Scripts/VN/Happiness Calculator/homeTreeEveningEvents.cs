using UnityEngine;

public class homeTreeEveningEvents : MonoBehaviour
{

    // Variables
    [HeaderAttribute("If player can dress up values")]
    public int canDressUpEvening;
    public int cantDressUpEvening;

    [HeaderAttribute("Early/Late Evening Events")]
    public int dadHome_Lecture;
    public int dadHome_HappyTalk;

    public int alone_InternetDown;
    public int alone_NewYTEpisode;
    public int alone_MailDelivery;
    public int alone_FridgeRefilled;

    [HeaderAttribute("Alone Activities")]
    public int alone_PlayPCGames;
    public int alone_PlayGuitar;
    public int alone_CleanHouse;
    public int alone_WatchAnime;
    public int alone_SleepEarly;

    [HeaderAttribute("Dad Home Activities")]
    public int dadHome_PlayPCGames;
    public int dadHome_PlayGuitar;
    public int dadHome_CleanHouse;
    public int dadHome_SleepEarly;

    private Hapiness_Calculator happyCalc;

    private void Start()
    {
        happyCalc = gameObject.GetComponent<Hapiness_Calculator>();
    }

    // If player can dress up in the evening
    public void eveningEvent_CanDressUp()
    {
        happyCalc.calculateHappinessValueOnMood(canDressUpEvening);
    }

    public void eveningEvent_cantDressUp()
    {
        happyCalc.calculateHappinessValueOnMood(cantDressUpEvening);
    }

    // Early/Late Day Events
    // Dad Home
    public void dadHomeEvent_Lecture()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_Lecture);
    }

    public void dadHomeEvent_HappyTalk()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_HappyTalk);
    }

    // Alone
    public void aloneEvent_InternetDown()
    {
        happyCalc.calculateHappinessValueOnMood(alone_InternetDown);
    }

    public void aloneEvent_NewYTEpisode()
    {
        happyCalc.calculateHappinessValueOnMood(alone_NewYTEpisode);
    }

    public void aloneEvent_MailDelivery()
    {
        happyCalc.calculateHappinessValueOnMood(alone_MailDelivery);
    }

    public void aloneEvent_FridgeRefilled()
    {
        happyCalc.calculateHappinessValueOnMood(alone_FridgeRefilled);
    }


    // Alone Activities
    public void aloneActivity_PlayPCGames()
    {
        happyCalc.calculateHappinessValueOnMood(alone_PlayPCGames);
    }

    public void aloneActivity_PlayGuitar()
    {
        happyCalc.calculateHappinessValueOnMood(alone_PlayGuitar);
    }

    public void aloneActivity_CleanHouse()
    {
        happyCalc.calculateHappinessValueOnMood(alone_CleanHouse);
    }

    public void aloneActivity_WatchAnime()
    {
        happyCalc.calculateHappinessValueOnMood(alone_WatchAnime);
    }

    public void aloneActivity_SleepEarly()
    {
        happyCalc.calculateHappinessValueOnMood(alone_SleepEarly);
    }

    // Dad Home Activities
    public void dadHomeActivity_PlayPCGames()
    {
        happyCalc.calculateHappinessValueOnMood(alone_PlayPCGames);
    }

    public void dadHomeActivity_PlayGuitar()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_PlayGuitar);
    }

    public void dadHomeActivity_CleanHouse()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_CleanHouse);
    }

    public void dadHomeActivity_SleepEarly()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_SleepEarly);
    }

}
