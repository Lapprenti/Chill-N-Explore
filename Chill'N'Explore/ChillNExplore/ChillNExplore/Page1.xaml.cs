using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChillNExplore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        Label lb;

        public Page1 ()
		{
			InitializeComponent ();
            Image();
		}

        private async void Image()
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)return;
            string filePath = file.Path;
            string fileName = "test4" + ".png"; 
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://35.190.168.129/images/" + fileName));
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpRequest.Proxy = null;
            ftpRequest.UseBinary = true;
            ftpRequest.Credentials = new NetworkCredential("thebeegeescode", "mdpTheBeeGees");
            ftpRequest.KeepAlive = false;
            FileInfo ff = new FileInfo(filePath);
            byte[] fileContents = new byte[ff.Length];
            using (FileStream fr = ff.OpenRead())
            {
                fr.Read(fileContents, 0, Convert.ToInt32(ff.Length));
            }
            using (Stream writer = ftpRequest.GetRequestStream())
            {
                writer.Write(fileContents, 0, fileContents.Length);
            }
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            string url = "http://localhost:59698/api/test";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            string content;
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            content = reader.ReadToEnd();
            lb.Text = content.ToString();
        }
        
    }
}