using RestSharp;
using System;
using System.Windows.Forms;
using FentonOpenAI;
using System.Text.Json;

namespace HelloOoba
{
    public partial class Form1 : Form
    {
        private const string baseUrl = "http://127.0.0.1:5000/v1/chat/completions";
        RestClient client = new RestClient(baseUrl);

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = this.btnSubmit;
        }

        private string CallOpenAI(string payload)
        {
            //string API_KEY = "";
            //string YOUR_RESOURCE_NAME = "";
            //string DEPLOYMENT_ID = "";
            //string API_VERSION = "2022-12-01";

            RestClient client = new RestClient("http://127.0.0.1:5000");
            RestRequest request = new RestRequest("/v1/chat/completions", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            string jsonBody = "{\"messages\": [{\"role\":\"user\", \"content\":\"" + payload + "\"}]," +
                "\"model\": \"lmsys_vicuna-7b-v1.5\"," +
                "\"frequency_penalty\": 0,\"logit_bias\":{},  \"max_tokens\":999,  \"n\": 1 }";
            request.AddJsonBody(jsonBody);
            try
            {
                RestResponse<OpenAIResponse> response = client.Execute<OpenAIResponse>(request);
                OpenAIResponse openAIResponse = JsonSerializer.Deserialize<OpenAIResponse>(response.Content);
                Console.WriteLine(openAIResponse.Choices[0].Message.Content);
                return openAIResponse.Choices[0].Message.Content;
            } catch ( Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtOutput.Text = txtOutput.Text + "Request: " + txtInput.Text + Environment.NewLine;
            btnSubmit.Enabled = false;
            string response = CallOpenAI(txtInput.Text);
            txtOutput.Text = txtOutput.Text + response + Environment.NewLine + Environment.NewLine;
            btnSubmit.Enabled = true;
        }

    }

}
