using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MSP.Services;
using MSP.Services.Model;

namespace MSP.MSPDataServices
{
    public class PersonService : IPersonService
    {
        public async Task<List<Person>> GetPeople()
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("http://www.microsoft.pub.ro/team");
            var htmlContent = await httpResponse.Content.ReadAsStringAsync();

            var personList = new List<Person>();

            if (httpResponse.IsSuccessStatusCode)
            {
                var startIndex = htmlContent.IndexOf("<ul class=\"list-items content-items\">");
                var substring = htmlContent.Substring(startIndex);

                var people = substring.Substring(0, substring.IndexOf("</ul>"));

                bool atLeastOne = people.Contains("<li");
                int personNumber = 0;

                if (atLeastOne)
                {
                    int occurance = people.IndexOf("<li");
                    personNumber++;
                    string temp = people.Substring(occurance + 1);
                    while (temp.Contains("<li"))
                    {
                        occurance = temp.IndexOf("<li");
                        temp = temp.Substring(occurance + 1);
                        personNumber++;
                    }

                    temp = people;
                    for (int i = 0; i < personNumber; i++)
                    {
                        occurance = temp.IndexOf("src=\"");
                        temp = temp.Substring(occurance + 5);
                        string avatarUrl = "http://www.microsoft.pub.ro" + temp.Substring(0, temp.IndexOf("\"")).Trim();

                        occurance = temp.IndexOf("name.png");
                        temp = temp.Substring(occurance);
                        occurance = temp.IndexOf("</img>");
                        temp = temp.Substring(occurance + 6);
                        string name = temp.Substring(0, temp.IndexOf("</h1>")).Trim();

                        occurance = temp.IndexOf("job.png");
                        temp = temp.Substring(occurance);
                        occurance = temp.IndexOf("</img>");
                        temp = temp.Substring(occurance + 6);
                        string position = temp.Substring(0, temp.IndexOf("</h3>")).Trim();

                        occurance = temp.IndexOf("hobby.png");
                        temp = temp.Substring(occurance);
                        occurance = temp.IndexOf("</img>");
                        temp = temp.Substring(occurance + 6);
                        string interests = temp.Substring(0, temp.IndexOf("</p>")).Trim();

                        occurance = temp.IndexOf("mailto:");
                        temp = temp.Substring(occurance + 7);
                        string email = temp.Substring(0, temp.IndexOf("\"")).Trim();

                        personList.Add(new Person
                        {
                            Name = name,
                            AvatarUrl = avatarUrl,
                            Email = email,
                            Interests = interests,
                            Position = position
                        });
                    }
                }
            }
            return personList;
        }
    }
}