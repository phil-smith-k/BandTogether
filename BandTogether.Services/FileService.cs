using BandTogether.Data;
using BandTogether.Data.Entities.File;
using BandTogether.Models.FileModels;
using BandTogether.Services.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Services
{
    public class FileService
    {
        private readonly string _currentUser;
        private readonly FileModelHelper _fileHelper = new FileModelHelper();

        public FileService() { }
        public FileService(string userId)
        {
            _currentUser = userId;
        }

        public ResourceFileDetail GetFileById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Files.Find(id);

                if (entity != null && entity is ResourceFile)
                    return _fileHelper.BuildResourceFileDetail(entity);
                else
                    throw new InvalidOperationException();
            }
        }
    }
}
