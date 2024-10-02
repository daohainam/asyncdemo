namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void cmdCallAwait_Click(object sender, EventArgs e)
        {
            InsertText(await GetThreadInfoAsync());
        }

        private async void cmdCallConfigureAwaitFall_Click(object sender, EventArgs e)
        {
            InsertText(await GetThreadInfoAsync().ConfigureAwait(false));
        }

        private void cmdCallThread_Click(object sender, EventArgs e)
        {
            new Thread(() => {
                InsertText(GetThreadInfo());
            }).Start();
        }

        private void cmdCallResult_Click(object sender, EventArgs e)
        {
            InsertText(GetThreadInfoAsync().Result);
        }

        private void InsertText(string text)
        {
            txtResult.Text = $"{DateTime.Now:HH:mm:ss} - {text}{Environment.NewLine}{txtResult.Text}";
        }

        private string GetThreadInfo()
        {
            Thread.Sleep(1000);
            return $"Thread ID: {Environment.CurrentManagedThreadId}";
        }

        private async Task<string> GetThreadInfoAsync()
        {
            return await Task.Run(() => GetThreadInfo());
        }
    }
}
