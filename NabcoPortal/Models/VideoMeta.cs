using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NabcoPortal.Models
{
    public class VideoMeta
    {
        public string FileName { get; set; }

        public FileStream GetVideo()
        {
            string videoPath = FileName;
            FileStream fs = new FileStream(videoPath,FileMode.Open);
            return fs;
        }
    }
}