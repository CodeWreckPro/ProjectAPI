using ProjectAPI.Models;

namespace ProjectAPI.Interfaces
{
    public interface IFetchJson
    {
        public Task<ChangeSets> FetchTasksListAsync(int id);
    }
}
