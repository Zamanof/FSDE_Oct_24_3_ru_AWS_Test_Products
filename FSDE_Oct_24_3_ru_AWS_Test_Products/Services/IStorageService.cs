namespace FSDE_Oct_24_3_ru_AWS_Test_Products.Services;

public interface IStorageService
{
    Task<string> UploadFileAsync(IFormFile? file);
    Task DeleteFileByUrlAsync(string? fileUrl);
}
