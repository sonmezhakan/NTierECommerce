using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Common.ImageHelpers
{
    public static class ImageUploader
    {
        public static string Upload(string imageName)
        {
            string newFileName = "";

            var uniqueName = Guid.NewGuid().ToString();

            var fileArray = imageName.Split('.');

            var extension = fileArray[fileArray.Length - 1];

            if (extension == "png" || extension == "jpg" || extension == "gif" || extension == "jpeg" || extension == "svg")
            {
                newFileName = uniqueName + "." + extension;

                return newFileName;

            }
            else
            {
                return "0";
            }
        }
    }
}
