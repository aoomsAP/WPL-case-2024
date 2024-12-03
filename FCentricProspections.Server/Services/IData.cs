using FCentricProspections.Server.DataModels;
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

        // Contact info -----------------------------------------------------------------------------------------------------------------------------------------

        OwnerDto GetOwner(long id);

        public ContactType GetContactType(long id);

        ContactInfoDto GetContactInfo(long shopId, long contactInfoId);


        // Prospection --------------------------------------------------------------------------------------------------------------------------------------------

        IEnumerable<ProspectionListDto> GetProspectionsByShopId(long shopId);

        IEnumerable<ProspectionListDto> GetProspectionsByUserId(long userId);

        Prospection GetProspection(long id);

        ProspectionDetailDto GetProspectionDetail(long prospectionId);

        IEnumerable<ProspectionBrandDto> GetProspectionBrands(long prospectionId);

        IEnumerable<ProspectionBrandInterestDto> GetProspectionBrandInterests(long prospectionId);

        IEnumerable<ProspectionCompetitorBrandDto> GetProspectionCompetitorBrands(long prospectionId);

        IEnumerable<ProspectionToDo> GetProspectionToDos(long prospectionId);

        void AddProspection(Prospection prospection);

        void UpdateProspection(Prospection prospection);

        void UpdateProspectionBrand(Prospection prospection);

        void UpdateProspectionCompetitorBrand(Prospection prospection);

        void UpdateProspectionBrandInterest(Prospection prospection);

        public void UpdateProspectionToDo(Prospection prospection);

        // ToDo --------------------------------------------------------------------------------------------------------------------------------------------

        IEnumerable<ToDo> GetToDos();

        ToDo GetToDo(long id);

        ToDoStatus GetToDoStatus(long id);

        void AddToDo(ToDo toDo);


        // Brand --------------------------------------------------------------------------------------------------------------------------------------------

        IEnumerable<BrandDto> GetBrands();

        Brand GetBrand(long id);

        IEnumerable<BrandDto> GetBrandsByShop(long shopId);

        IEnumerable<CompetitorBrandDto> GetCompetitorBrands();

        CompetitorBrand GetCompetitorBrand(long id);


        // User & Employee ---------------------------------------------------------------------------------------------------------------------
        
        UserDto GetUserDto(long id);

        User GetUser(long id);

        IEnumerable<UserDto> GetUsers();

        Employee GetEmployee(long id);

        EmployeeDto GetEmployeeWithAppointments(long id);

        Employee GetEmployeeByUserId(long userId);

        IEnumerable<EmployeeDto> GetEmployees();


        //  Appointments -------------------------------------------------------------------------------------------------------------

        Appointment GetAppointment(long id);

        IEnumerable<Appointment> GetAppointments();

        IEnumerable<Appointment> GetAppointmentsByEmployeeId(long employeeId);

        AppointmentState GetAppointmentState(long id);


        // Types ---------------------------------------------------------------------------------------------------------------------

        IEnumerable<ProspectionContactType> GetContactPersonTypes();

        ProspectionContactType GetContactPersonType(long id);

        IEnumerable<ProspectionVisitType> GetVisitTypes();

        ProspectionVisitType GetVisitType(long id);
    }

}
