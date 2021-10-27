using System.Collections.Generic;
using System.Threading.Tasks;
using ARMS.Models;

namespace ARMS.Providers.List
{
    public interface IListProvider
    {
        List<Semester> LoadSemesters();

        List<Campus> LoadCampuses();

        List<Building> LoadBuildings();
        
        List<Building> LoadBuildings(long campusId);

        List<Room> LoadRooms();
        
        List<Room> LoadRooms(long buildingId);

        List<Course> LoadCourses();

        List<Section> LoadSections(long courseId, long semesterId);

        List<Student> LoadStudents(long sectionId);

        List<ExaminationCourse> LoadExaminationCourses(long semesterId);

        List<UnassignedCourse> LoadUnassignedCourses(long semesterId, long examinationTypeId);

        List<AssignedCourse> LoadExplore(long semesterId, long examinationTypeId);

        List<AssignedCourse> LoadManual(long semesterId, long examinationTypeId);

        List<AssignedCourse> LoadAuto(long semesterId, long examinationTypeId);

        List<ExaminationRoom> LoadExaminationRooms(long semesterId, long examinationTypeId, long courseId);

        List<ExaminationRoom> LoadExaminationRooms(long examinationSlotId);

        List<ExaminationStudent> LoadExaminationStudents(long courseId, long roomId, long examinationSlotId);

        List<ExaminationStudent> LoadExaminationStudents(long examinationRoomId, long examinationSlotId);

        List<ExaminationSection> LoadExaminationSections(long semesterId, long courseId);

        List<ConflictStudent> LoadConflictStudents(long semesterId, long examinationTypeId);
        
        List<SeatingRoom> LoadSeatingRooms(long semesterId, long examinationTypeId);
        
        List<SeatingStudent> LoadSeatingStudents(long semesterId, long examinationSlotId, long examinationRoomId);
        
        List<AssignmentLog> LoadAssignmentLogs(long semesterId, long examinationTypeId);

        InquiryStudent LoadInquiryStudent(long semesterId, long examinationTypeId, string studentCode);
        
        ExaminationUsedRoom LoadExaminationUsedRoom(long semesterId, long examinationTypeId);
    }
}