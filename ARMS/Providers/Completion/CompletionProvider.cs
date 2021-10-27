using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARMS.Helpers;
using ARMS.Models.Completions;
using ARMS.Providers.API;

namespace ARMS.Providers.Completion
{
    public class CompletionProvider : ICompletionProvider
    {
        private static readonly ApiProvider ApiProvider = new ApiProvider();

        private Task<List<SemesterCompletion>> _semesters;

        private Task<List<SessionCompletion>> _sessions;

        private Task<List<FacultyCompletion>> _faculties;

        private Task<List<DepartmentCompletion>> _departments;

        private Task<List<CourseCompletion>> _courses;

        private Task<List<CourseCompletion>> _studyCourses;

        private Task<List<CourseCompletion>> _examinationCourses;

        private Task<List<CourseCompletion>> _assignedCourses;

        private Task<List<CourseCompletion>> _unassignedCourses;

        private Task<List<ExaminationSlotCompletion>> _examinationSlots;

        private Task<List<SectionCompletion>> _sections;

        private Task<List<CampusCompletion>> _campuses;

        private Task<List<BuildingCompletion>> _buildings;

        private Task<List<RoomCompletion>> _rooms;

        private Task<List<RoomCompletion>> _availableRooms;

        public List<SemesterCompletion> CompletionSemesters()
        {
            _semesters = ApiProvider.CompletionSemesters();
            return _semesters.Result.Select(item => new SemesterCompletion
            {
                Id = item.Id,
                AcademicLevelId = item.AcademicLevelId,
                Term = item.Term,
                AcademicYear = item.AcademicYear,
                IsCurrent = item.IsCurrent
            }).OrderBy(x => x.AcademicYear).Reverse()
                .ToList();
        }

        public List<SessionCompletion> CompletionSessions()
        {
            _sessions = ApiProvider.CompletionSessions();
            return _sessions.Result.Select(item => new SessionCompletion
            {
                SemesterId = item.SemesterId,
                ExaminationTypeId = item.ExaminationTypeId,
                NameEn = item.NameEn
            })
                .ToList();
        }

        public List<SessionCompletion> CompletionSessions(long semesterId)
        {
            _sessions = ApiProvider.CompletionSessions();
            return _sessions.Result.Where(item => semesterId == item.SemesterId).Select(item => new SessionCompletion
            {
                SemesterId = item.SemesterId,
                ExaminationTypeId = item.ExaminationTypeId,
                NameEn = item.NameEn
            }).ToList();
        }

        public List<FacultyCompletion> CompletionFaculties()
        {
            _faculties = ApiProvider.CompletionFaculties();
            return _faculties.Result.Select(item => new FacultyCompletion
            {
                Id = item.Id,
                Abbreviation = item.Abbreviation,
            })
                .ToList();
        }

        public List<DepartmentCompletion> CompletionDepartments()
        {
            _departments = ApiProvider.CompletionDepartments();
            return _departments.Result.Select(item => new DepartmentCompletion
            {
                Id = item.Id,
                NameEn = item.NameEn,
                FacultyId = item.FacultyId
            })
                .ToList();
        }

        public List<CourseCompletion> CompletionCourses()
        {
            _courses = ApiProvider.CompletionCourses();
            return _courses.Result.Select(item => new CourseCompletion
            {
                Id = item.Id,
                Code = item.Code.TrimEnd(),
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId
            })
                .ToList();
        }

        public List<CourseCompletion> CompletionStudyCourses(long semesterId)
        {
            _studyCourses = ApiProvider.CompletionStudyCourses(semesterId);
            return _studyCourses.Result.Select(item => new CourseCompletion
            {
                Id = item.Id,
                Code = item.Code.TrimEnd(),
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId
            })
                .ToList();
        }

        public List<CourseCompletion> CompletionExaminationCourses(long semesterId, long examinationTypeId)
        {
            _examinationCourses = ApiProvider.CompletionExaminationCourses(semesterId, examinationTypeId);
            return _examinationCourses.Result.Select(item => new CourseCompletion
            {
                Id = item.Id,
                Code = item.Code.TrimEnd(),
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId
            })
                .ToList();
        }

        public List<CourseCompletion> CompletionAssignedCourses(long semesterId, long examinationTypeId)
        {
            _assignedCourses = ApiProvider.CompletionAssignedCourses(semesterId, examinationTypeId);
            return _assignedCourses.Result.Select(item => new CourseCompletion
            {
                Id = item.Id,
                Code = item.Code.TrimEnd(),
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId
            })
                .ToList();
        }

        public List<CourseCompletion> CompletionUnassignedCourses(long semesterId, long examinationTypeId)
        {
            _unassignedCourses = ApiProvider.CompletionUnassignedCourses(semesterId, examinationTypeId);
            return _unassignedCourses.Result.Select(item => new CourseCompletion
            {
                Id = item.Id,
                Code = item.Code.TrimEnd(),
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId
            })
                .ToList();
        }

        public List<ExaminationSlotCompletion> CompletionExaminationSlots(long semesterId, long examinationTypeId)
        {
            _examinationSlots = ApiProvider.CompletionExaminationSlots(semesterId, examinationTypeId);
            return _examinationSlots.Result.Select(item => new ExaminationSlotCompletion
            {
                Id = item.Id,
                Date = item.Date,
                TimeStart = item.TimeStart,
                TimeEnd = item.TimeEnd
            })
                .ToList();
        }

        public List<SectionCompletion> CompletionSections(long semesterId)
        {
            _sections = ApiProvider.CompletionSections(semesterId);
            return _sections.Result.Select(item => new SectionCompletion
            {
                Id = item.Id,
                Number = item.Number,
                CourseId = item.CourseId,
                SeatUsed = item.SeatUsed
            })
                .ToList();
        }

        public List<CampusCompletion> CompletionCampuses()
        {
            _campuses = ApiProvider.CompletionCampuses();
            return _campuses.Result.Select(item => new CampusCompletion
            {
                Id = item.Id,
                NameEn = item.NameEn
            })
                .ToList();
        }

        public List<BuildingCompletion> CompletionBuildings()
        {
            _buildings = ApiProvider.CompletionBuildings();
            return _buildings.Result.Select(item => new BuildingCompletion
            {
                Id = item.Id,
                NameEn = item.NameEn,
                FloorNumber = item.FloorNumber,
                CampusId = item.CampusId
            })
                .ToList();
        }

        public List<RoomCompletion> CompletionRooms()
        {
            _rooms = ApiProvider.CompletionRooms();
            return _rooms.Result.Select(item => new RoomCompletion
            {
                Id = item.Id,
                Name = FilterString.FilterRoomName(item.Name),
                Floor = item.Floor,
                ExamCapacity = item.ExamCapacity,
                CampusId = item.CampusId,
                BuildingId = item.BuildingId
            })
                .ToList();
        }

        public List<RoomCompletion> CompletionAvailableRooms(long examinationSlotId)
        {
            _availableRooms = ApiProvider.CompletionAvailableRooms(examinationSlotId);
            return _availableRooms.Result.Select(item => new RoomCompletion
            {
                Id = item.Id,
                Name = FilterString.FilterRoomName(item.Name),
                Floor = item.Floor,
                ExamCapacity = item.ExamCapacity,
                CampusId = item.CampusId,
                BuildingId = item.BuildingId
            })
                .ToList();
        }
    }
}