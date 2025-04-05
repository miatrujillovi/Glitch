using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [Header("List of Platforms")]
    [SerializeField] private GameObject[] whitePlatforms;
    [SerializeField] private GameObject[] blackPlatforms;
    [Header("Background Sprites/SpriteRenderer")]
    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private Sprite whiteBG;
    [SerializeField] private Sprite blackBG;
    [Header("Mechanic Objects")]
    [SerializeField] private GameObject[] palpitationObjects;
    [SerializeField] private GameObject[] glitchObjects;

    public static int currentPart = 1;

    public void SecondPart()
    {
        //Background Change
        bg.sprite = whiteBG;

        //White Platforms
        whitePlatforms[0].SetActive(false);
        whitePlatforms[1].SetActive(false);

        //Black Platforms
        blackPlatforms[0].SetActive(true);
        blackPlatforms[1].SetActive(true);
        blackPlatforms[2].SetActive(true);
        blackPlatforms[3].SetActive(true);

        //Palpitation Objects
        palpitationObjects[0].SetActive(false);
        palpitationObjects[1].SetActive(true);

        //Glitch Objects
        glitchObjects[0].SetActive(false);
        glitchObjects[1].SetActive(false);
        glitchObjects[2].SetActive(true);
        glitchObjects[3].SetActive(true);
        glitchObjects[4].SetActive(true);
        glitchObjects[5].SetActive(true);

        currentPart++;
    }

    public void ThirdPart()
    {
        //Background Change
        bg.sprite = blackBG;

        //White Platforms
        whitePlatforms[2].SetActive(true);
        whitePlatforms[3].SetActive(true);
        whitePlatforms[4].SetActive(true);

        //Black Platforms
        blackPlatforms[0].SetActive(false);
        blackPlatforms[1].SetActive(false);
        blackPlatforms[2].SetActive(false);
        blackPlatforms[3].SetActive(false);

        //Palpitation Objects
        palpitationObjects[1].SetActive(false);
        palpitationObjects[2].SetActive(true);

        //Glitch Objects
        glitchObjects[2].SetActive(false);
        glitchObjects[3].SetActive(false);
        glitchObjects[4].SetActive(false);
        glitchObjects[5].SetActive(false);
        glitchObjects[6].SetActive(true);

        currentPart++;
    }

    public void FourthPart()
    {
        //Background Change
        bg.sprite = whiteBG;

        //White Platforms
        whitePlatforms[2].SetActive(false);
        whitePlatforms[3].SetActive(false);
        whitePlatforms[4].SetActive(false);

        //Black Platforms
        blackPlatforms[4].SetActive(true);

        //Palpitation Objects
        palpitationObjects[2].SetActive(false);

        //Glitch Objects
        glitchObjects[6].SetActive(false);

        currentPart++;
    }
}
