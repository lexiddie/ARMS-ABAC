using ARMSAPI.Data;
using System.Linq;
using ARMSAPI.Interfaces;
using ARMSAPI.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ARMSAPI.Providers
{
    public class ExaminationRoomProvider : IExaminationRoomProvider
    {
        protected readonly ApplicationDbContext _db;

        public ExaminationRoomProvider(ApplicationDbContext db)
        {
            _db = db;
        }

        public (int, int) RemoveAllManualAssign(long semesterId, long examinationTypeId)
        {
            var examRows = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                            && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                            && !x.IsAuto);
            
            var seatRows = _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
                                                     .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                 && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                                 && !x.IsAuto);

            var examCount = examRows.Count();
            var seatCount = seatRows.Count();

            using (var context = new ApplicationDbContextChild())
            {
                context.BulkDelete<ExaminationRoom>(examRows);
                context.BulkDelete<SeatArrangementResult>(seatRows);
            }

            return (examCount, seatCount);
        }

        public (int, int) RemoveAllAutoAssign(long semesterId, long examinationTypeId)
        {
            var examRows = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                            && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                            && x.IsAuto);
            
            var seatRows = _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
                                                     .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                 && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                                 && x.IsAuto);

            var examCount = examRows.Count();
            var seatCount = seatRows.Count();

            using (var context = new ApplicationDbContextChild())
            {
                context.BulkDelete<ExaminationRoom>(examRows);
                context.BulkDelete<SeatArrangementResult>(seatRows);
            }

            return (examCount, seatCount);
        }

        public (int, int) RemoveAll(long semesterId, long examinationTypeId)
        {
            var examRows = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                            && x.ExaminationSlot.ExaminationTypeId == examinationTypeId);
            
            var seatRows = _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
                                                     .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                 && x.ExaminationSlot.ExaminationTypeId == examinationTypeId);

            var examCount = examRows.Count();
            var seatCount = seatRows.Count();

            using (var context = new ApplicationDbContextChild())
            {
                context.BulkDelete<ExaminationRoom>(examRows);
                context.BulkDelete<SeatArrangementResult>(seatRows);
            }

            return (examCount, seatCount);
        }
    }
}