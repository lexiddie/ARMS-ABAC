namespace ARMSAPI.Interfaces
{
    public interface IExaminationRoomProvider
    {
        (int, int) RemoveAllManualAssign(long semesterId, long examinationTypeId);
        (int, int) RemoveAllAutoAssign(long semesterId, long examinationTypeId);
        (int, int) RemoveAll(long semesterId, long examinationTypeId);
    }
}