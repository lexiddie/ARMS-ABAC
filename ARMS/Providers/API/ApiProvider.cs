using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ARMS.Dtos;
using ARMS.Models;
using ARMS.Models.Completions;
using Newtonsoft.Json;

namespace ARMS.Providers.API
{
    public class ApiProvider : IApiProvider
    {
        private const string Url = "https://localhost:5001/api/";

        public async Task<List<SemesterCompletion>> CompletionSemesters()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Semester/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SemesterCompletion>>(res);
            return data;
        }

        public async Task<List<SessionCompletion>> CompletionSessions()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "ExaminationSlot/Session/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SessionCompletion>>(res);
            return data;
        }

        public async Task<List<FacultyCompletion>> CompletionFaculties()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Faculty/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<FacultyCompletion>>(res);
            return data;
        }

        public async Task<List<DepartmentCompletion>> CompletionDepartments()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Department/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<DepartmentCompletion>>(res);
            return data;
        }

        public async Task<List<CourseCompletion>> CompletionCourses()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Course/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CourseCompletion>>(res);
            return data;
        }

        public async Task<List<CourseCompletion>> CompletionStudyCourses(long semesterId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"Course/StudyCourse/SelectList/SemesterId={semesterId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CourseCompletion>>(res);
            return data;
        }

        public async Task<List<CourseCompletion>> CompletionExaminationCourses(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationCourse/SelectList/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CourseCompletion>>(res);
            return data;
        }

        public async Task<List<CourseCompletion>> CompletionAssignedCourses(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationCourse/Assigned/SelectList/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CourseCompletion>>(res);
            return data;
        }

        public async Task<List<CourseCompletion>> CompletionUnassignedCourses(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationCourse/Unassigned/SelectList/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CourseCompletion>>(res);
            return data;
        }

        public async Task<List<ExaminationSlotCompletion>> CompletionExaminationSlots(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationSlot/SelectList/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ExaminationSlotCompletion>>(res);
            return data;
        }

        public async Task<List<SectionCompletion>> CompletionSections(long semesterId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"Section/SelectList/SemesterId={semesterId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SectionCompletion>>(res);
            return data;
        }

        public async Task<List<CampusCompletion>> CompletionCampuses()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Campus/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CampusCompletion>>(res);
            return data;
        }

        public async Task<List<BuildingCompletion>> CompletionBuildings()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Building/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<BuildingCompletion>>(res);
            return data;
        }

        public async Task<List<RoomCompletion>> CompletionRooms()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Room/SelectList");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<RoomCompletion>>(res);
            return data;
        }

        public async Task<List<RoomCompletion>> CompletionAvailableRooms(long examinationSlotId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/AvailableRoom/ExaminationSlotId={examinationSlotId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<RoomCompletion>>(res);
            return data;
        }

        public async Task<List<StudentCompletion>> CompletionStudents(long semesterId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"SeatArrangementResult/Student/SelectList/SemesterId={semesterId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<StudentCompletion>>(res);
            return data;
        }

        public async Task<List<CampusDto>> ApiCampuses()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Campus");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CampusDto>>(res);
            return data;
        }

        public async Task<List<BuildingDto>> ApiBuildings()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Building");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<BuildingDto>>(res);
            return data;
        }

        public async Task<List<BuildingDto>> ApiBuildings(long campusId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"Building/CampusId={campusId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<BuildingDto>>(res);
            return data;
        }

        public async Task<List<RoomDto>> ApiRooms()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Room");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<RoomDto>>(res);
            return data;
        }

        public async Task<List<RoomDto>> ApiRooms(long buildingId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"Room/BuildingId={buildingId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<RoomDto>>(res);
            return data;
        }

        public async Task<List<SemesterDto>> ApiSemesters()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Semester");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SemesterDto>>(res);
            return data;
        }

        public async Task<List<CourseDto>> ApiCourses()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + "Course");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CourseDto>>(res);
            return data;
        }

        public async Task<List<SectionDto>> ApiSections(long courseId, long semesterId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationCourse/GetSection/CourseId={courseId},SemesterId={semesterId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SectionDto>>(res);
            return data;
        }

        public async Task<List<StudentDto>> ApiStudents(long sectionId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationCourse/GetStudent/SectionId={sectionId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<StudentDto>>(res);
            return data;
        }

        public async Task<List<ExaminationCourseDto>> ApiExaminationCourses(long semesterId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"CourseExaminationSlot/SemesterId={semesterId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ExaminationCourseDto>>(res);
            return data;
        }

        public async Task<List<UnassignedCourseDto>> ApiUnassignedCourses(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationCourse/Unassigned/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<UnassignedCourseDto>>(res);
            return data;
        }

        public async Task<List<AssignedCourseDto>> ApiExplore(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/Explore/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<AssignedCourseDto>>(res);
            return data;
        }

        public async Task<List<AssignedCourseDto>> ApiManual(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/Manual/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<AssignedCourseDto>>(res);
            return data;
        }

        public async Task<List<AssignedCourseDto>> ApiAutomate(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/Auto/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<AssignedCourseDto>>(res);
            return data;
        }

        public async Task<List<ExaminationRoomDto>> ApiExaminationRooms(long semesterId, long examinationTypeId, long courseId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/Detail/SemesterId={semesterId},ExaminationTypeId={examinationTypeId},CourseId={courseId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ExaminationRoomDto>>(res);
            return data;
        }

        public async Task<List<ExaminationRoomDto>> ApiExaminationRooms(long examinationSlotId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/ExaminationSlotId={examinationSlotId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ExaminationRoomDto>>(res);
            return data;
        }

        public async Task<List<ExaminationStudentDto>> ApiExaminationStudents(long courseId, long roomId, long examinationSlotId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/Detail/CourseId={courseId},RoomId={roomId},ExaminationSlotId={examinationSlotId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ExaminationStudentDto>>(res);
            return data;
        }

        public async Task<List<ExaminationStudentDto>> ApiExaminationStudents(long examinationRoomId, long examinationSlotId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"SeatArrangementResult/RoomId={examinationRoomId},ExaminationSlotId={examinationSlotId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ExaminationStudentDto>>(res);
            return data;
        }

        public async Task<List<ExaminationSectionDto>> ApiExaminationSections(long semesterId, long courseId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationCourse/SectionList/SemesterId={semesterId},CourseId={courseId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ExaminationSectionDto>>(res);
            Console.WriteLine($"Checking ExaminationSections Result {response.IsSuccessStatusCode}");
            return data;
        }

        public async Task<List<ConflictStudentDto>> ApiConflictStudents(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"SeatArrangementResult/ExamConflicts/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ConflictStudentDto>>(res);
            return data;
        }

        public async Task<List<SeatingRoomDto>> ApiSeatingRooms(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"SeatArrangementResult/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SeatingRoomDto>>(res);
            return data;
        }

        public async Task<List<SeatingStudentDto>> ApiSeatingStudents(long examinationSlotId, long examinationRoomId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"SeatArrangementResult/examinationSlotId={examinationSlotId},ExaminationRoomId={examinationRoomId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SeatingStudentDto>>(res);
            return data;
        }

        public async Task<List<AssignmentLogDto>> ApiAssignmentLogs(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationAssigningLog/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<AssignmentLogDto>>(res);
            return data;
        }

        public async Task<InquiryStudentDto> ApiInquiryStudent(long semesterId, long examinationTypeId, string studentCode)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"Student/SemesterId={semesterId},ExaminationTypeId={examinationTypeId},StudentCode={studentCode}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<InquiryStudentDto>(res);
            return data;
        }

        public async Task<ExaminationUsedRoomDto> ApiExaminationUsedRoom(long semesterId, long examinationTypeId)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(Url + $"ExaminationRoom/AssignedRoomCount/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}");
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ExaminationUsedRoomDto>(res);
            return data;
        }

        public async Task<Response> ApiActivateManual(ManualArrangement manualArrangement)
        {
            using var httpClient = new HttpClient();
            var jsonInString = JsonConvert.SerializeObject(manualArrangement);
            httpClient.BaseAddress = new Uri(Url);
            using var response = await httpClient.PostAsync("ExaminationAssigning/AssignCourse", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Response>(res);
            return data;
        }

        public async Task<Response> ApiActivateAutomate(AutomateArrangement automateArrangement)
        {
            using var httpClient = new HttpClient();
            var jsonInString = JsonConvert.SerializeObject(automateArrangement);
            httpClient.BaseAddress = new Uri(Url);
            using var response = await httpClient.PostAsync("ExaminationAssigning/AssignCourses", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Response>(res);
            return data;
        }

        //Change API to Dissolved with ED
        public async Task<Response> ApiDissolvedCourse(DissolvedCourse dissolvedCourse)
        {
            using var httpClient = new HttpClient();
            var jsonInString = JsonConvert.SerializeObject(dissolvedCourse);
            httpClient.BaseAddress = new Uri(Url);
            using var response = await httpClient.PostAsync("ExaminationRoom/DissolveCourse", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Response>(res);
            return data;
        }

        //Change API to Dissolved with ED
        public async Task<Response> ApiDissolvedCourses(DissolvedCourses dissolvedCourses)
        {
            using var httpClient = new HttpClient();
            var jsonInString = JsonConvert.SerializeObject(dissolvedCourses);
            httpClient.BaseAddress = new Uri(Url);
            using var response = await httpClient.PostAsync("ExaminationRoom/DissolveCourses", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Response>(res);
            return data;
        }
    }
}