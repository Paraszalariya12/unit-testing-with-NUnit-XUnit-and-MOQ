using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Bongo.DataAccess.Test
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTest
    {
        private StudyRoomBooking studyRoomBooking_One;
        private StudyRoomBooking studyRoomBooking_Two;
        private DbContextOptions<ApplicationDbContext> option;
        public StudyRoomBookingRepositoryTest()
        {
            studyRoomBooking_One = new StudyRoomBooking()
            {
                Date = DateTime.Now,
                Email = "test@test.com",
                FirstName = "Test",
                LastName = "Test",
                StudyRoomId = 1,
                BookingId = 11
            };

            studyRoomBooking_Two = new StudyRoomBooking()
            {
                Date = DateTime.Now,
                Email = "test2@test.com",
                FirstName = "Test2",
                LastName = "Test2",
                StudyRoomId = 2,
                BookingId = 12
            };
        }
        [SetUp]
        public void Setup()
        {
            option = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "temp_bongo").Options;
        }

        [Test]
        public void SaveBooking_studyRoomBooking_CheckTheValueFromDatabase()
        {
            //Arrang
           

            //ACT
            using (var context = new ApplicationDbContext(option))
            {
                context.Database.EnsureDeleted();
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_One);
            }

            //Assertion
            using (var context = new ApplicationDbContext(option))
            {
                var result = context.StudyRoomBookings.FirstOrDefault(a => a.BookingId == 11);
                Assert.IsNotNull(result);
                Assert.That(result.Date, Is.EqualTo(studyRoomBooking_One.Date));
                Assert.That(result.Email, Is.EqualTo(studyRoomBooking_One.Email));
                Assert.That(result.FirstName, Is.EqualTo(studyRoomBooking_One.FirstName));
                Assert.That(result.LastName, Is.EqualTo(studyRoomBooking_One.LastName));
                Assert.That(result.StudyRoomId, Is.EqualTo(studyRoomBooking_One.StudyRoomId));
                Assert.That(result.BookingId, Is.EqualTo(studyRoomBooking_One.BookingId));
            }

        }

        [Test]
        public void GetAllBooking_CheckTheValueFromDatabase()
        {
            //Arrang
            List<StudyRoomBooking> Expectedresult = new List<StudyRoomBooking>() { studyRoomBooking_One, studyRoomBooking_Two };
           
            using (var context = new ApplicationDbContext(option))
            {
                context.Database.EnsureDeleted();// This code ensure That Your OLD Database Data is Deleted before we do any operation
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_One);
                repository.Book(studyRoomBooking_Two);
            }

            List<StudyRoomBooking> bookings;
            //ACT
            using (var context = new ApplicationDbContext(option))
            {
                var repository = new StudyRoomBookingRepository(context);
                bookings = repository.GetAll(null).ToList();

            }

            //Assertion

            Assert.IsNotNull(bookings);
            //Assert.That(bookings, Is.EqualTo(Expectedresult));
            Assert.That(bookings.Count, Is.EqualTo(Expectedresult.Count));
            CollectionAssert.AreEqual(bookings, Expectedresult, new BookingCompare());
            //Assert.That(bookings,Is.Unique(Expectedresult))
        }
    }

    //Below is Best way to compare Two Object and Use it any where.
    public class BookingCompare : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else
            {
                var bookingcompare1 = (StudyRoomBooking)x;
                var bookingcompare2 = (StudyRoomBooking)y;
                if (bookingcompare1.BookingId != bookingcompare2.BookingId)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}