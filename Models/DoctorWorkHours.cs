using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Doctor_Appointment.Models
{

  

    //[PrimaryKey(nameof(DoctorID), nameof(WorkHours))]
    public class DoctorWorkHours
    {

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public int ReservationStartTime { get; set; }

        public int ReservationEndTime { get; set; }

        public List<int> WorkHours
        {
            get
            {
                List<int> result = new();
                for (int i = ReservationStartTime; i < ReservationEndTime; i++)
                {
                    result.Add(i);
                }
                return result;
            }
        }
        public IEnumerable<Doctor> AvailableHours { get; set; }
    }

    }

