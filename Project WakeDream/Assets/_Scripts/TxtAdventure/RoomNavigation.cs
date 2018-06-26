using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;


    // priavte varialbes
    private TxtAdvController _controller;    // Stores reference to the controller

    // Array of invalid strings
    private string[] invalidStrings = {"What?", "You can't go that way.", "You try and walk that direction but you land face first into a wall.",
    "You entered a magical portal that leads to unicorns and cotton candy. Oh wait never mind you got knocked out cold from trying to walk into a wall. That was all a dream.",
    "Nope.", "Invalid Direction", "Thats not a proper input silly!"};


    // Dictionary of exits
    private Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();


    #region private functions

    // Unity functions
    private void Awake()
    {
        // Gets reference to the controller
        _controller = GetComponent<TxtAdvController>();
    }

    #endregion

    /// <summary>
    ///  Attempting to change rooms
    /// </summary>
    /// <param name="directionNoun"></param>
    public void AttemptToChangeRooms(string directionNoun)
    {
        // If the exit exists
        if (exitDictionary.ContainsKey(directionNoun))
        {
            // Get the current room to the new room
            currentRoom = exitDictionary[directionNoun];

            _controller.LogStringWithReturn("You head off to the " + directionNoun);

            // Displays the new room text
            _controller.DisplayRoomText();
        }
        else
        {
            int randInt = Random.Range(0, invalidStrings.Length + 1);

            // Prints random invalid message with invalid input
            if (randInt == 0)
            {
                _controller.LogStringWithReturn("You cant go " + directionNoun + ".");
            }
            else
            {
                _controller.LogStringWithReturn(invalidStrings[randInt]);
            }
        }

    }

    /// <summary>
    /// Unpacks all the exits in the room and prints them to the display text area
    /// </summary>
    public void UnpackExitsInRoom()
    {
        // Loops through all the exits and prints them to the display, adds them to the dictionary
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            // Dictionary of exits. String of exit, and room to exit to
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);

            // Passes the exits to the txt adventure controller 
            _controller.interactionDescrptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    /// <summary>
    /// CLerars exits dictionary
    /// </summary>
    public void ClearExits()
    {
        exitDictionary.Clear();
    }


}