using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class VisionController : ApiController
    {
        // GET: api/Vision
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vision/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vision
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vision/5
        public void Delete(int id)
        {
        }

        [Route("api/test")]
        public async Task<bool> Face()
        {
            var test = true;
            FaceServiceClient faceServiceClient = new FaceServiceClient("57dfa44fcc82469fb81ec031ba2f43c6", "https://westcentralus.api.cognitive.microsoft.com/face/v1.0");
            // Create an empty PersonGroup
            string personGroupId = "myfriends";
            //await faceServiceClient.CreatePersonGroupAsync(personGroupId, "MyFriends");

            // Define Anna
            CreatePersonResult friend1 = await faceServiceClient.CreatePersonAsync(
                // Id of the PersonGroup that the person belonged to
                personGroupId,
                // Name of the person
                "toto"
            );

            const string friend1ImageDir = @"C:/Users/Megaport/Pictures/face";

            foreach (string imagePath in Directory.GetFiles(friend1ImageDir, "*.jpg"))
            {
                using (Stream s = File.OpenRead(imagePath))
                {
                    // Detect faces in the image and add to Anna
                    await faceServiceClient.AddPersonFaceAsync(
                        personGroupId, friend1.PersonId, s);
                }
            }
            await faceServiceClient.TrainPersonGroupAsync(personGroupId);
            TrainingStatus trainingStatus = null;
            trainingStatus = await faceServiceClient.GetPersonGroupTrainingStatusAsync(personGroupId);

            string testImageFile = "ftp://35.190.168.129/images/test1.png";

            using (Stream s = File.OpenRead(testImageFile))
            {
                var faces = await faceServiceClient.DetectAsync(s);
                var faceIds = faces.Select(face => face.FaceId).ToArray();

                var results = await faceServiceClient.IdentifyAsync(personGroupId, faceIds);
                foreach (var identifyResult in results)
                {
                    if (identifyResult.Candidates.Length == 0)
                    {
                        test = false;
                    }
                    else
                    {
                        test = true;
                    }
                }
            }
            return test;
        }
    }
}
