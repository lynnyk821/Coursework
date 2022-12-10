
namespace Курсова
{
    public class DataHandler
    {
        public string Label { get; private set; }
        public string Path { get; private set; }
        public string Data { get; private set; }
        public DataHandler(int index)
        {
            Path = GetPath(index);
        }
        public DataHandler(int index, MySelector selector)
        {
            Data = GetData(index, selector);
        }
        public DataHandler(string text)
        {
            Label = GetLabel(text);
        }
        private string GetLabel(string text)
        {
            for(int i = 0; i < UserData.Answers.TCapital.Length; i++)
            {
                if(text == UserData.Answers.TCapital[i])
                    return "Відгадайте столицю за прапором?";
            }
            return "Відгадайте країну за прапором?";
        }
        private string GetPath(int index) => $"C:\\Users\\Yaroslav\\Desktop\\Kursova\\Data\\{UserData.Answers.TrueAnswers[index]}.png";
        private string GetData(int index, MySelector selector) => MySelector.TRUE == selector ? UserData.Answers.TrueAnswers[index] : UserData.Answers.FalseAnswers[index];
    }
}
