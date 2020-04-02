using BandTogether.Data.Entities.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BandTogether.Services.ModelHelpers
{
    public class FileModelHelper
    {
        public string GetFileName(File file)
        {
            if (file == null)
                return "";
            else
                return file.FileName;
        }
        public byte[] GetFileData(File file)
        {
            if (file == null)
                return new byte[0];
            else
                return file.Data;
        }
        public string GetFileContentType(File file)
        {
            if (file == null)
                return "";
            else
                return file.ContentType;
        }
        public ImageFile BuildProfilePicture(HttpPostedFileBase image)
        {
            var imageFile = new ImageFile();

            imageFile.FileName = image.FileName;
            imageFile.ContentType = image.ContentType;
            imageFile.Data = new byte[image.ContentLength];
            image.InputStream.Read(imageFile.Data, 0, image.ContentLength);
            

            return imageFile;
        }
        public ImageFile UpdateProfilePicture(ImageFile currentImage, HttpPostedFileBase newImage)
        {
            currentImage.FileName = newImage.FileName;
            currentImage.ContentType = newImage.ContentType;
            currentImage.Data = new byte[newImage.ContentLength];
            newImage.InputStream.Read(currentImage.Data, 0, newImage.ContentLength);

            return currentImage;
        }
        public ResourceFile BuildResourceFile(HttpPostedFileBase file)
        {
            var resourceFile = new ResourceFile();

            resourceFile.FileName = file.FileName;
            resourceFile.ContentType = file.ContentType;
            resourceFile.Data = new byte[file.ContentLength];
            file.InputStream.Read(resourceFile.Data, 0, file.ContentLength);

            return resourceFile;
        }
    }
}
