using Catalog.Dtos;
using Catalog.Model;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
