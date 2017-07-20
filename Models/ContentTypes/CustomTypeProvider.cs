using System;
using KenticoCloud.Delivery;

namespace KenticoCloudLocalizationDemo.Models
{
    public class CustomTypeProvider : ICodeFirstTypeProvider
    {
        public Type GetType(string contentType)
        {
            switch (contentType)
            {
                case "movie":
                    return typeof(Movie);
                default:
                    return null;
            }
        }
    }
}