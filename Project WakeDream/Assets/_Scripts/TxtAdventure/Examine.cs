using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "TextAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(TxtAdvController controller, string[] separatedInputWords)
    {
        controller.LogStringWithReturn(controller.testVerbDictionaryWithNoun(controller.interactableItems.examineDictionary, separatedInputWords[0], separatedInputWords[1]));
    }

}
