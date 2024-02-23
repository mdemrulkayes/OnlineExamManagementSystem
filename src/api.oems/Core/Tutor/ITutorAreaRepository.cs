using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core.Models.Tutor;

namespace api.oems.Core.Tutor
{
    public interface ITutorAreaRepository
    {
        void Create(TutorArea area);

        void Update(TutorArea area);

        void Delete(TutorArea area);

        Task<TutorArea> GetTutorAreaAsync(int? id);

        Task<IEnumerable<TutorArea>> GetAllTutorAreaAsync();
    }
}
