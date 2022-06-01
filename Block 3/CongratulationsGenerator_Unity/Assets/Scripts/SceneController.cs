using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Congratulation;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CopyToClipboard(TextMeshProUGUI Congratulation)
    {
        if (Congratulation.text != "")
        {
            GUIUtility.systemCopyBuffer = Congratulation.text;
        }
    }

    Dictionary<int, string> holidays = new Dictionary<int, string>()
    {
        {1, "birthday"},
        {2, "new-year"},
        {3, "christmas"},
        {4, "woman"},
        {5, "man"},
    };

    public void Request()
    {
        string holiday = holidays[SceneManager.GetActiveScene().buildIndex];

        string url = $"https://pozdrav.in/gen/{holiday}";

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                using (HttpContent content = response.Content)
                {
                    string result = content.ReadAsStringAsync().Result;
                    int i = 0;
                    string message = default;

                    if (holiday == "man" | holiday == "woman")
                    {
                        foreach (var ch in result)
                        {
                            if (i == 119)
                            {
                                message = message + ch;
                            }
                            if (ch == '\n')
                            {
                                i++;
                            }
                        }
                    }
                    else
                    {
                        foreach (var ch in result)
                        {
                            if (i == 130)
                            {
                                message = message + ch;
                            }
                            if (ch == '\n')
                            {
                                i++;
                            }
                        }
                    }
                    message = (message.Remove(0, 75)).Trim();
                    char[] MyChar = { '<', '/', 's', 'p', 'a', 'n', '>' };
                    message = (message.TrimEnd(MyChar)).Trim();

                    Congratulation.text = message;
                }
            }
        }
    }
}
