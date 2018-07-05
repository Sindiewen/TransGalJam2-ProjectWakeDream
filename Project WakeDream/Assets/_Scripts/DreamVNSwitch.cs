using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

/// <summary>
/// Defines swtiching between VN and TA
/// </summary>
public class DreamVNSwitch : MonoBehaviour
{
    // VN Flowchart
    public Flowchart sleepTree;
    public string blockToExecute;

    // TA, VN Game objects
    public GameObject VN;
    public GameObject TA;

    // Text adventure controller
    private TxtAdvController _controller;
    private RoomNavigation _roomNav;
    public Room exitToVNRoom;
    public InputField _inputField;
    public Room[] StoryRooms;           // Stores rooms for the story


    // Private variables
    //private bool _isInVN;
    //private bool _isInTA;






    #region public func


    /// <summary>
    /// Enters text adventure
    /// </summary>
    public void enterTA()
    {
        //_isInTA = true;
        //_isInVN = false;

        // Disable the VN stuff, enable TA stuff
        VN.SetActive(false);
        TA.SetActive(true);

        // Enter next room for dream world, ensure that it prints next room and everything
        _roomNav.currentRoom = StoryRooms[sleepTree.GetIntegerVariable("DayCount")];

        // Prints out tons of blank space
        _controller.LogStringWithReturn("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
            "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        
        // Prints new room text
        _controller.DisplayRoomText();
        _controller.DisplayLoggedText();

        // Reactivates the input field when enter/return is pressed
        _inputField.ActivateInputField();

        // Empties inputfield for the player
        _inputField.text = null;

    }

    /// <summary>
    /// Enters vis novel
    /// </summary>
    public void enterVN()
    {
        //_isInVN = true;
        //_isInTA = false;

        VN.SetActive(true);
        TA.SetActive(false);

        // Iterates day by 1
        sleepTree.SetIntegerVariable("DayCount", sleepTree.GetIntegerVariable("DayCount") + 1);

        // Calls the block that starts the VN
        sleepTree.ExecuteBlock(blockToExecute);

        
    }





    #endregion

    #region private func
    private void Start()
    {
        _controller = GetComponent<TxtAdvController>();
        _roomNav = GetComponent<RoomNavigation>();
    }

    #endregion
}
