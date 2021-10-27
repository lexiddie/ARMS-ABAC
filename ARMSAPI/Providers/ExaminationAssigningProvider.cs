using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ARMSAPI.Data;
using ARMSAPI.Models.DataModels;
using ARMSAPI.Interfaces;
using ARMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ARMSAPI.Providers
{
    public class ExaminationAssigningProvider : IExaminationAssigningProvider
    {
        protected readonly ApplicationDbContext _db;
        protected readonly IFirebaseProvider _firebaseProvider;
        
        public ExaminationAssigningProvider(ApplicationDbContext db,
                                            IFirebaseProvider firebaseProvider)
        {
            _db = db;
            _firebaseProvider = firebaseProvider;
        }

        public ExaminationAssigningResultViewModel ManualAssigning(ExaminationAssigningViewModel model)
        {
            var examinationRooms = new List<ExaminationRoom>();
            var seatArrangements = new List<SeatArrangementResult>();

            _firebaseProvider.IsRetrieving();

            var examinationSlot = _db.ExaminationSlots.SingleOrDefault(x => x.Id == model.ExaminationSlotId);
            var campusRooms = _db.Rooms.Include(x => x.Building)
                                 .Where(x => model.RoomIds.Contains(x.Id)
                                             && x.Building.CampusId != 0)
                                 .GroupBy(x => x.Building.CampusId)
            .Select(x => new CampusRoomViewModel
                         {
                             CampusId = x.Key,
                             Rooms = x.OrderBy(y => y.Name)
                                      .Select(y => new ExaminationAssigningRoomViewModel
                                                   {
                                                       Id = y.Id,
                                                       Capacity = y.ExamCapacity,
                                                       Rows = y.ExamRows,
                                                       Seats = y.ExamSeatPerRow
                                                   })
                                      .ToList(),
                             SectionStudents = _db.Sections.Include(y => y.SectionDetails)
                                                           .Include(y => y.StudyCourses)
                                                               .ThenInclude(y => y.Student)
                                                           .Where(y => y.CourseId == model.CourseId
                                                                       && y.SemesterId == examinationSlot.SemesterId
                                                                       && y.SeatUsed > 0
                                                                       && y.SectionDetails.Any()
                                                                       && y.SectionDetails.FirstOrDefault().CampusId == x.Key)
                                                           .Select(y => new SectionStudent
                                                                        {
                                                                            Section = y,
                                                                            StudentCodes = y.StudyCourses.Select(z => z.Student)
                                                                                                         .OrderBy(z => z.Code)
                                                                                                         .Select(z => new StudentCodeViewModel
                                                                                                                      {
                                                                                                                          StudentId = z.Id,
                                                                                                                          StudentCode = z.Code
                                                                                                                      })
                                                                                                         .ToList()
                                                                        })
                                                           .ToList()
                         })
            .AsNoTracking()
            .ToList();
            
            _firebaseProvider.IsComputing();
            
            foreach(var campusRoom in campusRooms)
            {
                var roomIndex = 0;
                var sectionIndex = 0;
            
                var bufferRoom = new SeatAssigningViewModel
                                 {
                                     ExaminationSlotId = model.ExaminationSlotId
                                 };
            
                while (roomIndex < campusRoom.Rooms.Count && sectionIndex < campusRoom.SectionStudents.Count)
                {
                    var currentRoom = campusRoom.Rooms[roomIndex];
                    var currentSection = campusRoom.SectionStudents[sectionIndex].Section;
                    var currentStudents = campusRoom.SectionStudents[sectionIndex].StudentCodes;

                    if (currentStudents.Count > currentRoom.Capacity)
                    {
                        examinationRooms.Add(new ExaminationRoom
                                            {
                                                SectionId = currentSection.Id,
                                                CourseId = currentSection.CourseId,
                                                ExaminationSlotId = model.ExaminationSlotId,
                                                RoomId = currentRoom.Id,
                                                StartStudentCode = currentStudents.First().StudentCode,
                                                EndStudentCode = currentStudents[currentRoom.Capacity].StudentCode,
                                                TotalSeatUsed = currentRoom.Capacity,
                                                IsAuto = false
                                            });
            
                        bufferRoom.CourseId = currentSection.CourseId;
                        bufferRoom.Room = currentRoom;
                        bufferRoom.Students.AddRange(currentStudents.GetRange(0, currentRoom.Capacity)
                                                                      .Select(x => new StudentSectionViewModel
                                                                                   {
                                                                                       StudentId = x.StudentId,
                                                                                       SectionId = currentSection.Id
                                                                                })
                                                                      .ToList());
                        ManuallyAssignStudentsToSeats(seatArrangements, bufferRoom);
                        ++ roomIndex;
                        currentStudents.RemoveRange(0, currentRoom.Capacity);
                    }
                    else
                    {
                        examinationRooms.Add(new ExaminationRoom
                                            {
                                                SectionId = currentSection.Id,
                                                CourseId = currentSection.CourseId,
                                                ExaminationSlotId = model.ExaminationSlotId,
                                                RoomId = currentRoom.Id,
                                                StartStudentCode = currentStudents.First().StudentCode,
                                                EndStudentCode = currentStudents.Last().StudentCode,
                                                TotalSeatUsed = currentStudents.Count,
                                                IsAuto = false
                                            });
                        
                        if (currentStudents.Count < currentRoom.Capacity)
                        {
                            bufferRoom.Students.AddRange(currentStudents.Select(x => new StudentSectionViewModel
                                                                                    {
                                                                                        StudentId = x.StudentId,
                                                                                        SectionId = currentSection.Id
                                                                                    })
                                                                        .ToList());
                            ++ sectionIndex;
                            currentRoom.Capacity -= currentStudents.Count;
            
                            if (sectionIndex == campusRoom.SectionStudents.Count)
                            {
                                bufferRoom.CourseId = currentSection.CourseId;
                                bufferRoom.Room = currentRoom;
                                ManuallyAssignStudentsToSeats(seatArrangements, bufferRoom);
                                ++ roomIndex;
                            }
                        }
                        else
                        {
                            bufferRoom.CourseId = currentSection.CourseId;
                            bufferRoom.Room = currentRoom;
                            bufferRoom.Students.AddRange(currentStudents.Select(x => new StudentSectionViewModel
                                                                                    {
                                                                                        StudentId = x.StudentId,
                                                                                        SectionId = currentSection.Id
                                                                                    })
                                                                        .ToList());
                            ManuallyAssignStudentsToSeats(seatArrangements, bufferRoom);
                            ++ sectionIndex;
                            ++ roomIndex;
                        }
                    }
                }
            }
                                     
            return new ExaminationAssigningResultViewModel
                   {
                       ExaminationRooms = examinationRooms,
                       SeatArrangementResults = seatArrangements
                   };
        }

        public ExaminationAssigningResultViewModel AutoAssigning(ExaminationAssigningViewModel model)
        {
            _firebaseProvider.IsRetrieving();

            var assignedSections = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                       .Where(x => x.ExaminationSlot.SemesterId == model.SemesterId
                                                                   && x.ExaminationSlot.ExaminationTypeId == model.ExaminationTypeId)
                                                       .Select(x => x.SectionId)
                                                       .Distinct()
                                                       .ToList();

            var required = _db.CourseExaminationSlots.Where(x => x.ExaminationSlot.SemesterId == model.SemesterId
                                                                 && x.ExaminationSlot.ExaminationTypeId == model.ExaminationTypeId)
                                                     .Join(_db.Sections
                                                             .Include(x => x.SectionDetails)
                                                             .Include(x => x.StudyCourses)
                                                             .ThenInclude(x => x.Student)
                                                             .Where(x => x.SemesterId == model.SemesterId
                                                                                   && x.SeatUsed > 0
                                                                                   && x.SectionDetails.Any()
                                                                                   && !assignedSections.Contains(x.Id)),
                                                           courseSlot => courseSlot.CourseId,
                                                           section => section.CourseId,
                                                           (courseSlot, section) => new SectionExaminationSlot
                                                           {
                                                               ExaminationSlotId = courseSlot.ExaminationSlotId,
                                                               Section = section
                                                           })
                                                     .ToList();

            var roomSlotIds = _db.ExaminationRooms.Where(x => x.ExaminationSlot.SemesterId == model.SemesterId
                                                              && x.ExaminationSlot.ExaminationTypeId == model.ExaminationTypeId)
                                                  .Select(x => x.RoomId)
                                                  .Distinct()
                                                  .ToList();
            
            var result = required
                         .GroupBy(x => new { x.ExaminationSlotId, x.Section.SectionDetails.FirstOrDefault().CampusId })
                         .Select(x => new SectionSlotViewModel
                                      {
                                          ExaminationSlotId = x.Key.ExaminationSlotId,
                                          SingleSectionStudents = x.GroupBy(y => y.Section.CourseId)
                                                                   .Where(y => y.Count() == 1)
                                                                   .SelectMany(y => y.Select(z => new SectionStudent
                                                                                                  {
                                                                                                      Section = z.Section,
                                                                                                      StudentCodes = z.Section.StudyCourses.Select(a => a.Student)
                                                                                                                                           .OrderBy(a => a.Code)
                                                                                                                                           .Select(a => new StudentCodeViewModel
                                                                                                                                                        {
                                                                                                                                                            StudentId = a.Id,
                                                                                                                                                            StudentCode = a.Code
                                                                                                                                                        })
                                                                                                                                           .ToList()
                                                                                                  }))
                                                                   .OrderByDescending(z => z.StudentCodes.Count)
                                                                   .ToList(),
                                          SectionStudents = x.GroupBy(y => y.Section.CourseId)
                                                             .Where(y => y.Count() > 1)
                                                             .SelectMany(y => y.Select(z => new SectionStudent
                                                                                             {
                                                                                                 Section = z.Section,
                                                                                                 StudentCodes = z.Section.StudyCourses.Select(a => a.Student)
                                                                                                                                      .OrderBy(a => a.Code)
                                                                                                                                      .Select(a => new StudentCodeViewModel
                                                                                                                                                   {
                                                                                                                                                       StudentId = a.Id,
                                                                                                                                                       StudentCode = a.Code
                                                                                                                                                   })
                                                                                                                                      .ToList()
                                                                                             }))
                                                             .OrderBy(z => z.Section.CourseId)
                                                             .ThenBy(z => z.Section.Number)
                                                             .ToList(),
                                          Rooms = _db.Rooms.Include(y => y.Building)
                                                           .Where(y => y.IsAllowAutoAssign
                                                                       && !roomSlotIds.Contains(y.Id)
                                                                       && y.Building.CampusId == x.Key.CampusId)
                                                           .OrderBy(y => y.Name)
                                                           .Select(y => new ExaminationAssigningRoomViewModel
                                                                        {
                                                                            Id = y.Id,
                                                                            CampusId = y.Building.CampusId,
                                                                            Capacity = y.ExamCapacity,
                                                                            Rows = y.ExamRows,
                                                                            Seats = y.ExamSeatPerRow
                                                                        })
                                                           .ToList()
                                      })
                         .ToList();

            var examinationRooms = new List<ExaminationRoom>();
            var seatArrangements = new List<SeatArrangementResult>();
            var isLast = false;

            _firebaseProvider.IsComputing();
            var stopwatch = Stopwatch.StartNew();
            
            foreach(var item in result)
            {
                var roomIndex = 0;
                var sectionIndex = 0;
                var bufferRoom = new SeatAssigningViewModel
                                 {
                                     ExaminationSlotId = item.ExaminationSlotId
                                 };
            
                while (roomIndex < item.Rooms.Count && sectionIndex < item.SectionStudents.Count)
                {
                    var currentRoom = item.Rooms[roomIndex];
                    var currentSection = item.SectionStudents[sectionIndex].Section;
                    var currentStudent = item.SectionStudents[sectionIndex].StudentCodes;
            
                    if (currentStudent.Count < currentRoom.Capacity)
                    {
                        examinationRooms.Add(new ExaminationRoom
                                             {
                                                 SectionId = currentSection.Id,
                                                 CourseId = currentSection.CourseId,
                                                 ExaminationSlotId = item.ExaminationSlotId,
                                                 RoomId = currentRoom.Id,
                                                 StartStudentCode = currentStudent.First().StudentCode,
                                                 EndStudentCode = currentStudent.Last().StudentCode,
                                                 TotalSeatUsed = currentStudent.Count,
                                                 IsAuto = true
                                             });
                        bufferRoom.SectionStudents.Add(item.SectionStudents[sectionIndex]);
            
                        if (isLast)
                        {
                            bufferRoom.Room = currentRoom;
                            AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                            ++ roomIndex;
                            isLast = false;
                        }
                        else if (sectionIndex < item.SectionStudents.Count - 1 && currentSection.CourseId == item.SectionStudents[sectionIndex + 1].Section.CourseId)
                        {
                            currentRoom.Capacity -= currentStudent.Count;
                        }
                        else 
                        {
                            currentRoom.Capacity -= currentStudent.Count;
            
                            var filledNumber = 0;
            
                            if (currentStudent.Count <= currentRoom.Seats) // 1 row
                            {
                                filledNumber = (currentRoom.Rows - 1);
                            }
                            else if (currentRoom.Capacity <= currentRoom.Seats) // 1 row
                            {
                                filledNumber = 1;
                            }
                            else if (currentRoom.Rows / 2 == Math.Ceiling((double) currentStudent.Count / currentRoom.Seats)) // equal
                            {
                                filledNumber = currentRoom.Rows / 2;
                            }
                            else if ((currentRoom.Rows / 2.0) - Math.Ceiling((double) currentStudent.Count / currentRoom.Seats) == 0.5) // I 
                            {
                                filledNumber = (int) Math.Ceiling(currentRoom.Rows / 2.0);
                            }
                            else if ((currentRoom.Rows / 2.0) - Math.Ceiling((double) currentStudent.Count / currentRoom.Seats) == -0.5) // I
                            {
                                filledNumber = (int) Math.Floor(currentRoom.Rows / 2.0);
                            }
                            else if (Math.Ceiling((double) currentStudent.Count / currentRoom.Seats) < currentRoom.Rows / 2) // I with rest
                            {
                                filledNumber = ((int) Math.Ceiling(currentStudent.Count / 2.0) + 1);
                            }
            
                            var filledSection = filledNumber == 0 ? null
                                                                  : FindBestFit(item.SingleSectionStudents, filledNumber, currentRoom.Seats);
            
                            if (filledSection != null)
                            {
                                examinationRooms.Add(new ExaminationRoom
                                                     {
                                                         SectionId = filledSection.Section.Id,
                                                         CourseId = filledSection.Section.CourseId,
                                                         ExaminationSlotId = item.ExaminationSlotId,
                                                         RoomId = currentRoom.Id,
                                                         StartStudentCode = filledSection.StudentCodes.First().StudentCode,
                                                         EndStudentCode = filledSection.StudentCodes.Last().StudentCode,
                                                         TotalSeatUsed = filledSection.StudentCodes.Count,
                                                         IsAuto = true
                                                     });
                                bufferRoom.Room = currentRoom;
                                bufferRoom.SectionStudents.Add(filledSection);
                                AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                ++ roomIndex;
                            }
                            else if (filledNumber == 0)
                            {
                                bufferRoom.Room = currentRoom;
                                AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                ++ roomIndex;
                            }
                            else if (sectionIndex == item.SectionStudents.Count - 1) 
                            {
                                bufferRoom.Room = currentRoom;
                                AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                ++ roomIndex;                            
                            }
                            else
                            {
                                currentRoom.Capacity = filledNumber * currentRoom.Seats;
                                isLast = true;
                            }
                        }
                        ++ sectionIndex;
                    }
                    else
                    {
                        if (isLast)
                        {
                            isLast = false;
                        }
            
                        if (currentStudent.Count > currentRoom.Capacity)
                        {
                            examinationRooms.Add(new ExaminationRoom
                                                {
                                                    SectionId = currentSection.Id,
                                                    CourseId = currentSection.CourseId,
                                                    ExaminationSlotId = item.ExaminationSlotId,
                                                    RoomId = currentRoom.Id,
                                                    StartStudentCode = currentStudent.First().StudentCode,
                                                    EndStudentCode = currentStudent[currentRoom.Capacity].StudentCode,
                                                    TotalSeatUsed = currentRoom.Capacity,
                                                    IsAuto = true
                                                });
                            bufferRoom.Room = currentRoom;
                            var rangedSectionStudent = new SectionStudent
                            {
                                Section = currentSection,
                                StudentCodes = item.SectionStudents[sectionIndex].StudentCodes.GetRange(0, currentRoom.Capacity)
                            };
                            bufferRoom.SectionStudents.Add(rangedSectionStudent);
                            AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                            item.SectionStudents[sectionIndex].StudentCodes.RemoveRange(0, currentRoom.Capacity);
                            
                            ++ roomIndex;
                        }
                        else
                        {
                            examinationRooms.Add(new ExaminationRoom
                                                {
                                                    SectionId = currentSection.Id,
                                                    CourseId = currentSection.CourseId,
                                                    ExaminationSlotId = item.ExaminationSlotId,
                                                    RoomId = currentRoom.Id,
                                                    StartStudentCode = currentStudent.First().StudentCode,
                                                    EndStudentCode = currentStudent.Last().StudentCode,
                                                    TotalSeatUsed = currentStudent.Count,
                                                    IsAuto = true
                                                });
            
                            bufferRoom.Room = currentRoom;
                            bufferRoom.SectionStudents.Add(item.SectionStudents[sectionIndex]);
                            AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                            ++ roomIndex;
                            ++ sectionIndex;
                        }
                    }
                }
            
                if (item.SingleSectionStudents.Any())
                {
                    sectionIndex = 0;
                    while (roomIndex < item.Rooms.Count && sectionIndex < item.SingleSectionStudents.Count)
                    {
                        var currentRoom = item.Rooms[roomIndex];
                        var currentSection = item.SingleSectionStudents[sectionIndex].Section;
                        var currentStudent = item.SingleSectionStudents[sectionIndex].StudentCodes;
                        
                        if (currentStudent.Count < currentRoom.Capacity)
                        {
                            examinationRooms.Add(new ExaminationRoom
                                                {
                                                    SectionId = currentSection.Id,
                                                    CourseId = currentSection.CourseId,
                                                    ExaminationSlotId = item.ExaminationSlotId,
                                                    RoomId = currentRoom.Id,
                                                    StartStudentCode = currentStudent.First().StudentCode,
                                                    EndStudentCode = currentStudent.Last().StudentCode,
                                                    TotalSeatUsed = currentStudent.Count,
                                                    IsAuto = true
                                                });
                            bufferRoom.SectionStudents.Add(item.SingleSectionStudents[sectionIndex]);
            
                            if (isLast)
                            {
                                bufferRoom.Room = currentRoom;
                                AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                ++ roomIndex;
                                isLast = false;
                            }
                            else if (sectionIndex < item.SingleSectionStudents.Count - 1)
                            {
                                currentRoom.Capacity -= currentStudent.Count;
            
                                var filledNumber = 0;
            
                                if (currentStudent.Count <= currentRoom.Seats) // 1 row
                                {
                                    filledNumber = (currentRoom.Rows - 1);
                                }
                                else if (currentRoom.Capacity <= currentRoom.Seats) // 1 row
                                {
                                    filledNumber = 1;
                                }
                                else if (currentRoom.Rows / 2 == Math.Ceiling((double) currentStudent.Count / currentRoom.Seats)) // equal
                                {
                                    filledNumber = currentRoom.Rows / 2;
                                }
                                else if ((currentRoom.Rows / 2.0) - Math.Ceiling((double) currentStudent.Count / currentRoom.Seats) == 0.5) // I 
                                {
                                    filledNumber = (int) Math.Ceiling(currentRoom.Rows / 2.0);
                                }
                                else if ((currentRoom.Rows / 2.0) - Math.Ceiling((double) currentStudent.Count / currentRoom.Seats) == -0.5) // I
                                {
                                    filledNumber = (int) Math.Floor(currentRoom.Rows / 2.0);
                                }
                                else if (Math.Ceiling((double) currentStudent.Count / currentRoom.Seats) < currentRoom.Rows / 2) // I with rest
                                {
                                    filledNumber = ((int) Math.Ceiling(currentStudent.Count / 2.0) + 1);
                                }
            
                                var filledSection = filledNumber == 0 ? null
                                                                    : FindBestFit(item.SingleSectionStudents, filledNumber, currentRoom.Seats, sectionIndex + 1);
            
                                if (filledSection != null)
                                {
                                    examinationRooms.Add(new ExaminationRoom
                                                        {
                                                            SectionId = filledSection.Section.Id,
                                                            CourseId = filledSection.Section.CourseId,
                                                            ExaminationSlotId = item.ExaminationSlotId,
                                                            RoomId = currentRoom.Id,
                                                            StartStudentCode = filledSection.StudentCodes.First().StudentCode,
                                                            EndStudentCode = filledSection.StudentCodes.Last().StudentCode,
                                                            TotalSeatUsed = filledSection.StudentCodes.Count,
                                                            IsAuto = true
                                                        });
                                    bufferRoom.Room = currentRoom;
                                    bufferRoom.SectionStudents.Add(filledSection);
                                    AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                    ++ roomIndex;
                                }
                                else if (filledNumber == 0)
                                {
                                    bufferRoom.Room = currentRoom;
                                    AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                    ++ roomIndex;
                                }
                                else
                                {
                                    currentRoom.Capacity = filledNumber * currentRoom.Seats;
                                    isLast = true;
                                }
                            }
                            else 
                            {
                                bufferRoom.Room = currentRoom;
                                AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                ++ roomIndex;
                            }
            
                            ++ sectionIndex;
                        } 
                        else
                        {
                            if (isLast)
                            {
                                isLast = false;
                            }
            
                            if (currentStudent.Count > currentRoom.Capacity)
                            {
                                examinationRooms.Add(new ExaminationRoom
                                                    {
                                                        SectionId = currentSection.Id,
                                                        CourseId = currentSection.CourseId,
                                                        ExaminationSlotId = item.ExaminationSlotId,
                                                        RoomId = currentRoom.Id,
                                                        StartStudentCode = currentStudent.First().StudentCode,
                                                        EndStudentCode = currentStudent[currentRoom.Capacity].StudentCode,
                                                        TotalSeatUsed = currentRoom.Capacity,
                                                        IsAuto = true
                                                    });
            
                                bufferRoom.Room = currentRoom;
                                var rangedSectionStudent = new SectionStudent
                                                           {
                                                               Section = currentSection,
                                                               StudentCodes = item.SingleSectionStudents[sectionIndex].StudentCodes.GetRange(0, currentRoom.Capacity)
                                                           };
                                bufferRoom.SectionStudents.Add(rangedSectionStudent);
                                AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                item.SingleSectionStudents[sectionIndex].StudentCodes.RemoveRange(0, currentRoom.Capacity);
                                
                                ++ roomIndex;
                            }
                            else
                            {
                                examinationRooms.Add(new ExaminationRoom
                                                    {
                                                        SectionId = currentSection.Id,
                                                        CourseId = currentSection.CourseId,
                                                        ExaminationSlotId = item.ExaminationSlotId,
                                                        RoomId = currentRoom.Id,
                                                        StartStudentCode = currentStudent.First().StudentCode,
                                                        EndStudentCode = currentStudent.Last().StudentCode,
                                                        TotalSeatUsed = currentStudent.Count,
                                                        IsAuto = true
                                                    });
            
                                bufferRoom.Room = currentRoom;
                                bufferRoom.SectionStudents.Add(item.SingleSectionStudents[sectionIndex]);
                                AutoAssignStudentToSeats(seatArrangements, bufferRoom);
                                ++ roomIndex;
                                ++ sectionIndex;
                            }
                        }
                    }
                }
            }

            // stopwatch.Stop();
            // using (var ws = new StreamWriter("C:\\All\\Work\\Senior1\\log.txt", true))
            // {
            //     ws.WriteLine(stopwatch.Elapsed.ToString());
            // }
            
            return new ExaminationAssigningResultViewModel
                       {
                           ExaminationRooms = examinationRooms,
                           SeatArrangementResults = seatArrangements
                       };
        }

        private void AutoAssignStudentToSeats(List<SeatArrangementResult> seats, SeatAssigningViewModel model)
        {
            var groupedCourse = model.SectionStudents.GroupBy(x => x.Section.CourseId)
                                     .OrderBy(x => x.Sum(y => y.StudentCodes.Count()))
                                     .ToList();

            if (groupedCourse.Count == 1)
            {
                var sections = groupedCourse[0].Select(x => x).ToList();

                var row = 1;
                var seat = 1;
                
                foreach(var section in sections)
                {
                    foreach(var student in section.StudentCodes)
                    {
                        seats.Add(new SeatArrangementResult
                                  {
                                      StudentId = student.StudentId,
                                      SectionId = section.Section.Id,
                                      CourseId = section.Section.CourseId,
                                      ExaminationSlotId = model.ExaminationSlotId,
                                      RoomId = model.Room.Id,
                                      SeatNumber = seat ++,
                                      RowNumber = row,
                                      IsAuto = true
                                  });
                        
                        if (seat > model.Room.Seats)
                        {
                            ++ row;
                            seat = 1;
                        }
                    }
                }
            }
            else
            {
                var lessCourse = groupedCourse[0].Key;
                var moreCourse = groupedCourse[1].Key;
                var lessSectionStudent = groupedCourse[0].Select(x => x).ToList();
                var moreSectionStudent = groupedCourse[1].Select(x => x).ToList();
                var lessStudents = lessSectionStudent.SelectMany(x => x.StudentCodes);

                if (lessStudents.Count() <= model.Room.Seats)
                {
                    var seat = 1;

                    foreach(var section in lessSectionStudent)
                    {
                        foreach(var student in section.StudentCodes)
                        {
                            seats.Add(new SeatArrangementResult
                                      {
                                          StudentId = student.StudentId,
                                          SectionId = section.Section.Id,
                                          CourseId = lessCourse,
                                          ExaminationSlotId = model.ExaminationSlotId,
                                          RoomId = model.Room.Id,
                                          SeatNumber = seat++,
                                          RowNumber = 1,
                                          IsAuto = true
                                      });
                        }
                    }

                    seat = 1;
                    var row = 2;

                    foreach(var section in moreSectionStudent)
                    {
                        foreach(var student in section.StudentCodes)
                        {
                            seats.Add(new SeatArrangementResult
                                      {
                                          StudentId = student.StudentId,
                                          SectionId = section.Section.Id,
                                          CourseId = moreCourse,
                                          ExaminationSlotId = model.ExaminationSlotId,
                                          RoomId = model.Room.Id,
                                          SeatNumber = seat ++,
                                          RowNumber = row,
                                          IsAuto = true
                                      });

                            if (seat > model.Room.Seats)
                            {
                                ++ row;
                                seat = 1;
                            }
                        }
                    }
                }
                else // I Style
                {
                    var lessStudentSection = lessSectionStudent.SelectMany(x => x.StudentCodes.Select(y => new StudentSectionViewModel
                                                                                                           {
                                                                                                               StudentId = y.StudentId,
                                                                                                               SectionId = x.Section.Id
                                                                                                           }))
                                                               .ToList();
                    
                    var moreStudentSection = moreSectionStudent.SelectMany(x => x.StudentCodes.Select(y => new StudentSectionViewModel
                                                                                                           {
                                                                                                               StudentId = y.StudentId,
                                                                                                               SectionId = x.Section.Id
                                                                                                           }))
                                                               .ToList();


                    var lessIndex = 0;
                    var moreIndex = 0;
                    var seat = 1;
                    var row = 1;

                    if (lessCourse == 33 || moreCourse == 33)
                    {
                        var a = 0;
                    }

                    // for (var i = 1; i <= lessStudentSection.Count + moreStudentSection.Count; ++i)
                    while (lessIndex < lessStudentSection.Count || moreIndex < moreStudentSection.Count)
                    {
                        if (row % 2 == 0 && lessIndex < lessStudentSection.Count) // odd row and can assign
                        {
                            seats.Add(new SeatArrangementResult
                                      {
                                          StudentId = lessStudentSection[lessIndex].StudentId,
                                          SectionId = lessStudentSection[lessIndex].SectionId,
                                          CourseId = lessCourse,
                                          ExaminationSlotId = model.ExaminationSlotId,
                                          RoomId = model.Room.Id,
                                          RowNumber = row,
                                          SeatNumber = seat,
                                          IsAuto = true
                                      });

                            ++ lessIndex;
                        } 
                        else if (row % 2 != 0 && moreIndex < moreStudentSection.Count)// even row
                        {
                            seats.Add(new SeatArrangementResult
                                      {
                                          StudentId = moreStudentSection[moreIndex].StudentId,
                                          SectionId = moreStudentSection[moreIndex].SectionId,
                                          CourseId = moreCourse,
                                          ExaminationSlotId = model.ExaminationSlotId,
                                          RoomId = model.Room.Id,
                                          RowNumber = row,
                                          SeatNumber = seat,
                                          IsAuto = true
                                      });

                            ++ moreIndex;
                        }

                        ++ seat;
                        
                        if (seat > model.Room.Seats) 
                        {
                            ++ row;
                            seat = 1; 
                        }
                    }
                }
            }
            
            model.SectionStudents.Clear();
        }

        private void ManuallyAssignStudentsToSeats(List<SeatArrangementResult> seats, SeatAssigningViewModel model)
        {
            var row = 1;
            var seat = 1;

            foreach(var student in model.Students)
            {
                seats.Add(new SeatArrangementResult
                          {
                              StudentId = student.StudentId,
                              SectionId = student.SectionId,
                              CourseId = model.CourseId,
                              ExaminationSlotId = model.ExaminationSlotId,
                              RoomId = model.Room.Id,
                              SeatNumber = seat ++,
                              RowNumber = row,
                              IsAuto = false
                          });

                if (seat > model.Room.Seats)
                {
                    ++ row;
                    seat = 1;
                }
            }

            model.Students.Clear();
        }

        private SectionStudent FindBestFit(List<SectionStudent> singleSections, int numberOrRow, int seatPerRow, int startIndex = 0)
        {
            var numberNeeded = numberOrRow * seatPerRow;
            for (var i = startIndex; i < singleSections.Count; ++i)
            {
                var bufNumber = singleSections[i].StudentCodes.Count / seatPerRow;
                if (bufNumber <= numberOrRow && bufNumber > numberOrRow - 1 && singleSections[i].StudentCodes.Count <= numberNeeded)
                {
                    var bufSection = singleSections[i];
                    singleSections.RemoveAt(i);
                    return bufSection;
                }
            }

            return null;
        }
    }
}