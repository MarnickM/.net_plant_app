using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Services
{
    public static class ApiKeys
    {
        public static string CustomVisionEndPoint => "https://sdplantdration-prediction.cognitiveservices.azure.com";
        public static string PredictionKey => "3gsZv0v3cFiT74IcblPIEW0xu7NmlMpT6TXkRXcQIrkYZHv1GdCGJQQJ99AJAC5RqLJXJ3w3AAAIACOGUV3r";
        public static string ProjectId => "5651bd08-7f77-469e-a0df-5479a2f489c2";
        public static string PublishedName => "PlantdrationModel";
    }

    public class CustomVisionService
    {
        public static async Task<PredictionModel?> ClassifyImageAsync(Stream photoStream)
        {
            try
            {
                var endpoint = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(ApiKeys.PredictionKey))
                {
                    Endpoint = ApiKeys.CustomVisionEndPoint
                };

                // Send image to the Custom Vision API
                var results = await endpoint.ClassifyImageAsync(Guid.Parse(ApiKeys.ProjectId), ApiKeys.PublishedName, photoStream);

                // Return the most likely prediction
                return results.Predictions?.OrderByDescending(x => x.Probability).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new PredictionModel();
            }
        }
    }
}
