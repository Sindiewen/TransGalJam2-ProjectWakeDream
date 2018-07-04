using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtAdvController : MonoBehaviour
{
    // Public Variables
    [HideInInspector]
    public RoomNavigation roomNavigation;
    [HideInInspector]
    public List<string> interactionDescrptionsInRoom = new List<string>();
    [HideInInspector]
    public InteractableItems interactableItems;

    public Text displayText;    // Displays all text to the screen
    public InputAction[] inputActions; // Stores all the possible input actions


    private List<string> actionLog = new List<string>();    // Stores list of actions




    #region public Functions


    /// <summary>
    /// Displays the current room text.
    /// </summary>
    public void DisplayRoomText()
    {
        // Clears collectsions for new room
        ClearCollectionsForNewRoom();

        // Unpacks all exits in room
        UnpackRoom();

        string joinInteractionDescriptions = string.Join("\n", interactionDescrptionsInRoom.ToArray());

        // COmbines text together
        string CombinedText = roomNavigation.currentRoom.roomDescription + "\n" + joinInteractionDescriptions;

        // Passes that text to the action log
        LogStringWithReturn(CombinedText);
    }


    /// <summary>
    /// Prints all logged from the action log to the display
    /// </summary>
    public void DisplayLoggedText()
    {
        // Creates logged text by joining it all to an array and storying it here
        string logAsText = string.Join("\n", actionLog.ToArray());

        // sets the display text
        displayText.text = logAsText;
    }


    /// <summary>
    /// Logs the string to the action log
    /// </summary>
    /// <param name="stringToAdd"></param>
    public void LogStringWithReturn(string stringToAdd)
    {
        // Adds string to the action log
        actionLog.Add(stringToAdd + "\n");
    }


    /// <summary>
    /// Checks if dictionary has verb has nouns
    /// </summary>
    /// <param name="verbDict"></param>
    /// <param name="verb"></param>
    /// <param name="noun"></param>
    /// <returns></returns>
    public string testVerbDictionaryWithNoun(Dictionary<string, string> verbDict, string verb, string noun)
    {
        // Checks if the noun is in the verb dict
        if (verbDict.ContainsKey(noun))
        {
            return verbDict[noun];
        }

        // Add funny response here
        return "you can't " + verb + " " + noun;
    }

    #endregion



    #region private Functions

    // Unity functions
    private void Awake ()
    {
        // Reference to the room navigation
        roomNavigation = GetComponent<RoomNavigation>();
        interactableItems = GetComponent<InteractableItems>();
	}

    private void Start()
    {
        // starts initial room
        //DisplayRoomText();
        //DisplayLoggedText();
    }


    // Game controller functions
    /// <summary>
    /// Unpacks the room 
    /// </summary>
    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        PrepareObjects(roomNavigation.currentRoom);
    }

    /// <summary>
    /// Prepares objects inside the room for interacting, taking, examining, etc...
    /// </summary>
    /// <param name="currentRoom"></param>
    private void PrepareObjects(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjects.Length; i++)
        {
            // If it doesn't find object not in inventory, stores description
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);

            // If not null
            if (descriptionNotInInventory != null)
            {
                // Stores descriptions into the list
                interactionDescrptionsInRoom.Add(descriptionNotInInventory);
            }

            // Add interactable object
            InteractableObject interactableInRoom = currentRoom.interactableObjects[i];

            // Iterates through the interactables in the room
            for (int j = 0; j < interactableInRoom.interactions.Length; j++)
            {
                // stores the current interation at [j]
                Interaction interaction = interactableInRoom.interactions[j];


                

                // If the player types in examine
                if (interaction.inputAction.Keyword == "examine")
                {
                    // Stores interactable into the dict
                    interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }

                // If the player types in take
                if (interaction.inputAction.Keyword == "take")
                {
                    // Stores interactable into the dict
                    interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
            }
        }
    }

    /// <summary>
    /// Clears the descritions and the exits
    /// </summary>
    private void ClearCollectionsForNewRoom()
    {
        interactionDescrptionsInRoom.Clear();
        roomNavigation.ClearExits();
        interactableItems.clearCollections();
    }





    #endregion

}
