using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MSP.Services;
using MSP.Services.Model;

namespace MSP.MSPDataServices
{
    public class BlogService : IBlogService
    {
        public async Task<List<BlogEntrySummary>> GetPreviewPosts()
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync("http://www.microsoft.pub.ro/blog");
            var htmlContent = await httpResponse.Content.ReadAsStringAsync();

            List<BlogEntrySummary> blogEntryList = new List<BlogEntrySummary>();

            if (httpResponse.IsSuccessStatusCode)
            {
                var startIndex = htmlContent.IndexOf("<ul class=\"blog-posts content-items\">");
                var substring = htmlContent.Substring(startIndex);

                var blog = substring.Substring(0, substring.IndexOf("</ul>") + 5);

                bool atLeastOne = blog.Contains("<li");
                int blogEntries = 0;

                if (atLeastOne)
                {
                    int occurance = blog.IndexOf("<li");
                    blogEntries++;
                    string temp = blog.Substring(occurance + 1);
                    while (temp.Contains("<li"))
                    {
                        occurance = temp.IndexOf("<li");
                        temp = temp.Substring(occurance + 1);
                        blogEntries++;
                    }

                    temp = blog;
                    for (int i = 0; i < blogEntries; i++)
                    {
                        occurance = temp.IndexOf("href=\"");
                        temp = temp.Substring(occurance + 6);
                        string url = "http://www.microsoft.pub.ro" + temp.Substring(0, temp.IndexOf("\"")).Trim();

                        occurance = temp.IndexOf(">");
                        temp = temp.Substring(occurance + 1);
                        string title = temp.Substring(0, temp.IndexOf("</a>")).Trim();

                        occurance = temp.IndexOf("published");
                        temp = temp.Substring(occurance);
                        occurance = temp.IndexOf(">");
                        temp = temp.Substring(occurance + 1);
                        string datePublished = temp.Substring(0, temp.IndexOf("</div>")).Trim();

                        occurance = temp.IndexOf("commentcount");
                        temp = temp.Substring(occurance);
                        occurance = temp.IndexOf(">");
                        temp = temp.Substring(occurance + 1);
                        string commentCount = temp.Substring(0, temp.IndexOf("</span>")).Trim();

                        occurance = temp.IndexOf("<p");
                        temp = temp.Substring(occurance);
                        occurance = temp.IndexOf(">");
                        temp = temp.Substring(occurance + 1);
                        string comment = temp.Substring(0, temp.IndexOf("<a")).Trim();

                        blogEntryList.Add(new BlogEntrySummary
                        {
                            Title = title,
                            Url = url,
                            PublishedDate = datePublished,
                            CommentCount = commentCount,
                            Comment = comment
                        });

                        occurance = temp.IndexOf("<li");
                        if (occurance >= 0)
                            temp = temp.Substring(occurance);
                    }
                }
            }

            return blogEntryList;
        }


        public async Task<BlogEntry> GetPost(string url)
        {
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(url);
            var htmlContent = await httpResponse.Content.ReadAsStringAsync();

            var index = htmlContent.IndexOf("zone-sub-page-title");
            htmlContent = htmlContent.Substring(index);

            index = htmlContent.IndexOf("<h1");
            htmlContent = htmlContent.Substring(index + 3);

            index = htmlContent.IndexOf(">");
            htmlContent = htmlContent.Substring(index + 1);

            var title = htmlContent.Substring(0, htmlContent.IndexOf("</h1>"));

            index = htmlContent.IndexOf("</h1>");
            htmlContent = htmlContent.Substring(index + 5);

            index = htmlContent.IndexOf("<p");
            htmlContent = htmlContent.Substring(index + 2);

            index = htmlContent.IndexOf(">");
            htmlContent = htmlContent.Substring(index + 1);

            var comment = htmlContent.Substring(0, htmlContent.IndexOf("</p>"));

            return new BlogEntry
            {
                Title = title,
                Comment = comment
            };
        }
    }
}