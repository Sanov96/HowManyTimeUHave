namespace HowManyTimeUHave.Models
{
    public class MockSurveyRepository : ISurveyRepository
    {
        public IEnumerable<Survey> SurveyList =>
            new List<Survey>
            {
                // TODO: zmien sobie na jakies realne dane zeby sie nie gryzly - result i difference powinny byc wyliczane na podstawie danych 
                // ta liste mozna by bylo wyswietlac w jakims labelku z boku ekranu
                //jako ciekawostka innych uzytkownikow etc
                                new Survey {Id=1,meetingsCnt=10,fathersAge=50,mothersAge=60,result=123,},
                new Survey {Id=2,meetingsCnt=53,fathersAge=51,mothersAge=53,result=123},
                new Survey {Id=3,meetingsCnt=46,fathersAge=49,mothersAge=40, result = 123},
                new Survey {Id=4,meetingsCnt=46,fathersAge=49,mothersAge=40, result = 123},
                new Survey {Id=5,meetingsCnt=123,fathersAge=84,mothersAge=75, result = 123},

            };

        public Survey GetSurveyById(int surveyId)
        {
            return SurveyList.FirstOrDefault(x => x.Id == surveyId);
        }

        public bool AddSurvey(Survey survey)
        {
            try
            {
                SurveyList.Append(survey);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
