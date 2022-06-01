namespace CongratulationsGeneratorWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string holiday = default;

        private void button1_Click(object sender, EventArgs e)
        {
            holiday = "birthday";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            holiday = "new-year";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            holiday = "christmas";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            holiday = "woman";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            holiday = "man";
        }

        private void button6_Click(object sender, EventArgs e)
        {
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
                        
                        textBox1.Text = message;
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
            }
        }
    }
}