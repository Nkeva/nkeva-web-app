namespace nkeva_web_app.Services
{
    public class FileStorageService : IFileStorageService
    {
        private const string _rootPath = "FS";

        public FileStorageService()
        {
            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }
        }

        public Task DeleteFileAsync(Models.File file)
        {
            if(file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            var fileStoregePath = GetFilePath(file);
            if(File.Exists(fileStoregePath))
            {
                File.Delete(fileStoregePath);
            }
            return Task.CompletedTask;
        }

        public Task<Stream> DownloadFileAsync(Models.File file)
        {
            if(file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            var fileStoregePath = GetFilePath(file);
            if(!File.Exists(fileStoregePath))
            {
                throw new FileNotFoundException("File not found", fileStoregePath);
            }

            return Task.FromResult<Stream>(new FileStream(fileStoregePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true));
        }

        public async Task<Stream> UploadFileAsync(Models.File file, Stream fileStream, CancellationToken cancellationToken = default)
        {
            if(fileStream == null)
            {
                throw new ArgumentNullException(nameof(fileStream));
            }
            if(file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            if(fileStream.Length == 0)
            {
                throw new ArgumentException("File stream is empty", nameof(fileStream));
            }

            var schoolPath = GetPath(file);
            if(!Directory.Exists(schoolPath))
            {
                Directory.CreateDirectory(schoolPath);
            }
            var fileStoregePath = GetFilePath(file);
            
            using(var fs = new FileStream(fileStoregePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                await fileStream.CopyToAsync(fs, 4096, cancellationToken);
            }
            return fileStream;

        }
        private string GetPath(Models.File file)
        {
            string subDir = (file.SchoolId is null ? -1 : file.SchoolId).ToString();

            return Path.Combine(AppContext.BaseDirectory, _rootPath, subDir);
        }

        private string GetFilePath(Models.File file)
        {
            return Path.Combine(GetPath(file), file.Id.ToString());
        }
    }
}
