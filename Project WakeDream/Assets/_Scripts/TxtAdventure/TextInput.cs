using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    // Public variables
    public InputField inputField;   // Reference to the input field

    
    // Private variables
    TxtAdvController _controller;   // Stores reference to the text adventure controller

    


    #region private functions

    // Unity functions
    private void Awake()
    {
        // Gets reference to the txt adventure controller
        _controller = GetComponent<TxtAdvController>();

        // When the on end edit is listened for, call "accept string input"
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    /// <summary>
    /// 
    /// NOTE: tuens all values in the string into lowercase to ensure that it doesn't get messed up by casinput by case.
    /// </summary>
    /// <param name="userInput"></param>
    private void AcceptStringInput(string userInput)
    {
        // Converts all values in userinput to lwercase
        userInput = userInput.ToLower();

        // Mirrors input back to player
        _controller.LogStringWithReturn(userInput);

        // checks the user input for basic 1 letter input
        switch (userInput)
        {
            case "n":
                userInput = "go north";
                break;

            case "s":
                userInput = "go south";
                break;

            case "e":
                userInput = "go east";
                break;

            case "w":
                userInput = "go west";
                break;

            case "u":
                userInput = "go up";
                break;

            case "d":
                userInput = "go down";
                break;
        }

        //Process input - Used to look for separating words will be spaces
        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        // finding input
        for (int i = 0; i < _controller.inputActions.Length; i++)
        {
            // Little bit of code so i the programmer dont need to do _controller.inputActions[i] every time
            InputAction inputAction = _controller.inputActions[i];

            // Using the verb noun style (go north), first word is verb
            // If keyword match
            if (inputAction.Keyword == separatedInputWords[0])
            {
                inputAction.RespondToInput(_controller, separatedInputWords);
            }
        }

        // Completes input
        InputComplete();
    }

    /// <summary>
    ///  When input is complete
    /// </summary>
    private void InputComplete()
    {
        // Displayes the text
        _controller.DisplayLoggedText();
        
        // Reactivates the input field when enter/return is pressed
        inputField.ActivateInputField();

        // Empties inputfield for the player
        inputField.text = null;
    }

    #endregion
}
