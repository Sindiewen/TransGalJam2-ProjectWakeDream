using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionResponses/ChangeRoom")]
public class ChangeRoomResponse : ActionResponse
{
    public Room roomToChangeTo;

    public override bool doActionResponse(TxtAdvController controller)
    {
        // If use the item in the right room, then change to room where doors open
        if (controller.roomNavigation.currentRoom.roomName == requiredString)
        {
            controller.roomNavigation.currentRoom = roomToChangeTo;
            controller.DisplayRoomText();
            return true;
        }

        return false;
    }

}
