namespace MAUICustomEventsTask
{
    // Write code below this line

    // Write code above this line

    public class apiEventArgs : EventArgs
    {
        public string Link { get; }

        public apiEventArgs(string content)
        {
            this.Link = content;
        }
    }

    public partial class MainPage : ContentPage
    {
        public apiEvent apiService = new apiEvent();

        public MainPage()
        {
            InitializeComponent();

            getImageButton.Clicked += GetImage;
            apiService.OnResponse += SetImage;
        }

        private void SetImage(object? sender, apiEventArgs e)
        {
            mainImage.Source = e.Link;
        }

        private void GetImage(object? sender, EventArgs e)
        {
            string apiUrl = "https://random.imagecdn.app/v1/image";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    apiService.OnApiResponse(content);
                }
            }
        }
    }
}