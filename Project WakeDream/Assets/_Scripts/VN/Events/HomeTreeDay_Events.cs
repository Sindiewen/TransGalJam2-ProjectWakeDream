using UnityEngine;
using Fungus;

public class HomeTreeDay_Events : MonoBehaviour
{
    // public variables
    public Flowchart homeTreeDay;   // Reference to the evening tree

    public bool dadWorkingDay;  // Copies the value from the tree - checks if dads working in the evening

    // Gets the references to allow calculating the happiness values
    public homeTreeDayEvents homeTreeDayEvents;


    // Private variables
    private string strDialougeText1 = null;   // Stores the potential string dailouge that will be printed to the VN	

    private int randNum;    // Stores random number



    // Class implemtnation

    // Seeds the evening events
    // 	Using the dadWorkingEvening variable, we will use this to check if
    // dad is home to properly seed the events that will happen
    public void seedDayEvents()
    {
        // Checks if dad is working in the evening
        dadWorkingDay = homeTreeDay.GetBooleanVariable("dadWorkingDay");

        // IF The dad is working in the eveng, allow for special evening based events to happenj
        if (dadWorkingDay)
        {
            // Seeds random number for the rng
            randNum = Random.Range(0, 4);
            switch (randNum)
            {
                case 0: // internet down
                    _homeEventEveningInternetDown();
                    break;

                case 1: // New episode of favorite youtube channel
                    _homeEventEveningNewYTEpisode();
                    break;

                case 2: // Mail delivery
                    _homeEventEveningMailDelivery();
                    break;

                case 3: // Fridge refilled
                    _homeEventEveningFridgeRefilled();
                    break;
            }
        }

        else
        {
            randNum = Random.Range(0, 2);
            switch (randNum)
            {
                case 0: // Dad hostile lecture
                    _homeEventEveningDadHostileLecture();
                    break;

                case 1: // Dad calm, happy talk
                    _homeEventEveningDadHappyTalk();
                    break;
            }
        }

        homeTreeDay.SetStringVariable("strDay", strDialougeText1);
    }


    // Day Events Dad Working methods
    private void _homeEventEveningInternetDown()
    {
        // Internet down
        strDialougeText1 = "You notice the internet went down. Thankfully the old trick" +
        " of unplugging and replugging in the router gets it back up in no time!";
        homeTreeDayEvents.aloneEvent_InternetDown();
    }

    private void _homeEventEveningNewYTEpisode()
    {
        // New YT episode
        strDialougeText1 = "You hop onto your computer, and notice one of your favorite youtubers updated " +
        " and released a brand new video! You watch in glee.";
        homeTreeDayEvents.aloneEvent_NewYTEpisode();
    }

    private void _homeEventEveningMailDelivery()
    {
        // Mail delivery
        strDialougeText1 = "You notice that a package addressed to you just arrived!" +
        " You wonder what it is...";
        homeTreeDayEvents.aloneEvent_MailDelivery();
    }

    private void _homeEventEveningFridgeRefilled()
    {
        // Fridge refiled
        strDialougeText1 = "You open the fridge and noticed your dad refilled the fridge. Since you're home alone,"
        + "You get first dibs to making dinner with it!";
        homeTreeDayEvents.aloneEvent_FridgeRefilled();
    }


    // Dad not working methods
    private void _homeEventEveningDadHostileLecture()
    {
        // Dad gives a rather hostile lecture 
        strDialougeText1 = "Your dad gives you a relatively hostile lecture. You stay quiet as he berates you." +
        " You don't feel good.";
        homeTreeDayEvents.dadHomeEvent_Lecture();
    }

    private void _homeEventEveningDadHappyTalk()
    {
        strDialougeText1 = "You and your dad have a nice, relaxing talk. It's kind of nice to hear.";
        homeTreeDayEvents.dadHomeEvent_HappyTalk();
    }


}
