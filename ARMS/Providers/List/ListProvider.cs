using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARMS.Dtos;
using ARMS.Helpers;
using ARMS.Models;
using ARMS.Models.Completions;
using ARMS.Providers.API;

namespace ARMS.Providers.List
{
    public class ListProvider : IListProvider
    {
        private static readonly ApiProvider ApiProvider = new ApiProvider();

        private Task<List<FacultyCompletion>> _completionFaculties;

        private Task<List<DepartmentCompletion>> _completionDepartments;

        private Task<List<StudentCompletion>> _completionStudents;

        private Task<List<ExaminationSlotCompletion>> _completionExaminationSlots;

        private Task<List<SectionCompletion>> _completionSections;

        private Task<List<SemesterDto>> _semesters;

        private Task<List<CampusDto>> _campuses;

        private Task<List<BuildingDto>> _buildings;

        private Task<List<RoomDto>> _rooms;

        private Task<List<CourseDto>> _courses;

        private Task<List<SectionDto>> _sections;

        private Task<List<StudentDto>> _students;

        private Task<List<ExaminationCourseDto>> _examinationCourses;

        private Task<List<UnassignedCourseDto>> _unassignedCourses;

        private Task<List<AssignedCourseDto>> _assignedCourses;

        private Task<List<ExaminationRoomDto>> _examinationRooms;

        private Task<List<ExaminationStudentDto>> _examinationStudents;

        private Task<List<ExaminationSectionDto>> _examinationSections;

        private Task<List<ConflictStudentDto>> _conflictStudents;

        private Task<List<SeatingRoomDto>> _seatingRooms;
        
        private Task<List<SeatingStudentDto>> _seatingStudents;

        private Task<List<AssignmentLogDto>> _assignmentLogs;

        public List<Semester> LoadSemesters()
        {
            _semesters = ApiProvider.ApiSemesters();
            return _semesters.Result.Select(item => new Semester
            {
                Id = item.Id,
                AcademicLevelId = item.AcademicLevelId,
                AcademicYear = item.AcademicYear,
                Term = item.Term,
                IsCurrent = item.IsCurrent,
                StartDate = item.StartedDate,
                EndDate = item.EndedDate,
                MidtermStartDate = ReadDateTime.ReadDate(item.MidtermStartDate),
                MidtermEndDate = ReadDateTime.ReadDate(item.MidtermEndDate),
                FinalStartDate = ReadDateTime.ReadDate(item.FinalStartDate),
                FinalEndDate = ReadDateTime.ReadDate(item.FinalEndDate),
                TotalWeek = decimal.ToInt32(item.TotalWeekCount),
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }


        public List<Campus> LoadCampuses()
        {
            _campuses = ApiProvider.ApiCampuses();
            return _campuses.Result.Select(item => new Campus
            {
                Id = item.Id,
                NameEn = item.NameEn,
                NameTh = item.NameTh,
                TotalBuilding = item.TotalBuilding,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }



        public List<Building> LoadBuildings()
        {
            _buildings = ApiProvider.ApiBuildings();
            return _buildings.Result.Select(item => new Building
            {
                Id = item.Id,
                NameEn = item.NameEn,
                NameTh = item.NameTh,
                TotalFloor = item.FloorNumber,
                TotalRoom = item.TotalRoom,
                CampusId = item.CampusId,
                CampusName = item.CampusName,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }

        public List<Building> LoadBuildings(long campusId)
        {
            _buildings = ApiProvider.ApiBuildings(campusId);
            return _buildings.Result.Select(item => new Building
            {
                Id = item.Id,
                NameEn = item.NameEn,
                NameTh = item.NameTh,
                TotalFloor = item.FloorNumber,
                TotalRoom = item.TotalRoom,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }

        public List<Room> LoadRooms()
        {
            _rooms = ApiProvider.ApiRooms();
            return _rooms.Result.Select(item => new Room
            {
                Id = item.Id,
                Name = FilterString.FilterRoomName(item.Name),
                Floor = item.Floor,
                TotalSeat = item.ExamCapacity,
                TotalRow = item.ExamRows,
                CampusId = item.CampusId,
                CampusName = item.CampusName,
                BuildingId = item.BuildingId,
                BuildingName = item.BuildingName,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }

        public List<Room> LoadRooms(long buildingId)
        {
            _rooms = ApiProvider.ApiRooms(buildingId);
            return _rooms.Result.Select(item => new Room
            {
                Id = item.Id,
                Name = FilterString.FilterRoomName(item.Name),
                Floor = item.Floor,
                TotalSeat = item.ExamCapacity,
                TotalRow = item.ExamRows,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }

        public List<Course> LoadCourses()
        {
            _completionFaculties = ApiProvider.CompletionFaculties();
            _completionDepartments = ApiProvider.CompletionDepartments();
            _courses = ApiProvider.ApiCourses();
            Task.WhenAll(_completionFaculties, _completionDepartments, _courses);
            return _courses.Result.Select(item => new Course
            {
                Id = item.Id,
                Code = item.Code,
                Name = item.NameEn,
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId,
                Faculty = LoadFaculty(item.FacultyId),
                Department = LoadDepartment(item.FacultyId, item.DepartmentId),
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }

        public List<Section> LoadSections(long courseId, long semesterId)
        {
            _sections = ApiProvider.ApiSections(courseId, semesterId);
            return _sections.Result.Select(item => new Section
            {
                Id = item.Id,
                Number = item.Number,
                CourseId = item.CourseId,
                SeatUsed = item.SeatUsed,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }

        public List<Student> LoadStudents(long sectionId)
        {
            _students = ApiProvider.ApiStudents(sectionId);
            return _students.Result.Select(item => new Student
            {
                Id = item.Id,
                Code = item.Code,
                FirstName = item.FirstName,
                LastName = item.LastName,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            })
                .ToList();
        }

        public List<ExaminationCourse> LoadExaminationCourses(long semesterId)
        {
            _examinationCourses = ApiProvider.ApiExaminationCourses(semesterId);
            return _examinationCourses.Result.Select(item => new ExaminationCourse
            {
                Id = item.Id,
                Code = item.Code.TrimEnd(),
                Name = item.Name,
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId,
                TotalSection = item.TotalSection,
                TotalStudent = item.TotalStudent,
                Midterm = LoadExaminationSlot(item.Midterm),
                Final = LoadExaminationSlot(item.Final)
            }).OrderBy(x => x.CodeAndName)
                .ToList();
        }

        public List<UnassignedCourse> LoadUnassignedCourses(long semesterId, long examinationTypeId)
        {
            _unassignedCourses = ApiProvider.ApiUnassignedCourses(semesterId, examinationTypeId);
            return _unassignedCourses.Result.Select(item => new UnassignedCourse
            {
                Id = item.Id,
                Code = item.Code.TrimEnd(),
                Name = item.Name,
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId,
                TotalSection = item.TotalSection,
                TotalStudent = item.TotalStudent,
                ExaminationSlot = LoadExaminationSlot(item.ExaminationSlot)
            })
                .ToList();
        }

        private ExaminationSlot LoadExaminationSlot(long examinationSlotId)
        {
            var examinationSlot = new ExaminationSlot();
            foreach (var item in _completionExaminationSlots.Result.Where(item => examinationSlotId == item.Id))
            {
                examinationSlot.Id = item.Id;
                examinationSlot.TimeStart = ReadDateTime.ReadRealTime(item.TimeStart);
                examinationSlot.TimeEnd = ReadDateTime.ReadRealTime(item.TimeEnd);
                examinationSlot.Date = ReadDateTime.ReadDate(item.Date);
                return examinationSlot;
            }
            return examinationSlot;
        }

        private static ExaminationSlot LoadExaminationSlot(ExaminationSlotDto item)
        {
            var examinationSlot = new ExaminationSlot();
            if (item == null) return null;
            examinationSlot.Id = item.Id;
            examinationSlot.TimeStart = ReadDateTime.ReadRealTime(item.TimeStart);
            examinationSlot.TimeEnd = ReadDateTime.ReadRealTime(item.TimeEnd);
            examinationSlot.Date = ReadDateTime.ReadDate(item.Date);
            return examinationSlot;
        }

        public List<AssignedCourse> LoadExplore(long semesterId, long examinationTypeId)
        {
            _assignedCourses = ApiProvider.ApiExplore(semesterId, examinationTypeId);
            Task.WhenAll(_assignedCourses);
            return _assignedCourses.Result.Select(item => new AssignedCourse
            {
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId,
                CourseId = item.CourseId,
                CourseCode = item.CourseCode.TrimEnd(),
                CourseName = item.CourseName,
                TotalSection = item.TotalSection,
                TotalStudent = item.TotalStudent,
                TotalRoom = item.TotalRoom,
                ExaminationSlot = LoadExaminationSlot(item.ExaminationSlot),
                CreatedBy = item.CreatedBy
            }).OrderBy(x => x.ExaminationSlot.ExaminationDateTime).ToList();
        }

        public List<AssignedCourse> LoadManual(long semesterId, long examinationTypeId)
        {
            _assignedCourses = ApiProvider.ApiManual(semesterId, examinationTypeId);
            Task.WhenAll(_assignedCourses);
            return _assignedCourses.Result.Select(item => new AssignedCourse
            {
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId,
                CourseId = item.CourseId,
                CourseCode = item.CourseCode.TrimEnd(),
                CourseName = item.CourseName,
                TotalSection = item.TotalSection,
                TotalStudent = item.TotalStudent,
                TotalRoom = item.TotalRoom,
                ExaminationSlot = LoadExaminationSlot(item.ExaminationSlot),
                CreatedBy = item.CreatedBy
            }).OrderBy(x => x.ExaminationSlot.ExaminationDateTime).ToList();
        }

        public List<AssignedCourse> LoadAuto(long semesterId, long examinationTypeId)
        {
            _assignedCourses = ApiProvider.ApiAutomate(semesterId, examinationTypeId);
            Task.WhenAll(_assignedCourses);
            return _assignedCourses.Result.Select(item => new AssignedCourse
            {
                FacultyId = item.FacultyId,
                DepartmentId = item.DepartmentId,
                CourseId = item.CourseId,
                CourseCode = item.CourseCode.TrimEnd(),
                CourseName = item.CourseName,
                TotalSection = item.TotalSection,
                TotalStudent = item.TotalStudent,
                TotalRoom = item.TotalRoom,
                ExaminationSlot = LoadExaminationSlot(item.ExaminationSlot),
                CreatedBy = item.CreatedBy
            }).OrderBy(x => x.ExaminationSlot.ExaminationDateTime).ToList();
        }

        public List<ExaminationRoom> LoadExaminationRooms(long semesterId, long examinationTypeId, long courseId)
        {
            _examinationRooms = ApiProvider.ApiExaminationRooms(semesterId, examinationTypeId, courseId);
            Task.WhenAll(_examinationRooms);
            return _examinationRooms.Result.Select(item => new ExaminationRoom
            {
                Id = item.Id,
                Name = FilterString.FilterRoomName(item.Name),
                CampusId = item.CampusId,
                CampusName = item.CampusName,
                BuildingId = item.BuildingId,
                BuildingName = item.BuildingName,
                TotalSeat = item.TotalSeat,
                TotalSection = item.TotalSection,
                TotalStudent = item.TotalStudent,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy
            })
                .ToList();
        }

        public List<ExaminationRoom> LoadExaminationRooms(long examinationSlotId)
        {
            _examinationRooms = ApiProvider.ApiExaminationRooms(examinationSlotId);
            return _examinationRooms.Result.Select(item => new ExaminationRoom
            {
                Id = item.Id,
                Name = FilterString.FilterRoomName(item.Name),
                Floor = item.Floor,
                CampusId = item.CampusId,
                CampusName = item.CampusName,
                BuildingId = item.BuildingId,
                BuildingName = item.BuildingName,
                TotalSeat = item.TotalSeat,
                TotalSection = item.TotalSection,
                TotalStudent = item.TotalStudent,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy
            })
                .ToList();
        }

        public List<ExaminationStudent> LoadExaminationStudents(long courseId, long roomId, long examinationSlotId)
        {
            _examinationStudents = ApiProvider.ApiExaminationStudents(courseId, roomId, examinationSlotId);
            return _examinationStudents.Result.Select(item => new ExaminationStudent
            {
                Id = item.Id,
                Code = item.Code,
                FirstName = item.FirstName,
                LastName = item.LastName,
                SectionNumber = item.SectionNumber,
                Seat = item.SeatNumber,
                Row = item.RowNumber,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            }).OrderBy(x => x.Row).ThenBy(x => x.Seat).ToList();
        }

        public List<ExaminationStudent> LoadExaminationStudents(long examinationRoomId, long examinationSlotId)
        {
            _examinationStudents = ApiProvider.ApiExaminationStudents(examinationRoomId, examinationSlotId);
            return _examinationStudents.Result.Select(item => new ExaminationStudent
            {
                Id = item.Id,
                Code = item.Code,
                FirstName = item.FirstName,
                LastName = item.LastName,
                SectionNumber = item.SectionNumber,
                Seat = item.SeatNumber,
                Row = item.RowNumber,
                CreatedDate = ReadDateTime.ReadDate(item.CreatedAt),
                CreatedTime = ReadDateTime.ReadTime(item.CreatedAt),
                CreatedBy = item.CreatedBy,
                IsActive = item.IsActive
            }).OrderBy(x => x.Row).ThenBy(x => x.Seat).ToList();
        }

        public List<ExaminationSection> LoadExaminationSections(long semesterId, long courseId)
        {
            _examinationSections = ApiProvider.ApiExaminationSections(semesterId, courseId);
            return _examinationSections.Result.Select(item => new ExaminationSection
            {
                Id = item.Id,
                Number = item.Number,
                SeatUsed = item.SeatUsed,
                CampusId = item.CampusId,
                CampusName = item.CampusName
            })
                .ToList();
        }

        private StudentCompletion LoadStudent(long studentId)
        {
            var student = new StudentCompletion();
            foreach (var item in _completionStudents.Result.Where(item => studentId == item.Id))
            {
                student.Id = item.Id;
                student.Code = item.Code;
                student.FirstName = item.FirstName;
                student.LastName = item.LastName;
                return student;
            }
            return student;
        }

        public List<ConflictStudent> LoadConflictStudents(long semesterId, long examinationTypeId)
        {
            Console.WriteLine($"Checking semester {semesterId} {examinationTypeId}");
            _conflictStudents = ApiProvider.ApiConflictStudents(semesterId, examinationTypeId);
            _completionStudents = ApiProvider.CompletionStudents(semesterId);
            _completionExaminationSlots = ApiProvider.CompletionExaminationSlots(semesterId, examinationTypeId);
            Task.WhenAll(_conflictStudents, _completionStudents, _completionExaminationSlots);
            var conflictStudents = new List<ConflictStudent>();
            foreach (var data in _conflictStudents.Result)
            {
                var conflictStudent = new ConflictStudent();
                var student = LoadStudent(data.StudentId);
                var slot = LoadExaminationSlot(data.ExaminationSlotId);
                conflictStudent.Id = student.Id;
                conflictStudent.Code = student.Code;
                conflictStudent.FirstName = student.FirstName;
                conflictStudent.LastName = student.LastName;
                conflictStudent.ExaminationSlot = slot;
                conflictStudent.CourseIds = data.CourseIds.Select(i => i.Id).ToList();
                conflictStudents.Add(conflictStudent);
            }
            return conflictStudents;
        }

        // public List<SeatingRoom> LoadSeatingRooms(long semesterId, long examinationTypeId)
        // {
        //     _seatingRooms = ApiProvider.ApiSeatingRooms(semesterId, examinationTypeId);
        //     _completionStudents = ApiProvider.CompletionStudents(semesterId);
        //     _completionSections = ApiProvider.CompletionSections(semesterId);
        //     _completionExaminationSlots = ApiProvider.CompletionExaminationSlots(semesterId, examinationTypeId);
        //     _rooms = ApiProvider.ApiRooms();
        //     
        //     Task.WhenAll(_seatingRooms, _completionStudents, _completionSections, _completionExaminationSlots, _rooms);
        //     
        //     return (from data in _seatingRooms.Result
        //         let room = LoadRoom(data.RoomId)
        //         let examinationSlot = LoadExaminationSlot(data.ExaminationSlotId)
        //         let seatingStudents = LoadSeatingStudents(data.ExaminationStudents)
        //         select new SeatingRoom
        //         {
        //             Id = room.Id,
        //             Name = FilterString.FilterRoomName(room.Name),
        //             Floor = room.Floor,
        //             CampusId = room.CampusId,
        //             CampusName = room.CampusName,
        //             BuildingId = room.BuildingId,
        //             BuildingName = room.BuildingName,
        //             ExaminationStudents = seatingStudents,
        //             ExaminationSlotId = examinationSlot.Id,
        //             Date = examinationSlot.Date,
        //             TimeStart = examinationSlot.TimeStart,
        //             TimeEnd = examinationSlot.TimeEnd,
        //         }).OrderBy(x => x.ExaminationDateTime).ToList();
        // }

        public List<SeatingRoom> LoadSeatingRooms(long semesterId, long examinationTypeId)
        {
            _seatingRooms = ApiProvider.ApiSeatingRooms(semesterId, examinationTypeId);
            _completionExaminationSlots = ApiProvider.CompletionExaminationSlots(semesterId, examinationTypeId);
            _rooms = ApiProvider.ApiRooms();
            Task.WhenAll(_seatingRooms, _completionExaminationSlots, _rooms);
            return (from data in _seatingRooms.Result
                let room = LoadRoom(data.RoomId)
                let examinationSlot = LoadExaminationSlot(data.ExaminationSlotId)
                select new SeatingRoom
                {
                    Id = room.Id,
                    Name = room.Name,
                    Floor = room.Floor,
                    CampusId = room.CampusId,
                    CampusName = room.CampusName,
                    BuildingId = room.BuildingId,
                    BuildingName = room.BuildingName,
                    ExaminationSlotId = examinationSlot.Id,
                    ExaminationDateTime = examinationSlot.ExaminationDateTime,
                    TotalStudent = data.ExaminationStudents
                }).OrderBy(x => x.ExaminationDateTime).ToList();
        }

        public List<SeatingStudent> LoadSeatingStudents(long semesterId, long examinationSlotId, long examinationRoomId)
        {
            _seatingStudents = ApiProvider.ApiSeatingStudents(examinationSlotId, examinationRoomId);
            _completionStudents = ApiProvider.CompletionStudents(semesterId);
            _completionSections = ApiProvider.CompletionSections(semesterId);
            Task.WhenAll(_seatingStudents, _completionStudents, _completionSections);
            var seatingStudents = new List<SeatingStudent>();
            foreach (var i in _seatingStudents.Result)
            {
                var seatingStudent = new SeatingStudent();
                foreach (var j in _completionStudents.Result.Where(j => i.Id == j.Id))
                {
                    seatingStudent.Id = j.Id;
                    seatingStudent.Code = j.Code;
                    seatingStudent.FirstName = j.FirstName;
                    seatingStudent.LastName = j.LastName;
                    seatingStudent.CourseCode = i.CourseCode;
                    seatingStudent.Section = LoadSectionNumber(i.SectionId);
                    seatingStudent.Row = i.Row;
                    seatingStudent.Seat = i.Seat;
                    break;
                }
                seatingStudents.Add(seatingStudent);
            }

            return seatingStudents.OrderBy(x => x.Row).ThenBy(x => x.Seat).ToList();
        }

        public List<AssignmentLog> LoadAssignmentLogs(long semesterId, long examinationTypeId)
        {
            _assignmentLogs = ApiProvider.ApiAssignmentLogs(semesterId, examinationTypeId);
            return (from data in _assignmentLogs.Result
                    select new AssignmentLog
                    {
                        LogType = data.LogType,
                        ActivityType = data.ActivityType,
                        CreatedDate = ReadDateTime.ReadDate(data.CreatedAt),
                        CreatedTime = ReadDateTime.ReadTime(data.CreatedAt),
                        CreatedBy = data.CreatedBy
                    }).OrderBy(x => x.CreatedDate).ThenBy(x => x.CreatedTime).Reverse().ToList();
        }

        private Room LoadRoom(long roomId)
        {
            var room = new Room();
            foreach (var item in _rooms.Result.Where(item => roomId == item.Id))
            {
                room.Id = item.Id;
                room.Name = FilterString.FilterRoomName(item.Name);
                room.Floor = item.Floor;
                room.CampusId = item.CampusId;
                room.CampusName = item.CampusName;
                room.BuildingId = item.BuildingId;
                room.BuildingName = item.BuildingName;
                return room;
            }
            return room;
        }

        //For Seating Student
        // private List<SeatingStudent> LoadSeatingStudents(IEnumerable<SeatingStudentDto> items)
        // {
        //     var seatingStudents = new List<SeatingStudent>();
        //     foreach (var i in items)
        //     {
        //         var seatingStudent = new SeatingStudent();
        //         foreach (var j in _completionStudents.Result.Where(j => i.Id == j.Id))
        //         {
        //             seatingStudent.Id = j.Id;
        //             seatingStudent.Code = j.Code;
        //             seatingStudent.FirstName = j.FirstName;
        //             seatingStudent.LastName = j.LastName;
        //             seatingStudent.Section = LoadSectionNumber(i.SectionId);
        //             seatingStudent.Row = i.Row;
        //             seatingStudent.Seat = i.Seat;
        //             break;
        //         }
        //         seatingStudents.Add(seatingStudent);
        //     }
        //
        //     return seatingStudents.OrderBy(x => x.Row).ThenBy(x => x.Seat).ToList();
        // }

        //For Seating Student
        private string LoadSectionNumber(long sectionId)
        {
            var sectionNumber = "";
            foreach (var item in _completionSections.Result.Where(item => sectionId == item.Id))
            {
                sectionNumber = item.Number;
                return sectionNumber;
            }
            return sectionNumber;
        }

        public InquiryStudent LoadInquiryStudent(long semesterId, long examinationTypeId, string studentCode)
        {
            var item = ApiProvider.ApiInquiryStudent(semesterId, examinationTypeId, studentCode);
            var inquiryStudent = new InquiryStudent
            {
                Id = item.Result.Id,
                StudentCode = item.Result.StudentCode.TrimEnd(),
                FirstName = item.Result.FirstName,
                LastName = item.Result.LastName,
                ExaminationCourses = LoadCourseSchedules(item.Result.ExaminationCourses)
            };
            return inquiryStudent;
        }

        public ExaminationUsedRoom LoadExaminationUsedRoom(long semesterId, long examinationTypeId)
        {
            var item = ApiProvider.ApiExaminationUsedRoom(semesterId, examinationTypeId);
            var examinationUsedRoom = new ExaminationUsedRoom
            {
                TotalUsedRoom = item.Result.TotalUsedRoom
            };
            return examinationUsedRoom;
        }

        private static List<CourseSchedule> LoadCourseSchedules(IEnumerable<CourseScheduleDto> items)
        {
            return items.Select(item => new CourseSchedule
            {
                Id = item.Id,
                Code = item.Code,
                Name = item.Name,
                SectionNumber = item.SectionNumber,
                RoomName = FilterString.FilterRoomName(item.RoomName),
                Seat = item.Seat,
                ExamDate = ReadDateTime.ReadDate(item.ExamDate),
                StartTime = ReadDateTime.ReadRealTime(item.StartTime),
                EndTime = ReadDateTime.ReadRealTime(item.EndTime)
            }).OrderBy(x => x.ExaminationDateTime)
                .ToList();
        }

        private Department LoadDepartment(long facultyId, long departmentId)
        {
            var department = new Department();
            foreach (var item in _completionDepartments.Result.Where(item => departmentId == item.Id))
            {
                department.Id = departmentId;
                department.NameEn = item.NameEn;
                department.FacultyId = facultyId;
                return department;
            }
            return department;
        }

        private Faculty LoadFaculty(long facultyId)
        {
            var faculty = new Faculty();
            foreach (var item in _completionFaculties.Result.Where(item => facultyId == item.Id))
            {
                faculty.Id = facultyId;
                faculty.Abbreviation = item.Abbreviation;
                return faculty;
            }
            return faculty;
        }
    }
}