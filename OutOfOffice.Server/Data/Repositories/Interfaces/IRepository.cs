using Microsoft.AspNetCore.Mvc;
using OutOfOffice.Server.Data.Repositories.Filters;
using OutOfOffice.Server.Data.Responses;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Data.Repositories.Interfaces
{
    public interface IRepository<T, F>
    {
        public Task<PageResponse<T>> Get(Pagination pagination, F filter);
        public Task<T> GetById(int id);
        public Task Create(T entry);
        public Task Update(T entry);
        public Task Delete(int id);
    }
}
