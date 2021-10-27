using System;
using Microsoft.AspNetCore.Mvc;

namespace ARMSAPI.Models
{
    public class Message
    {
        public const string ErrorOccurred = "Error occurred while executing tasks.";
        public const string DuplicatedCode = "Code Already Existed.";
        public const string CreateSuccessful = "Create Successful.";
        public const string EditSuccessful = "Edit Successful.";
        public const string DeleteSuccessful = "Delete Successful.";
        public const string UnableToCreate = "Unable to Create.";
        public const string UnableToEdit = "Unable to Edit.";
        public const string ModelError = "Unable to Bind Model.";
        public const string UnableToDelete = "Unable to Delete.";
        public const string InvalidDissolvingCode = "Invalid dissolve code (Can only be 1, 2 or 3).";
        public const string NoDataToDissolve = "No Data to dissolve.";
        public const string ExaminationCourseExisted = "You already assigned this course.";
        public const string NoCourseToAssign = "No Course to be assigned.";
        public const string  StudentNotFound = "Student Not Found.";
        public static string CreatedByAutoManual(bool isAuto, string user)
        {
            return isAuto ? $"Automate by {user}"
                          : $"Manual by {user}";
        }
        public static string AssigningCompleted(string assignedCourse = null)
        {
            if (String.IsNullOrEmpty(assignedCourse))
            {
                return "Assigned All Courses.";
            }
            else 
            {
                return $"Assigned {assignedCourse}.";
            }
        }

        public static string DissolvingCompleted(string dissolvedCourse = null)
        {
            if (String.IsNullOrEmpty(dissolvedCourse))
            {
                return "Dissolved All Examination Courses.";
            }
            else 
            {
                return $"Dissolved {dissolvedCourse}.";
            }
        }

        public const string ManualAssign = "Manual Assignment";
        public const string AutoAssign = "Automate Assignment";
        public const string DissolvedCourse = "Dissolved Course";
        public const string DissolvedCourses = "Dissolved Courses";
        public const string DissolvedAllManualCourses = "Dissolved All Manual Assigned Courses";
        public const string DissolvedAllAutoCourses = "Dissolved All Automate Assigned Courses";
    }
}