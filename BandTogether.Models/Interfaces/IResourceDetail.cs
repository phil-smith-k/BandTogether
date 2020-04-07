using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.Interfaces
{
    public interface IResourceDetail
    {
        int ResourceId { get; set; }
        string TeacherId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTimeOffset DateCreated { get; set; }
        DateTimeOffset? DateModified { get; set; }
        bool IsDownloadable { get; set; }
        bool IsPublic { get; set; }
        int FileId { get; set; }
    }
}
