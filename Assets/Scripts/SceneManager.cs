using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI FavColorText;

    [SerializeField]
    TextMeshProUGUI PostText;

    [SerializeField]
    TextMeshProUGUI GetText;

    [SerializeField]
    TextMeshProUGUI AnswerText;

    int colorIndex = 0;

    public void SetColorIndex(int index)
    {
        colorIndex = index;
        if (colorIndex == 0)
            FavColorText.text = "Your favorite color is red";
        else if (colorIndex == 1)
            FavColorText.text = "Your favorite color is yellow";
        else if (colorIndex == 2)
            FavColorText.text = "Your favorite color is green";
        else if (colorIndex == 3)
            FavColorText.text = "Your favorite color is blue";
    }

    public void PostMethod()
    {
        PostText.text = "POST Status";
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("answer-index", colorIndex);

        using (UnityWebRequest www = UnityWebRequest.Post("http://www.MYSERVER.com/unity-get-post-example-process.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                PostText.text = "POST Status\n" + www.error;
            }
            else
            {
                Debug.Log("Form upload complete!");
                PostText.text = "POST Status\n" + "Form upload complete!";
            }
        }
    }

    public void GetMethod()
    {
        GetText.text = "GET Status";
        StartCoroutine(Download());
    }

    IEnumerator Download()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://www.MYSERVER.com/unity-get-post-example-process.txt");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
            GetText.text = "GET Status\n" + www.error;
        }
        else {
            Debug.Log(www.downloadHandler.text);
            GetText.text = "GET Status\n" + "Text download complete!";

            string[] answers = www.downloadHandler.text.Split(",");

            AnswerText.text = "Answers\n" +  answers[0] + " Red\n" +  answers[1] + " Yellow\n" +  answers[2] + " Green\n" +  answers[3] + " Blue\n";
        }
    }
}
