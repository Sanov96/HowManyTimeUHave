namespace HowManyTimeUHave.Models
{
    public interface ISurveyRepository
    {
        IEnumerable<Survey> SurveyList { get; }
        Survey GetSurveyById(int surveyId);
        bool AddSurvey(Survey survey);

    }
}
