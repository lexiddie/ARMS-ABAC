using Microsoft.AspNetCore.Mvc.Rendering;

namespace ARMSAPI.Interfaces
{
    public interface ISelectListProvider
    {
        //General
        // SelectList GetTitlesEn();
        // SelectList GetTitlesTh();
        // SelectList GetRaces();
        // SelectList GetNationalities();
        // SelectList GetReligions();
        // SelectList GetStudentGroups();
        // SelectList GetBankBranches();
        
        //Academic
        SelectList GetScholarships();
        SelectList GetAcademicPrograms();
        SelectList GetAcademicLevels();
        SelectList GetAcademicHonors();
        SelectList GetFaculties();
        SelectList GetDepartments();
        SelectList GetDepartments(long id);
        SelectList GetSemesters();
        SelectList GetSemestersByAcademicLevelId(long id);
        SelectList GetSemesters(long? academicLevelId);
        SelectList GetCurriculum();
        SelectList GetMinors(long? departmentId);
        SelectList GetConcentrations(long? departmentId);

        //Admission
        SelectList GetAdmissionTypes();
        SelectList GetPreSchools();
        SelectList GetEducationBackground();

        //Course 
        SelectList GetCourses();
        SelectList GetCourses(long? academicLevelId);
        SelectList GetSections();
        SelectList GetSections(long courseId);
        SelectList GetCourseByInstructorId(long instructorId, long semesterId);

        //CheatingStatus
        SelectList GetExaminationTypes();
        SelectList GetIncidents();

        //Instructor
        // SelectList GetInstructor();
        // SelectList GetInstructorsByFacultyId(long id);
        // SelectList GetCodeFaculties(long id);
        // SelectList GetCodeDepartments(long id);

        //Address
        // SelectList GetCountries();
        // SelectList GetProvinces();
        // SelectList GetProvinces(long countryId);
        // SelectList GetProvinces(long countryId, long selectedProvinceId);
        // SelectList GetDistricts();
        // SelectList GetSubdistricts();
        // SelectList GetStates();
        // SelectList GetCities(long countryId);
        // SelectList GetCities();

        //Announcement
        // SelectList GetChannels();
        // SelectList GetTopics();
        // SelectList GetTopics(List<long> selectedTopic);

        //Registration
        // SelectList GetRegistrationStatuses();
        // SelectList GetSlotBySemester(long id);
        
        //Academic Calendar 
        // SelectList GetEvents();
        // SelectList GetEventCategories();

        //Parent
        // SelectList GetRelationships();
        
        //Maintenance Status
        // SelectList GetMaintenanceFees(long? facultyId, long? departmentId, long? academicLevelId, long? studentGroupId);

        //Building
        // SelectList GetCampuses();
        // SelectList GetBuildings();
        // SelectList GetRoomTypes(); 

        //Teaching Load
        // SelectList GetTeachingTypes();   
    }
}