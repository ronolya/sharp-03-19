using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_5
{
    public partial class Lesson
    {
        public static void FieldsExample()
        {
            var photo = new Photo();
            var app = new Applicant();
            var pass = new Passport();

            app.name = "Olga";
            app.surname = "Ronda";
            app.passport = pass;
            app.photo = photo;

            var anotherApp = new Applicant
            {
                name = "Vasya",
                surname = "Pupkin"
            };

            Console.WriteLine(app.surname);
        }

        public static void ConstantExample()
        {
            Console.WriteLine(Photo.expiration);
            //Photo.expiration = 33;
        }

        public static void MethodsExample()
        {
            var photo = new Photo();
            photo.Update(new FileInfo("image.jpg"));

            var app = new Applicant()
            {
                birthdate = new DateTime(1990, 11, 15)
            };
            Console.WriteLine(app.GetAge());


            var pass = new Passport()
            {
                ExpirationDate = new DateTime(2019, 10, 12)
            };
            Console.WriteLine(pass.IsExpired());

        }

        public static void IndexerExample()
        {
            var address = new Address()
            {
                workingAddress = "220234, ул.Алибегова 12.",
                livingAddress = "2389068, ул. Кропоткина 27",
                registrationAddress = "2389068, ул. Кропоткина 27"
            };

            var sendDocsToAddress = address["2389068"];
            Console.WriteLine(sendDocsToAddress);

            var building = new Building()
            {
                flatNumbers = new int[] { 1, 2, 3, 4 },
                people = new string[] { "Vasya", "Petya", "Katya", "Lena" }
            };

            var neighbour = building[3];
            Console.WriteLine(neighbour);
        }

        public static void ConstructorExample()
        {
            var app1 = new Applicant();
            var app2 = new Applicant("Alex Pupkin");
            var app3 = new Applicant("Olga", "Rondarava");
        }

        public static void OverloadingExample()
        {
            var v1 = new Vector { x = 1, y = 1 };
            var v2 = new Vector { x = 2, y = 2 };

            var v3 = v1 + v2;
        }
    }

    class Photo
    {
        public DateTime takeStamp;
        public Image image;

        public const int expiration = 3;

        public void Update(FileInfo file)
        {
            var img = Image.FromFile(file.FullName);
            if (Validate(img, file.CreationTime))
            {
                image = img;
                takeStamp = file.CreationTime;
            }
        }

        public bool Validate(Image img, DateTime taken)
        {
            var expired = taken.AddMonths(expiration);

            if (img.Width == 150 && img.Height == 200
                && expired > DateTime.Today)
            {
                return true;
            }
            return false;
        }
    }

    class Applicant
    {
        public String name;
        public String surname;
        public DateTime birthdate;
        public DateTime applicationDate;

        double age;

        public Photo photo;
        public Passport passport;

        public Applicant()
        {
            this.applicationDate = DateTime.Now;
        }

        public Applicant(string fullName)
        {
            this.applicationDate = DateTime.Now;
            this.surname = fullName.ToUpper();
        }

        public Applicant(string name, string surname)
        {
            this.applicationDate = DateTime.Now;
            this.name = name.ToUpper();
            this.surname = surname.ToUpper();
        }

        public double Age
        {
            get
            {
                if (age == 0)
                {
                    age = GetAge();
                }
                return age;
            }
        }

        public double GetAge()
        {
            var diff = birthdate - DateTime.Now;
            return diff.TotalDays / 365.25;
        }
    }

    class Passport
    {
        const int expiration = 10;

        String number;
        DateTime issueDate;

        public DateTime ExpirationDate { get; set; }

        public DateTime IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }

        public string Number
        {
            get { return number; }
            set
            {
                if (!value.StartsWith("MP"))
                {
                    number = "MP" + value;
                }
                else
                {
                    number = value;
                }
            }
        }


        public bool IsExpired()
        {
            var diff = ExpirationDate - DateTime.Now;
            return (diff.TotalDays / 365.25) >= expiration;
        }
    }

    class Address
    {
        public String registrationAddress;
        public String livingAddress;
        public String workingAddress;

        public string this[string zipCode]
        {
            get
            {

                if (registrationAddress.IndexOf(zipCode) >= 0)
                    return registrationAddress;

                if (workingAddress.IndexOf(zipCode) >= 0)
                    return workingAddress;

                return livingAddress;
            }
        }
    }

    class Building
    {
        public int[] flatNumbers;
        public string[] people;

        public string this[int flatNumber]
        {
            get
            {
                int index = Array.IndexOf(flatNumbers, flatNumber);
                if (index >= 0)
                {
                    return people[index];
                }
                return null;
            }

            set
            {
                int index = Array.IndexOf(flatNumbers, flatNumber);
                if (index >= 0)
                {
                    people[index] = value;
                }
                else
                {
                    index = Array.IndexOf(people, null);
                    flatNumbers[index] = flatNumber;
                    people[index] = value;
                }
            }
        }
    }

    class Vector
    {
        public int x;
        public int y;

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector() {
                x = v1.x + v2.x,
                y = v1.y + v2.y
            };
        }
    }
}
