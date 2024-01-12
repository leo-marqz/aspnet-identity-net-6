using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetIdentity.Services
{
    public class AWSFileStorage : IFileStorage
    {
        public Task DeleteAsync(string container, string directory, string filename)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(string container, string directory, string oldFilename, byte[] newContent, string extension, string contentType)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadAsync(string container, string directory, byte[] content, string extension, string contentType)
        {
            throw new NotImplementedException();
        }
    }
}