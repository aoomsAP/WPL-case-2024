﻿using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.DomainModels;
using System.Diagnostics.Metrics;

namespace FCentricProspections.Server.Services
{
    public interface IData
    {
        // Shop --------------------------------------------------------------------------------------------------------------------------------------------------
        
        IEnumerable<ShopListDto> GetShops();

        ShopDetailDto GetShopDetail(long id);

        Shop GetShop(long id);


        // Prospection --------------------------------------------------------------------------------------------------------------------------------------------

        IEnumerable<ProspectionListDto> GetProspectionsByShopId(long shopId);

        IEnumerable<ProspectionListDto> GetProspectionsByUserId(long userId);

        Prospection GetProspection(long id);

        ProspectionDetailDto GetProspectionDetail(long prospectionId);

        IEnumerable<ProspectionBrandDto> GetProspectionBrands(long prospectionId);

        IEnumerable<ProspectionBrandInterestDto> GetProspectionBrandInterests(long prospectionId);

        IEnumerable<ProspectionCompetitorBrandDto> GetProspectionCompetitorBrands(long prospectionId);

        void AddProspection(Prospection prospection);

        void UpdateProspection(Prospection prospection);

        void UpdateProspectionBrand(Prospection prospection);

        void UpdateProspectionCompetitorBrand(Prospection prospection);

        void UpdateProspectionBrandInterest(Prospection prospection);


        // Brand --------------------------------------------------------------------------------------------------------------------------------------------

        IEnumerable<BrandDto> GetBrands();

        Brand GetBrand(long id);

        IEnumerable<CompetitorBrandDto> GetCompetitorBrands();

        CompetitorBrand GetCompetitorBrand(long id);


        // User ---------------------------------------------------------------------------------------------------------------------
        
        UserDto GetUserDto(long id);

        User GetUser(long id);

        IEnumerable<UserDto> GetUsers();

        Employee GetEmployee(long id);

        IEnumerable<EmployeeDto> GetEmployees();

        Employee GetEmployeeWithAppointments(long id);

        Employee GetEmployeeByUserId(long userId);

        //  Appointments -------------------------------------------------------------------------------------------------------------

        Appointment GetAppointment(long id);

        IEnumerable<Appointment> GetAppointments();

        AppointmentState GetAppointmentState(long id);




        // Types ---------------------------------------------------------------------------------------------------------------------

        IEnumerable<ProspectionContactType> GetContactPersonTypes();

        ProspectionContactType GetContactPersonType(long id);

        IEnumerable<ProspectionVisitType> GetVisitTypes();

        ProspectionVisitType GetVisitType(long id);
    }

}
