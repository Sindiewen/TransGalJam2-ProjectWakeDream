using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(TxtAdvController controller, string[] separatedInputWords)
    {
        // Passes the 2nd word in the input to change rooms
        controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }

}
