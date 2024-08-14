// developer name : hem chanmetrey
// start-date : 10 Aug 2024
// for : Rose company

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum Comparation
{
    biger,smaller,draw,none
}

enum Oparator
{
    plus,
    multiple,
    minus,
    devistion,
    

}

public enum GameState
{
    easy,hard,veryhard
}

public class GameManager : MonoBehaviour
{
    [Header("Cards")]
    public List<Card> cards = new List<Card>();
    private List<Card> caculateCardGroup1 = new List<Card>();
    private List<Card> caculateCardGroup2 = new List<Card>();


    [Header("Image")]
    [SerializeField]
    private Image[] caculateGroup1Image;
    [SerializeField]
    private Image[] caculateGroup2Image;
    [SerializeField] private Image oparatorImage1;
    [SerializeField] private Image oparatorImage2;
    [SerializeField] private Image resultImage;


    [Header("Oparator Sprite")]
    [SerializeField] private Sprite plusSprite;
    [SerializeField] private Sprite minusSprite;
    [SerializeField] private Sprite devistionSprite;
    [SerializeField] private Sprite multipleSprite;
    [SerializeField] private Sprite biggerSprite;
    [SerializeField] private Sprite smallerSprite;
    [SerializeField] private Sprite drawSprite;
    [SerializeField] private Sprite questionMarkSprite;

    [Header("Text")]
    [SerializeField] private Text oparator1SumText;
    [SerializeField] private Text oparator2SumText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text messageShowText;
    [SerializeField] private Text resultMessageText;
    [SerializeField] private Text scoreEndPanelText;


    [Header("GameObject Panel")]

    [SerializeField] private GameObject caculatingMessagePanel;
    [SerializeField] private GameObject endPanel;
    public Image bigerButton, smallerButton, drawButton, questionMarkPanel;

    [Header("HangMan")]
    [SerializeField]
    List<GameObject> hangMan = new List<GameObject>();
    [SerializeField] private Animator hangeManAnimator;

    [Header("Color")]
    public Color32 normalColor;
    public Color32 wrongColors;
    public Color32 trueColors;
    public Color32 SelectColor;

    List<int> numbers = new List<int>();
    int score = 0;
    int caculateSum1 = 0;
    int caculateSum2 = 0;
    int life = 0;

    Comparation resultComparation;
    Comparation userChoseComparation;

    private void Start()
    {
        scoreText.text = score.ToString();

        resultComparation = Comparation.none;
        userChoseComparation = Comparation.none;


        print($"GameState - {MenuController.gameState}");
        switch (MenuController.gameState)
        {
            case GameState.easy:
                DealCardsEasy();
                break;
            case GameState.hard:
                DealCardsHard();
                break;
            default:
                DealCardsVeryHard();
                break;
        }


        // DealCardsEasy();
        //switch(MenuController.Ga)
        //DealCardsHard();

        int result = Caculator(2, 3, Oparator.devistion);
        Debug.Log("Result: " + result);
        Oparator randomChoice = GetRandomOparator();
        Debug.Log("Random oparator: " + randomChoice);
    }


    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }


      
    }



    void DealCardsHard()
    {

        Oparator oparator1 = GetRandomOparator();
        Oparator oparator2 = GetRandomOparator();

        oparatorImage1.sprite = OpartorToSprite(oparator1);
        oparatorImage2.sprite = OpartorToSprite(oparator2);

        for (int i = 0; i < 52; i++)
        {
            numbers.Add(i);
        }

        Shuffle(numbers);

        //numbers.ForEach(n => print(cards[n].name));

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 == 0)
            {
                caculateCardGroup1.Add(cards[numbers[i]]);
            }
            else
            {
                caculateCardGroup2.Add(cards[numbers[i]]);
            }
        }

        //caculateCardGroup1.ForEach(card => print("group1 - " + card.name));
        //caculateCardGroup2.ForEach(card => print("group2 - " + card.name));

        for (int i = 0; i < 4; i++)
        {
            caculateGroup1Image[i].sprite = caculateCardGroup1[i].sprite;
            caculateGroup2Image[i].sprite = caculateCardGroup2[i].sprite;
        }

        caculateSum1 = Caculator(caculateCardGroup1[0].value+caculateCardGroup1[1].value, caculateCardGroup1[2].value + caculateCardGroup1[3].value , oparator1);
        caculateSum2 = Caculator(caculateCardGroup2[0].value+caculateCardGroup2[1].value, caculateCardGroup2[2].value + caculateCardGroup2[3].value , oparator2);

       




    }


    void DealCardsVeryHard()
    {

        Oparator oparator1 = GetRandomOparator();
        Oparator oparator2 = GetRandomOparator();

        oparatorImage1.sprite = OpartorToSprite(oparator1);
        oparatorImage2.sprite = OpartorToSprite(oparator2);

        for (int i = 0; i < 52; i++)
        {
            numbers.Add(i);
        }

        Shuffle(numbers);

        //numbers.ForEach(n => print(cards[n].name));

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 == 0)
            {
                caculateCardGroup1.Add(cards[numbers[i]]);
            }
            else
            {
                caculateCardGroup2.Add(cards[numbers[i]]);
            }
        }

        //caculateCardGroup1.ForEach(card => print("group1 - " + card.name));
        //caculateCardGroup2.ForEach(card => print("group2 - " + card.name));

        for (int i = 0; i < 6; i++)
        {
            caculateGroup1Image[i].sprite = caculateCardGroup1[i].sprite;
            caculateGroup2Image[i].sprite = caculateCardGroup2[i].sprite;
        }

        int state1_1 = 0;
        int state1_2 = 0;
        int state2_1 = 0;
        int state2_2 = 0;
        for(int i = 0; i < 3; i++)
        {
            state1_1 += caculateCardGroup1[i].value;
            state1_2 += caculateCardGroup1[i+3].value;
            state2_1 += caculateCardGroup2[i].value;
            state2_2 += caculateCardGroup2[i + 3].value;
        }


        caculateSum1 = Caculator(state1_1,state1_2, oparator1);
        caculateSum2 = Caculator(state2_1,state2_2, oparator2);






    }



    void DealCardsEasy()
    {
       
        Oparator oparator1 = GetRandomOparator();
        Oparator oparator2 = GetRandomOparator();

        oparatorImage1.sprite = OpartorToSprite(oparator1);
        oparatorImage2.sprite = OpartorToSprite(oparator2);

        for (int i = 0; i < 52; i++)
        {
            numbers.Add(i);
        }

        Shuffle(numbers);

        //numbers.ForEach(n => print(cards[n].name));

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 == 0)
            {
                caculateCardGroup1.Add(cards[numbers[i]]);
            }
            else
            {
                caculateCardGroup2.Add(cards[numbers[i]]);
            }
        }

        //caculateCardGroup1.ForEach(card => print("group1 - " + card.name));
        //caculateCardGroup2.ForEach(card => print("group2 - " + card.name));

        for(int i = 0; i < 2; i++)
        {
            caculateGroup1Image[i].sprite = caculateCardGroup1[i].sprite;
            caculateGroup2Image[i].sprite = caculateCardGroup2[i].sprite;
        }

        caculateSum1 = Caculator(caculateCardGroup1[0].value, caculateCardGroup1[1].value, oparator1); 
        caculateSum2 = Caculator(caculateCardGroup2[0].value, caculateCardGroup2[1].value, oparator2);

        //print($"{caculateSum1} - {caculateSum2}");

        

        
    }

    Comparation ComputeResultCompare(int value1,int value2)
    {
         if(value1 > value2)
        {
            resultImage.sprite = biggerSprite;
            return Comparation.biger;
        }else if ( value1  < value2)
        {
            resultImage.sprite = smallerSprite;
            return Comparation.smaller;
        }
        else
        {
            resultImage.sprite = drawSprite;
            return Comparation.draw;
        }
    }

    Oparator GetRandomOparator()
    {
        System.Random random = new System.Random();
        return (Oparator)random.Next(0, System.Enum.GetNames(typeof(Oparator)).Length);
    }

    int Caculator(int value1,int value2,Oparator oparator)
    {
        if(oparator == Oparator.plus)
        {
            return value1 + value2;
        }else if(oparator == Oparator.minus)
        {
            return value1 - value2;
        }else if (oparator == Oparator.multiple)
        {
            return value1 * value2;
        }
        else
        {
            return (value1 / value2);
        }
       
    }

    Sprite OpartorToSprite(Oparator oparator)
    {
        if (oparator == Oparator.plus)
        {
            return plusSprite;
        }
        else if (oparator == Oparator.minus)
        {
            return minusSprite;
        }
        else if (oparator == Oparator.multiple)
        {
            return multipleSprite;
        }
        else
        {
            return devistionSprite;
        }
    }


    bool isUserCanClick = true;
    public void UserChoseOption(Image image)
    {

        if (isUserCanClick)
        {
            AudioController.Instance.PlaySFX("tap");
            isUserCanClick = false;
            string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
            image.color = SelectColor;
            //print($"Butto Name - {buttonName}");

            switch (buttonName)
            {
                case ">":
                    userChoseComparation = Comparation.biger;
                    break;
                case "<":
                    userChoseComparation = Comparation.smaller;
                    break;
                case "=":
                    userChoseComparation = Comparation.draw;
                    break;
                default:
                    userChoseComparation = Comparation.none;
                    break;
            }

            StartCoroutine(Restart());

        }

        
    }

    IEnumerator Restart()
    {
        
       


        

        caculatingMessagePanel.SetActive(true);
        AudioController.Instance.PlaySFX("loading");
        messageShowText.text = "caculating ...";


        // Result show
        //-------------------------------------------------------------------------------------------------

        yield return new WaitForSeconds(1f);

        oparator1SumText.text = caculateSum1.ToString();
        oparator2SumText.text = caculateSum2.ToString();
        resultComparation = ComputeResultCompare(caculateSum1, caculateSum2);
        caculatingMessagePanel.SetActive(false);

        CompareCompationUserAndResult();

        yield return new WaitForSeconds(2f);


        // Reset Game
        //-------------------------------------------------------------------------------------------------
        isUserCanClick = true;

        if (!isLose)
        {
            caculatingMessagePanel.SetActive(true);
            AudioController.Instance.PlaySFX("loading");
            messageShowText.text = "next ...";
        }
        numbers.Clear();
        caculateCardGroup1.Clear();
        caculateCardGroup2.Clear();
        resultImage.sprite = questionMarkSprite;

        oparator1SumText.text = "";
        oparator2SumText.text = "";
        resultMessageText.text = "";

        bigerButton.color = normalColor;
        smallerButton.color = normalColor;
        drawButton.color = normalColor;
        questionMarkPanel.color = normalColor;

        // Re RadomCard
        //-------------------------------------------------------------------------------------------------

        yield return new WaitForSeconds(1f);
        caculatingMessagePanel.SetActive(false);
        if (!isLose)
        {
            DealCardsEasy();
        }
        


    }

    bool isLose = false;
    void CompareCompationUserAndResult()
    {
        if (resultComparation == userChoseComparation)
        {
            questionMarkPanel.color = trueColors;
            score += 10;
            scoreText.text = score.ToString();
            resultMessageText.text = "correct !";
            AudioController.Instance.PlaySFX("correct");
        }
        else
        {
            life++;
            AudioController.Instance.PlaySFX("wrong");
            if (life <= hangMan.Count)
            {
                
                hangMan[life - 1].SetActive(true);
            }
            else
            {
                
                AudioController.Instance.PlaySFX("over");
                StartCoroutine(EndPanelShowAnimator());
                scoreEndPanelText.text = "total score : " + score.ToString();
                
            }

            questionMarkPanel.color = wrongColors;
            //print("wrong");
            resultMessageText.text = "wrong !";
        }
    }

    IEnumerator EndPanelShowAnimator()
    {
        hangeManAnimator.Play("die");
        yield return new WaitForSeconds(2f);
        AudioController.Instance.PlaySFX("over");
        isLose = true;
        endPanel.SetActive(true);
        yield return new WaitForSeconds(0.2f);
      //  hangeManAnimator.Play("idle");

    }

    public void ReloadScene()
    {
        AudioController.Instance.PlaySFX("tap");
        StartCoroutine(ReloadSceneAnmimatoin());
    }

    IEnumerator ReloadSceneAnmimatoin()
    {
        GameObject cavas = GameObject.Find("game-canvas");

        while (cavas.GetComponent<CanvasGroup>().alpha > 0)
        {

            cavas.GetComponent<CanvasGroup>().alpha -= 10 * Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeScene()
    {
        AudioController.Instance.PlaySFX("tap");
        StartCoroutine(GoHomeAnimatoin());
    }

    IEnumerator GoHomeAnimatoin()
    {
        GameObject cavas = GameObject.Find("game-canvas");

        while (cavas.GetComponent<CanvasGroup>().alpha > 0)
        {

            cavas.GetComponent<CanvasGroup>().alpha -= 10 * Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("menu");
    }
}

