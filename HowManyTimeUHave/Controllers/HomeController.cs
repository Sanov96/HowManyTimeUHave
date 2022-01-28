
using HowManyTimeUHave.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using HowManyTimeUHave.ViewModels;


namespace HowManyTimeUHave.Controllers
{
    public class HomeController : Controller
    {

     
        public ISurveyRepository _surveyRepository;


        public HomeController(ISurveyRepository surveyRepository)
        {
    
            _surveyRepository = surveyRepository;
        }


        [HttpGet]
        public ActionResult Index()
        {

            SurveyViewModel surveyViewModel = new SurveyViewModel();
            surveyViewModel.SurveyList = _surveyRepository.SurveyList;
            
            return View(surveyViewModel);
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpPost]
       public string PostUsingParametrs(string mAge, string fAge, string aCnt)
        {

            try
            {
                Survey current = new Survey
                {
                    mothersAge = Convert.ToInt32(mAge),
                    fathersAge = Convert.ToInt32(fAge),
                    meetingsCnt = Convert.ToInt32(aCnt),
                    averageLength = Convert.ToInt32(Request.Form["CountryName"].ToString())
                    
                };

                int takiecus = Int32.Parse(Request.Form["CountryName"].ToString());

                

                _surveyRepository.AddSurvey(current);


                int lowerage;

                

                if (current.mothersAge < 0 || current.fathersAge < 0)
                    return " Dane źle wprowadzone ";


                if (current.mothersAge == 0 || current.fathersAge == 0)
                {

                    if (current.mothersAge ==0)
                    {
                        lowerage = (current.averageLength - current.fathersAge) * current.meetingsCnt;
                        return "Spotkasz się z tatą jeszcze:  " + lowerage + " razy";
                    }
                    else if (current.fathersAge == current.mothersAge)

                    {
                        lowerage = (current.averageLength - current.mothersAge) * current.meetingsCnt;
                        return "Spotkasz się z mamą jeszcze:  " + lowerage + " razy";
                    }
                }

                if (current.mothersAge > current.fathersAge)
                {
                    lowerage = (current.averageLength - current.mothersAge) * current.meetingsCnt;
                    return " Spotkasz się z rodzicami jeszcze  " + lowerage + " razy";
                }
                else
                {
                    lowerage = (current.averageLength - current.fathersAge) * current.meetingsCnt;
                    return " Spotkasz się z rodzicami jeszcze  " + lowerage + " razy";

                }

                
                
              


            }
            catch (Exception ex)
            {
                //lapie bledy z parsowania na int
                return ex.Message;
            }


            

            
      









        }









    }
}