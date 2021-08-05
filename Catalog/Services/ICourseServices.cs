using Catalog.Dtos;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public interface ICourseServices
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetById(string id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
