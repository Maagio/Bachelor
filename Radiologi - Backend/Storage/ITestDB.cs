using Radiologi___Backend.Models;

namespace Radiologi___Backend.Storage
{
    public interface ITestDB
    {
        void CreateTest(Questionare questionare);
        List<Questionare> GetTestsByClassId(string classId);
        Questionare GetTestByTestId(string id);
        void SaveAnswers(AnsweredTest answeredTest);
    }
}
