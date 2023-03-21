using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Bongo.Web.Test
{
    public class RoomBookingControllerTest
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingServiceMock;
        StudyRoomBooking _request;
        RoomBookingController _controller;
        [SetUp]
        public void Setup()
        {
            _studyRoomBookingServiceMock = new Mock<IStudyRoomBookingService>();
            _controller = new RoomBookingController(_studyRoomBookingServiceMock.Object);
            _request = new StudyRoomBooking()
            {
                Date = DateTime.Now,
                Email = "test@test.com",
                FirstName = "Test",
                LastName = "Test",
                StudyRoomId = 1,
                //BookingId = 11
            };
        }

        [Test]
        public void Index_ResultReturn()
        {
            _controller.Index();
            _studyRoomBookingServiceMock.Verify(a => a.GetAllBooking(), Times.Once);
        }

        [Test]
        public void BookRoomCheck_ModelStateInvalid_ReturnView()
        {
            _controller.ModelState.AddModelError("Test", "Test");

            var result = _controller.Book(new StudyRoomBooking());
            ViewResult viewResult = (ViewResult)result;

            Assert.That("book", Is.EqualTo(viewResult.ViewName).IgnoreCase);
        }

        [Test]

        public void BookRoomCheck_NoRoomAvailable_RetunrnValidResponse()
        {
            _studyRoomBookingServiceMock.Setup(a => a.BookStudyRoom(It.IsAny<StudyRoomBooking>())).Returns(new StudyRoomBookingResult()
            {
                Code = StudyRoomBookingCode.NoRoomAvailable
            });

            var result = _controller.Book(new StudyRoomBooking());
            Assert.IsInstanceOf<ViewResult>(result);
            ViewResult viewResult = (ViewResult)result;
            Assert.That("No Study Room available for selected date", Is.EqualTo(viewResult.ViewData["Error"]).IgnoreCase);

        }

        [Test]
        public void BookRoomCheck_RoomAvailable_RetunrnValidResponse()
        {

            _studyRoomBookingServiceMock.Setup(a => a.BookStudyRoom(It.IsAny<StudyRoomBooking>())).Returns((StudyRoomBooking booking) =>
           new StudyRoomBookingResult()
           {
               Code = StudyRoomBookingCode.Success,
               FirstName = booking.FirstName,
               LastName = booking.LastName,
               Email = booking.Email
           });

            var result = _controller.Book(_request);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            RedirectToActionResult ActionResult = (RedirectToActionResult)result;

            Assert.That(_request.FirstName, Is.EqualTo(ActionResult.RouteValues["FirstName"]));
        }
    }
}