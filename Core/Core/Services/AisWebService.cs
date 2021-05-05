using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Services
{
    public class AisWebService
    {
        public async Task<List<NotamCollection>> GetNotams(string icaos)
        {
            try
            {
 
                var uri = new Uri(string.Format($"https://aisweb.decea.mil.br/api/?apiKey=1948175746&apiPass=cba6ae56-a1dd-11ea-9f40-00505680c1b4&area=notam&icaocode={icaos}", string.Empty));
                var http = new HttpClient();

                HttpResponseMessage response = await http.GetAsync(uri);

                var status = response.EnsureSuccessStatusCode();
                List<NotamCollection> result = null;

                if (status.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    using var reader = new StreamReader(stream);
                    var serializer = new XmlSerializer(typeof(AisWeb));
                    var aisweb = (AisWeb)serializer.Deserialize(reader);
                    result = aisweb?.Notams;
                }

                response.Dispose();
                http.Dispose();
                return result;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}
