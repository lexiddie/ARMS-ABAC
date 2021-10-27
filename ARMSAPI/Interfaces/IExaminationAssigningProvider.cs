using ARMSAPI.Models;

namespace ARMSAPI.Interfaces
{
    public interface IExaminationAssigningProvider
    {
        ExaminationAssigningResultViewModel ManualAssigning(ExaminationAssigningViewModel model);
        ExaminationAssigningResultViewModel AutoAssigning(ExaminationAssigningViewModel model);
    }
}