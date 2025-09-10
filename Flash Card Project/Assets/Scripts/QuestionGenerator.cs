using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    public TMP_Text qText; //text refrence for question text
    public TMP_Text aText; //text refrence for button a text
    public TMP_Text bText; //text refrence for button b text
    public TMP_Text cText; // text refrence for button c text
    public int int1; // first value
    public int int2; //second value
    public int cAnswerPos; // position value of correct answer
    
    public void GenerateQuestion()
    {
        int1 = Random.Range(1, 13);
        int2 = Random.Range(1, 13);
        qText.text = int1.ToString() + "x" + int2.ToString();
        cAnswerPos = Random.Range(1, 4);
        switch (cAnswerPos)
        {
            case 1:
                aText.text = (int1 * int2).ToString();
                bText.text = makeLowerWrongAnswer().ToString();
                cText.text = makeHigherWrongAnswer().ToString();
                break;
            case 2:
                aText.text = makeLowerWrongAnswer().ToString();
                bText.text = (int1 * int2).ToString();
                cText.text = makeHigherWrongAnswer().ToString();
                break;
            case 3:
                aText.text = makeHigherWrongAnswer().ToString();
                bText.text = makeLowerWrongAnswer().ToString();
                cText.text = (int1 * int2).ToString();
                break;
        }
    }

    private int makeLowerWrongAnswer()
    {
        if (int2 > 1)
        {
            return int1 * (int2 - 1);
        }
        else
        {
            return int1 * (int2 + 2);
        }
    }
    
    private int makeHigherWrongAnswer()
    {
        if (int2 < 12)
        {
            return int1 * (int2 + 1);
        }
        else
        {
            return int1 * (int2 - 2);
        }
    }

    public int getCorrectAnswer()
    {
        return cAnswerPos;
    }
}
