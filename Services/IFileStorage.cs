using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetIdentity.Services
{
    public interface IFileStorage
    {
        // container: bookstore
        // directory: books
        // filename: python-desde-cero.png
        //path: azure -> bookstore/books/python-desde-cero.png

        Task<string> UploadAsync(string container, string directory, 
                            byte[] content, string extension, string contentType);
        Task<string> UpdateAsync(string container, string directory, string oldFilename, 
                            byte[] newContent, string extension, string contentType);
        Task DeleteAsync(string container, string directory, string filename);
    }
}