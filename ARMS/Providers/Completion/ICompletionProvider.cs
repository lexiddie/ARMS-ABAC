using System.Collections.Generic;
using ARMS.Models.Completions;

namespace ARMS.Providers.Completion
{
    public interface ICompletionProvider
    {
        List<SemesterCompletion> CompletionSemesters();

        List<SessionCompletion> CompletionSessions();

        List<SessionCompletion> CompletionSessions(long semesterId);

        List<FacultyCompletion> CompletionFaculties();

        List<DepartmentCompletion> CompletionDepartments();

        List<CourseCompletion> CompletionCourses();

        List<CourseCompletion> CompletionStudyCourses(long semesterId);

        List<CourseCompletion> CompletionExaminationCourses(long semesterId, long examinationTypeId);

        List<CourseCompletion> CompletionAssignedCourses(long semesterId, long examinationTypeId);

        List<CourseCompletion> CompletionUnassignedCourses(long semesterId, long examinationTypeId);

        List<ExaminationSlotCompletion> CompletionExaminationSlots(long semesterId, long examinationTypeId);

        List<SectionCompletion> CompletionSections(long semesterId);

        List<CampusCompletion> CompletionCampuses();

        List<BuildingCompletion> CompletionBuildings();

        List<RoomCompletion> CompletionRooms();

        List<RoomCompletion> CompletionAvailableRooms(long examinationSlotId);
    }
}