using BandTogether.Data.Entities.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
