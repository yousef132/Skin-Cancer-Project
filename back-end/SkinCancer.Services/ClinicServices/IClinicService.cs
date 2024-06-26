﻿using Microsoft.AspNetCore.Mvc;
using SkinCancer.Entities.AuthModels;
using SkinCancer.Entities.Models;
using SkinCancer.Entities.ModelsDtos.DoctorClinicDtos;
using SkinCancer.Entities.ModelsDtos.DoctorDtos;
using SkinCancer.Entities.ModelsDtos.PatientDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Services.ClinicServices
{
    public interface IClinicService
    {

        Task<IEnumerable<DoctorClinicDetailsDto>> GetAllClinicsAsync();

        Task<ProcessResult> CreateClinicAsync(CreateClinicDto clinicDto);
    
        Task<ProcessResult> DeleteClinicAsync(int id);

        Task<IEnumerable<DoctorClinicDetailsDto>> GetClinicByName(string name);

        Task<IEnumerable<DoctorClinicDetailsDto>> GetClinicOrderedByRate();

        Task<IEnumerable<DoctorClinicDetailsDto>> GetClinicsByPriceRangeService
            (int minPrice, int maxPrice);

        Task<DoctorClinicDetailsDto> GetClinicById(int id);

        Task<ProcessResult> UpdateClinicAsync(DoctorClinicUpdateDto clinicDto);

        Task<ProcessResult> PatientRateClinicAsync(PatientRateDto dto);

        Task<ProcessResult> IsDoctorHasClinicAsync(string doctorId);

        



    }
}
