using ContactDemo.API.Controllers;
using ContactDemo.API.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ContactDemo.API.Test
{
    public class ContactControllerTest
    {
        public List<Contact> Contacts { get; set; }

        public ContactControllerTest()
        {
            Contacts = new List<Contact>
            {
                new Contact(),
                new Contact()
            };
        }

        [Fact]
        public async Task Test_GetContacts_ReturnsOK()
        {
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.GetContacts()).ReturnsAsync(Contacts);

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.GetContacts();
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public async Task Test_GetContact_ReturnsOK()
        {
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.GetContact(1)).ReturnsAsync(Contacts[0]);

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.GetContact(1);
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public async Task Test_GetContact_ReturnsNotFound()
        {
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.GetContact(1)).ReturnsAsync(Contacts[0]);

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.GetContact(5);
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Test_DeleteContact_ReturnsOK()
        {
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.GetContact(1)).ReturnsAsync(Contacts[0]);
            contactRepository.Setup(o => o.DeleteContact(1));

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.DeleteContact(1);
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public async Task Test_DeleteContact_ReturnsNotFound()
        {
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.GetContact(1)).ReturnsAsync(Contacts[0]);
            contactRepository.Setup(o => o.DeleteContact(1));

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.DeleteContact(5);
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Test_UpdateContact_ReturnsOK()
        {
            var contactToUpdate = new Mock<Contact>();
            contactToUpdate.Object.Id = 1;
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.GetContact(1)).ReturnsAsync(Contacts[0]);
            contactRepository.Setup(o => o.UpdateContact(contactToUpdate.Object));

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.UpdateContact(contactToUpdate.Object);
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public async Task Test_UpdateContact_ReturnsNotFound()
        {
            var contactToUpdate = new Mock<Contact>();
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.GetContact(1)).ReturnsAsync(Contacts[0]);
            contactRepository.Setup(o => o.UpdateContact(contactToUpdate.Object));

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.UpdateContact(contactToUpdate.Object);
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Test_AddContact_ReturnsOK()
        {
            var contactToUpdate = new Mock<Contact>();
            var contactRepository = new Mock<IContactRepository>();
            contactRepository.Setup(o => o.AddContact(contactToUpdate.Object));

            var contactController = new ContactController(contactRepository.Object);

            var result = await contactController.AddContact(contactToUpdate.Object);
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
