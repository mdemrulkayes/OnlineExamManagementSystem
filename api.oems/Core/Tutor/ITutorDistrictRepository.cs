using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core.Models.Tutor;

namespace api.oems.Core.Tutor
{
    public interface ITutorDistrictRepository
    {
        Task<TutorDistrict> GetTutorDistrict(int? id);

        Task<IEnumerable<TutorDistrict>> GetAllTutorDistrict();

        void CreateTutorDistrict(TutorDistrict district);

        void UpdateTutorDistrict(TutorDistrict district);

        void DeleteTutorDistrict(TutorDistrict district);
    }
}
