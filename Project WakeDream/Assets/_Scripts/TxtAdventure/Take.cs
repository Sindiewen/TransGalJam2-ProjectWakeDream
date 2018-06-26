using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("TextAdventure/InputActions/Take"))]
public class Take : InputAction
{
    public override void RespondToInput(TxtAdvController controller, string[] separatedInputWords)
    {
        Dictionary<string, string> takeDict = controller.interactableItems.takeItem(separatedInputWords);

        // If the dict is not null
        if (takeDict != null)
        {
            controller.LogStringWithReturn(controller.testVerbDictionaryWithNoun(takeDict, separatedInputWords[0], separatedInputWords[1]));
        }
    }
}