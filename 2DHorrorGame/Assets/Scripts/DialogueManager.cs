using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using static inventory;

public class DialogueManager : MonoBehaviour
{
    //UI ELEMENTS
    public TextAsset inkFile;
    public Text nameText;
    public Text dialogueText;

    public Button[] choiceButtons;
    

    public Image[] rishiImages;
    public Image[] diegoImages;
    public Image[] girishImages;
    public Image[] ghostImages;

    public string nonGhostLoc;

    private Image currentImage;

    static Story story;
    List<string> tags;
    static Choice choiceSelected;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Image image in rishiImages)
        {
            image.enabled = false;
        }
        foreach (Image image in diegoImages)
        {
            image.enabled = false;
        }
        foreach (Image image in girishImages)
        {
            image.enabled = false;
        }
        foreach (Image image in ghostImages)
        {
            image.enabled = false;
        }
        foreach (Button button in choiceButtons)
        {
            button.gameObject.SetActive(false);
        }
        /*choiceButtons[0].gameObject.SetActive(false);
        choiceButtons[1].gameObject.SetActive(false);
        choiceButtons[2].gameObject.SetActive(false);*/
        story = new Story(inkFile.text);
        tags = new List<string>();
        choiceSelected = null;
        
    }


  
    void EndDialogue()
    {
        SceneManager.LoadScene(nonGhostLoc);
        Debug.Log("End of Dialogue");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && story.currentChoices.Count == 0)
        {
            if (story.canContinue)
            {
                AdvancedDialogue();
                Debug.Log(story.currentChoices.Count);
                if (story.currentChoices.Count != 0)
                {
                    inventory inv = new inventory();
                    inventory.updateTool(3);
                    //Debug.Log(story.currentChoices.Count);
                    int i = 0;
                    foreach (Choice choice in story.currentChoices)
                    {
                        choiceButtons[i].gameObject.SetActive(true);
                        choiceButtons[i].enabled = true;
                        choiceButtons[i].GetComponentInChildren<Text>().text = choice.text;
                        Debug.Log(choice.index);
                        choiceButtons[i].onClick.AddListener(delegate {
                            Debug.Log(choice.index);
                            Debug.Log(story.currentChoices.Count);
                            story.ChooseChoiceIndex(choice.index);
                            choiceButtons[0].gameObject.SetActive(false);
                            choiceButtons[1].gameObject.SetActive(false);
                            choiceButtons[2].gameObject.SetActive(false);
                            AdvancedDialogue();
                        });
                        i++;
                    }

                }
                else
                {
                    choiceButtons[0].gameObject.SetActive(false);
                    choiceButtons[1].gameObject.SetActive(false);
                    choiceButtons[2].gameObject.SetActive(false);
                }
            }
            else
            {
                EndDialogue();
            }
        }
    }


    private void AdvancedDialogue()
    {
        string currentSentance = story.Continue();
        ParseTags();
        dialogueText.text = currentSentance;
    }

    private void ParseTags()
    {
        tags = story.currentTags;
        nameText.text = "";
        if (currentImage != null)
        {
            currentImage.enabled = false;
        }
        foreach (string tag in tags)
        {
            string speaker = tag.Split(' ')[0];
            string expression = tag.Split(' ')[1];
            nameText.text = speaker;
            switch (speaker.ToLower())
            {
                case "noise":
                    Debug.Log("Noise");
                    break;
                case "animated":
                    Debug.Log("Some animation");
                    break;
                case "gameover":
                    SceneManager.LoadScene("gameover");
                    break;
                default:
                    showImage(speaker.ToLower(), expression);
                    break;
            }
        }
    }

    private void showImage(string name, string expression)
    {
        //image.enabled = true;
        //Debug.Log(name);
        //Debug.Log(expression);
        


        if (name == "don")            //If player is Diego *****  
        {
            switch (expression)

            {
                case "resting":            //testing to see how to access the photos for each expression
                    diegoImages[0].enabled = true;
                    currentImage = diegoImages[0];
                break;
                case "scared":
                    diegoImages[1].enabled = true;
                    currentImage = diegoImages[1];
                    break;
                case "shocked":
                    diegoImages[2].enabled = true;
                    currentImage = diegoImages[2];
                    break;
                case "smiling":
                    diegoImages[3].enabled = true;
                    currentImage = diegoImages[3];
                    break;
            }
        }
        else if (name == "rishi")        //If player is Rishi *****
        {
            switch (expression)

                { 
            
                case "confused":
                    rishiImages[0].enabled = true;
                    currentImage = rishiImages[0];
                    break;

                case "interesting":
                    rishiImages[1].enabled = true;
                    currentImage = rishiImages[1];
                    break;

                case "laidback":
                    rishiImages[2].enabled = true;
                    currentImage = rishiImages[2];
                    break;

                case "rest":
                    rishiImages[3].enabled = true;
                    currentImage = rishiImages[3];
                    break;

                case "shocked":
                    rishiImages[4].enabled = true;
                    currentImage = rishiImages[4];
                    break;

                case "smiling":
                    rishiImages[5].enabled = true;
                    currentImage = rishiImages[5];
                    break;

                case "thinking":
                    rishiImages[6].enabled = true;
                    currentImage = rishiImages[6];
                    break;
            }
        }
        


        else if (name == "girish")
        {
            switch (expression)
              {
                case "angry":
                    girishImages[0].enabled = true;
                    currentImage = girishImages[0];
                    break;

                case "curious":
                    girishImages[1].enabled = true;
                    currentImage = girishImages[1];
                    break;

                case "evil":
                    girishImages[2].enabled = true;
                    currentImage = girishImages[2];
                    break;

                case "grinning":
                    girishImages[3].enabled = true;
                    currentImage = girishImages[3];
                    break;

                case "resting":
                    girishImages[4].enabled = true;
                    currentImage = girishImages[4];
                    break;

                case "shocked":
                    girishImages[5].enabled = true;
                    currentImage = girishImages[5];
                    break;

                case "thinking":
                    girishImages[6].enabled = true;
                    currentImage = girishImages[6];
                    break;

                case "worried":
                    girishImages[7].enabled = true;
                    currentImage = girishImages[7];
                    break;

            }
        }
        else if (name == "unknown" || name == "netra")
        {
            switch (expression)
            {
                case "closedGrin":
                    ghostImages[0].enabled = true;
                    currentImage = ghostImages[0];
                    break;
                case "creepy":
                    ghostImages[1].enabled = true;
                    currentImage = ghostImages[1];
                    break;
                case "evil":
                    ghostImages[2].enabled = true;
                    currentImage = ghostImages[2];
                    break;
                case "grinning":
                    ghostImages[3].enabled = true;
                    currentImage = ghostImages[3];
                    break;
                case "resting":
                    ghostImages[4].enabled = true;
                    currentImage = ghostImages[4];
                    break;
                case "screaming":
                    ghostImages[5].enabled = true;
                    currentImage = ghostImages[5];
                    break;
            }
        }


    }




}
