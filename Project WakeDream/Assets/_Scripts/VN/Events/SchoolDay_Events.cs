using UnityEngine;
using Fungus;

/// <Summary>
/*
 * This is a script which will store each potential school based event from:
 * - School Bus Events
 * - School Day events/activities
*/
/// </Summary>
public class SchoolDay_Events : MonoBehaviour
{

    // Refence to the SchholTree Happiness Events class
    public SchoolTreeHappinessEvents schoolTreeHappinessEvents;

	// Class Objects
	public Flowchart schoolTree;    // Stores reference to the schoolTree flowchart

    // Private Variables
    private string strDialougeText1 = null;   // Stores the potential string dailouge that will be printed to the VN	

    private int randNum;	// Stores a random number




	// Public Class Methods //

	// WHen called, this method will generate seed a number and correspond that number to another method that 
	// the numver lands on.
	public void seedSchoolBusEvent()
	{
		randNum = Random.Range(0, 3);
		
		switch(randNum)
		{
			case 0:	// Loud peole on bus
				_busEventLoudPeople();
				break;

			case 1:	// Annoying person hitting my seat
				_busEventHittingSeat();
				break;

			case 2:	// sitting with friend
				_busEventSittingWithFriend();
				break;
		}

        schoolTree.SetStringVariable("schoolStr", strDialougeText1);
	}


    // Seeds events for school
    // WHen called, this method will generate seed a number and correspond that number to another method that 
    // the numver lands on.
    public void seedDuringSchoolEvents()
    {
        randNum = Random.Range(0, 4);

        switch (randNum)
        {
            case 0:
                _schoolEventFight();
                break;

            case 1:
                _schoolEventHarassment();
                break;

            case 2:
                _schoolEventFireAlarm();
                break;

            case 3:
                _schoolEventFriendEncounter();
                break;
        }

        schoolTree.SetStringVariable("schoolStr", strDialougeText1);
    }



    /* School Bus Events */
    // Private Class Methods
    private void _busEventLoudPeople()
    {
        // This event is there is loud people on the bus
        strDialougeText1 = "As you get on the bus, you notice there are plenty of loud highschoolers on the bus."
            + " You feel this sense of hostility from the students. You attempt to mind your own business." +
            "One of the teens throw something at you, you prompty ignore them and mind your own business.";
        schoolTreeHappinessEvents.busEvent_LoudPpl();
    }

    private void _busEventHittingSeat()
    {
        // Event for annyoing person hitting seats
        strDialougeText1 = "As you sit down in your seat, some jerkoff decides to hit your seat from behind. Needless to say, this" +
            " angers you alot, But you do nothing.";
        schoolTreeHappinessEvents.busEvent_HittingSeat();
    }

    private void _busEventSittingWithFriend()
    {
        // A friend of your sat next to you on the bus.
        strDialougeText1 = "You notice one of your friends happens to be on the bus today. You take a seat with him. It's comforting to" +
            "have a friend with you on the bus today.";
        schoolTreeHappinessEvents.busEvent_SittingWithFriend();
    }


    /* During School Event */
    private void _schoolEventFight()
    {
        // Fight breaks out
        strDialougeText1 = "A fight breaks out and gets in your way. Thankfully you know to stay out of it, but" +
            " it's always very annoying to see.";
        schoolTreeHappinessEvents.schoolEvent_FightFunc();
    }

    private void _schoolEventHarassment()
    {
        // some dude harassess me
        strDialougeText1 = "Someone decides to try and harass me, brining my spirits down. I promptly ignore and continue" +
            " moving forward.";
        schoolTreeHappinessEvents.schoolEvent_HarassmentFunc();
    }

    private void _schoolEventFireAlarm()
    {
        strDialougeText1 = "The fire alarm went off. It's hard to tell if someone pulled it, or it's a test. " +
            "You use this time during the fire alarm to unwind.";
        schoolTreeHappinessEvents.schoolEvent_FireAlarmFunc();
    }

    private void _schoolEventFriendEncounter()
    {
        strDialougeText1 = "You randomly run into a friend and have a quick conversation before moving on.";
        schoolTreeHappinessEvents.schoolEvent_FriendEncounterFunc();
    }
}