using System;
using System.Linq;
using ARMSAPI.Data;
using ARMSAPI.Models;
using ARMSAPI.Interfaces;
using ARMSAPI.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace ARMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class ExaminationAssigningController : BaseController
    {
        protected readonly IExaminationAssigningProvider _examinationAssigningProvider;
        protected readonly ILogProvider _logProvider;
        protected readonly IFirebaseProvider _firebaseProvider;

        public ExaminationAssigningController(ApplicationDbContext db,
                                              ILogProvider logProvider,
                                              IExaminationAssigningProvider examinationAssigningProvider,
                                              IFirebaseProvider firebaseProvider) : base(db)
        {
            _examinationAssigningProvider = examinationAssigningProvider;
            _logProvider = logProvider;
            _firebaseProvider = firebaseProvider;
        }

        [HttpPost("AssignCourse")]
        public IActionResult AssignCourse([FromBody] ExaminationAssigningViewModel model)
        {
            _firebaseProvider.IsProcessing();
            var isExisted = _db.ExaminationRooms.Any(x => x.CourseId == model.CourseId
                                                          && x.ExaminationSlotId == model.ExaminationSlotId);

            if (isExisted)
            {
                _firebaseProvider.IsError(Message.ExaminationCourseExisted);
                return Ok(new
                {
                    IsSuccess = false,
                    Response = Message.ExaminationCourseExisted
                });
            }

            try
            {
            var results = _examinationAssigningProvider.ManualAssigning(model);
            var courseName = _db.Courses.SingleOrDefault(x => x.Id == model.CourseId).CodeAndName;

            _firebaseProvider.IsUpdating();

            var now = DateTime.Now;
            results.ExaminationRooms.ForEach(x =>
            {
                x.CreatedAt = now;
                x.UpdatedAt = now;
                x.CreatedBy = model.User;
                x.UpdatedBy = model.User;
            });

            results.SeatArrangementResults.ForEach(x =>
            {
                x.CreatedAt = now;
                x.UpdatedAt = now;
                x.CreatedBy = model.User;
                x.UpdatedBy = model.User;
            });

            using (var context = new ApplicationDbContextChild())
            {
                context.BulkInsert<ExaminationRoom>(results.ExaminationRooms);
                context.BulkInsert<SeatArrangementResult>(results.SeatArrangementResults);
            }

            var examinationSlot = _db.ExaminationSlots.SingleOrDefault(x => x.Id == model.ExaminationSlotId);
            _logProvider.RecordManualAssign(courseName, model.User, examinationSlot.SemesterId, examinationSlot.ExaminationTypeId);

            _firebaseProvider.Finish();
            return Ok(new
            {
                IsSuccess = true,
                Response = new
                {
                    ExaminationRoom = results.ExaminationRooms.Count,
                    ExaminationSeat = results.SeatArrangementResults.Count
                }
            });
            }
            catch
            {
                _firebaseProvider.IsError(Message.ErrorOccurred);
                return StatusCode(500, new 
                                       {
                                           IsSuccess = false,
                                           Response = Message.ErrorOccurred
                                       });
            }
        }

        [HttpPost("AssignCourses")]
        public IActionResult AssignCourses([FromBody] ExaminationAssigningViewModel model)
        {
            try
            {
                _firebaseProvider.IsAutomate();
                _firebaseProvider.IsProcessing();
                var results = _examinationAssigningProvider.AutoAssigning(model);

                if (results.ExaminationRooms.Count == 0 && results.SeatArrangementResults.Count == 0)
                {
                    _firebaseProvider.IsError(Message.NoCourseToAssign);

                    return Ok(new
                    {
                        IsSuccess = false,
                        Response = Message.NoCourseToAssign
                    });
                }

                _firebaseProvider.IsUpdating();

                var now = DateTime.Now;
                results.ExaminationRooms.ForEach(x =>
                {
                    x.CreatedAt = now;
                    x.UpdatedAt = now;
                    x.CreatedBy = model.User;
                    x.UpdatedBy = model.User;
                });

                results.SeatArrangementResults.ForEach(x =>
                {
                    x.CreatedAt = now;
                    x.UpdatedAt = now;
                    x.CreatedBy = model.User;
                    x.UpdatedBy = model.User;
                });

                using (var context = new ApplicationDbContextChild())
                {
                    context.BulkInsert<ExaminationRoom>(results.ExaminationRooms);
                    context.BulkInsert<SeatArrangementResult>(results.SeatArrangementResults);
                }

                _logProvider.RecordAutoAssign(model.User, model.SemesterId, model.ExaminationTypeId);
                _firebaseProvider.Finish();
                return Ok(new
                {
                    IsSuccess = true,
                    Response = new
                    {
                        ExaminationRoom = results.ExaminationRooms.Count,
                        ExaminationSeat = results.SeatArrangementResults.Count
                    }
                });
            }
            catch
            {
                _firebaseProvider.IsError(Message.ErrorOccurred);
                return StatusCode(500, new
                {
                    IsSuccess = false,
                    Response = Message.ErrorOccurred
                });
            }
        }
    }
}