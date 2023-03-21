using Bongo.Core.Services;
using Bongo.Core.Services.IServices;
using Bongo.DataAccess.Repository;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Moq;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Core.Test
{
    [TestFixture]
    public class StudyRoomBookingServiceTest
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepository;
        private Mock<IStudyRoomRepository> _studyRoomRepository;
        private StudyRoomBookingService studyRoomBookingService;
        StudyRoomBooking _request;
        StudyRoomBooking _savedStudyRoomBooking;
        private List<StudyRoom> _availableStudyRoom;


        [SetUp]
        public void SetUp()
        {
            _studyRoomBookingRepository = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepository = new Mock<IStudyRoomRepository>();

            studyRoomBookingService = new StudyRoomBookingService(_studyRoomBookingRepository.Object, _studyRoomRepository.Object);

            _request = new StudyRoomBooking()
            {
                Date = DateTime.Now,
                Email = "test@test.com",
                FirstName = "Test",
                LastName = "Test",
                StudyRoomId = 1,
                //BookingId = 11
            };

            _availableStudyRoom = new List<StudyRoom>() { new StudyRoom() { Id = 1, RoomName = "India-Student", RoomNumber = "001" } };
            _studyRoomRepository.Setup(a => a.GetAll()).Returns(_availableStudyRoom);
        }

        [TestCase]
        public void GetAllStudyRoom_ResultStudyRoomBooking()
        {
            studyRoomBookingService.GetAllBooking();
            _studyRoomBookingRepository.Verify(x => x.GetAll(null), Times.Exactly(1));

        }
        [TestCase]
        public void BookStudyRoomNullcheck_InputStudyRoomBooking_ResultErrorMessage()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => studyRoomBookingService.BookStudyRoom(null));
        }

        [TestCase]
        public void BookStudyRoom_InputStudyRoomBooking_ResultStudyRoomBooking()
        {
            _studyRoomBookingRepository.Setup(a => a.Book(It.IsAny<StudyRoomBooking>())).Callback<StudyRoomBooking>(booking =>
            {
                _savedStudyRoomBooking = booking;
            });

            var Result = studyRoomBookingService.BookStudyRoom(_request);

            _studyRoomBookingRepository.Verify(a => a.Book(It.IsAny<StudyRoomBooking>()), Times.Once);

            Assert.That(_request.FirstName, Is.EqualTo(Result.FirstName));
            Assert.That(_request.LastName, Is.EqualTo(Result.LastName));
            Assert.That(_request.Email, Is.EqualTo(Result.Email));
            Assert.That(_request.Date, Is.EqualTo(Result.Date));
            //Assert.That(_availableStudyRoom.First().Id, Is.EqualTo(Result.));
        }


        [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
        public StudyRoomBookingCode ResultStudyRoomAvailable_RoomAvailibility_ReturnStatusCode(bool roomavailibility)
        {
            if (!roomavailibility)
            {
                _availableStudyRoom.Clear();
            }

            return studyRoomBookingService.BookStudyRoom(_request).Code;
        }


        [TestCase(0, false)]
        [TestCase(55, true)]
        public void ResultStudyRoomAvailable_BookRoomAvailibility_ReturnBookingID(int expectedBookingId, bool roomavailibility)
        {
            if (!roomavailibility)
            {
                _availableStudyRoom.Clear();

            }
            _studyRoomBookingRepository.Setup(a => a.Book(It.IsAny<StudyRoomBooking>())).Callback<StudyRoomBooking>(booking =>
            {
                booking.BookingId = 55;
            });

            var result = studyRoomBookingService.BookStudyRoom(_request);
            
            if (!roomavailibility)
            {
                _studyRoomBookingRepository.Verify(a => a.Book(It.IsAny<StudyRoomBooking>()), Times.Never);
            }
            else
            {
                Assert.That(expectedBookingId, Is.EqualTo(result.BookingId));
            }
        }


    }
}
