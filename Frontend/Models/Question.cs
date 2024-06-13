namespace Radiologi___Frontend___Maui.Models
{
    public class Question
    {
        public string Label { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public List<string> MultipleChoiceOptions { get; set; } = new List<string>();
        public QuestionType Type { get; set; }
    }

    public enum QuestionType
    {
        Text,
        MultipleChoice
    }
}
