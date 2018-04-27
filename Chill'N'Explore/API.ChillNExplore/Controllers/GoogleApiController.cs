using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.ChillNExplore.Controllers
{
    public class GoogleApiController : ApiController
    {
        private string key = "AIzaSyAzLjHX8ZpNZyITsdAPW2zw76tvgPcew7E";

        public string Key { get => key; set => key = value; }
        
        /// <summary>
        /// Methode qui permet de soumettre une requête web à une api en GET
        /// </summary>
        /// <param name="url">L'adresse exacte de l'api</param>
        /// <returns></returns>
        public string GetDataFromHTTPClient(string url)
        {
            try
            {
                HttpClient proxy = new HttpClient();
                //on recupere un http reponse
                var response = proxy.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Methode qui permet de soumettre une requête web à une api en POST
        /// </summary>
        /// <param name="url">L'adresse exacte de l'api</param>
        /// <returns></returns>
        [HttpPost]
        public string PostDataFromHTTPClient(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = 0;
                HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
                string content;

                using (var response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        content = reader.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            return content;
                        }
                        else
                        {
                            return "Erreur !!!!!!!!!!!!!!!!!!!!!!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Retourne la position de l'utilisateur 
        /// </summary>
        /// <returns></returns>
        public string GetPos()
        {
            string url = "https://www.googleapis.com/geolocation/v1/geolocate?key=" + this.key;
            var jsonResult = PostDataFromHTTPClient(url);
            JObject result = JObject.Parse(jsonResult.ToString());
            var lat = result.SelectToken("$.location.lat");
            var lng = result.SelectToken("$.location.lng");
            return lat.ToString()+","+lng.ToString();

        }
        // GET: api/GoogleApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GoogleApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GoogleApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GoogleApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GoogleApi/5
        public void Delete(int id)
        {
        }
    }
}
