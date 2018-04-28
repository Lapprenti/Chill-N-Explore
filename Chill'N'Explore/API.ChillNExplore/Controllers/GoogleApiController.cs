using API.ChillNExplore.Models;
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

        // Uniquement get car 
        public string Key { get => key; }
        
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
        /// Retourne la position de l'utilisateur (latitude,longitude)
        /// </summary>
        /// <returns>string</returns>
        public string GetPos()
        {
            string url = "https://www.googleapis.com/geolocation/v1/geolocate?key=" + this.key;
            var jsonResult = PostDataFromHTTPClient(url);
            JObject result = JObject.Parse(jsonResult.ToString());
            var lat = result.SelectToken("$.location.lat");
            var lng = result.SelectToken("$.location.lng");
            return lat.ToString()+","+lng.ToString();
        }
        /// <summary>
        /// retourne les coordonnées GPS du centre de la ville passee en parametre
        /// </summary>
        /// <param name="uneVille">string</param>
        /// <returns>string</returns>
        [Route("api/ChillNExplore/{town}/GetLatLngForCity"), HttpGet]
        public string GetLatLngForCity(string uneVille)
        {
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address="+uneVille+"&key=" + this.key;
            var jsonResult = GetDataFromHTTPClient(url);
            JObject result = JObject.Parse(jsonResult.ToString());
            var lat = result.SelectToken("$.results[0].geometry.location.lat");
            var lng = result.SelectToken("$.results[0].geometry.location.lng");
            return lat.ToString() + "," + lng.ToString();
        }
        /// <summary>
        /// Recupère la ville et le type de lieu dans un rayon de 1000m autour du centre
        /// </summary>
        /// <param name="uneVille">string</param>
        /// <param name="unType">string</param>
        /// <returns>Les noms des 4 premiers monuments</returns>
        [Route("api/ChillNExplore/{town}/{type}/GetNamesLieuxInterest"), HttpGet]
        public List<string> GetNamesLieuxInterest(string uneVille, string unType)
        {
            //church  //museum  //food
            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?type="+unType+"&location="+ GetLatLngForCity(uneVille)+"&radius=1000&key="+this.key;
            var jsonResult = GetDataFromHTTPClient(url);
            JObject result = JObject.Parse(jsonResult.ToString());
            var lesMusées = result.SelectToken("$.results");
            
            List<string> lesNoms = new List<string>();

            for (int i = 0; i <=3 ; i++)
            {
                
                var leMusée = lesMusées[i];
                var leNom = leMusée.SelectToken("$.name");
                lesNoms.Add(leNom.ToString());
            }

            return lesNoms;
        }

        /// <summary>
        /// methode qui retourne les 4 premiere localisation
        /// </summary>
        /// <param name="uneVille">string</param>
        /// <param name="unType">string</param>
        /// <returns>List<string></returns>
        [Route("api/ChillNExplore/{town}/{type}/GetLocationLieuxInterest"), HttpGet]
        public List<string> GetLocationLieuxInterest(string uneVille, string unType)
        {
            //church  //museum  //food
            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?type=" + unType + "&location=" + GetLatLngForCity(uneVille) + "&radius=1000&key=" + this.key;
            var jsonResult = GetDataFromHTTPClient(url);
            JObject result = JObject.Parse(jsonResult.ToString());
            var lesMusées = result.SelectToken("$.results");

            List<string> lesLatitudes = new List<string>();

            for (int i = 0; i <= 3; i++)
            {

                var leMusée = lesMusées[i];
                var lat = leMusée.SelectToken("$.geometry.location.lat");
                var lng = leMusée.SelectToken("$.geometry.location.lng");

                var latlng = lat.ToString() + "," + lng.ToString();
                lesLatitudes.Add(latlng);
            }

            return lesLatitudes;
        }

        /// <summary>
        /// retourne les 4 premiers lieu d'un type choisi associées à leur coordonnées GPS
        /// </summary>
        /// <param name="town">string</param>
        /// <param name="type">string</param>
        /// <returns>JSON</returns>
        [Route("api/ChillNExplore/{town}/{type}/GetInterestWithLocation"), HttpGet]
        public JArray GetInterestWithLocation(string town, string type)
        {
            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?type=" + type + "&location=" + GetLatLngForCity(town) + "&radius=1000&key=" + this.key;
            var jsonResult = GetDataFromHTTPClient(url);
            JObject result = JObject.Parse(jsonResult.ToString());

            List<string> interests = new List<string>();
            JArray jArray = new JArray();
            var lesMusées = result.SelectToken("$.results");
            for (int i = 0; i <= 3; i++)
            {
                var leMusée = lesMusées[i];
                
                var leNom = leMusée.SelectToken("$.name");
                var lat = leMusée.SelectToken("$.geometry.location.lat");
                var lng = leMusée.SelectToken("$.geometry.location.lng");
                
                var latlng = lat.ToString() + "," + lng.ToString();

                JObject jObject = new JObject();
                jObject.Add("name",leNom);
                jObject.Add("lat", lat);
                jObject.Add("lng", lng);

                jArray.Add(jObject);
            }

            return jArray;
        }
    }
}
