using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        Platform AddPlatform(Platform platform);
        int DeletePlatform(Platform platform);
    }
}