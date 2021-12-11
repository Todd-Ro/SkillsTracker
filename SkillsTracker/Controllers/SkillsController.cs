using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        List<string> ProgLanguages = new List<string> 
        { "JavaScript", "CSharp", "TypeScript" };

        //[Route ("skills")]
        public IActionResult Index()
        {
            string myContent = "<h1>Skills Tracker</h1>" +
                "<h2><ol>" +
                "<li>JavaScript</li> <li>C#</li> <li>TypeScript</li>" +
                "</ol></h2>";
            return Content(myContent, "text/html");
        }


        //Basic structure of a foreach loop
        /* 
         * foreach (string student in students) {
         *      Console.WriteLine("Grade for " + student + ": ");
         *      string input = Console.ReadLine();
         *      double grade = double.Parse(input);
         *      grades.add(grade);
         * }
         */


        [Route("skills/form")]
        public IActionResult Form()
        {
            StringBuilder sb = new StringBuilder();
            string text = "<form method='POST' action='form/result'>" +
                "<label for='date'>Date:</label>" +
                "<input type='date' name='date'>" + 
                "<br>";
            //<select name ='level'>
            sb.Append(text);
            foreach(string language in ProgLanguages)
            {
                string text2 =
               "<label for='languages'>Skill in "+language+":" + "&nbsp;&nbsp;&nbsp;&nbsp;" + "</label>" + 
               "<select name = '" +
               language +
               "'>" +
               "<option value = 'beginner'>Beginner</option>" +
               "<option value = 'intermediate'>Intermediate</option>" +
               "<option value = 'advanced'>Advanced</option>" +
               "</select>"
               + "<br>"
               ;
                sb.Append(text2);
            }
           
            string submit = "<button>Submit</button>" +
            "</form>";
            sb.Append(submit);
            string totalText = sb.ToString();

            return Content(totalText, "text/html");
        }

        [HttpPost]
        [Route("skills/form/result")]
        public IActionResult FormHandler(string date, string JavaScript, 
            string CSharp, string TypeScript)
        {
            Dictionary<string, string> languages = new Dictionary<string, string>();
            languages.Add("JavaScript", JavaScript);
            languages.Add("CSharp", CSharp);
            languages.Add("TypeScript", TypeScript);
            StringBuilder results = new StringBuilder();
            string dateHeading = "<h3>Date selected: " + date + "</h3>";
            results.Append(dateHeading);
            //results.Append("<Ol>");
            foreach (string languageName in ProgLanguages)
            {
                string skillDisplay =
                    //"<li>" +
                "<h2>" + "Skill level in " + languageName + ": " + languages[languageName] + "</h2>"
                //+"</li>"
                ;
                results.Append(skillDisplay);
            }
            //results.append"</ol>";
            return Content(results.ToString(), "text/html");
        }

    }

    
}
