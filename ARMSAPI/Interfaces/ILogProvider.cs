namespace ARMSAPI.Interfaces
{
    public interface ILogProvider
    {
        bool RecordExaminationAssigning(string logType, string activityType, string user, long semesterId, long examinationTypeId);
        bool RecordManualAssign(string course, string user, long semesterId, long examinationTypeId);
        bool RecordAutoAssign(string user, long semesterId, long examinationTypeId);
        bool RecordDissolved(int code, string user, long semesterId, long examinationTypeId);
        bool RecordDissolved(string course, string user, long semesterId, long examinationTypeId);
    }
}