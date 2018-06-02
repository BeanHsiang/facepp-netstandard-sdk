using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FacePlusPlus.Util
{
    static class ContentExtension
    {
        static internal Stream AddAndGetStream(this Dictionary<string, dynamic> content, string image_path, string name = "image_file")
        {
            if (!string.IsNullOrWhiteSpace(image_path) && File.Exists(image_path))
            {
                var fileInfo = new FileInfo(image_path);
                var stream = new BufferedStream(File.OpenRead(image_path));
                var sc = new StreamContent(stream);
                content.Add(name, (sc, fileInfo.Name));
                return stream;
            }
            return null;
        }
    }
}
