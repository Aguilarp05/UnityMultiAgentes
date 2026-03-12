using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerName;

    public Image sharkSpeaker;

    public Sprite financieroSprite;
    public Sprite ejecutivoSprite;
    public Sprite visionarioSprite;

    public TMP_InputField pitchInput;

    public GameObject pitchPanel;
    public GameObject dialogueBox;

    public float autoAdvanceTime = 10f;

    string[] speakers =
    {
        "financiero",
        "ejecutivo",
        "visionario",
        "ejecutivo"
    };

    string[] dialogueLines =
    {
        "Let's take a look at the financial potential of this idea.",
        "Tell us more about how this business operates.",
        "I'm curious about what makes this idea unique.",
        "Alright, let's analyze this pitch."
    };

    int currentLine = 0;

    bool pitchSubmitted = false;

    void Start()
    {
        dialogueBox.SetActive(false);
        pitchPanel.SetActive(true);
    }

    public void NextDialogue()
    {
        if (!pitchSubmitted)
        {
            SubmitPitch();
            return;
        }

        if (currentLine < dialogueLines.Length)
        {
            ShowDialogue();
        }
    }

    void SubmitPitch()
    {
        string pitch = pitchInput.text;

        Debug.Log("User pitch: " + pitch);

        pitchSubmitted = true;

        pitchPanel.SetActive(false);
        dialogueBox.SetActive(true);

        StartCoroutine(AutoDialogue());
    }

    IEnumerator AutoDialogue()
    {
        while (currentLine < dialogueLines.Length)
        {
            ShowDialogue();
            yield return new WaitForSeconds(autoAdvanceTime);
        }
    }

    void ShowDialogue()
    {
        dialogueText.text = dialogueLines[currentLine];

        string speaker = speakers[currentLine];

        if (speaker == "financiero")
        {
            sharkSpeaker.sprite = financieroSprite;
            speakerName.text = "FINANCIERO";
        }

        if (speaker == "ejecutivo")
        {
            sharkSpeaker.sprite = ejecutivoSprite;
            speakerName.text = "EJECUTIVO";
        }

        if (speaker == "visionario")
        {
            sharkSpeaker.sprite = visionarioSprite;
            speakerName.text = "VISIONARIO";
        }

        currentLine++;
    }
}