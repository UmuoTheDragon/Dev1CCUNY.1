using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DialogueManagerq : MonoBehaviour
{
    //Text Component
    public TextMeshPro Text;
    //The SpriteRenderer that draws the speaking character
    public SpriteRenderer Character;
    //The SpriteRenderer that draws the background
    //public SpriteRenderer Background;

    //A list of all the character sprites
    //I need to make this variables so I can reference them
    public Sprite enidHappy;
    public Sprite enidNeutral;
    public Sprite enidSus;
    public Sprite enidClosedEyes;
    public Sprite vodiHappy;
    public Sprite vodiNeutral;
    public Sprite vodiSus;
    public Sprite vodiDismayed;

    //A list of all the background sprites
    

    public List<DialogueLine> Lines;
    public int Index = 0;

    void Start()
    {
        //Here I make sure to imprint the first line of dialogue
        //on the text/sprite renderers
        ImprintLine();
    }

    private void Update()
    {
        //If I hit space. . .
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Set the current line of dialogue to the next one
            Index++;
            //And redo all the text and art to match it
            ImprintLine();
        }
    }

    public void ImprintLine()
    {
        //If we've hit the end of the script. . .
        if (Index >= Lines.Count)
        {
            //End the game
            SceneManager.LoadScene("You Win");
            return;
        }

        //Find which line of dialogue we're currently on
        DialogueLine current = Lines[Index];
        //Set the text to match that line's dialogue text
        Text.text = current.Text;
        //Find the character art the line of dialogue requests
        Character.sprite = GetCharacter(current.Character);
        //Find the background art the line of dialogue requests
        //Background.sprite = GetBackground(current.Background);
    }
    public Sprite GetCharacter(string who)
    {
        //If the dialogue line calls for "Gary", use this sprite
        if (who == "enid") return enidNeutral;
        if (who == "enid happy") return enidHappy;
        if (who == "enid sus") return enidSus;
        if (who == "enid closedEyes") return enidClosedEyes;
        if (who == "vodi") return vodiNeutral;
        if (who == "vodi happy") return vodiHappy;
        if (who == "vodi sus") return vodiSus;
        if (who == "vodi dismayed") return vodiDismayed;
        //If Character is left blank, just don't change anything
        return Character.sprite;
    }

    //Convert the text description of a background to a sprite
   // public Sprite GetBackground(string where)
    //{
        //If the dialogue line calls for "Outside", use this sprite
        //if (where == "Outside") return OutsideBG;
        //If the dialogue line calls for "Inside", use this sprite
        //if (where == "Inside") return InsideBG;
        //If Background is left blank, just don't change anything
        //return Background.sprite;
    //}

    
}
