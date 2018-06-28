using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    // Public variables
    [HideInInspector]
    public List<string> nounsInRoom = new List<string>();   // Stores all the nouns in the room (nouns = items)
    public List<InteractableObject> usableItemList = new List<InteractableObject>();
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();


    // private variables
    private List<string> nounsInInventory = new List<string>(); // Stores all the nouns in the inventory (nouns = items)
    private TxtAdvController _controller;

    private Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();

    // Array of invalid strings
    private string[] invalidStrings = {"Take what?", "Are you sure that exists in the room?", "You grab air.",
    "It doesn't exist here.", "Invalid input"};


    #region public functions

    /// <summary>
    /// Returns any objects in the room that are not in the inventory
    /// </summary>
    /// <param name="currentRoom"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        // Initializes the interactable object that will be stores by the iterator from the current room
        InteractableObject interactableInRoom = currentRoom.interactableObjects[i];

        // checks if the current nouns in the inventory are not in the room
        if (!nounsInInventory.Contains(interactableInRoom.noun))
        {
            // Adds to nouns in room
            nounsInRoom.Add(interactableInRoom.noun);

            // Returns interactable in the room's description
            return interactableInRoom.description;
        }

        return null;
    }

    /// <summary>
    /// Checks if noun is in room so we can take it
    /// </summary>
    /// <param name="separatedInputWords"></param>
    /// <returns></returns>
    public Dictionary<string, string> takeItem (string[] separatedInputWords)
    {
        // stores the noun
        string noun = separatedInputWords[1];

        // If the room contains a noun, store it into the inventory
        if (nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            AddActionResponsesToUseDictionary();
            nounsInRoom.Remove(noun);
            return takeDictionary;
        }
        else
        {
            // It doesn't exist in this room
            int randInt = Random.Range(0, invalidStrings.Length + 1);

            if (randInt == 0)
            {
                _controller.LogStringWithReturn("There is no " + noun + " here to take.");
            }
            else
            {
                _controller.LogStringWithReturn(invalidStrings[randInt]);
            }

            return null;
        }
    }


    ////////////////////
    /// Custom actions
    ////////////////////

    /// <summary>
    /// Using item from inventory to room
    /// </summary>
    /// <param name="separatedInputWord"></param>
    public void useItem(string[] separatedInputWord)
    {
        string nounToUse = separatedInputWord[1];


        // Checks if noun is in inventory
        if (nounsInInventory.Contains(nounToUse))
        {
            // Checks if it can be used
            if (useDictionary.ContainsKey(nounToUse))
            {
                // Result of the action
                bool actionResult = useDictionary[nounToUse].doActionResponse(_controller);

                // Action failed - Nothing happened
                if (!actionResult)
                {
                    _controller.LogStringWithReturn("Hmm... Nothing happens.");
                }
            }
            else // Action failed - You can't use that 
            {
                _controller.LogStringWithReturn("You can't use the " + nounToUse);
            }
        }
        else // Item not in inventory
        {
            _controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use.");
        }
    }

    
    /// <summary>
    /// Stores the action responses that can be used in the room
    /// </summary>
    public void AddActionResponsesToUseDictionary()
    {
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            string noun = nounsInInventory[i];

            // get the object from the list based on the name 
            InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);

            // If null, continue
            if (interactableObjectInInventory == null)
            {
                continue;
            }
            
            // not null
            for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];

                if (interaction.actionResponse == null)
                {
                    continue;
                }

                if (!useDictionary.ContainsKey(noun))
                {
                    useDictionary.Add(noun, interaction.actionResponse);
                }
            }
        }
    }

    /// <summary>
    /// Displays the player's inventory
    /// </summary>
    public void displayInventory()
    {
        _controller.LogStringWithReturn("You're currently holding ");

        // if inventory empty
        if (nounsInInventory.Count == 0)
        {
            _controller.LogStringWithReturn("Nothing.\n");
        }
        else
        {
            for (int i = 0; i < nounsInInventory.Count; i++)
            {
                _controller.LogStringWithReturn(nounsInInventory[i]);
            }
        }

    }


    /// <summary>
    /// Clears colelctsions before leaving room
    /// </summary>
    public void clearCollections()
    {
        examineDictionary.Clear();
        takeDictionary.Clear();
        nounsInRoom.Clear();
    }

    #endregion

    #region private functions

    private void Awake()
    {
        // Get component
        _controller = GetComponent<TxtAdvController>();
    }

    private InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < usableItemList.Count; i++)
        {
            if (usableItemList[i].noun == noun)
            {
                return usableItemList[i];
            }
        }

        return null;
    }

    #endregion

}
