

using System.Threading.Tasks;

namespace ASPNetIdentity.Services
{
    public class AzureFileStorage : IFileStorage
    {
        public Task DeleteAsync(string container, string directory, string filename)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateAsync(string container, string directory, string oldFilename, byte[] newContent, string extension, string contentType)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UploadAsync(string container, string directory, byte[] content, string extension, string contentType)
        {
            throw new System.NotImplementedException();
        }
    }
}