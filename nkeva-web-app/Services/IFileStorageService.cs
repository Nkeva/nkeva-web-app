namespace nkeva_web_app.Services
{
    public interface IFileStorageService
    {
        // download / upload / delete files
        // use stream to download / upload

        // download file
        Task<Stream> DownloadFileAsync(Models.File file);
        Task<Stream> UploadFileAsync(
            Models.File file,
            Stream fileStream,
            CancellationToken cancellationToken = default(CancellationToken)
        );
        Task DeleteFileAsync(Models.File file);
    }
}
