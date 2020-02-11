using UnityEngine;
using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using UnityEngine.UI;
using System;
using System.Collections;

public class InputController : MonoBehaviour, IInputHandler
{

    [SerializeField]
    private InputField inputField; 

    [SerializeField]
    private bool askingForIn;
    private string inputedText;
    private string[] splitInput;

   
    void Start()
    {
        askingForIn = false;

        // Tell the Model classes this is the class in charge of Input.
        InputReceiver.InputSender = this;
        inputedText = "";
        inputField.DeactivateInputField();

    }



    public void AwaitVectorInput(out float x, out float y)
    {   
        ActivateField:
        // Activate the field to start accepting input
        inputField.ActivateInputField();
        askingForIn = true;

        // Wait
        StartCoroutine(WaitForInput());

        // The expected string is in the format "...,..." but the splitter
        // uses more than ',' just in case.
        splitInput = inputedText.Split(
            new char[]{',','.',' '}, StringSplitOptions.RemoveEmptyEntries);

        // If the split didn't result in 2 strings to be parsed then it's
        // already invalid
        if(splitInput.Length != 2)
            goto ActivateField;

        float.TryParse(splitInput[0], out x);
        float.TryParse(splitInput[1], out y);

    

    }

    /// <summary>
    /// Wait for input and return it as True/False.
    /// By default it returns false.
    /// </summary>
    /// <returns> The user's input as True or False. </returns>
    public bool AwaitBoolInput()
    {
        // Activate the field to start accepting input
        inputField.ActivateInputField();
        askingForIn = true;

        // Wait
        StartCoroutine(WaitForInput());

        if(inputedText.ToUpper() == "YES" ||
           inputedText.ToUpper() == "TRUE"||
           inputedText.ToUpper() == "Y" )
        {

            return true;

        }
        else 
            return false;
    }

    /// <summary>
    /// Register the text the user wrote in the input field.
    /// </summary>
    /// <param name="txt"> String the user inputed into the field.</param>
    public void RegisterFieldInput(string txt)
    {
        inputedText = txt;
        askingForIn = false;
        inputField.DeactivateInputField();

    }

    /// <summary>
    /// Stop this script until the user has submited their input in the
    /// InputField (RegisterFieldInput is called.).
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForInput()
    {
        while(askingForIn)
        {
            yield return null;
        }

    } 


}
