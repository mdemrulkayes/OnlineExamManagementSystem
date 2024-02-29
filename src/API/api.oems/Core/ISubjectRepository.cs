using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface ISubjectRepository
    {
        void CreateSubject(Subject subject);

        void UpdateSubject(Subject subject);

        void DeleteSubejct(Subject subject);

        Task<IEnumerable<Subject>> GetAllSubjectsAsync();

        Task<IEnumerable<Subject>> GetAllSubjectsAsync(string userId);

        Task<Subject> GetSubjectById(int? id);

        Task<Subject> GetSubjectByCode(string subjectCode);
    }
}
