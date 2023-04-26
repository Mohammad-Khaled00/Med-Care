using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Doctor_Appointment.Models
{

    /*    public struct DayHours
        {
            List<int> Hours;
            int start;
            int end;

            public DayHours(int start, int end)
            {
                this.start = start;
                this.end = end;
                for (int i = start; i < end; i++)
                {
                    Hours.Add(i);
                }
            }
        }*/

    [PrimaryKey(nameof(DoctorID), nameof(WorkHours))]
    public class DoctorWorkHours
    {

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public int ReservationStartTime { get; set; }

        public int ReservationEndTime { get; set; }

/*        public DayHours WorkHours
        {
            //get;
            set
            {
                WorkHours = new DayHours(ReservationStartTime, ReservationEndTime);
            }
        }*/
        //[NotMapped]
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

        //public MyObjectBuilder bWorkHours { get; set; }

        public IEnumerable<Doctor> AvailableHours { get; set; }
    }

/*    public class WorkHours
    {
        public List<int> Hours;
        public int start;
        public int end;

        public void Generate(int start, int end)
        {
            this.start = start;
            this.end = end;

            for (int i = start; i < end; i++)
            {
                Hours.Add(i);
            }
        }*/
/*        public WorkHours(int start, int end)
        {
            this.start = start;
            this.end = end;
            for (int i = start; i < end; i++)
            {
                Hours.Add(i);
            }
        }*/
    }
public class MyObjectBuilder
{
    //public void Configure(EntityTypeBuilder<WorkHours> builder, int st, int ed)
    public void Configure(EntityTypeBuilder<WorkHours> builder)
    {
        var intArrayValueConverter = new ValueConverter<int[], string>(
            i => string.Join(",", i),
            s => string.IsNullOrWhiteSpace(s) ? new int[0] : s.Split(new[] { ',' }).Select(v => int.Parse(v)).ToArray());
        //builder.Property(x => x.Generate(st, ed));
        builder.Property(x => x.Hours).HasConversion(intArrayValueConverter);
    }
}
}