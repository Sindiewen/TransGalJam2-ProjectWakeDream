using UnityEngine;

public class homeTreeDayEvents : MonoBehaviour
{

    // Variables
    [HeaderAttribute("Early/Late Day Events")]
    public int dadHome_Lecture;
    public int dadHome_HappyTalk;

    public int alone_InternetDown;
    public int alone_NewYTEpisode;
    public int alone_MailDelivery;
    public int alone_FridgeRefilled;

    [HeaderAttribute("Alone Activities")]
    public int alone_PlayGuitar;
    public int alone_PlayPCGames;
    public int alone_OutsideIdle;
    public int alone_OutsideHike;
    public int alone_watchAnime;

    [HeaderAttribute("Dad Home Activities")]
    public int dadHome_PlayGuitar;
    public int dadHome_PlayPCGames;
    public int dadHome_OutsideIdle;
    public int dadHome_OutsideHike;
    public int dadHome_OutsideBike;

    private Hapiness_Calculator happyCalc;


    private void Start()
    {
        happyCalc = gameObject.GetComponent<Hapiness_Calculator>();;
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
    public void aloneActivity_PlayGuitar()
    {
        happyCalc.calculateHappinessValueOnMood(alone_PlayGuitar);
    }

    public void aloneActivity_PlayPCGames()
    {
        happyCalc.calculateHappinessValueOnMood(alone_PlayPCGames);
    }

    public void aloneActivity_OutsideIdle()
    {
        happyCalc.calculateHappinessValueOnMood(alone_OutsideIdle);
    }

    public void aloneActivity_OutsideHike()
    {
        happyCalc.calculateHappinessValueOnMood(alone_OutsideHike);
    }

    public void aloneActivity_WatchAnime()
    {
        happyCalc.calculateHappinessValueOnMood(alone_watchAnime);
    }

    // Dad Home Activities
    public void dadHomeActivity_PlayGuitar()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_PlayGuitar);
    }

    public void dadHomeActivity_PlayPCGames()
    {
        happyCalc.calculateHappinessValueOnMood(alone_PlayPCGames);
    }

    public void dadHomeActivity_OutsideIdle()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_OutsideIdle);
    }

    public void dadHomeActivity_OutsideHike()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_OutsideHike);
    }

    public void dadHomeActivity_OutsideBike()
    {
        happyCalc.calculateHappinessValueOnMood(dadHome_OutsideBike);
    }


}

