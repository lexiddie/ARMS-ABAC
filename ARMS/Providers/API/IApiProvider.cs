using System.Collections.Generic;
using System.Threading.Tasks;
using ARMS.Dtos;
using ARMS.Models;
using ARMS.Models.Completions;

namespace ARMS.Providers.API
{
    public interface IApiProvider
    {
        Task<List<SemesterCompletion>> CompletionSemesters();

        Task<List<SessionCompletion>> CompletionSessions();

        Task<List<FacultyCompletion>> CompletionFaculties();

        Task<List<DepartmentCompletion>> CompletionDepartments();

        Task<List<CourseCompletion>> CompletionCourses();

        Task<List<CourseCompletion>> CompletionStudyCourses(long semesterId);

        Task<List<CourseCompletion>> CompletionExaminationCourses(long semesterId, long examinationTypeId);

        Task<List<CourseCompletion>> CompletionAssignedCourses(long semesterId, long examinationTypeId);

        Task<List<CourseCompletion>> CompletionUnassignedCourses(long semesterId, long examinationTypeId);

        Task<List<ExaminationSlotCompletion>> CompletionExaminationSlots(long semesterId, long examinationTypeId);

        Task<List<SectionCompletion>> CompletionSections(long semesterId);

        Task<List<CampusCompletion>> CompletionCampuses();

        Task<List<BuildingCompletion>> CompletionBuildings();

        Task<List<RoomCompletion>> CompletionRooms();

        Task<List<RoomCompletion>> CompletionAvailableRooms(long examinationSlotId);

        Task<List<StudentCompletion>> CompletionStudents(long semesterId);

        Task<List<CampusDto>> ApiCampuses();

        Task<List<BuildingDto>> ApiBuildings();
        
        Task<List<BuildingDto>> ApiBuildings(long campusId);

        Task<List<RoomDto>> ApiRooms();
        
        Task<List<RoomDto>> ApiRooms(long buildingId);

        Task<List<SemesterDto>> ApiSemesters();

        Task<List<CourseDto>> ApiCourses();

        Task<List<SectionDto>> ApiSections(long courseId, long semesterId);

        Task<List<StudentDto>> ApiStudents(long sectionId);

        Task<List<ExaminationCourseDto>> ApiExaminationCourses(long semesterId);

        Task<List<UnassignedCourseDto>> ApiUnassignedCourses(long semesterId, long examinationTypeId);

        Task<List<AssignedCourseDto>> ApiExplore(long semesterId, long examinationTypeId);

        Task<List<AssignedCourseDto>> ApiManual(long semesterId, long examinationTypeId);

        Task<List<AssignedCourseDto>> ApiAutomate(long semesterId, long examinationTypeId);

        Task<List<ExaminationRoomDto>> ApiExaminationRooms(long semesterId, long examinationTypeId, long courseId);

        Task<List<ExaminationRoomDto>> ApiExaminationRooms(long examinationSlotId);

        Task<List<ExaminationStudentDto>> ApiExaminationStudents(long courseId, long roomId, long examinationSlotId);

        Task<List<ExaminationStudentDto>> ApiExaminationStudents(long examinationRoomId, long examinationSlotId);

        Task<List<ExaminationSectionDto>> ApiExaminationSections(long semesterId, long courseId);

        Task<List<ConflictStudentDto>> ApiConflictStudents(long semesterId, long examinationTypeId);
        
        Task<List<SeatingRoomDto>> ApiSeatingRooms(long semesterId, long examinationTypeId);
        
        Task<List<SeatingStudentDto>> ApiSeatingStudents(long examinationSlotId, long ExaminationRoomId);
        
        Task<List<AssignmentLogDto>> ApiAssignmentLogs(long semesterId, long examinationTypeId);

        Task<InquiryStudentDto> ApiInquiryStudent(long semesterId, long examinationTypeId, string studentCode);
        
        Task<ExaminationUsedRoomDto> ApiExaminationUsedRoom(long semesterId, long examinationTypeId);

        Task<Response> ApiActivateManual(ManualArrangement manualArrangement);

        Task<Response> ApiActivateAutomate(AutomateArrangement automateArrangement);

        Task<Response> ApiDissolvedCourse(DissolvedCourse dissolvedCourse);

        Task<Response> ApiDissolvedCourses(DissolvedCourses dissolvedCourses);
        
    }
}