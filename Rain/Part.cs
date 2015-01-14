using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain
{
    public class Part
    {
        public string HttpMethod { get; set; }
        public List<Response> Responses { get; set; }
        public List<String> Docs { get; set; }
        public string Route { get; set; }
        public List<Header> Headers { get; set; }
        public List<Parameter> Parameters { get; set; }

        /// <summary>
        /// Set up property values.
        /// </summary>
        public Part()
        {
            this.Responses = new List<Response>();
            this.Docs = new List<string>();
            this.Headers = new List<Header>();
            this.Parameters = new List<Parameter>();
        }

        /// <summary>
        /// Appends a snippet of text to an existing response
        /// example or adds a new response example with the
        /// specified text.
        /// </summary>
        /// <param name="code">The response code to use e.g. 200, 400</param>
        /// <param name="id">The unique id of the response e.g. success, bad_param. This is so
        /// you can have multiple response code examples, for example different validation errors
        /// will return different 400 responses.</param>
        /// <param name="text">The text of the response, used as the example.</param>
        public void AppendResponse(int code, string id, string text)
        {
            List<Response> responses = this.Responses.Where(r => r.Code == code).ToList();
            if (responses.Count == 0)
            {
                this.Responses.Add(new Response()
                {
                    Id = id,
                    Code = code,
                    Text = new List<string>() { text }
                });
            }
            else
            {
                Response response = responses.Where(r => r.Id == id).First();
                response.Text.Add(text);
            }
        }

        /// <summary>
        /// Gets a response's text joined with newlines
        /// based on the unique response code and id.
        /// </summary>
        /// <param name="code">The response code to search for.</param>
        /// <param name="id">The id of the response to search for.</param>
        /// <returns>All of the response text joined with newlines.</returns>
        public string GetResponse(int code, string id)
        {
            Response response = Responses.Where(r => r.Id == id && r.Code == code).First();
            return String.Join("\n", response.Text.ToArray());
        }

        public class Response
        {
            public int Code { get; set; }
            public string Id { get; set; }
            public List<String> Text { get; set; }
        }

        public class Parameter
        {
            public string Name { get; set; }
            public List<String> Text { get; set; }
            public string Type { get; set; }
            public string Default { get; set; }
        }

        public class Header
        {
            public string Name { get; set; }
            public List<String> Text { get; set; }
        }
    }
}
