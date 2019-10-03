using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

//locals
using DisplayImage.Model;

namespace DisplayImage.Services
{
    public class ImageService
    {
        private const string imagePath = "DisplayImages";
        public async Task<List<ImageSpec>> GetFileList()
        {
            List<ImageSpec> result = new List<ImageSpec>();
            DirectoryInfo d = new DirectoryInfo(@"wwwroot\" + imagePath);
            try
            {
                var files = d.GetFiles("*.*");
                if (files != null)
                {
                    foreach (var f in files)
                    {
                        var spec = new ImageSpec
                        {
                            Name = Path.GetFileNameWithoutExtension(f.Name),
                            DisplayURL = $"{imagePath}\\{f.Name}"
                        };
                        result.Add(spec);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await Task.CompletedTask;
            return result;
        }
    }
}
