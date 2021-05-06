using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
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
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://aisweb.decea.mil.br/api/?apiKey=1948175746&apiPass=cba6ae56-a1dd-11ea-9f40-00505680c1b4&area=notam&icaocode={icaos}"),
                };

                var response = await client.SendAsync(request);
                var status = response.EnsureSuccessStatusCode();
                List<NotamCollection> result = null;

                if (status.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    var reader = new StreamReader(stream);
                    var serializer = new XmlSerializer(typeof(AisWeb));
                    var aisweb = (AisWeb)serializer.Deserialize(reader);
                    result = aisweb?.Notams;
                }

                response.Dispose();
                client.Dispose();
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
