using DicomWebApp.Web.Models;

namespace DicomWebApp.Web.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MyDicomContext>();

                context.Database.EnsureCreated();

                if (!context.Patients.Any())
                {
                    var patients = new List<Patient>()
                    {
                        new Patient()
                        {
                            PatientID = "1",
                            Name = "John Doe",
                            BirthDate = new DateTime(1980, 1, 1)
                        },
                        new Patient()
                        {
                            PatientID = "2",
                            Name = "Jane Smith",
                            BirthDate = new DateTime(1990, 2, 2)
                        }
                    };

                    var studies = new List<Study>()
                    {
                        new Study()
                        {
                            StudyInstanceUID = "1.2.840.113619.2.3.281.8005.2001.11.14.45",
                            Patient = patients[0]
                        },
                        new Study()
                        {
                            StudyInstanceUID = "1.2.840.113619.2.3.281.8005.2001.11.14.45",
                            Patient = patients[1]
                        }
                    };

                    var series = new List<Series>()
                    {
                        new Series()
                        {
                            SeriesInstanceUID = "1.2.840.113619.2.3.281.8005.2001.11.14.45.2",
                            Study = studies[0]
                        },
                        new Series()
                        {
                            SeriesInstanceUID = "1.2.840.113619.2.3.281.8005.2001.11.14.45.2",
                            Study = studies[1]
                        }
                    };

                    var images = new List<Image>()
                    {
                        new Image()
                        {
                            SOPInstanceUID = "1.2.840.113619.2.3.281.8005.2001.11.14.45.2.17.1",
                            Series = series[0],
                            FilePath = "https://i.pinimg.com/564x/f3/af/dd/f3afddae33344bb1ff41653bc86df2f8.jpg"
                        },
                        new Image()
                        {
                            SOPInstanceUID = "1.2.840.113619.2.3.281.8005.2001.11.14.45.2.17.1",
                            Series = series[1],
                            FilePath = "https://i.pinimg.com/564x/f3/af/dd/f3afddae33344bb1ff41653bc86df2f8.jpg"
                        }
                    };

                    context.Patients.AddRange(patients);
                    context.Studies.AddRange(studies);
                    context.Series.AddRange(series);
                    context.Images.AddRange(images);

                    context.SaveChanges();
                }
            }
        }
    }
}
