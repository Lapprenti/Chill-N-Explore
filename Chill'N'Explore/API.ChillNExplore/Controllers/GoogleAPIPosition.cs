using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace API.ChillNExplore.Controllers
{
    public class GoogleAPIPosition : ApiController
    {
        private string key = "AIzaSyDwBNRxlmTllDvHoAjAVkC_WB23_0v-bJc";

        public string Key { get => key; set => key = value; }

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
        [Route("api/google/Position")]
        public string PostDataFromHTTPClient(string url)
        {
            try
            {
                //var url = "https://www.googleapis.com/geolocation/v1/geolocate?&key=AIzaSyDwBNRxlmTllDvHoAjAVkC_WB23_0v-bJc";
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
        public string GetPosition()
        {
            string coord = "";
            string url = "https://www.googleapis.com/geolocation/v1/geolocate?key=" + this.key;

            JObject result = JObject.Parse(jsonResult.ToString());

        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
